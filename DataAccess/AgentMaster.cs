using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
	public class AgentMaster
	{
		public AgentMaster()
		{

		}

		public static void Save(Entity.AgentMaster agentmaster)
		{
			using (DataManager oDm = new DataManager())
			{
				oDm.Add("@pAgentId", SqlDbType.Int, ParameterDirection.InputOutput, agentmaster.AgentId);
				oDm.Add("@pName", SqlDbType.VarChar, 50, agentmaster.Name);
				oDm.Add("@pEmail", SqlDbType.VarChar, 100, agentmaster.Email);
				oDm.Add("@pContactNo", SqlDbType.VarChar, 50, agentmaster.ContactNo);
				oDm.Add("@pPassword", SqlDbType.VarChar, 50, agentmaster.Password);
				

				oDm.CommandType = CommandType.StoredProcedure;

				oDm.ExecuteNonQuery("AgentMaster_Save");

				agentmaster.AgentId = (int)oDm["@pAgentId"].Value;
			}
		}

		public static DataTable GetAll()
		{
			using (DataManager oDm = new DataManager())
			{
				oDm.CommandType = CommandType.StoredProcedure;

				return oDm.ExecuteDataTable("AgentMaster_GetAll");
			}
		}

		public static Entity.AgentMaster GetAgentMasterById(int agentId)
		{
			using (DataManager oDm = new DataManager())
			{

				oDm.CommandType = CommandType.StoredProcedure;

				oDm.Add("@pAgentId", SqlDbType.Int, ParameterDirection.Input, agentId);

				SqlDataReader dr = oDm.ExecuteReader("AgentMaster_GetById");

				Entity.AgentMaster agentMaster = new Entity.AgentMaster();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						agentMaster.AgentId = agentId;
						agentMaster.Name = (dr[1] == DBNull.Value) ? "" : dr[1].ToString();
						agentMaster.Email = (dr[2] == DBNull.Value) ? "" : dr[2].ToString();
						agentMaster.ContactNo = (dr[3] == DBNull.Value) ? "" : dr[3].ToString();
						agentMaster.Password = (dr[4] == DBNull.Value) ? "" : dr[4].ToString();
						
					}
				}
				return agentMaster;
			}
		}

		public static void Delete(int agentId)
		{
			using (DataManager oDm = new DataManager())
			{

				oDm.CommandType = CommandType.StoredProcedure;

				oDm.Add("@pAgentId", SqlDbType.Int, ParameterDirection.Input, agentId);

				oDm.ExecuteNonQuery("AgentMaster_Delete");
			}
		}

        public static Entity.AgentMaster AuthenticateUser(string Email)
        {
            using (DataManager oDm = new DataManager())
            {
                oDm.Add("@Email", SqlDbType.VarChar, 50, Email);
                oDm.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = oDm.ExecuteReader("GetUserNameAndPass_Customer");
                Entity.AgentMaster agent = new Entity.AgentMaster();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        agent.AgentId = (dr[0] == DBNull.Value) ? 0 : Convert.ToInt32(dr[0].ToString());
                        agent.Email = (dr[1] == DBNull.Value) ? "" : dr[1].ToString();
                        agent.Password = (dr[2] == DBNull.Value) ? "" : dr[2].ToString();
                        agent.Name = (dr[3] == DBNull.Value) ? "" : dr[3].ToString();
                    }
                    return agent;
                }
                return null;
            }
        }
    }
}