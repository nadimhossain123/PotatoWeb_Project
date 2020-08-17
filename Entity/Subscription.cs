using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Subscription
    {
        public Subscription()
        { }

        public Int64 SubscriptionId { get; set; }
        public int MemberId { get; set; }
        public int FinancialYearId { get; set; }
        public decimal Amount { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime EntryDateTo { get; set; }
        public string Narration { get; set; }
        public string CreatedBy { get; set; }
        public int Status { get; set; }
        public string MobileNo { get; set; }
        public string BlockName { get; set; }
        public string MRNo { get; set; }
    }
}
