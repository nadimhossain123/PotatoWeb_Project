using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DataAccess
{
    public class Circular
    {

        public static int Save(string circular)
        {
            int result;
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pCircularBody", SqlDbType.NVarChar,10000, circular);
                oDm.CommandType = CommandType.StoredProcedure;
                result=oDm.ExecuteNonQuery("usp_Circular_Save");
            }
            return result;
        }


        public static DataTable GetCurrentCircular()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_Circular_GetAll");
            }
        }


    }
}
