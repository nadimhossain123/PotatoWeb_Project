using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class Member
    {
       public Member()
       {
       }

       public int MemberId { get; set; }
       public string MemberName { get; set; }
       public string FormNo { get; set; }
       public string FirmName { get; set; }
       public string Address { get; set; }
       public string BlockName { get; set; }
       public int DistrictId { get; set; }
       public string Pin { get; set; }
       public string MobileNo { get; set; }
       public string LandLine { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set; }
       public bool IsLifeMembership { get; set; }
       public decimal LifeMembershipAmt { get; set; }
       public bool IsYearlySMSSubscriber { get; set; }
       public decimal SMSSubscriberAmt { get; set; }
       public int SubscriptionId { get; set; }
       public bool IsPortalMember { get; set; }
       public decimal PortalMemberAmt { get; set; }
       public bool IsMobileAppActivated { get; set; }
       public string DeviceId { get; set; }
        public string Password { get; set; }



    }
}
