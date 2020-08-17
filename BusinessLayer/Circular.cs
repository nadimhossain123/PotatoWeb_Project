using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class Circular
    {
        public int Save(string circular)
        {
            return DataAccess.Circular.Save(circular);
        }

        public DataTable GetCurrentCircular()
        {
            return DataAccess.Circular.GetCurrentCircular();
        }


    }
}
