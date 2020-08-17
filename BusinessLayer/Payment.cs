using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class Payment
    {
        public Entity.Payment GetMemberDetails(int MemberId)
        {
            return DataAccess.Payment.GetMemberDetailsByMemberId(MemberId);
        }

        public string GetPaymentDetails(int TransactionId)
        {
            return DataAccess.Payment.GetPaymentDetailsByTransactionId(TransactionId);
        }

        public int PaymentSuccess(int TransactionId)
        {
            return DataAccess.Payment.PaymentSuccess(TransactionId);
        }

        public int PaymentFailure(int TransactionId)
        {
            return DataAccess.Payment.PaymentFailure(TransactionId);
        }
        public DataTable SubscriptionDetails_GetByTransactionId(int TransactionId)
        {
            return DataAccess.Payment.SubscriptionDetails_GetByTransactionId(TransactionId);
        }



    }
}
