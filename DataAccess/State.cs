using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
    public class State
    {
        public State()
        {
        }

        public static void Save(Entity.State State)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pStateId", SqlDbType.Int, ParameterDirection.Input, State.StateId);
                oDm.Add("@pStateName", SqlDbType.VarChar, 50, ParameterDirection.Input, State.StateName);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("usp_State_Save");
            }
        }

        public static DataTable GetAll()
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.CommandType = CommandType.StoredProcedure;
                return oDm.ExecuteDataTable("usp_State_GetAll");
            }
        }

        public static void Delete(int StateId)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@pStateId", SqlDbType.Int, ParameterDirection.Input, StateId);
                oDm.CommandType = CommandType.StoredProcedure;
                oDm.ExecuteNonQuery("usp_State_Delete");
            }
        }
    }
}
