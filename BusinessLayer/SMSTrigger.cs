using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class SMSTrigger
    {
        public SMSTrigger()
        {
        }

        public void Save(string UserName, int MobNoCount, int CharCount, int TotalCredit)
        {
            DataAccess.SMSTrigger.Save(UserName, MobNoCount, CharCount, TotalCredit);
        }

        public DataTable GetAll()
        {
            return DataAccess.SMSTrigger.GetAll();
        }

        public bool IsMessageSentToday()
        {
            return DataAccess.SMSTrigger.IsMessageSentToday();
        }

        public void Unlock()
        {
            DataAccess.SMSTrigger.Unlock();
        }

        public DataTable GetBalance()
        {
            return DataAccess.SMSTrigger.GetBalance();
        }

        public int GetAppDownloadCount()
        {
            return DataAccess.SMSTrigger.GetAppDownloadCount();
        }

        public void Update(Entity.SMSBalance sMSBalance)
        {
            DataAccess.SMSTrigger.Update(sMSBalance);
        }

        public void SavePortal(string UserName, int MobNoCount, int CharCount, int TotalCredit)
        {
            DataAccess.SMSTrigger.SavePortal(UserName, MobNoCount, CharCount, TotalCredit);
        }

        public DataTable GetAllPortal()
        {
            return DataAccess.SMSTrigger.GetAllPortal();
        }
    }
}
