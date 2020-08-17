using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public class SMSTrigger
    {
       public SMSTrigger()
       {

       }

       public static void Save(string UserName, int MobNoCount, int CharCount, int TotalCredit)
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.Add("@pUserName", SqlDbType.VarChar, 50, UserName);
               oDm.Add("@pMobNoCount", SqlDbType.Int, MobNoCount);
               oDm.Add("@pCharCount", SqlDbType.Int, CharCount);
               oDm.Add("@pTotalCredit", SqlDbType.Int, TotalCredit);
               oDm.CommandType = CommandType.StoredProcedure;
               oDm.ExecuteNonQuery("usp_SMSTrigger_Save");
           }
       }

       public static DataTable GetAll()
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.CommandType = CommandType.StoredProcedure;
               return oDm.ExecuteDataTable("usp_SMSTrigger_GetAll");
           }
       }

       public static bool IsMessageSentToday()
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.CommandType = CommandType.StoredProcedure;
               DataTable DT = oDm.ExecuteDataTable("usp_SMSTrigger_MessageToday");
               if (DT.Rows.Count > 0)
                   return true;
               else
                   return false;
           }
       }

       public static void Unlock()
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.CommandType = CommandType.StoredProcedure;
               oDm.ExecuteNonQuery("usp_SMSTrigger_Unlock");
           }
       }

       public static DataTable GetBalance()
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.CommandType = CommandType.StoredProcedure;
               return oDm.ExecuteDataTable("usp_SMSBalance");
           }
       }


        public static int GetAppDownloadCount()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                DataTable DT = oDm.ExecuteDataTable("GetAppDownloadCount");
                int Count = Convert.ToInt32(DT.Rows[0]["Count"]);
                return Count;
            }
        }

        public static void Update(Entity.SMSBalance sMSBalance)
       {
           using (DataManager oDm = new DataManager())
           {
               oDm.Add("@pBalanceId", SqlDbType.Int, sMSBalance.BalanceId);
               oDm.Add("@pBalance", SqlDbType.Decimal, sMSBalance.Balance);
               oDm.Add("@pExpanceBalance", SqlDbType.Decimal, sMSBalance.ExpanceBalance);


               oDm.CommandType = CommandType.StoredProcedure;

               oDm.ExecuteNonQuery("SMSBalance_Update");
           }
       }

        public static void SavePortal(string UserName, int MobNoCount, int CharCount, int TotalCredit)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pUserName", SqlDbType.VarChar, 50, UserName);
                oDm.Add("@pMobNoCount", SqlDbType.Int, MobNoCount);
                oDm.Add("@pCharCount", SqlDbType.Int, CharCount);
                oDm.Add("@pTotalCredit", SqlDbType.Int, TotalCredit);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("usp_SMSTriggerPortal_Save");
            }
        }
        public static DataTable GetAllPortal()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_SMSTriggerPortal_GetAll");
            }
        }
    }
}
