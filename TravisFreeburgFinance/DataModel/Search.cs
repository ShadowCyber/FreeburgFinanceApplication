using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisFreeburgFinance.DataModel
{
    class Search
    {

        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
            }
        }

        private string _Category;
        public string Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
            }
        }

        private DateTime? _BeginningDate;
        public DateTime? BeginningDate
        {
            get { return _BeginningDate; }
            set
            {
                _BeginningDate = value;
            }
        }

        private DateTime? _EndDate;
        public DateTime? EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
            }
        }

        private string _SortBy;
        public string SortBy
        {
            get { return _SortBy; }
            set
            {
                _SortBy = value;
            }
        }

    }
}
