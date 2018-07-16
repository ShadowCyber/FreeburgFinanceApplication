/*
 * Created by SharpDevelop.
 * User: Travis Freeburg
 * Date: 7/8/2018
 * Time: 4:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;

namespace TravisFreeburgFinance
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {

        internal string SortByField = nameof(DataModel.Transaction.TransactionID);

        internal List<DataModel.Transaction> DataGridValue = new List<DataModel.Transaction>();

        internal Factory oFactory = new Factory();

        internal DataModel.Search SearchModel = new DataModel.Search();

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();


        }

        void MainFormLoad(object sender, EventArgs e)
        {

            foreach (DataModel.eCategory oCategory in Enum.GetValues(typeof(DataModel.eCategory)))
            {
                cbBudgetCategory.Items.Add(oCategory);
            }
            cbBudgetCategory.SelectedIndex = 0;


            foreach (PropertyInfo oProp in typeof(DataModel.Transaction).GetProperties())
            {
                cbSearchCategory.Items.Add(oProp.Name);
                cbSortBy.Items.Add(oProp.Name);
            }
            cbSortBy.SelectedIndex = 0;
            cbSearchCategory.SelectedIndex = 0;


            cbSearchCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBudgetCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSortBy.DropDownStyle = ComboBoxStyle.DropDownList;


            SearchModel.BeginningDate = BeginningDate.Value;
            SearchModel.EndDate = EndDate.Value;
            SearchModel.Category = cbSearchCategory.SelectedItem.ToString();
            SearchModel.SearchText = tbSearch.Text;
            SearchModel.SortBy = cbSortBy.SelectedItem.ToString();

            // Do a search in the datamanger with nothing for search model but the sortby, enddate, beginningdate.
            List<DataModel.Transaction> lTransactions = oFactory.oDataManager.SearchTransactions(SearchModel);

            dgTransactions.AutoGenerateColumns = true;
            dgTransactions.DataSource = lTransactions;


            dgTransactions.Refresh();



        }

        internal void Search(DataModel.Search oSearch)
        {

            dgTransactions.DataSource = oFactory.oDataManager.SearchTransactions(SearchModel);
            dgTransactions.Refresh();

        }

        internal void HideEdit(AddUpdateForm addUpdateForm)
        {
            addUpdateForm.Hide();
            addUpdateForm.Dispose();
            this.Show();
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<DataModel.Transaction> lTransactions = (List<DataModel.Transaction>)dgTransactions.DataSource;

            if (lTransactions != null)
            {

                var propertyInfo = typeof(DataModel.Transaction).GetProperty((string)cbSortBy.SelectedItem);
                lTransactions = lTransactions.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();

                //lTransactions = (List<DataModel.Transaction>)lTransactions.OrderBy(transaction => transaction.Category).ToList();
                dgTransactions.DataSource = lTransactions;
                dgTransactions.Refresh();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (BeginningDate.Value < EndDate.Value)
            {

                SearchModel = new DataModel.Search();
                SearchModel.Category = (string)cbSearchCategory.SelectedItem;
                SearchModel.SortBy = (string)cbSortBy.SelectedItem;
                SearchModel.SearchText = tbSearch.Text;
                SearchModel.BeginningDate = BeginningDate.Value;
                SearchModel.EndDate = EndDate.Value;

                Search(SearchModel);

            }
            else
            {
                MessageBox.Show("Beginning Date needs to be before EndDate");
            }

        }
        
        private void btnUpdateBudget_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBudget.Text))
            {
                Regex regExpresion = new Regex(@"^-*[0-9\.]+$");
                // If they are updating the budget with a valid number
                if (regExpresion.IsMatch(tbBudget.Text))
                {
                    DataModel.Budget oBudget = new DataModel.Budget()
                    {
                        Category = cbBudgetCategory.SelectedItem.ToString(),
                        Value = tbBudget.Text
                    };
                    oBudget = oFactory.oDataManager.AddUpdateBudget(oBudget);
                    if (oBudget.Success)
                    {
                        string SuccessMessage = "Successfully updated budget. ";
                        if (!string.IsNullOrEmpty(oBudget.Message))
                        {
                            SuccessMessage += oBudget.Message;
                        }
                        MessageBox.Show(SuccessMessage);
                    }
                    else
                    {
                        MessageBox.Show(oBudget.Message);
                    }
                }
                else
                {
                    DataModel.Budget oBudget = oFactory.oDataManager.GetBudget(cbBudgetCategory.SelectedItem.ToString());
                    if (oBudget != null)
                    {
                        tbBudget.Text = oBudget.Value;
                    }
                    else
                    {
                        tbBudget.Text = "";
                    }
                    MessageBox.Show("Please provide a valid number. Ex. 1234.56");
                }
            }
            else
            {
                DataModel.Budget oBudget = new DataModel.Budget()
                {
                    Category = cbBudgetCategory.SelectedItem.ToString(),
                    Value = ""
                };
                oBudget = oFactory.oDataManager.RemoveBudget(oBudget);
                if (oBudget.Success)
                {
                    MessageBox.Show("Successfully removed budget. ");

                }
                else
                {
                    MessageBox.Show(oBudget.Message);
                    oBudget = oFactory.oDataManager.GetBudget(cbBudgetCategory.SelectedItem.ToString());
                    if (oBudget != null)
                    {
                        tbBudget.Text = oBudget.Value;
                    }
                    else
                    {
                        tbBudget.Text = "";
                    }
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (dgTransactions.Rows?.Count > 0 && dgTransactions.SelectedRows?.Count > 0)
            {
                DataModel.Transaction oTransaction = new DataModel.Transaction(dgTransactions.SelectedRows[0]);
                oTransaction = oFactory.oDataManager.RemoveTransaction(oTransaction);
                if (oTransaction.Success)
                {
                    dgTransactions.DataSource = oFactory.oDataManager.SearchTransactions(SearchModel);
                }
                else
                {
                    MessageBox.Show("Failed to delete transaction: " + oTransaction.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction. ");
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {

            this.Hide();
            AddUpdateForm oAddUpdate = new AddUpdateForm();
            oAddUpdate.oMainForm = this;

            oAddUpdate.Show();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (dgTransactions.Rows?.Count > 0 && dgTransactions.SelectedRows?.Count > 0)
            {
                DataModel.Transaction oTransaction = new DataModel.Transaction(dgTransactions.SelectedRows[0]);
                this.Hide();
                AddUpdateForm oAddUpdate = new AddUpdateForm();
                oAddUpdate.oTransaction = oTransaction;
                oAddUpdate.oMainForm = this;
                oAddUpdate.Show();
            }
            else
            {
                MessageBox.Show("Please select a transaction. ");
            }
        }

        private void cbBudgetCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DataModel.Budget> lBudget = oFactory.oData.RetrieveBudgets();
            if (cbBudgetCategory.SelectedItem != null)
            {
                if (lBudget?.Count > 0)
                {
                    DataModel.Budget oBudget = lBudget.Where(tmpbudget => tmpbudget.Category.ToString() == cbBudgetCategory.SelectedItem.ToString()).FirstOrDefault();
                    if (oBudget != null)
                    {
                        tbBudget.Text = oBudget.Value;
                    }
                    else
                    {
                        tbBudget.Text = "";
                    }
                }
            }
        }



    }
}
