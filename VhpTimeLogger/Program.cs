using System;
using System.Drawing;
using System.Windows.Forms;
using TimeLogger;
using DbNavigate;
using BusinessLogic.Services;
using VhpTimeLogger.Forms;
using VhpTimeLogger.Forms.Beheer;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using NLog;
using VhpBusinessLogic.Services;

namespace VhpTimeLogger
{
    public class SysTrayApp : Form
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new SysTrayApp());
        }
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private Timer timer = new Timer();
        private TimeSheetForm timeSheet;
        private DateTime startOfTheDay;
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public SysTrayApp()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var processname = System.IO.Path.GetFileNameWithoutExtension(location);

            var process = System.Diagnostics.Process.GetProcessesByName(processname);
            if (process.Length > 1)
            {
                MessageBox.Show("De applicatie draait al!");
                this.Close();
                return;
            }

            // Create a simple tray menu with only one item.            
            InitializeContextMenu();


            // Create a tray icon. In this example we use a            
            // standard system icon for simplicity, but you           
            // can of course use your own custom icon too.          
            trayIcon = new NotifyIcon();
            trayIcon.Text = "VhpTimeLogger";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            // Add menu to tray icon and show it.        
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        private void InitializeContextMenu()
        {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Openen", showTimesheet);
            trayMenu.MenuItems.Add("Rapportage", showRapportage);
            trayMenu.MenuItems.Add("Afsluiten", OnExit);

            MenuItem beheer = new MenuItem("Beheer");
            beheer.MenuItems.Add("Activiteiten", showActiviteiten);
            beheer.MenuItems.Add("Projecten", showProjecten);
            trayMenu.MenuItems.Add(beheer);
        }

        protected override void OnLoad(EventArgs e)
        {
            //new TestForm().ShowDialog();
            //return;
            //VhpTimeLogger.Forms.Beheer.Projecten bp = new VhpTimeLogger.Forms.Beheer.Projecten();
            //bp.ShowDialog();
            //return;
            ConnectToShare();
            SetStartOfTheDay();
            showTimesheet(this, new EventArgs());

            timer.Interval = GetInterval();
            timer.Tick += new EventHandler(flashTimesheet);
            timer.Start();
            Visible = false;
            // Hide form window.           
            ShowInTaskbar = false;
            // Remove from taskbar.           
            base.OnLoad(e);
        }

        private void SetStartOfTheDay()
        {
            StartOfTheDayService startOfTheDayService = new StartOfTheDayService();
            try
            {
                var result = startOfTheDayService.Get();
                if (result == null)
                {
                    StartOfTheDay StartOfTheDayForm = new StartOfTheDay();
                    StartOfTheDayForm.ShowDialog();
                    startOfTheDay = StartOfTheDayForm.Start;
                    startOfTheDayService.Insert(startOfTheDay);
                }
                else
                {
                    startOfTheDay = result.GetValueOrDefault();
                }
                log.Info("StartOfTheDay bepaald op {0}", startOfTheDay);                    
            }
            catch (Exception ex)
            {
                string message = string.Format("Kan de database niet benaderen: {0}:{1} \n\nKlik op OK om het nog een keer te proberen.", ex.Message, ex.StackTrace);
                log.Error(message);
                log.ErrorException(ex.Message, ex);
                DialogResult result = MessageBox.Show(message, "Fout bij database benadering", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SetStartOfTheDay();
            }
        }

        private int GetInterval()
        {
            DateTime now = DateTime.Now;
            DateTime temp = new DateTime(now.Ticks).AddHours(1);
            DateTime nextTick = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, 0, 0);

            TimeSpan delay = nextTick - now;
            return (int)delay.TotalMilliseconds;
        }

        void showRapportage(object sender, EventArgs e)
        {
            Rapportage rapportage = new Rapportage();
            rapportage.ShowDialog();
        }

        void showActiviteiten(object sender, EventArgs e)
        {
            Activiteiten activiteiten = new Activiteiten();
            activiteiten.Attach(timeSheet);
            activiteiten.ShowDialog();
        }

        void showProjecten(object sender, EventArgs e)
        {
            Projecten projecten = new Projecten();
            projecten.Attach(timeSheet);
            projecten.ShowDialog();
            //frmDataGridPaging frm = new frmDataGridPaging();
            //frm.ShowDialog();
        }

        void showTimesheet(object sender, EventArgs e)
        {
            timer.Stop();
            timeSheet = new TimeSheetForm();
            timeSheet.OnClose += new TimeSheetForm.CloseWindow(timeSheet_OnClose);
            timeSheet.StartOfTheDay = startOfTheDay;
            timeSheet.ShowDialog();
        }

        void flashTimesheet(object sender, EventArgs e)
        {
            timer.Stop();
            timeSheet = new TimeSheetForm();
            timeSheet.WindowState = FormWindowState.Minimized;
            timeSheet.OnClose += new TimeSheetForm.CloseWindow(timeSheet_OnClose);
            timeSheet.StartOfTheDay = startOfTheDay;
            timeSheet.ShowDialog();
        }

        void timeSheet_OnClose(object sender, EventArgs e)
        {
            timeSheet.Dispose();
            timeSheet = null;

            timer.Interval = GetInterval();
            timer.Start();
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.            
                trayIcon.Dispose();
            } base.Dispose(isDisposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SysTrayApp
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "SysTrayApp";
            this.Load += new System.EventHandler(this.SysTrayApp_Load);
            this.ResumeLayout(false);

        }

        private void SysTrayApp_Load(object sender, EventArgs e)
        {

        }

        public static void ConnectToShare()
        {
            var username = ConfigurationManager.AppSettings["Username"];
            var password = ConfigurationManager.AppSettings["Password"];
            var networkShare = ConfigurationManager.AppSettings["DatabaseShare"];

            var command = string.Format("net use {0} /user:{1} {2}", networkShare, username, password);

            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = "C:\\",
            };
            
            var process = Process.Start(processInfo);
            process.WaitForExit();
            var exitCode = process.ExitCode;
            process.Close();
        }
    }
}