namespace VhpTimeLogger.Controls
{
    partial class Totalen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotaalverantwoord = new System.Windows.Forms.Label();
            this.lblLabelTegaan = new System.Windows.Forms.Label();
            this.lblTeGaan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Totaal verantwoord";
            // 
            // lblTotaalverantwoord
            // 
            this.lblTotaalverantwoord.AutoSize = true;
            this.lblTotaalverantwoord.Location = new System.Drawing.Point(109, 4);
            this.lblTotaalverantwoord.Name = "lblTotaalverantwoord";
            this.lblTotaalverantwoord.Size = new System.Drawing.Size(10, 13);
            this.lblTotaalverantwoord.TabIndex = 1;
            this.lblTotaalverantwoord.Text = "-";
            // 
            // lblLabelTegaan
            // 
            this.lblLabelTegaan.AutoSize = true;
            this.lblLabelTegaan.Location = new System.Drawing.Point(3, 21);
            this.lblLabelTegaan.Name = "lblLabelTegaan";
            this.lblLabelTegaan.Size = new System.Drawing.Size(47, 13);
            this.lblLabelTegaan.TabIndex = 2;
            this.lblLabelTegaan.Text = "Te gaan";
            // 
            // lblTeGaan
            // 
            this.lblTeGaan.AutoSize = true;
            this.lblTeGaan.Location = new System.Drawing.Point(109, 21);
            this.lblTeGaan.Name = "lblTeGaan";
            this.lblTeGaan.Size = new System.Drawing.Size(10, 13);
            this.lblTeGaan.TabIndex = 3;
            this.lblTeGaan.Text = "-";
            // 
            // Totalen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTeGaan);
            this.Controls.Add(this.lblLabelTegaan);
            this.Controls.Add(this.lblTotaalverantwoord);
            this.Controls.Add(this.label1);
            this.Name = "Totalen";
            this.Size = new System.Drawing.Size(220, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotaalverantwoord;
        private System.Windows.Forms.Label lblLabelTegaan;
        private System.Windows.Forms.Label lblTeGaan;
    }
}
