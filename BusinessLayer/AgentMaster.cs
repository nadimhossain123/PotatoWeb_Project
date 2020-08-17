using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer
{
	public class AgentMaster
	{
		public AgentMaster()
		{

		}

		public void Save(Entity.AgentMaster agentmaster)
		{
			DataAccess.AgentMaster.Save(agentmaster);
		}

		public DataTable GetAll()
		{
			return DataAccess.AgentMaster.GetAll();
		}

		public Entity.AgentMaster GetAgentMasterById(int agentId)
		{
			return DataAccess.AgentMaster.GetAgentMasterById(agentId);
		}

		public void Delete(int agentId)
		{
			DataAccess.AgentMaster.Delete(agentId);
		}

        public Entity.AgentMaster AuthenticateUser(string Email)
        {
            return DataAccess.AgentMaster.AuthenticateUser(Email);
        }
    }
}