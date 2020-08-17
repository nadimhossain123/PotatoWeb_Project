using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class Member
    {
        public Member()
        {
        }

        public int  Save(Entity.Member Member)
        {
           return  DataAccess.Member.Save(Member);
        }

        public DataTable GetAll(string FormNo, int DistrictId, string BlockName, string MemberName, string MobileNo, string ExpiryDate, int SearchType, string SMSSubscriberAmt)
        {
            return DataAccess.Member.GetAll(FormNo, DistrictId,BlockName, MemberName, MobileNo, ExpiryDate, SearchType, SMSSubscriberAmt);
        }

        public DataTable GetDistrict()
        {
            return DataAccess.Member.GetDistrict();
        }
        public Entity.Member GetAllById(int MemberId)
        {
           return DataAccess.Member.GetAllById(MemberId);
        }

        public void Delete(int MemberId)
        {
            DataAccess.Member.Delete(MemberId);
        }

        public void QuickUpdate(int MemberId)
        {
            DataAccess.Member.QuickUpdate(MemberId);
        }

        public DataTable getMobileNumbers()
        {
            return DataAccess.Member.getMobileNumbers();
        }

        public DataTable getMembersForNotification()
        {
            return DataAccess.Member.getMembersForNotification();
        }

        public void BulkMobNoInsert(DataTable dtMobNo)
        {
            DataAccess.Member.BulkMobNoInsert(dtMobNo);
        }

        public static int EndDate_Update(int memberId, DateTime endDate)
        {
            return DataAccess.Member.EndDate_Update(memberId, endDate);
        }
        public DataTable getMobileNumbers_Membership()
        {
            return DataAccess.Member.getMobileNumbers_Membership();
        }
    }
}
