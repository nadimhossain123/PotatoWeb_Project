using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Provider
    {
        public Provider()
        {
        }

        public static void Save(string CurrentProvider)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pCurrentProvider", SqlDbType.VarChar, 50, CurrentProvider);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("usp_CurrentProvider_Save");
            }
        }

        public static string GetCurrentProvider()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                DataTable dt = oDm.ExecuteDataTable("usp_GetCurrentProvider");
                return dt.Rows[0][0].ToString().Trim();
            }
        }
    }
}
