using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PBALBS
{
    public partial class Master : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = Session["UserId"].ToString();
            if (!IsPostBack)
            {
                if (HttpContext.Current.User.IsInRole("Agent"))
                {
                   Settings.Visible = false;
                    //District.Visible = false;
                    //Block.Visible = false;
                    //MemberList.Visible = false;
                    AddPotato.Visible = false;
                    RateList.Visible = false;
                    ImportExport.Visible = false;
                    SMS.Visible = false;
                    //SubscriptionApproval.Visible = false;
                    //AddEmployee.Visible = false;
                }
            }
            SetCurrentPage();
        }

        protected void liAddEditMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditMember.aspx");
        }


        private void SetCurrentPage()
        {
            var pageName = GetPageName();

            switch (pageName)
            {
                case "AddEditDistrict.aspx":
                    Settings.Attributes["class"] = "active has-sub";
                    break;
                case "AddEditBlock.aspx":
                    Settings.Attributes["class"] = "active has-sub";
                    break;
                case "AddEditMember.aspx":
                    AddMember.Attributes["class"] = "active";
                    break;
                case "MemberDetails.aspx":
                    MemberList.Attributes["class"] = "active";
                    break;
                case "AddEditPotatoRate.aspx":
                    AddPotato.Attributes["class"] = "active";
                    break;
                case "PotatoRateDetails.aspx":
                    RateList.Attributes["class"] = "active";
                    break;
                case "ImportMobNo.aspx":
                    ImportExport.Attributes["class"] = "active";
                    break;
                case "SendSMS.aspx":
                    SMS.Attributes["class"] = "active has-sub";
                    break;
                case "SMSTrigger.aspx":
                    SMS.Attributes["class"] = "active has-sub";
                    break;
                // Newly Add //
                case "MembershipSendSMS.aspx":
                    SMS.Attributes["class"] = "active has-sub";
                    break;
                case "MembershipSMSReport.aspx":
                    SMS.Attributes["class"] = "active has-sub";
                    break;
                    //--//
                case "AddSubscription.aspx":
                    Subscription.Attributes["class"] = "active has-sub";
                    break;
                case "SubscriptionList.aspx":
                    Subscription.Attributes["class"] = "active has-sub";
                    break;
                case "SubscriptionApproval.aspx":
                    SubscriptionApproval.Attributes["class"] = "active";
                    break;
            }
        }
        private string GetPageName()
        {
            return Request.Url.ToString().Split('/').Last();
        }

    }
}
