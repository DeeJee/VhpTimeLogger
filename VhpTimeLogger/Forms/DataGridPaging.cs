// Praise the Lord for ever and ever ...
// ****** *** **** *** **** *** **** ***
//
//  **************************
// *  - It doesn’t matter, -  *
// *  - whatever you are,  -  *
// *  - whatever you did,  -  *
// *  - remember           -  *
// *  - Jesus Loves you.   -  *
//  **************************
//
// Written by: Manohar Solomon. K
// E-Mail: manoh.code@gmail.com
// <<< ------------------------------------------------------------- >>>


using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Services;
using VhpDataEntities;

namespace DbNavigate
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmDataGridPaging : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dgEmp;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnFillGrid;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.TextBox tbPageSize;
		private System.Windows.Forms.Label lblPageSize;
		private System.Windows.Forms.DataGridTableStyle dgtsEmp;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbcE_Id;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbcE_Name;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbcE_Salary;
		private System.Windows.Forms.DataGridTextBoxColumn dgtbcE_DOJ;
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>

		// Protected connection variable.
		protected SqlConnection mcnSample;

		// Page
		private int mintTotalRecords = 0;
		private int mintPageSize = 0;
		private int mintPageCount = 0;
		private int mintCurrentPage = 1;
        List<Projects> projecten;


		// Connection String
		protected const string CONNECTION_STRING = "Server=localhost;UID=sa;PWD=;Database=Sample";



		public frmDataGridPaging()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgEmp = new System.Windows.Forms.DataGrid();
			this.dgtsEmp = new System.Windows.Forms.DataGridTableStyle();
			this.dgtbcE_Id = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbcE_Name = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbcE_Salary = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgtbcE_DOJ = new System.Windows.Forms.DataGridTextBoxColumn();
			this.btnFirst = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnLast = new System.Windows.Forms.Button();
			this.btnFillGrid = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.tbPageSize = new System.Windows.Forms.TextBox();
			this.lblPageSize = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgEmp)).BeginInit();
			this.SuspendLayout();
			// 
			// dgEmp
			// 
			this.dgEmp.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dgEmp.CaptionText = "Table : Employee";
			this.dgEmp.DataMember = "";
			this.dgEmp.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgEmp.Location = new System.Drawing.Point(8, 8);
			this.dgEmp.Name = "dgEmp";
			this.dgEmp.RowHeaderWidth = 20;
			this.dgEmp.Size = new System.Drawing.Size(376, 160);
			this.dgEmp.TabIndex = 0;
			this.dgEmp.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																							  this.dgtsEmp});
			// 
			// dgtsEmp
			// 
			this.dgtsEmp.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dgtsEmp.DataGrid = this.dgEmp;
			this.dgtsEmp.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																									  this.dgtbcE_Id,
																									  this.dgtbcE_Name,
																									  this.dgtbcE_Salary,
																									  this.dgtbcE_DOJ});
			this.dgtsEmp.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgtsEmp.MappingName = "tblEmp";
			this.dgtsEmp.ReadOnly = true;
			// 
			// dgtbcE_Id
			// 
			this.dgtbcE_Id.Format = "";
			this.dgtbcE_Id.FormatInfo = null;
			this.dgtbcE_Id.HeaderText = "Emp Id";
			this.dgtbcE_Id.MappingName = "E_Id";
			this.dgtbcE_Id.Width = 50;
			// 
			// dgtbcE_Name
			// 
			this.dgtbcE_Name.Format = "";
			this.dgtbcE_Name.FormatInfo = null;
			this.dgtbcE_Name.HeaderText = "Name";
			this.dgtbcE_Name.MappingName = "E_Name";
			this.dgtbcE_Name.ReadOnly = true;
			this.dgtbcE_Name.Width = 120;
			// 
			// dgtbcE_Salary
			// 
			this.dgtbcE_Salary.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dgtbcE_Salary.Format = "#######.00";
			this.dgtbcE_Salary.FormatInfo = null;
			this.dgtbcE_Salary.HeaderText = "Salary";
			this.dgtbcE_Salary.MappingName = "E_Salary";
			this.dgtbcE_Salary.ReadOnly = true;
			this.dgtbcE_Salary.Width = 75;
			// 
			// dgtbcE_DOJ
			// 
			this.dgtbcE_DOJ.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dgtbcE_DOJ.Format = "dd-MMM-yyyy";
			this.dgtbcE_DOJ.FormatInfo = null;
			this.dgtbcE_DOJ.HeaderText = "Date of Joining";
			this.dgtbcE_DOJ.MappingName = "E_DOJ";
			this.dgtbcE_DOJ.ReadOnly = true;
			this.dgtbcE_DOJ.Width = 101;
			// 
			// btnFirst
			// 
			this.btnFirst.Enabled = false;
			this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnFirst.Location = new System.Drawing.Point(8, 184);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(24, 23);
			this.btnFirst.TabIndex = 1;
			this.btnFirst.Text = "|<";
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Enabled = false;
			this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnPrevious.Location = new System.Drawing.Point(32, 184);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(24, 23);
			this.btnPrevious.TabIndex = 2;
			this.btnPrevious.Text = "<";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnNext
			// 
			this.btnNext.Enabled = false;
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNext.Location = new System.Drawing.Point(144, 184);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(24, 23);
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = ">";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnLast
			// 
			this.btnLast.Enabled = false;
			this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnLast.Location = new System.Drawing.Point(168, 184);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(24, 23);
			this.btnLast.TabIndex = 4;
			this.btnLast.Text = ">|";
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// btnFillGrid
			// 
			this.btnFillGrid.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnFillGrid.Location = new System.Drawing.Point(264, 184);
			this.btnFillGrid.Name = "btnFillGrid";
			this.btnFillGrid.Size = new System.Drawing.Size(56, 23);
			this.btnFillGrid.TabIndex = 5;
			this.btnFillGrid.Text = "Fill Grid";
			this.btnFillGrid.Click += new System.EventHandler(this.btnFillGrid_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(328, 184);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(56, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStatus.Enabled = false;
			this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblStatus.Location = new System.Drawing.Point(57, 186);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(85, 20);
			this.lblStatus.TabIndex = 7;
			this.lblStatus.Text = "0 / 0";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbPageSize
			// 
			this.tbPageSize.Location = new System.Drawing.Point(200, 185);
			this.tbPageSize.Name = "tbPageSize";
			this.tbPageSize.Size = new System.Drawing.Size(56, 20);
			this.tbPageSize.TabIndex = 8;
			this.tbPageSize.Text = "5";
			this.tbPageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPageSize
			// 
			this.lblPageSize.AutoSize = true;
			this.lblPageSize.Location = new System.Drawing.Point(200, 170);
			this.lblPageSize.Name = "lblPageSize";
			this.lblPageSize.Size = new System.Drawing.Size(59, 16);
			this.lblPageSize.TabIndex = 9;
			this.lblPageSize.Text = "&Page Size:";
			// 
			// frmDataGridPaging
			// 
			this.AcceptButton = this.btnFillGrid;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(394, 223);
			this.Controls.Add(this.btnFillGrid);
			this.Controls.Add(this.tbPageSize);
			this.Controls.Add(this.lblPageSize);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnFirst);
			this.Controls.Add(this.dgEmp);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmDataGridPaging";
			this.Text = "DataGrid Paging - Example";
			this.Load += new System.EventHandler(this.frmDbNavigate_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgEmp)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDbNavigate_Load(object sender, System.EventArgs e)
		{
            //loadPage();
            ProjectService projectService = new ProjectService();
            projecten = projectService.GetAll();

		}

		private void btnFirst_Click(object sender, System.EventArgs e)
		{
			this.goFirst();
		}

		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			this.goPrevious(); 
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			this.goNext();
		}

		private void btnLast_Click(object sender, System.EventArgs e)
		{
			this.goLast();
		}

		private void btnFillGrid_Click(object sender, System.EventArgs e)
		{
			this.fillGrid();
			this.btnFillGrid.Enabled = false;
			this.btnFirst.Enabled = true;
			this.btnPrevious.Enabled = true;
			this.lblStatus.Enabled = true;
			this.btnNext.Enabled = true;
			this.btnLast.Enabled = true;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.closeConnection();
			this.Close(); 
		}

		
		private void openConnection()
		{
			try
			{
				this.mcnSample = new SqlConnection(CONNECTION_STRING);
				this.mcnSample.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void closeConnection()
		{
			try
			{
				if (this.mcnSample.State == ConnectionState.Open)
					this.mcnSample.Close();
				this.mcnSample.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void fillGrid()
		{
			// For Page view.
			this.mintPageSize = int.Parse(this.tbPageSize.Text);
			this.mintTotalRecords = getCount();
			this.mintPageCount = this.mintTotalRecords / this.mintPageSize;
			
			// Adjust page count if the last page contains partial page.
			if (this.mintTotalRecords % this.mintPageSize > 0)
				this.mintPageCount++;

			this.mintCurrentPage = 0;

			loadPage();
		}

		private int getCount()
		{
            ProjectService projectService = new ProjectService();
            return projectService.GetAll().Count();
		}

		private void loadPage()
		{
			int intSkip = 0;

			intSkip = (this.mintCurrentPage * this.mintPageSize);

            List<Projects> data = new List<Projects>();
            int maxWaarde;
            if (intSkip + mintPageSize <= projecten.Count - 1)
            {
                maxWaarde = intSkip + mintPageSize;
            }
            else
            {
                maxWaarde = projecten.Count ;
            }

            for (int index = intSkip; index < maxWaarde; index++)
            {
                data.Add(this.projecten[index]);
            }

			// Populate Data Grid
            this.dgEmp.DataSource = data;

			// Show Status
			this.lblStatus.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
		}

		private void goFirst()
		{
			this.mintCurrentPage = 0;

			loadPage();
		}

		private void goPrevious()
		{
			if (this.mintCurrentPage == this.mintPageCount)
				this.mintCurrentPage = this.mintPageCount - 1;

			this.mintCurrentPage--;

			if (this.mintCurrentPage < 1) 
				this.mintCurrentPage = 0;

			loadPage();
		}

		private void goNext()
		{
			this.mintCurrentPage++;

			if (this.mintCurrentPage > (this.mintPageCount - 1))
				this.mintCurrentPage = this.mintPageCount - 1;

			loadPage();
		}

		private void goLast()
		{
			this.mintCurrentPage = this.mintPageCount - 1;

			loadPage();
		}




	}
}
