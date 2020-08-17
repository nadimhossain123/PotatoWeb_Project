using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
    public class Subscription
    {
        public Subscription()
        { }

        public static int Subscription_Save(Entity.Subscription subscription)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@SubscriptionId", SqlDbType.BigInt, ParameterDirection.Input, subscription.SubscriptionId);
                oDm.Add("@MemberId_FK", SqlDbType.Int, ParameterDirection.Input, subscription.MemberId);
                oDm.Add("@FinancialYearId_FK", SqlDbType.Int, ParameterDirection.Input, subscription.FinancialYearId);
                oDm.Add("@Amount", SqlDbType.Decimal, ParameterDirection.Input, subscription.Amount);
                oDm.Add("@EntryDate", SqlDbType.DateTime, ParameterDirection.Input, subscription.EntryDate);
                oDm.Add("@Narration", SqlDbType.VarChar, 500, ParameterDirection.Input, subscription.Narration);
                oDm.Add("@CreatedBy", SqlDbType.VarChar, 50, ParameterDirection.Input, subscription.CreatedBy);
                oDm.Add("@MRNo", SqlDbType.VarChar, 50, ParameterDirection.Input, subscription.MRNo);
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteNonQuery("usp_Subscription_Save");
            }
        }

        public static DataTable Subscription_GetAll(Entity.Subscription subscription)
        {
            using (DataManager oDm = new DataManager())
            {
                if (subscription.MemberId == 0)
                    oDm.Add("@MemberId_FK", SqlDbType.Int, ParameterDirection.Input, DBNull.Value);
                else
                    oDm.Add("@MemberId_FK", SqlDbType.Int, ParameterDirection.Input, subscription.MemberId);
                if (subscription.FinancialYearId == 0)
                    oDm.Add("@FinancialYearId_FK", SqlDbType.Int, ParameterDirection.Input, DBNull.Value);
                else
                    oDm.Add("@FinancialYearId_FK", SqlDbType.Int, ParameterDirection.Input, subscription.FinancialYearId);
                if (subscription.EntryDate == DateTime.MinValue)
                    oDm.Add("@EntryDateFrom", SqlDbType.DateTime, ParameterDirection.Input, DBNull.Value);
                else
                    oDm.Add("@EntryDateFrom", SqlDbType.DateTime, ParameterDirection.Input, subscription.EntryDate);
                if (subscription.EntryDateTo == DateTime.MinValue)
                    oDm.Add("@EntryDateTo", SqlDbType.DateTime, ParameterDirection.Input, DBNull.Value);
                else
                    oDm.Add("@EntryDateTo", SqlDbType.DateTime, ParameterDirection.Input, subscription.EntryDateTo);
                if (subscription.Status == 2)
                    oDm.Add("@Status", SqlDbType.Bit, DBNull.Value);
                else
                    oDm.Add("@Status", SqlDbType.Bit, subscription.Status);
                if (subscription.MobileNo.Trim().Length == 0)
                {
                    oDm.Add("@MobileNo", SqlDbType.VarChar, 10, DBNull.Value);
                }
                else
                {
                    oDm.Add("@MobileNo", SqlDbType.VarChar, 10, subscription.MobileNo);
                }
                if (subscription.BlockName=="--SELECT--")
                    oDm.Add("@BlockName", SqlDbType.VarChar, 250, DBNull.Value);
                else
                    oDm.Add("@BlockName", SqlDbType.VarChar, 250, subscription.BlockName);
                if (subscription.Amount == 0)
                {
                    oDm.Add("@Amount", SqlDbType.Decimal, DBNull.Value);
                }
                else
                {
                    oDm.Add("@Amount", SqlDbType.Decimal, subscription.Amount);
                }
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_Subscription_GetAll");
            }
        }

        public static DataTable Subscription_GetBySubscriptionId(Int64 subscriptionId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@SubscriptionId", SqlDbType.BigInt, ParameterDirection.Input, subscriptionId);

                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_Subscription_GetBySubscriptionId");
            }
        }

        public static int Subscription_Delete(Int64 subscriptionId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@SubscriptionId", SqlDbType.BigInt, ParameterDirection.Input, subscriptionId);

                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteNonQuery("usp_Subscription_Delete");
            }
        }

        public static DataTable FinancialYear_GetAll()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_FinancialYear_GetAll");
            }
        }

        public static DataTable GetMemberPaidAmount_byFinancialYear(int memberId, int financialYearId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@MemberId", SqlDbType.Int, ParameterDirection.Input, memberId);
                oDm.Add("@FinancialYearId", SqlDbType.Int, ParameterDirection.Input, financialYearId);

                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_GetMemberPaidAmount_byFinancialYear");
            }
        }

        public static DataTable Subscription_GetAllByFinancialYear(Entity.Subscription subscription)
        {
            using (DataManager oDm = new DataManager())
            {
                if (subscription.MemberId == 0)
                    oDm.Add("@MemberId_FK", SqlDbType.Int, ParameterDirection.Input, DBNull.Value);
                else
                    oDm.Add("@MemberId_FK", SqlDbType.Int, ParameterDirection.Input, subscription.MemberId);
                oDm.Add("@FinancialYearId_FK", SqlDbType.Int, ParameterDirection.Input, subscription.FinancialYearId);
                if (subscription.Status == 2)
                    oDm.Add("@Status", SqlDbType.Bit, DBNull.Value);
                else
                    oDm.Add("@Status", SqlDbType.Bit, subscription.Status);

                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_Subscription_GetAllByFinancialYear");
            }
        }
    }
}
