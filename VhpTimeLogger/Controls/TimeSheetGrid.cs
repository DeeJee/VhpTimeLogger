using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeLogger;
using VhpDataEntities;

namespace VhpTimeLogger.Controls
{
    public partial class TimeSheetGrid : UserControl
    {
        string[] projects;
        string[] activities;
        int top = 0;

        public TimeSheetGrid()
        {
            InitializeComponent();
            if (LicenseManager.CurrentContext.UsageMode != LicenseUsageMode.Designtime)
            {
                projects = ProjectDataSource.GetData();
                activities = ActivityDataSource.GetData();
            }
            else
            {
                projects = new string[] { "Project1", "Project2", "Project3" };
                activities = new string[] { "Activity1", "Activity2" };
            }
        }

        //private string[] GetProjects()
        //{
        //    ProjectDataSource datasource = new ProjectDataSource();
        //    return datasource.GetData();
        //}

        //private string[] GetActivities()
        //{
        //    ActivityDataSource datasource = new ActivityDataSource();
        //    return datasource.GetData();
        //}

        private void timeSheetLine12_Load(object sender, EventArgs e)
        {

            pnlLines.Controls.Clear();
            for (int index = 0; index < MinimumNumberOfLines; index++)
            {
                TimeSheetLine line = new TimeSheetLine();
                line.Projects = projects;
                line.Activities = activities;
                line.Top = top;
                pnlLines.Controls.Add(line);
                top += line.Height + 3;
            }

            if (!DesignMode)
            {
                if (Registrations.Count >= MinimumNumberOfLines)
                {
                    AddMoreLines(Registrations.Count - MinimumNumberOfLines + 1);
                }

                int index2 = 0;
                foreach (TimeSheetLine line in pnlLines.Controls)
                {
                    line.WorkRegistration = Registrations[index2];
                    index2++;
                    if (index2 == Registrations.Count) { break; }

                }
            }
        }
        private void AddMoreLines(int extraLines)
        {
            for (int index = 0; index < extraLines; index++)
            {
                TimeSheetLine line = new TimeSheetLine();
                line.Projects = projects;
                line.Activities = activities;
                line.Top = top;
                pnlLines.Controls.Add(line);
                top += line.Height + 2;

            }
        }

        private List<WorkRegistration> registrations;
        public List<WorkRegistration> Registrations
        {
            get { return registrations; }
            set { registrations = value; }
        }

        public int MinimumNumberOfLines { get; set; }
    }
}
