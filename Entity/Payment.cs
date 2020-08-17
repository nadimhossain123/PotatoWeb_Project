using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    
        public class Payment
        {
            public int MemberId { get; set; }
            public string FName { get; set; }

            public string Amount { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }

            public string MerchantKey { get; set; }
            public string MerchantSalt { get; set; }

            public string TransactionId { get; set; }
            public string ProductInfo { get; set; }

            public string Hash { get; set; }
            public string SUrl { get; set; }

        public string udf5 { get; set; }
        }
    }

