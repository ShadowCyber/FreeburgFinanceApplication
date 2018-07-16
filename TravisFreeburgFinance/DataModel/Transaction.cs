
using System;
using System.Windows.Forms;

namespace TravisFreeburgFinance.DataModel
{
	/// <summary>
	/// Description of Transaction.
	/// </summary>
	public class Transaction
	{
		private long? _transactionID;
		public long? TransactionID {
			get {return _transactionID;}
			set {
				_transactionID = value;
			}
		}
		
		private string _Category;
		public string Category{
			get {return _Category;}
			set {
				_Category = value;
			}
		}
		
		private decimal? _amount;
		public decimal? Amount {
			get {return _amount;}
			set {
				_amount = value;
			}
		}
		
		private string _TransactionDate;
		public string TransactionDate {
			get {return _TransactionDate;}
			set {
				_TransactionDate = value;
			}
		}
		
		private string _Description;
		public string Description{
			get {return _Description;}
			set {
				_Description = value;
			}
		}
		
		public string Message;
		
		public bool Success = true;

        public bool IgnoreBudget = false;
		
		
		public Transaction()
		{			
		}

        public Transaction(DataGridViewRow Row)
        {
            TransactionID = (long?)Row.Cells[nameof(DataModel.Transaction.TransactionID)].Value;
            Category = (string)Row.Cells[nameof(DataModel.Transaction.Category)].Value;
            Amount= (decimal?)Row.Cells[nameof(DataModel.Transaction.Amount)].Value;
            TransactionDate= (string)Row.Cells[nameof(DataModel.Transaction.TransactionDate)].Value;
            Description= (string)Row.Cells[nameof(DataModel.Transaction.Description)].Value;
        }

    }
}
