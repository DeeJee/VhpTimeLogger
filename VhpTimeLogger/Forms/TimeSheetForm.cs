using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using VhpTimeLogger;
using VhpTimeLogger.Forms;
using VhpBusinessLogic.Services;
using VhpDataEntities;
using NLog;
using System.Diagnostics;
using VhpTimeLogger.Controls;
using System.Collections;
using System.Reflection;
using BusinessLogic.Services;
using VhpTimeLogger.Interfaces;

namespace TimeLogger
{
    public partial class TimeSheetForm : Form, IObserver
    {
        List<TimeSheetLine> lines = new List<TimeSheetLine>();
        private int top;
        public event CloseWindow OnClose;
        public delegate void CloseWindow(object sender, EventArgs e);
        private WorkregistrationService workRegistrationService;
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private int maxAantalOnverantwoorddeMinuten = 29;
        private int minimumNumberOfLines = 12;

        public TimeSheetForm()
        {
            InitializeComponent();
            foreach(var control in panel1.Controls.OfType<TimeSheetLine>())
            {
                control.Projects = ProjectDataSource.GetData();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            lblStartVanDeDag.Text = StartOfTheDay.ToString();
            lblFormuliergeopend.Text = "Formulier geopend op " + DateTime.Now.ToString();

            FlashWindowEx();
            ToonTotalen();

            lblBuildnummer.Text = string.Format("Build: {0}",Assembly.GetEntryAssembly().GetName().Version.ToString());
        }

        private void LoadLines()
        {
            top = 0;
            workRegistrationService = new WorkregistrationService();
            List<WorkRegistration> registrations = workRegistrationService.GetForDate(dateTimePicker1.Value);
            int aantalRegels = BepaalAantalRegels(registrations);

            panel1.Controls.Clear();
            AddLines(aantalRegels);
            FillLines(registrations);
        }

        private void FillLines(List<WorkRegistration> registrations)
        {
            IEnumerator enumerator = panel1.Controls.GetEnumerator();
            foreach (WorkRegistration registration in registrations)
            {
                if (enumerator.MoveNext())
                {
                    TimeSheetLine line = enumerator.Current as TimeSheetLine;
                    line.WorkRegistration = registration;
                }
            }
        }

        private void AddLines(int aantalRegels)
        {
            this.SuspendLayout();
            top = 0;
            for (int index = 0; index < aantalRegels; index++)
            {
                TimeSheetLine line = CreateLine();
                line.Top = top;
                panel1.Controls.Add(line);
                top += line.Height + line.Margin.Top + line.Margin.Bottom;
            }
            this.ResumeLayout();
        }

        private TimeSheetLine CreateLine()
        {
            TimeSheetLine line = new TimeSheetLine();
            line.OnValidationStateChanged += line_OnValidationStateChanged;
            line.OnTimeChanged += line_OnTimeChanged;
            line.OnDuplication += line_OnDuplication;
            line.Margin = new Padding(2);
            return line;
        }

        void line_OnDuplication(object sender, EventArgs e)
        {
            TimeSheetLine lineToBeCopied = sender as TimeSheetLine;

            TimeSheetLine line = FindFirstEmptyLine();
            WorkRegistration workRegistration = new WorkRegistration
            {
                Project = lineToBeCopied.WorkRegistration.Project,
                Activity = lineToBeCopied.WorkRegistration.Activity,
                Description = lineToBeCopied.WorkRegistration.Description
            };
            line.WorkRegistration = workRegistration;
            line.FocusTimeSpent();
        }

        private TimeSheetLine FindFirstEmptyLine()
        {
            foreach (TimeSheetLine line in panel1.Controls)
            {
                if (!line.IsComplete)
                {
                    return line;
                }
            }
            return null;
        }

        private int BepaalAantalRegels(List<WorkRegistration> registrations)
        {
            if (registrations.Count < minimumNumberOfLines)
            {
                return minimumNumberOfLines;
            }
            //-1 omdat we altijd een lege regel willen hebben
            return registrations.Count + 1;
        }

        void line_OnTimeChanged(object sender, EventArgs e)
        {
            ToonTotalen();
        }

        void line_OnValidationStateChanged(object sender, EventArgs e)
        {
            AddNewLineIfNeeded();
        }

        private void AddNewLineIfNeeded()
        {
            bool newLineNeeded = true;
            foreach (TimeSheetLine line in panel1.Controls)
            {
                if (!line.IsComplete)
                {
                    newLineNeeded = false;
                    break;
                }
            }
            if (newLineNeeded)
            {
                TimeSheetLine line = CreateLine();
                line.Top = top - panel1.VerticalScroll.Value;
                top += line.Height + line.Margin.Top + line.Margin.Bottom;
                panel1.Controls.Add(line);
            }
        }

        private void ToonTotalen()
        {
            int totaal = 0;
            foreach (Control ctrl in this.panel1.Controls)
            {
                TimeSheetLine line = ctrl as TimeSheetLine;
                if (line != null)
                {
                    totaal += (int)line.WorkRegistration.TimeSpent;
                }
            }

            TimeCalculationService service = new TimeCalculationService();
            service.CalculateTimeToGo(StartOfTheDay, DateTime.Now, totaal);

            totalen1.Verantwoord = totaal;
            totalen1.ShowTeGaan = (dateTimePicker1.Value == DateTime.Today);
            if (dateTimePicker1.Value == DateTime.Today)
            {
                totalen1.TeGaan = service.CalculateTimeToGo(StartOfTheDay, DateTime.Now, totaal);
            }
            totalen1.Refresh();
        }

        private void FlashWindowEx()
        {
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = this.Handle;
            fInfo.dwFlags = FLASHW_ALL;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;

            FlashWindowEx(ref fInfo);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            WorkregistrationService workregistrationService = new WorkregistrationService();

            bool valid = ValidateControls(panel1.Controls);

            if (!valid)
            {
                MessageBox.Show("Niet alle velden zijn correct ingevuld");
                return;
            }

            List<TimeSheetLine> toBePersisted = new List<TimeSheetLine>();
            foreach (TimeSheetLine line in panel1.Controls)
            {
                if (line.IsComplete)
                {
                    line.WorkRegistration.DateWorkDone = dateTimePicker1.Value;
                    toBePersisted.Add(line);
                    //workregistrationService.PersistRegistration(line.WorkRegistration);
                }
            }

            List<WorkRegistration> registrations = new List<WorkRegistration>();
            WorkRegistration previous = null;
            for (int index = 0; index < toBePersisted.Count; index++)
            {
                WorkRegistration line = toBePersisted[index].WorkRegistration;
                if (previous == null)
                {
                    line.WorkedFrom = StartOfTheDay;
                    line.WorkedTo = StartOfTheDay.AddMinutes((double)line.TimeSpent);
                }
                else
                {
                    line.WorkedFrom = previous.WorkedTo;
                    line.WorkedTo = line.WorkedFrom.AddMinutes((double)line.TimeSpent);
                }
                previous = line;
                registrations.Add(line);
            }
            workregistrationService.PersistRegistrations(registrations);
            CloseOrMinimize();
        }

        private void CloseOrMinimize()
        {
            if (totalen1.TeGaan <= maxAantalOnverantwoorddeMinuten)
            {
                Close();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private bool ValidateControls(Control.ControlCollection controls)
        {
            foreach (TimeSheetLine line in controls)
            {
                if (!line.IsValid)
                {
                    return false;
                }
            }
            return true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (this.OnClose != null)
            {
                OnClose(this, new EventArgs());
            }
        }

        #region toolbar flashing
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        public const UInt32 FLASHW_ALL = 3;
        FLASHWINFO fInfo = new FLASHWINFO();
        #endregion

        private void btnRapportage_Click(object sender, EventArgs e)
        {
            Rapportage rapportage = new Rapportage();
            rapportage.ShowDialog();
        }


        #region properties
        public DateTime StartOfTheDay { get; set; }
        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadLines();
        }

        private static int CompareByName(Control c1, Control c2)
        {
            return c1.TabIndex.CompareTo(c2.TabIndex);
        }


        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            AddNewLineIfNeeded();
            ToonTotalen();
        }

        public void Notify()
        {
            LoadLines();
            Update();
        }
    }
}
