/*
 * Created by SharpDevelop.
 * User: Travis Freeburg
 * Date: 7/8/2018
 * Time: 4:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TravisFreeburgFinance
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.TextBox tbBudget;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.ComboBox cbSearchCategory;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.ComboBox cbBudgetCategory;
		public System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.DateTimePicker BeginningDate;
		private System.Windows.Forms.DateTimePicker EndDate;
		private System.Windows.Forms.DataGridView dgTransactions;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGridViewTextBoxColumn TransactionID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Category;
		private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
		private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnUpdateBudget;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			
		}
		private void InitializeComponent() {
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbSearchCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBudgetCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBudget = new System.Windows.Forms.TextBox();
            this.dgTransactions = new System.Windows.Forms.DataGridView();
            this.TransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BeginningDate = new System.Windows.Forms.DateTimePicker();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdateBudget = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 31);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(154, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 19);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Search Text:";
            // 
            // cbSearchCategory
            // 
            this.cbSearchCategory.FormattingEnabled = true;
            this.cbSearchCategory.Location = new System.Drawing.Point(187, 31);
            this.cbSearchCategory.Name = "cbSearchCategory";
            this.cbSearchCategory.Size = new System.Drawing.Size(121, 21);
            this.cbSearchCategory.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(601, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Category:";
            // 
            // cbBudgetCategory
            // 
            this.cbBudgetCategory.FormattingEnabled = true;
            this.cbBudgetCategory.Location = new System.Drawing.Point(601, 31);
            this.cbBudgetCategory.Name = "cbBudgetCategory";
            this.cbBudgetCategory.Size = new System.Drawing.Size(121, 21);
            this.cbBudgetCategory.TabIndex = 6;
            this.cbBudgetCategory.SelectedIndexChanged += new System.EventHandler(this.cbBudgetCategory_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(426, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Budget";
            // 
            // tbBudget
            // 
            this.tbBudget.Location = new System.Drawing.Point(426, 31);
            this.tbBudget.Name = "tbBudget";
            this.tbBudget.Size = new System.Drawing.Size(154, 20);
            this.tbBudget.TabIndex = 4;
            // 
            // dgTransactions
            // 
            this.dgTransactions.AllowUserToAddRows = false;
            this.dgTransactions.AllowUserToDeleteRows = false;
            this.dgTransactions.AllowUserToOrderColumns = true;
            this.dgTransactions.AllowUserToResizeColumns = false;
            this.dgTransactions.AllowUserToResizeRows = false;
            this.dgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionID,
            this.Category,
            this.Amount,
            this.TransactionDate,
            this.Description});
            this.dgTransactions.Location = new System.Drawing.Point(12, 239);
            this.dgTransactions.MultiSelect = false;
            this.dgTransactions.Name = "dgTransactions";
            this.dgTransactions.Size = new System.Drawing.Size(744, 203);
            this.dgTransactions.TabIndex = 8;
            // 
            // TransactionID
            // 
            this.TransactionID.DataPropertyName = "TransactionID";
            this.TransactionID.HeaderText = "TransactionID";
            this.TransactionID.Name = "TransactionID";
            this.TransactionID.ReadOnly = true;
            this.TransactionID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TransactionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TransactionDate
            // 
            this.TransactionDate.DataPropertyName = "TransactionDate";
            this.TransactionDate.HeaderText = "Transaction Date";
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.ReadOnly = true;
            this.TransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TransactionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Beginning Date:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(187, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "End Date:";
            // 
            // BeginningDate
            // 
            this.BeginningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BeginningDate.Location = new System.Drawing.Point(13, 108);
            this.BeginningDate.Name = "BeginningDate";
            this.BeginningDate.Size = new System.Drawing.Size(117, 20);
            this.BeginningDate.TabIndex = 11;
            this.BeginningDate.Value = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            // 
            // EndDate
            // 
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate.Location = new System.Drawing.Point(187, 108);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(117, 20);
            this.EndDate.TabIndex = 12;
            this.EndDate.Value = new System.DateTime(2018, 8, 1, 0, 0, 0, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(13, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 28);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdateBudget
            // 
            this.btnUpdateBudget.Location = new System.Drawing.Point(607, 68);
            this.btnUpdateBudget.Name = "btnUpdateBudget";
            this.btnUpdateBudget.Size = new System.Drawing.Size(114, 24);
            this.btnUpdateBudget.TabIndex = 14;
            this.btnUpdateBudget.Text = "Update";
            this.btnUpdateBudget.UseVisualStyleBackColor = true;
            this.btnUpdateBudget.Click += new System.EventHandler(this.btnUpdateBudget_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Sort By: ";
            // 
            // cbSortBy
            // 
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Location = new System.Drawing.Point(84, 198);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(121, 21);
            this.cbSortBy.TabIndex = 16;
            this.cbSortBy.SelectedIndexChanged += new System.EventHandler(this.cbSortBy_SelectedIndexChanged);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(15, 458);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(115, 24);
            this.bAdd.TabIndex = 17;
            this.bAdd.Text = "Add Transaction";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(141, 458);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(128, 24);
            this.bUpdate.TabIndex = 18;
            this.bUpdate.Text = "Update Transaction";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(656, 209);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(100, 24);
            this.bDelete.TabIndex = 19;
            this.bDelete.Text = "Delete Transaction";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 512);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.cbSortBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpdateBudget);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.BeginningDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgTransactions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBudgetCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbBudget);
            this.Controls.Add(this.cbSearchCategory);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.tbSearch);
            this.Name = "MainForm";
            this.Text = "TravisFreeburgFinance";
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bDelete;
    }
}
