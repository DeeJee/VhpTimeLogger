namespace VhpTimeLogger.Controls
{
    partial class TimeSheetLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSheetLine));
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.ddlActivities = new System.Windows.Forms.ComboBox();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.tbxTimeSpent = new VhpTimeLogger.Controls.NumericTextBox();
            this.ddlProjects = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(492, 0);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(276, 20);
            this.tbxDescription.TabIndex = 3;
            this.tbxDescription.Leave += new System.EventHandler(this.TimeSheetLine_Leave);
            // 
            // ddlActivities
            // 
            this.ddlActivities.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlActivities.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlActivities.FormattingEnabled = true;
            this.ddlActivities.Location = new System.Drawing.Point(286, -1);
            this.ddlActivities.Name = "ddlActivities";
            this.ddlActivities.Size = new System.Drawing.Size(200, 21);
            this.ddlActivities.TabIndex = 2;
            this.ddlActivities.Leave += new System.EventHandler(this.TimeSheetLine_Leave);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Image = ((System.Drawing.Image)(resources.GetObject("btnDuplicate.Image")));
            this.btnDuplicate.Location = new System.Drawing.Point(3, 0);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(21, 21);
            this.btnDuplicate.TabIndex = 10;
            this.btnDuplicate.TabStop = false;
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // tbxTimeSpent
            // 
            this.tbxTimeSpent.AllowSpace = false;
            this.tbxTimeSpent.Location = new System.Drawing.Point(774, 0);
            this.tbxTimeSpent.Name = "tbxTimeSpent";
            this.tbxTimeSpent.Size = new System.Drawing.Size(50, 20);
            this.tbxTimeSpent.TabIndex = 4;
            this.tbxTimeSpent.TextChanged += new System.EventHandler(this.tbxTimeSpent_TextChanged);
            // 
            // ddlProjects
            // 
            this.ddlProjects.FormattingEnabled = true;
            this.ddlProjects.Location = new System.Drawing.Point(30, -1);
            this.ddlProjects.Name = "ddlProjects";
            this.ddlProjects.Size = new System.Drawing.Size(250, 21);
            this.ddlProjects.TabIndex = 20;
            // 
            // TimeSheetLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlProjects);
            this.Controls.Add(this.btnDuplicate);
            this.Controls.Add(this.tbxTimeSpent);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.ddlActivities);
            this.Name = "TimeSheetLine";
            this.Size = new System.Drawing.Size(833, 21);
            this.Load += new System.EventHandler(this.TimeSheetLine_Load);
            this.Leave += new System.EventHandler(this.TimeSheetLine_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.ComboBox ddlActivities;
        private VhpTimeLogger.Controls.NumericTextBox tbxTimeSpent;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.ComboBox ddlProjects;
    }
}
