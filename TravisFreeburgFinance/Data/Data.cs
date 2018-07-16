
using System;
using System.IO;
using Newtonsoft.Json;
using System.Runtime;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TravisFreeburgFinance.Data
{
    /// <summary>
    /// Description of Data.
    /// </summary>
    public class Data
    {

        const string transactionsPath = @".\Transactions.txt";
        const string budgetsPath = @".\Budgets.txt";


        public Data()
        {
            List<TravisFreeburgFinance.DataModel.Transaction> Transactions = new List<TravisFreeburgFinance.DataModel.Transaction>();
            List<TravisFreeburgFinance.DataModel.Budget> Budgets = new List<TravisFreeburgFinance.DataModel.Budget>();


            Transactions.Add(new TravisFreeburgFinance.DataModel.Transaction()
            {
                Category = DataModel.eCategory.Entertainment.ToString(),
                TransactionID = 1,
                Amount = (decimal?)100.50,
                TransactionDate = DateTime.Now.AddDays((double)-5).ToString("MM/dd/yyyy"),
                Description = "Movie"
            });

            Transactions.Add(new DataModel.Transaction()
            {
                TransactionID = 2,
                Category = DataModel.eCategory.Food.ToString(),
                Description = "Subway",
                TransactionDate = DateTime.Now.AddDays((double)-4).ToString("MM/dd/yyyy"),
                Amount = (decimal?)151.23
            });

            Transactions.Add(new DataModel.Transaction()
            {
                TransactionID = 3,
                Category = DataModel.eCategory.Loan.ToString(),
                Description = "Sofi",
                TransactionDate = DateTime.Now.AddDays((double)-3).ToString("MM/dd/yyyy"),
                Amount = (decimal?)950.23
            });
            Transactions.Add(new DataModel.Transaction()
            {
                TransactionID = 4,
                Category = DataModel.eCategory.Entertainment.ToString(),
                Description = "Soccer Payment",
                TransactionDate = DateTime.Now.AddDays((double)-2).ToString("MM/dd/yyyy"),
                Amount = (decimal?)450
            });
            Transactions.Add(new DataModel.Transaction()
            {
                TransactionID = 5,
                Category = DataModel.eCategory.Loan.ToString(),
                Description = "Navient",
                TransactionDate = DateTime.Now.AddDays((double)-1).ToString("MM/dd/yyyy"),
                Amount = (decimal?)150.05
            });
            Transactions.Add(new DataModel.Transaction()
            {
                TransactionID = 6,
                Category = DataModel.eCategory.Utilities.ToString(),
                Description = "Water",
                TransactionDate = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = (decimal?)23.5
            });


            string json = JsonConvert.SerializeObject(Transactions);
            string budgetjson = JsonConvert.SerializeObject(Budgets);

            if (File.Exists(transactionsPath))
            {
                File.Delete(transactionsPath);
            }

            if (File.Exists(budgetsPath))
            {
                File.Delete(budgetsPath);
            }


            using (FileStream fs = File.Create(transactionsPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(json);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            using (FileStream fs = File.Create(budgetsPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(budgetjson);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }


        }


        #region Public

        #region Transaction


        public List<DataModel.Transaction> RetrieveTransactions()
        {
            string s = "";
            using (StreamReader sr = File.OpenText(transactionsPath))
            {
                s = sr.ReadLine();
            }
            List<TravisFreeburgFinance.DataModel.Transaction> Transactions = (List<TravisFreeburgFinance.DataModel.Transaction>)JsonConvert.DeserializeObject<List<TravisFreeburgFinance.DataModel.Transaction>>(s);

            if (Transactions == null)
            {
                Transactions = new List<DataModel.Transaction>();
            }

            return Transactions;
        }

        public DataModel.Transaction Transaction_GetOne(long TransactionID)
        {
            List<DataModel.Transaction> lTransactions = RetrieveTransactions();
            DataModel.Transaction oReturn = null;
            for (int i = 0; i < lTransactions.Count; i++)
            {
                if (lTransactions[i].TransactionID == TransactionID)
                {
                    oReturn = lTransactions[i];
                    break;
                }
            }

            return oReturn;
        }

        public void Transaction_Update(DataModel.Transaction oTransaction)
        {
            List<DataModel.Transaction> lTransactions = RetrieveTransactions();
            long? TransactionID = oTransaction.TransactionID;

            for (int i = 0; i < lTransactions.Count; i++)
            {
                if (lTransactions[i].TransactionID == TransactionID)
                {
                    lTransactions[i] = oTransaction;
                    break;
                }
            }

            UpdateTransactionFile(lTransactions);
        }

        public void Transaction_Delete(long ID)
        {
            List<DataModel.Transaction> lTransactions = RetrieveTransactions();

            List<DataModel.Transaction> newTransactions = new List<DataModel.Transaction>();
            for (int i = 0; i < lTransactions.Count; i++)
            {
                if (lTransactions[i].TransactionID != ID)
                {
                    newTransactions.Add(lTransactions[i]);
                }
            }

            UpdateTransactionFile(newTransactions);
        }

        public DataModel.Transaction Transaction_Add(DataModel.Transaction oTransaction)
        {
            List<DataModel.Transaction> lTransactions = RetrieveTransactions();
            long? TransactionID = lTransactions.OrderBy(tmpTran => tmpTran.TransactionID).Select(tmpTran => tmpTran.TransactionID).DefaultIfEmpty(0).LastOrDefault();

            oTransaction.TransactionID = TransactionID + 1;

            lTransactions.Add(oTransaction);

            UpdateTransactionFile(lTransactions);

            return oTransaction;
        }

        #endregion

        #region Budget

        public List<DataModel.Budget> Budget_RetrieveAll()
        {
            string s = "";
            using (StreamReader sr = File.OpenText(budgetsPath))
            {
                s = sr.ReadLine();
            }
            List<TravisFreeburgFinance.DataModel.Budget> Budgets = (List<TravisFreeburgFinance.DataModel.Budget>)JsonConvert.DeserializeObject<List<TravisFreeburgFinance.DataModel.Budget>>(s);
            if (Budgets == null)
            {
                Budgets = new List<DataModel.Budget>();
            }
            return Budgets;
        }

        private void Budget_Update(DataModel.Budget oBudget)
        {
            List<DataModel.Budget> lBudgets = Budget_RetrieveAll();

            for (int i = 0; i < lBudgets.Count; i++)
            {
                if (lBudgets[i].Category == oBudget.Category)
                {
                    lBudgets[i] = oBudget;
                    break;
                }
            }

            UpdateBudgetsFile(lBudgets);
        }

        public void Budget_Delete(DataModel.eCategory eCat)
        {
            List<DataModel.Budget> lBudgets = Budget_RetrieveAll();
            List<DataModel.Budget> newBudgets = new List<DataModel.Budget>();

            for (int i = 0; i < lBudgets.Count; i++)
            {
                if (lBudgets[i].Category != eCat.ToString())
                {
                    newBudgets.Add(lBudgets[i]);
                }
            }

            UpdateBudgetsFile(newBudgets);
        }


        public void Budget_AddUpdate(DataModel.Budget oBudget)
        {
            List<DataModel.Budget> lBudgets = Budget_RetrieveAll();

            DataModel.Budget existingBudget = lBudgets.Where(tmpBudget => tmpBudget.Category == oBudget.Category).FirstOrDefault();


            for (int i = 0; i < lBudgets.Count; i++)
            {
                if (lBudgets[i].Category == oBudget.Category)
                {
                    lBudgets[i] = oBudget;
                    break;
                }
            }


            if (existingBudget == null)
            {
                lBudgets.Add(oBudget);
            }

            UpdateBudgetsFile(lBudgets);

        }

        #endregion



        #endregion

        #region Private

        private void UpdateTransactionFile(List<DataModel.Transaction> Transactions)
        {
            string json = JsonConvert.SerializeObject(Transactions);

            using (FileStream fs = File.Create(transactionsPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(json);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

        }

        private void UpdateBudgetsFile(List<DataModel.Budget> Budgets)
        {
            string json = JsonConvert.SerializeObject(Budgets);

            using (FileStream fs = File.Create(budgetsPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(json);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

        }

        #endregion
    }
}
