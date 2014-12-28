using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VhpTimeLogger.Controls;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string[] aap = new string[] { "aap", "noot", "mies" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimeSheetLine tsl = new TimeSheetLine();
            tsl.Projects = aap;
            Controls.Add(new TimeSheetLine());

            comboBox1.DataSource = aap;
            userControl11.Projects = aap;
        }
    }
}
