using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using Yogesh.ExcelXml;
using VhpTimeLogger.Diversen;

namespace VhpTimeLogger.Forms
{
    public partial class Rapportage : Form
    {
        public Rapportage()
        {
            InitializeComponent();
        }

        private void Rapportage_Load(object sender, EventArgs e)
        {
            DateTime now=DateTime.Now;
            DateTime begin = new DateTime(now.Year, now.Month, 1).AddMonths(-1);            
            DateTime end = new DateTime(begin.Year,begin.Month, DateTime.DaysInMonth(begin.Year,begin.Month));
            dtpFrom.Value = begin;
            dtpTo.Value = end;
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;

            GroupedReport report = new GroupedReport();
            ExcelXmlWorkbook book = report.Create(from, to);

            string reportname = string.Format("Rapport van {0} tot {1}.xls",from.ToString(Constants.DateMask), to.ToString(Constants.DateMask));
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = reportname;
            DialogResult result=  dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                book.Export(dialog.FileName);
            }

        }

        private void btnUitdraai_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;

            Uitdraai uitdraai = new Uitdraai();
            ExcelXmlWorkbook book = uitdraai.Create(from, to);

            string reportname = string.Format("Uitdraai van {0} tot {1}.xls", from.ToString(Constants.DateMask), to.ToString(Constants.DateMask));
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = reportname;
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                book.Export(dialog.FileName);
            }
        }
    }
}
