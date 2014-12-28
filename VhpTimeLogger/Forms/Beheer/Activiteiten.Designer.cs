namespace VhpTimeLogger.Forms.Beheer
{
    partial class Activiteiten
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
            System.Windows.Forms.Label idLabelLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label actiefLabel;
            this.lvActivities = new System.Windows.Forms.ListView();
            this.columnId = new System.Windows.Forms.ColumnHeader();
            this.ColumnName = new System.Windows.Forms.ColumnHeader();
            this.columnActive = new System.Windows.Forms.ColumnHeader();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.actiefCheckBox = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nieuwButton = new System.Windows.Forms.Button();
            this.wijzigenButton = new System.Windows.Forms.Button();
            this.verwijderButton = new System.Windows.Forms.Button();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.annulerenButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            idLabelLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            actiefLabel = new System.Windows.Forms.Label();
            this.detailsGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabelLabel
            // 
            idLabelLabel.AutoSize = true;
            idLabelLabel.Location = new System.Drawing.Point(6, 22);
            idLabelLabel.Name = "idLabelLabel";
            idLabelLabel.Size = new System.Drawing.Size(19, 13);
            idLabelLabel.TabIndex = 2;
            idLabelLabel.Text = "Id:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(6, 48);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Name:";
            // 
            // actiefLabel
            // 
            actiefLabel.AutoSize = true;
            actiefLabel.Location = new System.Drawing.Point(6, 76);
            actiefLabel.Name = "actiefLabel";
            actiefLabel.Size = new System.Drawing.Size(37, 13);
            actiefLabel.TabIndex = 6;
            actiefLabel.Text = "Actief:";
            // 
            // lvActivities
            // 
            this.lvActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.ColumnName,
            this.columnActive});
            this.lvActivities.FullRowSelect = true;
            this.lvActivities.Location = new System.Drawing.Point(3, 3);
            this.lvActivities.Name = "lvActivities";
            this.lvActivities.Size = new System.Drawing.Size(536, 429);
            this.lvActivities.TabIndex = 1;
            this.lvActivities.UseCompatibleStateImageBehavior = false;
            this.lvActivities.View = System.Windows.Forms.View.Details;
            this.lvActivities.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvProjects_MouseClick);
            this.lvActivities.SelectedIndexChanged += new System.EventHandler(this.lvActivities_SelectedIndexChanged);
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            this.columnId.Width = 30;
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Activiteit";
            this.ColumnName.Width = 300;
            // 
            // columnActive
            // 
            this.columnActive.Text = "Aktief";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(50, 45);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(474, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // actiefCheckBox
            // 
            this.actiefCheckBox.Location = new System.Drawing.Point(50, 71);
            this.actiefCheckBox.Name = "actiefCheckBox";
            this.actiefCheckBox.Size = new System.Drawing.Size(104, 24);
            this.actiefCheckBox.TabIndex = 7;
            this.actiefCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(50, 102);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(50, 19);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(104, 20);
            this.idTextBox.TabIndex = 11;
            // 
            // nieuwButton
            // 
            this.nieuwButton.Location = new System.Drawing.Point(3, 438);
            this.nieuwButton.Name = "nieuwButton";
            this.nieuwButton.Size = new System.Drawing.Size(75, 23);
            this.nieuwButton.TabIndex = 12;
            this.nieuwButton.Text = "Nieuw";
            this.nieuwButton.UseVisualStyleBackColor = true;
            this.nieuwButton.Click += new System.EventHandler(this.nieuwButton_Click);
            // 
            // wijzigenButton
            // 
            this.wijzigenButton.Enabled = false;
            this.wijzigenButton.Location = new System.Drawing.Point(84, 438);
            this.wijzigenButton.Name = "wijzigenButton";
            this.wijzigenButton.Size = new System.Drawing.Size(75, 23);
            this.wijzigenButton.TabIndex = 13;
            this.wijzigenButton.Text = "Wijzigen";
            this.wijzigenButton.UseVisualStyleBackColor = true;
            this.wijzigenButton.Click += new System.EventHandler(this.wijzigenButton_Click);
            // 
            // verwijderButton
            // 
            this.verwijderButton.Enabled = false;
            this.verwijderButton.Location = new System.Drawing.Point(165, 438);
            this.verwijderButton.Name = "verwijderButton";
            this.verwijderButton.Size = new System.Drawing.Size(75, 23);
            this.verwijderButton.TabIndex = 14;
            this.verwijderButton.Text = "Verwijderen";
            this.verwijderButton.UseVisualStyleBackColor = true;
            this.verwijderButton.Click += new System.EventHandler(this.verwijderenButton_Click);
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.annulerenButton);
            this.detailsGroupBox.Controls.Add(this.idTextBox);
            this.detailsGroupBox.Controls.Add(this.actiefCheckBox);
            this.detailsGroupBox.Controls.Add(actiefLabel);
            this.detailsGroupBox.Controls.Add(this.nameTextBox);
            this.detailsGroupBox.Controls.Add(nameLabel);
            this.detailsGroupBox.Controls.Add(this.btnSave);
            this.detailsGroupBox.Controls.Add(idLabelLabel);
            this.detailsGroupBox.Enabled = false;
            this.detailsGroupBox.Location = new System.Drawing.Point(22, 492);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(536, 152);
            this.detailsGroupBox.TabIndex = 15;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "details";
            // 
            // annulerenButton
            // 
            this.annulerenButton.Location = new System.Drawing.Point(131, 102);
            this.annulerenButton.Name = "annulerenButton";
            this.annulerenButton.Size = new System.Drawing.Size(75, 23);
            this.annulerenButton.TabIndex = 12;
            this.annulerenButton.Text = "Annuleren";
            this.annulerenButton.UseVisualStyleBackColor = true;
            this.annulerenButton.Click += new System.EventHandler(this.annulerenButton_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.nieuwButton);
            this.buttonPanel.Controls.Add(this.wijzigenButton);
            this.buttonPanel.Controls.Add(this.lvActivities);
            this.buttonPanel.Controls.Add(this.verwijderButton);
            this.buttonPanel.Location = new System.Drawing.Point(22, 19);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(551, 467);
            this.buttonPanel.TabIndex = 16;
            // 
            // Activiteiten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 688);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.detailsGroupBox);
            this.Name = "Activiteiten";
            this.Text = "Activiteiten";
            this.Load += new System.EventHandler(this.Activiteiten_Load);
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvActivities;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader columnActive;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox actiefCheckBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button nieuwButton;
        private System.Windows.Forms.Button wijzigenButton;
        private System.Windows.Forms.Button verwijderButton;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button annulerenButton;


    }
}