using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using NLog;

namespace VhpTimeLogger.Forms
{
    public partial class StartOfTheDay : Form
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public StartOfTheDay()
        {
            InitializeComponent();
        }

        private void StartOfTheDay_Load(object sender, EventArgs e)
        {
            log.Info("StartOfTheDay_Load");
            tbxBegintijd.Text = string.Format("{0}:{1:00}", DateTime.Now.Hour, DateTime.Now.Minute);
        }

        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string[] time = tbxBegintijd.Text.Split(':');
                start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(time[0]), int.Parse(time[1]), 0, DateTimeKind.Utc);
                Close();
            }
            catch(Exception){
                log.Info("De tekst '{0}' kan niet worden omgezet naar een datum",tbxBegintijd.Text);
                tbxBegintijd.Focus();
            }            
        }

        private void tbxBegintijd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Close();
            }
        }
    }
}
