using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VhpTimeLogger.Controls
{
    public partial class Totalen : UserControl
    {
        public Totalen()
        {
            InitializeComponent();
        }

        public int Verantwoord { get; set; }
        public int TeGaan { get; set; }

        private bool showTeGaan = true;
        public bool ShowTeGaan 
        { 
            get 
            { 
                return showTeGaan; 
            } 
            set 
            { 
                showTeGaan = value; 
            }
        }

        public override void Refresh()
        {
            int[] verantwoord = NaarUrenEnMinuten(Verantwoord);
            lblTotaalverantwoord.Text = string.Format("{0} min / {1}u{2}m ", Verantwoord, verantwoord[0], verantwoord[1]);
            
            int[] urenMinuten = NaarUrenEnMinuten(TeGaan);
            lblTeGaan.Text = string.Format("{0} min / {1}u{2}m ", TeGaan, urenMinuten[0], urenMinuten[1]);
            lblTeGaan.Visible = ShowTeGaan;
            lblLabelTegaan.Visible = ShowTeGaan;
            
            base.Refresh();
        }

        private int[] NaarUrenEnMinuten(int minuten)
        {
            int[] result = new int[2];
            result[0] = minuten / 60;
            result[1] = minuten % 60;
            return result;
        }
    }
}
