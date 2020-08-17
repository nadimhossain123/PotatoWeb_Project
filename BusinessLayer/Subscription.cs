using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class Subscription
    {
        public Subscription()
        { }

        public int Subscription_Save(Entity.Subscription subscription)
        {
            return DataAccess.Subscription.Subscription_Save(subscription);
        }

        public DataTable Subscription_GetAll(Entity.Subscription subscription)
        {
            return DataAccess.Subscription.Subscription_GetAll(subscription);
        }

        public DataTable Subscription_GetBySubscriptionId(Int64 subscriptionId)
        {
            return DataAccess.Subscription.Subscription_GetBySubscriptionId(subscriptionId);
        }

        public int Subscription_Delete(Int64 subscriptionId)
        {
            return DataAccess.Subscription.Subscription_Delete(subscriptionId);
        }

        public DataTable FinancialYear_GetAll()
        {
            return DataAccess.Subscription.FinancialYear_GetAll();
        }

        public DataTable GetMemberPaidAmount_byFinancialYear(int memberId, int financialYearId)
        {
            return DataAccess.Subscription.GetMemberPaidAmount_byFinancialYear(memberId, financialYearId);
        }

        public DataTable Subscription_GetAllByFinancialYear(Entity.Subscription subscription)
        {
            return DataAccess.Subscription.Subscription_GetAllByFinancialYear(subscription);
        }
    }
}
