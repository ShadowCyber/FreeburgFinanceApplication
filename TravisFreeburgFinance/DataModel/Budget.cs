
using System;

namespace TravisFreeburgFinance.DataModel
{
	/// <summary>
	/// Description of Budgets.
	/// </summary>
	public class Budget
	{
		public string Category;
		public string Value;
        public string Message;
        public bool Success = true;
		
		public Budget()
		{
		}
	}
}
