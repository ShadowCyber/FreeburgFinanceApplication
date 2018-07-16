using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisFreeburgFinance
{
    public class Factory
    {

        public Factory()
        {
        }

        private Data.Data _oData;
        public Data.Data oData
        {
            get
            {
                if (_oData == null)
                {
                    _oData = new Data.Data();
                }
                return _oData;
            }
        }


        private DataManager.DataManager _oDataManager;
        public DataManager.DataManager oDataManager
        {
            get
            {
                if (_oDataManager == null)
                {
                    _oDataManager = new DataManager.DataManager(this);
                }
                return _oDataManager;
            }
        }

    }

}
