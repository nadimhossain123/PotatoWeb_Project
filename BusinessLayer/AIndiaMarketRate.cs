using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class AIndiaMarketRate
    {
        public AIndiaMarketRate()
        {
        }

        public void Save(string Date, DataTable dtRate)
        {
            DataAccess.AIndiaMarketRate.Save(Date, dtRate);
        }

        public DataTable GetRateByDate(string Date)
        {
            return DataAccess.AIndiaMarketRate.GetRateByDate(Date);
        }

        public DataSet GetAll(string StartDate, string EndDate)
        {
            return DataAccess.AIndiaMarketRate.GetAll(StartDate, EndDate);
        }
    }
}
