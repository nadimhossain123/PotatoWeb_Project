using System;
using System.Collections.Generic;

namespace Entity
{
	public class SMSBalance
	{
		public SMSBalance()
		{

		}

		private int  balanceId;
		private decimal balance;
		private decimal expanceBalance;
		
		public int  BalanceId
		{
			get{ return balanceId;}
			set{ balanceId = value;}
		}
		public decimal Balance
		{
			get{ return balance;}
			set{ balance = value;}
		}
		public decimal ExpanceBalance
		{
			get{ return expanceBalance;}
			set{ expanceBalance = value;}
		}
		
	}
}