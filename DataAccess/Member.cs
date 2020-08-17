using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Member
    {
        public Member()
        {
        }

        public static int Save(Entity.Member Member)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pMemberId", SqlDbType.Int, ParameterDirection.Input, Member.MemberId);
                oDm.Add("@pMemberName", SqlDbType.VarChar, 50, ParameterDirection.Input, Member.MemberName);
                oDm.Add("@pFormNo", SqlDbType.VarChar, 20, ParameterDirection.Input, Member.FormNo);
                oDm.Add("@pFirmName", SqlDbType.VarChar, 50, ParameterDirection.Input, Member.FirmName);
                oDm.Add("@pAddress", SqlDbType.VarChar, 250, ParameterDirection.Input, Member.Address);
                oDm.Add("@pBlockName", SqlDbType.VarChar, 250, ParameterDirection.Input, Member.BlockName);
                oDm.Add("@pDistrictId", SqlDbType.Int, ParameterDirection.Input, Member.DistrictId);
                oDm.Add("@pPin", SqlDbType.VarChar, 6, ParameterDirection.Input, Member.Pin);
                oDm.Add("@pMobileNo", SqlDbType.VarChar, 10, ParameterDirection.Input, Member.MobileNo);
                oDm.Add("@pLandLine", SqlDbType.VarChar, 20, ParameterDirection.Input, Member.LandLine);
                oDm.Add("@pStartDate", SqlDbType.DateTime, ParameterDirection.Input, Member.StartDate);
                oDm.Add("@pEndDate", SqlDbType.DateTime, ParameterDirection.Input, Member.EndDate);
                oDm.Add("@pIsLifeMembership", SqlDbType.Bit, ParameterDirection.Input, Member.IsLifeMembership);
                oDm.Add("@pLifeMembershipAmt", SqlDbType.Decimal, ParameterDirection.Input, Member.LifeMembershipAmt);
                oDm.Add("@pIsYearlySMSSubscriber", SqlDbType.Bit, ParameterDirection.Input, Member.IsYearlySMSSubscriber);
                oDm.Add("@pSMSSubscriberAmt", SqlDbType.Decimal, ParameterDirection.Input, Member.SMSSubscriberAmt);
                oDm.Add("@pSubscriptionId", SqlDbType.Int, ParameterDirection.Input, Member.SubscriptionId);
                oDm.Add("@pIsPortalMember", SqlDbType.Bit, ParameterDirection.Input, Member.IsPortalMember);
                oDm.Add("@pPortalMemberAmt", SqlDbType.Decimal, ParameterDirection.Input, Member.PortalMemberAmt);
                oDm.Add("@pIsMobileAppActivated", SqlDbType.Bit, ParameterDirection.Input, Member.IsMobileAppActivated);
                oDm.Add("@pDeviceId", SqlDbType.VarChar, 200, ParameterDirection.Input, Member.DeviceId);
                oDm.Add("@pPassword", SqlDbType.VarChar, 20, ParameterDirection.Input, Member.Password);
                oDm.CommandType = CommandType.StoredProcedure;
               return oDm.ExecuteNonQuery("usp_Merchant_Save");
            }
        }

        public static DataTable GetAll(string FormNo, int DistrictId, string BlockName, string MemberName,string MobileNo, string ExpiryDate, int SearchType,string SMSSubscriberAmt)
        {
            using (DataManager oDm = new DataManager())
            {
                if (FormNo.Trim().Length == 0)
                {
                    oDm.Add("@pFormNo", SqlDbType.VarChar, 20, ParameterDirection.Input, DBNull.Value);
                }
                else
                {
                    oDm.Add("@pFormNo", SqlDbType.VarChar, 20, ParameterDirection.Input, FormNo);
                }

                if (DistrictId == 0)
                {
                    oDm.Add("@pDistrictId", SqlDbType.Int, ParameterDirection.Input,DBNull.Value);
                }
                else { oDm.Add("@pDistrictId", SqlDbType.Int, ParameterDirection.Input, DistrictId); }

                if (BlockName.Trim().Length > 0)
                    oDm.Add("@pBlockName", SqlDbType.VarChar, 250, BlockName);
                else
                    oDm.Add("@pBlockName", SqlDbType.VarChar, 250, DBNull.Value);

                if (MemberName.Trim().Length == 0)
                {
                    oDm.Add("@pMemberName", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                else { oDm.Add("@pMemberName", SqlDbType.VarChar, 50, ParameterDirection.Input, MemberName); }

                if (MobileNo.Trim().Length == 0)
                {
                    oDm.Add("@pMobileNo", SqlDbType.VarChar, 10, DBNull.Value);
                }
                else
                {
                    oDm.Add("@pMobileNo", SqlDbType.VarChar, 10, MobileNo);
                }

                if (ExpiryDate.Trim().Length == 0)
                {
                    oDm.Add("@pExpireDate", SqlDbType.DateTime, DBNull.Value);
                }
                else { oDm.Add("@pExpireDate", SqlDbType.DateTime, Convert.ToDateTime(ExpiryDate)); }

                oDm.Add("@pSearchType", SqlDbType.Int, SearchType);

                if (SMSSubscriberAmt.Trim().Length == 0)
                {
                    oDm.Add("@pSMSSubscriberAmt", SqlDbType.Decimal, DBNull.Value);
                }
                else
                {
                    oDm.Add("@pSMSSubscriberAmt", SqlDbType.Decimal, Convert.ToDecimal(SMSSubscriberAmt));
                }
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_Merchant_GetAll");
            }
        }

        public static DataTable GetDistrict()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_District_GetAll");
            }
        }

        public static Entity.Member GetAllById(int MemberId)
        {
            using (DataManager oDm = new DataManager())
            {

                oDm.CommandType = CommandType.StoredProcedure;

                oDm.Add("@pMemberId", SqlDbType.Int, ParameterDirection.Input, MemberId);

                SqlDataReader dr = oDm.ExecuteReader("usp_Merchant_GetAllById");

                Entity.Member EntityMember = new Entity.Member();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EntityMember.MemberId = MemberId;
                        EntityMember.MemberName = (dr[1] == DBNull.Value) ? "" : dr[1].ToString();
                        EntityMember.FormNo = (dr[2] == DBNull.Value) ? "" : dr[2].ToString();
                        EntityMember.FirmName = (dr[3] == DBNull.Value) ? "" : dr[3].ToString();
                        EntityMember.Address = (dr[4] == DBNull.Value) ? "" : dr[4].ToString();
                        EntityMember.BlockName = (dr[5] == DBNull.Value) ? "" : dr[5].ToString();
                        EntityMember.DistrictId = (dr[6] == DBNull.Value) ? 0 : int.Parse(dr[6].ToString());
                        EntityMember.Pin = (dr[7] == DBNull.Value) ? "" : dr[7].ToString();
                        EntityMember.MobileNo = (dr[8] == DBNull.Value) ? "" : dr[8].ToString();
                        EntityMember.LandLine = (dr[9] == DBNull.Value) ? "" : dr[9].ToString();
                        EntityMember.StartDate = (dr[10] == DBNull.Value) ? DateTime.MinValue : DateTime.Parse(dr[10].ToString());
                        EntityMember.EndDate = (dr[11] == DBNull.Value) ? DateTime.MinValue : DateTime.Parse(dr[11].ToString());
                        EntityMember.IsLifeMembership = (dr[12] == DBNull.Value) ? false : bool.Parse(dr[12].ToString());
                        EntityMember.LifeMembershipAmt = (dr[13] == DBNull.Value) ? 0 : decimal.Parse(dr[13].ToString());
                        EntityMember.IsYearlySMSSubscriber = (dr[14] == DBNull.Value) ? false : bool.Parse(dr[14].ToString());
                        EntityMember.SMSSubscriberAmt = (dr[15] == DBNull.Value) ? 0 : decimal.Parse(dr[15].ToString());
                        EntityMember.IsPortalMember = (dr[16] == DBNull.Value) ? false : bool.Parse(dr[16].ToString());
                        EntityMember.PortalMemberAmt = (dr[17] == DBNull.Value) ? 0 : decimal.Parse(dr[17].ToString());

                    }
                }
                return EntityMember;
            }
        }

        public static void Delete(int MemberId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;

                oDm.Add("@pMemberId", SqlDbType.Int, ParameterDirection.Input, MemberId);
                oDm.ExecuteNonQuery("usp_Merchant_Delete");
            }
        }

        public static void QuickUpdate(int MemberId)
        {
            using (DataManager oDm = new DataManager())
            {

                oDm.CommandType = CommandType.StoredProcedure;

                oDm.Add("@pMemberId", SqlDbType.Int, ParameterDirection.Input, MemberId);

                oDm.ExecuteNonQuery("usp_Member_QuickActivate");
            }
        }

        public static DataTable getMobileNumbers()
        {
            using (DataManager oDm = new DataManager())
            {
                
                oDm.CommandType = CommandType.StoredProcedure;

                return oDm.ExecuteDataTable("usp_GetMobileNumbers");


            }
        }

        public static DataTable getMembersForNotification()
        {
            using (DataManager oDm = new DataManager())
            {

                oDm.CommandType = CommandType.StoredProcedure;

                return oDm.ExecuteDataTable("usp_GetMembersForNotification");


            }
        }

        public static void BulkMobNoInsert(DataTable dtMobNo)
        {
            using (DataManager oDm = new DataManager())
            {
                string MobNoXML = string.Empty;
                if (dtMobNo != null && dtMobNo.Rows.Count > 0)
                {
                    using (DataSet ds = new DataSet())
                    {
                        ds.Tables.Add(dtMobNo);

                        MobNoXML = ds.GetXml();
                    }
                }

                oDm.Add("@pMobNo", SqlDbType.Xml, MobNoXML);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("usp_Member_BulkInsert");
            }
        }

        public static int EndDate_Update(int memberId, DateTime endDate)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;

                oDm.Add("@MemberId", SqlDbType.Int, ParameterDirection.Input, memberId);
                oDm.Add("@EndDate", SqlDbType.DateTime, ParameterDirection.Input, endDate);

                return oDm.ExecuteNonQuery("usp_EndDate_Update");
            }
        }
        public static DataTable getMobileNumbers_Membership()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_GetMobileNumbers_Membership");
            }
        }
    }
}
