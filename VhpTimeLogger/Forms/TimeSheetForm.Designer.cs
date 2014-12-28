using VhpTimeLogger.Controls;
namespace TimeLogger
{
    partial class TimeSheetForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSheetForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timeSheetLine12 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine11 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine10 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine9 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine8 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine7 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine6 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine4 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine3 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine5 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine2 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.timeSheetLine1 = new VhpTimeLogger.Controls.TimeSheetLine();
            this.lblFormuliergeopend = new System.Windows.Forms.Label();
            this.btnRapportage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStartVanDeDag = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.totalen1 = new VhpTimeLogger.Controls.Totalen();
            this.lblBuildnummer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Activiteit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Omschrijving";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(772, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tijdsduur";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(747, 485);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.timeSheetLine12);
            this.panel1.Controls.Add(this.timeSheetLine11);
            this.panel1.Controls.Add(this.timeSheetLine10);
            this.panel1.Controls.Add(this.timeSheetLine9);
            this.panel1.Controls.Add(this.timeSheetLine8);
            this.panel1.Controls.Add(this.timeSheetLine7);
            this.panel1.Controls.Add(this.timeSheetLine6);
            this.panel1.Controls.Add(this.timeSheetLine4);
            this.panel1.Controls.Add(this.timeSheetLine3);
            this.panel1.Controls.Add(this.timeSheetLine5);
            this.panel1.Controls.Add(this.timeSheetLine2);
            this.panel1.Controls.Add(this.timeSheetLine1);
            this.panel1.Location = new System.Drawing.Point(29, 87);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 306);
            this.panel1.TabIndex = 16;
            // 
            // timeSheetLine12
            // 
            this.timeSheetLine12.Location = new System.Drawing.Point(3, 278);
            this.timeSheetLine12.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine12.Name = "timeSheetLine12";
            this.timeSheetLine12.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine12.TabIndex = 11;
            //this.timeSheetLine12.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine12.WorkRegistration")));
            this.timeSheetLine12.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine12.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine11
            // 
            this.timeSheetLine11.Location = new System.Drawing.Point(3, 253);
            this.timeSheetLine11.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine11.Name = "timeSheetLine11";
            this.timeSheetLine11.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine11.TabIndex = 10;
            //this.timeSheetLine11.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine11.WorkRegistration")));
            this.timeSheetLine11.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine11.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine10
            // 
            this.timeSheetLine10.Location = new System.Drawing.Point(3, 228);
            this.timeSheetLine10.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine10.Name = "timeSheetLine10";
            this.timeSheetLine10.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine10.TabIndex = 9;
            //this.timeSheetLine10.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine10.WorkRegistration")));
            this.timeSheetLine10.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine10.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine9
            // 
            this.timeSheetLine9.Location = new System.Drawing.Point(3, 203);
            this.timeSheetLine9.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine9.Name = "timeSheetLine9";
            this.timeSheetLine9.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine9.TabIndex = 8;
            //this.timeSheetLine9.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine9.WorkRegistration")));
            this.timeSheetLine9.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine9.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine8
            // 
            this.timeSheetLine8.Location = new System.Drawing.Point(3, 178);
            this.timeSheetLine8.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine8.Name = "timeSheetLine8";
            this.timeSheetLine8.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine8.TabIndex = 7;
            //this.timeSheetLine8.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine8.WorkRegistration")));
            this.timeSheetLine8.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine8.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine7
            // 
            this.timeSheetLine7.Location = new System.Drawing.Point(3, 153);
            this.timeSheetLine7.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine7.Name = "timeSheetLine7";
            this.timeSheetLine7.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine7.TabIndex = 6;
            //this.timeSheetLine7.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine7.WorkRegistration")));
            this.timeSheetLine7.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine7.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine6
            // 
            this.timeSheetLine6.Location = new System.Drawing.Point(3, 128);
            this.timeSheetLine6.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine6.Name = "timeSheetLine6";
            this.timeSheetLine6.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine6.TabIndex = 5;
            //this.timeSheetLine6.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine6.WorkRegistration")));
            this.timeSheetLine6.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine6.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine4
            // 
            this.timeSheetLine4.Location = new System.Drawing.Point(3, 78);
            this.timeSheetLine4.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine4.Name = "timeSheetLine4";
            this.timeSheetLine4.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine4.TabIndex = 3;
            //this.timeSheetLine4.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine4.WorkRegistration")));
            this.timeSheetLine4.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine4.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine3
            // 
            this.timeSheetLine3.Location = new System.Drawing.Point(3, 53);
            this.timeSheetLine3.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine3.Name = "timeSheetLine3";
            this.timeSheetLine3.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine3.TabIndex = 2;
            //this.timeSheetLine3.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine3.WorkRegistration")));
            this.timeSheetLine3.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine3.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine5
            // 
            this.timeSheetLine5.Location = new System.Drawing.Point(3, 103);
            this.timeSheetLine5.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine5.Name = "timeSheetLine5";
            this.timeSheetLine5.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine5.TabIndex = 4;
            //this.timeSheetLine5.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine5.WorkRegistration")));
            this.timeSheetLine5.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine5.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine2
            // 
            this.timeSheetLine2.Location = new System.Drawing.Point(3, 28);
            this.timeSheetLine2.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine2.Name = "timeSheetLine2";
            this.timeSheetLine2.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine2.TabIndex = 1;
            //this.timeSheetLine2.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine2.WorkRegistration")));
            this.timeSheetLine2.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine2.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // timeSheetLine1
            // 
            this.timeSheetLine1.Location = new System.Drawing.Point(3, 3);
            this.timeSheetLine1.Margin = new System.Windows.Forms.Padding(2);
            this.timeSheetLine1.Name = "timeSheetLine1";
            this.timeSheetLine1.Size = new System.Drawing.Size(797, 21);
            this.timeSheetLine1.TabIndex = 0;
            //this.timeSheetLine1.WorkRegistration = ((VhpDataEntities.WorkRegistration)(resources.GetObject("timeSheetLine1.WorkRegistration")));
            this.timeSheetLine1.OnTimeChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnTimeChanged);
            this.timeSheetLine1.OnValidationStateChanged += new VhpTimeLogger.Controls.TimeSheetLine.ValidationStateChanged(this.line_OnValidationStateChanged);
            // 
            // lblFormuliergeopend
            // 
            this.lblFormuliergeopend.AutoSize = true;
            this.lblFormuliergeopend.Location = new System.Drawing.Point(531, 9);
            this.lblFormuliergeopend.Name = "lblFormuliergeopend";
            this.lblFormuliergeopend.Size = new System.Drawing.Size(101, 13);
            this.lblFormuliergeopend.TabIndex = 18;
            this.lblFormuliergeopend.Text = "lblFormuliergeopend";
            // 
            // btnRapportage
            // 
            this.btnRapportage.Location = new System.Drawing.Point(63, 484);
            this.btnRapportage.Name = "btnRapportage";
            this.btnRapportage.Size = new System.Drawing.Size(75, 23);
            this.btnRapportage.TabIndex = 19;
            this.btnRapportage.Text = "Rapportage";
            this.btnRapportage.UseVisualStyleBackColor = true;
            this.btnRapportage.Click += new System.EventHandler(this.btnRapportage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Start van de dag:";
            // 
            // lblStartVanDeDag
            // 
            this.lblStartVanDeDag.AutoSize = true;
            this.lblStartVanDeDag.Location = new System.Drawing.Point(125, 9);
            this.lblStartVanDeDag.Name = "lblStartVanDeDag";
            this.lblStartVanDeDag.Size = new System.Drawing.Size(92, 13);
            this.lblStartVanDeDag.TabIndex = 21;
            this.lblStartVanDeDag.Text = "lblStartVanDeDag";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Selecteer een datum";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(137, 44);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 25;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // totalen1
            // 
            this.totalen1.Location = new System.Drawing.Point(632, 424);
            this.totalen1.Name = "totalen1";
            this.totalen1.ShowTeGaan = true;
            this.totalen1.Size = new System.Drawing.Size(241, 57);
            this.totalen1.TabIndex = 22;
            this.totalen1.TeGaan = 0;
            this.totalen1.Verantwoord = 0;
            // 
            // lblBuildnummer
            // 
            this.lblBuildnummer.AutoSize = true;
            this.lblBuildnummer.Location = new System.Drawing.Point(13, 511);
            this.lblBuildnummer.Name = "lblBuildnummer";
            this.lblBuildnummer.Size = new System.Drawing.Size(77, 13);
            this.lblBuildnummer.TabIndex = 27;
            this.lblBuildnummer.Text = "lblBuildnummer";
            // 
            // TimeSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 536);
            this.Controls.Add(this.lblBuildnummer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.totalen1);
            this.Controls.Add(this.lblStartVanDeDag);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRapportage);
            this.Controls.Add(this.lblFormuliergeopend);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimeSheetForm";
            this.Text = "VhpTimeLogger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFormuliergeopend;
        private System.Windows.Forms.Button btnRapportage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStartVanDeDag;
        private VhpTimeLogger.Controls.Totalen totalen1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private TimeSheetLine timeSheetLine12;
        private TimeSheetLine timeSheetLine11;
        private TimeSheetLine timeSheetLine10;
        private TimeSheetLine timeSheetLine9;
        private TimeSheetLine timeSheetLine8;
        private TimeSheetLine timeSheetLine7;
        private TimeSheetLine timeSheetLine6;
        private TimeSheetLine timeSheetLine4;
        private TimeSheetLine timeSheetLine3;
        private TimeSheetLine timeSheetLine5;
        private TimeSheetLine timeSheetLine2;
        private TimeSheetLine timeSheetLine1;
        private System.Windows.Forms.Label lblBuildnummer;
    }
}

