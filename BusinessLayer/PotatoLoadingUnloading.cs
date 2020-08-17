using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class PotatoLoadingUnloading
    {
        public void Save(DataTable dtRate)
        {
            DataAccess.PotatoLoadingUnloading.Save(dtRate);
        }
        public void SaveUnloading(DataTable dtRate)
        {
            DataAccess.PotatoLoadingUnloading.SaveUnloading(dtRate);
        }
        public DataTable GetCapacityAndLoadingByYear(string Year)
        {
            return DataAccess.PotatoLoadingUnloading.GetCapacityAndLoadingByYear(Year);
        }
        public DataTable GetUnloadingByMonthAndYear(int Month,string Year)
        {
            return DataAccess.PotatoLoadingUnloading.GetUnloadingByMonthAndYear(Month,Year);
        }
    }
}
