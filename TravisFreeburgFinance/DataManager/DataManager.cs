using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace TravisFreeburgFinance.DataManager
{
    /// <summary>
    /// Description of DataManager.
    /// </summary>
    public class DataManager
    {

        private Factory oFactory;
        private string OverBudgetMessage = "Warning: You have gone over budget this month.";

        public DataManager(Factory oFactory)
        {
            this.oFactory = oFactory;
        }

        #region Transaction


        internal List<DataModel.Transaction> SearchTransactions(DataModel.Search tmpSearch)
        {

            List<DataModel.Transaction> lTransactions = oFactory.oData.RetrieveTransactions();
            var propertyInfo = typeof(DataModel.Transaction).GetProperty((string)tmpSearch.Category);
            var sortpropertyInfo = typeof(DataModel.Transaction).GetProperty((string)tmpSearch.SortBy);

            if (!string.IsNullOrEmpty(tmpSearch.SearchText))
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    lTransactions = lTransactions.Where(transaction => (propertyInfo.GetValue(transaction, null).ToString().ToLower().Contains(tmpSearch.SearchText.ToLower())) && DateTime.Compare(DateTime.Parse(transaction.TransactionDate), tmpSearch.BeginningDate.Value) >= 0 && DateTime.Compare(DateTime.Parse(transaction.TransactionDate), tmpSearch.EndDate.Value) <= 0).OrderBy(x => sortpropertyInfo.GetValue(x, null)).ToList();
                }
                else
                {
                    lTransactions = lTransactions.Where(transaction => (propertyInfo.GetValue(transaction, null).ToString().Equals(tmpSearch.SearchText)) && DateTime.Parse(transaction.TransactionDate) >= tmpSearch.BeginningDate.Value && DateTime.Parse(transaction.TransactionDate) <= tmpSearch.EndDate.Value).OrderBy(x => sortpropertyInfo.GetValue(x, null)).ToList();
                }
            }
            else
            {
                lTransactions = lTransactions.Where(transaction => DateTime.Parse(transaction.TransactionDate) >= tmpSearch.BeginningDate.Value && DateTime.Parse(transaction.TransactionDate) <= tmpSearch.EndDate.Value).OrderBy(x => sortpropertyInfo.GetValue(x, null)).ToList();
            }

            return lTransactions;
        }


        internal DataModel.Transaction AddTransaction(DataModel.Transaction oTransaction)
        {
            try
            {
                oTransaction = oFactory.oData.AddTransaction(oTransaction);

                if (!ValidateBudget((DataModel.eCategory)Enum.Parse(typeof(DataModel.eCategory), oTransaction.Category)))
                {
                    oTransaction.Message = OverBudgetMessage;
                }
            }
            catch (Exception ex)
            {
                oTransaction.Success = false;
                oTransaction.Message = "Failed to add Transaction: " + ex.Message + ex.StackTrace;
            }
            return oTransaction;
        }

        internal DataModel.Transaction UpdateTransaction(DataModel.Transaction oTransaction)
        {
            try
            {
                oFactory.oData.UpdateTransaction(oTransaction);

                if (!ValidateBudget((DataModel.eCategory)Enum.Parse(typeof(DataModel.eCategory), oTransaction.Category)))
                {
                    oTransaction.Message = OverBudgetMessage;
                }

            }
            catch (Exception ex)
            {
                oTransaction.Success = false;
                oTransaction.Message = "Failed to update Transaction: " + ex.Message + ex.StackTrace;
            }
            return oTransaction;
        }

        internal DataModel.Transaction RemoveTransaction(DataModel.Transaction oTransaction)
        {
            try
            {
                oFactory.oData.RemoveTransaction((long)oTransaction.TransactionID);


                if (ValidateBudget((DataModel.eCategory)Enum.Parse(typeof(DataModel.eCategory), oTransaction.Category)))
                {
                    oTransaction.Message = OverBudgetMessage;
                    oTransaction.Message = "Warning: You are over budget this month.";
                }
            }
            catch (Exception ex)
            {
                oTransaction.Success = false;
                oTransaction.Message = "Failed to remove Transaction: " + ex.Message + ex.StackTrace;
            }
            return oTransaction;
        }

        #endregion

        #region Budget

        internal DataModel.Budget GetBudget(string oCat)
        {
            List<DataModel.Budget> lBudgets = oFactory.oData.RetrieveBudgets();
            DataModel.Budget oBudget = lBudgets.Where(tmp => tmp.Category == oCat).FirstOrDefault();

            return oBudget;
        }

        internal DataModel.Budget AddUpdateBudget(DataModel.Budget oBudget)
        {
            try
            {
                oFactory.oData.AddUpdateBudget(oBudget);

                if (!ValidateBudget((DataModel.eCategory)Enum.Parse(typeof(DataModel.eCategory), oBudget.Category)))
                {
                    oBudget.Message = OverBudgetMessage;
                }

            }
            catch (Exception ex)
            {
                oBudget.Success = false;
                oBudget.Message = "Failed to add Budget: " + ex.Message + ex.StackTrace;
            }
            return oBudget;
        }



        internal DataModel.Budget RemoveBudget(DataModel.Budget oBudget)
        {
            try
            {
                oFactory.oData.RemoveBudget((DataModel.eCategory)Enum.Parse(typeof(DataModel.eCategory), oBudget.Category));

            }
            catch (Exception ex)
            {
                oBudget.Success = false;
                oBudget.Message = "Failed to remove Budget: " + ex.Message + ex.StackTrace;
            }
            return oBudget;
        }


        #endregion

        #region Private

        private bool ValidateBudget(DataModel.eCategory oCategory)
        {
            // Grab all Transactions that have an amount and under the category inputted
            List<DataModel.Transaction> lTransactions = oFactory.oData.RetrieveTransactions().Where(tmpTran => tmpTran.Category == oCategory.ToString() && tmpTran.Amount != null && tmpTran.Amount > 0 && DateTime.Parse(tmpTran.TransactionDate).Month == DateTime.Now.Month).ToList();

            // Get the budget for the inputted category
            DataModel.Budget oBudget = oFactory.oData.RetrieveBudgets().Where(tmpBudget => tmpBudget.Category == oCategory.ToString()).FirstOrDefault();

            if (oBudget != null && !string.IsNullOrEmpty(oBudget.Value) && lTransactions?.Count > 0)
            {
                decimal BudgetValue = Convert.ToDecimal(oBudget.Value);
                decimal TransactionValue = lTransactions.Sum(tmpTran => (decimal)tmpTran.Amount);
                if (TransactionValue > BudgetValue)
                {
                    return false;
                }

            }

            return true;
        }
        #endregion
    }

}
