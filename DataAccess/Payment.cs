using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Payment
    {
        public static Entity.Payment GetMemberDetailsByMemberId(int MemberId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.Add("@pMemberId", SqlDbType.Int, MemberId);
                SqlDataReader dr = oDm.ExecuteReader("MemberDetails_GetById");

                Entity.Payment pm = new Entity.Payment();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pm.MemberId = MemberId;
                        pm.FName = (dr["MemberName"] == DBNull.Value) ? "" : dr["MemberName"].ToString();
                        pm.Email = (dr["Email"] == DBNull.Value) ? "" : dr["Email"].ToString();
                        pm.Mobile = (dr["MobileNo"] == DBNull.Value) ? "" : dr["MobileNo"].ToString();

                    }
                }
                return pm;
            }
        }

        public static string GetPaymentDetailsByTransactionId(int TransactionId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.Add("@pTransactionId", SqlDbType.Int, TransactionId);
                SqlDataReader dr = oDm.ExecuteReader("PaymentDetails_GetByTransactionId");

                string Amount = "";
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Amount = (dr["Amount"] == DBNull.Value) ? "" : dr["Amount"].ToString();
                        

                    }
                }
                return Amount;
            }
        }

        public static int PaymentSuccess(int TransactionId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.Add("@pTransactionId", SqlDbType.Int, TransactionId);
                SqlDataReader dr = oDm.ExecuteReader("PaymentSuccess");

                int Result = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Result = Convert.ToInt32((dr["Result"] == DBNull.Value) ? "" : dr["Result"]);


                    }
                }
                return Result;
            }
        }

        public static int PaymentFailure(int TransactionId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.Add("@pTransactionId", SqlDbType.Int, TransactionId);
                SqlDataReader dr = oDm.ExecuteReader("PaymentFailure");

                int Result = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Result = Convert.ToInt32((dr["Result"] == DBNull.Value) ? "" : dr["Result"]);


                    }
                }
                return Result;
            }
        }

        public static DataTable  SubscriptionDetails_GetByTransactionId(int TransactionId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.Add("@pTransactionId", SqlDbType.Int, TransactionId);
                DataTable Dt= oDm.ExecuteDataTable("SubscriptionDetails_GetByTransactionId");

                
                return Dt;
            }
        }

    }
}
