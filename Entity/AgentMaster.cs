using System;
using System.Collections.Generic;

namespace Entity
{
	public class AgentMaster
	{
		public AgentMaster()
		{

		}

		private int  agentId;
		private string name;
		private string email;
		private string contactNo;
		private string password;
		
		public int  AgentId
		{
			get{ return agentId;}
			set{ agentId = value;}
		}
		public string Name
		{
			get{ return name;}
			set{ name = value;}
		}
		public string Email
		{
			get{ return email;}
			set{ email = value;}
		}
		public string ContactNo
		{
			get{ return contactNo;}
			set{ contactNo = value;}
		}
		public string Password
		{
			get{ return password;}
			set{ password = value;}
		}
		
	}
}