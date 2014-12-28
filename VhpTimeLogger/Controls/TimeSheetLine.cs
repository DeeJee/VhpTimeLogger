using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Services;
using VhpDataEntities;

namespace VhpTimeLogger.Controls
{
    public partial class TimeSheetLine : UserControl
    {
        public event ValidationStateChanged OnTimeChanged;
        public event ValidationStateChanged OnValidationStateChanged;
        public event Duplicate OnDuplication;
        public delegate void ValidationStateChanged(object sender, EventArgs e);
        public delegate void Duplicate(object sender, EventArgs e);

        private bool isValid;
        public bool IsValid
        {
            get
            {
                isValid = ValidateModel();
                return isValid;
            }
        }

        private WorkRegistration workRegistration = new WorkRegistration();
        public WorkRegistration WorkRegistration
        {
            get
            {
                workRegistration.Project = ddlProjects.Text;
                workRegistration.Activity = ddlActivities.Text;
                workRegistration.Description = tbxDescription.Text;
                workRegistration.TimeSpent = tbxTimeSpent.IntValue;

                return workRegistration;
            }
            set
            {
                workRegistration = value;
                ddlProjects.Text = workRegistration.Project;
                ddlActivities.Text = workRegistration.Activity;
                tbxDescription.Text = workRegistration.Description;
                tbxTimeSpent.Text = workRegistration.TimeSpent.ToString();
            }
        }

        private bool isComplete;
        public bool IsComplete
        {
            get
            {
                isComplete = CheckeCompleteness();
                return isComplete;
            }
        }

        public TimeSheetLine()
        {
            InitializeComponent();
            this.Margin = new Padding { All = 20 };
        }

        private void TimeSheetLine_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //ddlProjects.Items.AddRange(Projects);
                //ddlActivities.Items.AddRange(Activities);

                //ddlProjects.Text = workRegistration.Project;
                //ddlActivities.Text = workRegistration.Activity;
                //tbxDescription.Text = workRegistration.Description;
                //if (workRegistration.TimeSpent > 0)
                //{
                //    tbxTimeSpent.Text = workRegistration.TimeSpent.ToString();
                //}
            }
        }

        //public string[] Projects { get; set; }
        public string[] Activities { get; set; }

        //private string[] GetActivities()
        //{
        //    ActivityDataSource ds = new ActivityDataSource();
        //    return ds.GetData();
        //}

        //private string[] GetProjects()
        //{
        //    ProjectDataSource ds = new ProjectDataSource();
        //    return ds.GetData();
        //}

        //public string Project
        //{
        //    get { return ddlProjects.Text; }
        //    set { ddlProjects.Text = value; }
        //}


        //public string Activity
        //{
        //    get { return ddlActivities.Text; }
        //    set { ddlActivities.Text = value; }
        //}


        //public string Description
        //{
        //    get { return tbxDescription.Text; }
        //    set { tbxDescription.Text = value; }
        //}

        //public int TimeSpent
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(tbxTimeSpent.Text))
        //        {
        //            return 0;
        //        }

        //        return Int32.Parse(tbxTimeSpent.Text);
        //    }
        //    set { tbxTimeSpent.Text = value.ToString(); }
        //}



        private bool ValidateModel()
        {
            if (string.IsNullOrEmpty(ddlProjects.Text) && string.IsNullOrEmpty(ddlActivities.Text) && tbxTimeSpent.IntValue == 0)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(ddlProjects.Text) && !string.IsNullOrEmpty(ddlActivities.Text) && tbxTimeSpent.IntValue > 0)
            {
                if (!ddlActivities.Items.Contains(ddlActivities.Text))
                {
                    return false;
                }

                if (!ddlProjects.Items.Contains(ddlProjects.Text))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        //public string[] Activities
        //{
        //    set
        //    {
        //        ddlActivities.Items.AddRange(value);
        //    }
        //}

        private string[] _projects;
        public string[] Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                ddlProjects.DataSource = value;
            }
        }


        private bool CheckeCompleteness()
        {
            return (!string.IsNullOrEmpty(ddlProjects.Text) &&
                    !string.IsNullOrEmpty(ddlActivities.Text) &&
                    tbxTimeSpent.IntValue > 0);
        }

        private void TimeSheetLine_Leave(object sender, EventArgs e)
        {
            bool oldstate = isComplete;
            bool newState = ValidateModel();

            if (oldstate != newState && OnValidationStateChanged != null)
            {
                OnValidationStateChanged(this, new EventArgs());
            }
        }

        private void tbxTimeSpent_TextChanged(object sender, EventArgs e)
        {
            if (OnTimeChanged != null)
            {
                OnTimeChanged(this, new EventArgs());
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (OnDuplication != null)
            {
                OnDuplication(this, new EventArgs());
            }
        }

        internal void FocusTimeSpent()
        {
            tbxTimeSpent.Focus();
        }
    }
}
