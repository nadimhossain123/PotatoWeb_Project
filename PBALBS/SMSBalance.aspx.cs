using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class SMSBalance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBalance();
            }
        }

        private void GetBalance()
        {
            BusinessLayer.SMSTrigger objSMSTrigger = new BusinessLayer.SMSTrigger();
            DataTable DT = objSMSTrigger.GetBalance();

            txtBalance.Text = Convert.ToInt32(DT.Rows[0]["Balance"]).ToString();
            txtExpanceBalance.Text = Convert.ToInt32(DT.Rows[0]["ExpanceBalance"]).ToString();

            int Balance = Convert.ToInt32(DT.Rows[0]["Balance"]) - Convert.ToInt32(DT.Rows[0]["ExpanceBalance"]);
            lblAvailable.Text = Balance.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BusinessLayer.SMSTrigger objSMSBalance = new BusinessLayer.SMSTrigger();
            Entity.SMSBalance sMSBalance = new Entity.SMSBalance();
            sMSBalance.BalanceId = 1;
            sMSBalance.Balance = (txtBalance.Text.Trim().Length > 0) ? Convert.ToDecimal(txtBalance.Text.Trim()) : 0;
            sMSBalance.ExpanceBalance = (txtExpanceBalance.Text.Trim().Length > 0) ? Convert.ToDecimal(txtExpanceBalance.Text.Trim()) : 0;
            objSMSBalance.Update(sMSBalance);
            GetBalance();
        }
    }
}