using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
   public class Provider
    {
       public Provider()
       {
       }

       public void Save(string CurrentProvider)
       {
           DataAccess.Provider.Save(CurrentProvider);
       }

       public string GetCurrentProvider()
       {
           return DataAccess.Provider.GetCurrentProvider();
       }
    }
}
