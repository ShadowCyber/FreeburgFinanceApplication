using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravisFreeburgFinance
{
    public partial class AddUpdateForm : Form
    {

        private DataModel.Transaction _oTransaction = null;
        public DataModel.Transaction oTransaction
        {
            get { return _oTransaction; }
            set
            {
                _oTransaction = value;
            }
        }

        private MainForm _oMainForm = null;
        public MainForm oMainForm
        {
            get { return _oMainForm; }
            set
            {
                _oMainForm = value;
            }
        }

        public AddUpdateForm()
        {
            InitializeComponent();

        }

        private void AddUpdateForm_Load(object sender, EventArgs e)
        {

            foreach (DataModel.eCategory oCategory in Enum.GetValues(typeof(DataModel.eCategory)))
            {
                cbCategory.Items.Add(oCategory);
            }
            cbCategory.SelectedIndex = 0;

            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            if (oTransaction != null && oTransaction.TransactionID != null && oTransaction.TransactionID > 0)
            {
                oTransaction = oMainForm.oFactory.oData.Transaction_GetOne((long)oTransaction.TransactionID);
                if (oTransaction != null)
                {

                    DataModel.eCategory oCategory;
                    Enum.TryParse(oTransaction.Category, out oCategory);
                    cbCategory.SelectedItem = oCategory;
                    tbDescription.Text = oTransaction.Description;

                    if (oTransaction.Amount != null)
                    {
                        tbAmount.Text = Convert.ToString(oTransaction.Amount);
                    }

                    if (oTransaction.TransactionDate != null)
                    {
                        dtTransactionDate.Value = DateTime.Parse(oTransaction.TransactionDate);
                    }
                    else
                    {
                        dtTransactionDate.Value = DateTime.Now;
                    }

                    checkboxBudget.Checked = (bool)oTransaction.IgnoreBudget;

                }
                else
                {
                    MessageBox.Show("Warning: Transaction was not found.");
                }
            }
            else
            {
                oTransaction = new DataModel.Transaction();
                oTransaction.TransactionDate = DateTime.Now.ToString("MM/dd/yyyy");
                oTransaction.Category = cbCategory.SelectedItem.ToString();
                dtTransactionDate.Value = DateTime.Now;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            // Category and Date are defaulted.
            Regex regExpresion = new Regex(@"^-*[0-9\.]+$");
            if (!string.IsNullOrEmpty(tbAmount.Text) && regExpresion.IsMatch(tbAmount.Text))
            {
                oTransaction.Description = tbDescription.Text;
                oTransaction.TransactionDate = dtTransactionDate.Value.ToString("MM/dd/yyyy");
                oTransaction.IgnoreBudget = checkboxBudget.Checked;
                oTransaction.Category = cbCategory.SelectedItem.ToString();

                oTransaction.Amount = Math.Round(Convert.ToDecimal(tbAmount.Text), 2);

                if (oTransaction.TransactionID != null)
                {
                    // This is needed for file update. For some reason the file doesn't get updated correctly from this form.
                    oTransaction = oMainForm.oFactory.oDataManager.UpdateTransaction(oTransaction);
                }
                else
                {
                    // This is needed for file update. For some reason the file doesn't get updated correctly from this form.
                    oTransaction = oMainForm.oFactory.oDataManager.AddTransaction(oTransaction);
                }

                if (oTransaction.Success) {
                    if (!String.IsNullOrEmpty(oTransaction.Message))
                    {
                        MessageBox.Show(oTransaction.Message);
                    }

                    DataModel.Search oSearch = new DataModel.Search();
                    oSearch.BeginningDate = DateTime.Parse(oTransaction.TransactionDate);
                    oSearch.EndDate = DateTime.Parse(oTransaction.TransactionDate);
                    oSearch.SearchText = oTransaction.TransactionID.ToString();
                    oSearch.Category = nameof(DataModel.Transaction.TransactionID);
                    oSearch.SortBy = nameof(DataModel.Transaction.TransactionID);
                    oMainForm.SearchModel = oSearch;
                    oMainForm.Search(oSearch);
                    oMainForm.HideEdit(this);
                }
                else
                {
                    MessageBox.Show("Failed to add/update transaction. ");

                }



            }
            else
            {
                MessageBox.Show("Amount is required, please fill it out with a valid number before you save. ");

            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            oMainForm.HideEdit(this);
        }
    }
}
