using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class State
    {
        public State()
        {
        }

        public void Save(Entity.State State)
        {
            DataAccess.State.Save(State);
        }

        public DataTable GetAll()
        {
            return DataAccess.State.GetAll();
        }

        public void Delete(int StateId)
        {
            DataAccess.State.Delete(StateId);
        }
    }
}
