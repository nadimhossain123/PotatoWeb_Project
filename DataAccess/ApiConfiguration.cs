using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
   public class ApiConfiguration
    {
       public static DataTable GetAll()
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.CommandType = CommandType.StoredProcedure;
               return oDm.ExecuteDataTable("usp_SMSAPI_GetAll");
           }
       }

       public static int Delete(int SMSAPIId)
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.CommandType = CommandType.StoredProcedure;

               oDm.Add("@SMSAPIId", SqlDbType.Int, ParameterDirection.Input, SMSAPIId);

               return oDm.ExecuteNonQuery("Usp_SMSAPI_Delete");
           }
       }

       public static int Save(int SMSAPIId)
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.Add("@SMSAPIId", SqlDbType.Int, SMSAPIId);

               oDm.CommandType = CommandType.StoredProcedure;
               return oDm.ExecuteNonQuery("usp_SMSAPI_Save");
           } 
       }
    }
}
