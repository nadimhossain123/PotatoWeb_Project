using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
   public class ApiConfiguration
    {
        public DataTable GetAll()
        {
            return DataAccess.ApiConfiguration.GetAll();
        }

        public int Delete(int SMSAPIId)
        {
            return DataAccess.ApiConfiguration.Delete(SMSAPIId);
        }


        public int Save(int SMSAPIId)
        {
            return DataAccess.ApiConfiguration.Save(SMSAPIId);
        }
    }
}
