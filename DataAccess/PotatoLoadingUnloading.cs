using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
    public class PotatoLoadingUnloading
    {
        public static void Save(DataTable dtRate)
        {
            using (DataManager oDm = new DataManager())
            {
                
                string RateDetailsXML = string.Empty;
                if (dtRate != null && dtRate.Rows.Count > 0)
                {
                    using (DataSet ds = new DataSet())
                    {
                        ds.Tables.Add(dtRate);

                        RateDetailsXML = ds.GetXml();
                    }
                }

                oDm.Add("@pRateDetails", SqlDbType.Xml, RateDetailsXML);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("usp_PotatoCapacityAndLoading_Save");
            }
        }
        public static void SaveUnloading(DataTable dtRate)
        {
            using (DataManager oDm = new DataManager())
            {

                string RateDetailsXML = string.Empty;
                if (dtRate != null && dtRate.Rows.Count > 0)
                {
                    using (DataSet ds = new DataSet())
                    {
                        ds.Tables.Add(dtRate);

                        RateDetailsXML = ds.GetXml();
                    }
                }

                oDm.Add("@pRateDetails", SqlDbType.Xml, RateDetailsXML);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("usp_PotatoUnloading_Save");
            }
        }
        public static DataTable GetCapacityAndLoadingByYear(string Year)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pYear", SqlDbType.VarChar, Year);
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_CapacityAndLoading_GetByYear");
            }
        }
        public static DataTable GetUnloadingByMonthAndYear(int Month,string Year)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pYear", SqlDbType.VarChar, Year);
                oDm.Add("@pMonth", SqlDbType.Int, Month);
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_Unloading_GetByMonthAndYear");
            }
        }
    }
}
