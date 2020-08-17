using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Net;
using System.IO;

namespace PBALBS
{
    public partial class PaymentReceipt : System.Web.UI.Page
    {
        public Int64 SubscriptionId
        {
            get { return Convert.ToInt64(ViewState["SubscriptionId"]); }
            set { ViewState["SubscriptionId"] = value; }
        }

        decimal totalAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadFinancialYear();
                LoadDistrict();
                LoadMember();
                if (HttpContext.Current.User.IsInRole("Agent"))
                {
                    //ddlStatus.SelectedValue = "0";
                    //ddlStatus.Enabled = false;
                }
                



            }
        }

        protected void LoadFinancialYear()
        {
            BusinessLayer.Subscription objSubscription = new BusinessLayer.Subscription();
            DataTable dt = new DataTable();

            dt = objSubscription.FinancialYear_GetAll();

            if (dt != null)
            {
                ddlYear.DataSource = dt;
                ddlYear.DataTextField = "FinancialYear";
                ddlYear.DataValueField = "FinancialYearId";
                ddlYear.DataBind();
            }
        }

        protected void LoadMember()
        {
            int DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            BusinessLayer.Member ObjMember = new BusinessLayer.Member();
            DataTable dt = ObjMember.GetAll("",DistrictId, "", "", "", "", 1, "");

            if (dt != null)
            {
                ddlMember.DataSource = dt;
                ddlMember.DataTextField = "MemberFullName";
                ddlMember.DataValueField = "MemberId";
                ddlMember.DataBind();
            }

            ListItem li = new ListItem("--SELECT--", "0");
            ddlMember.Items.Insert(0, li);
            
        }
        protected void LoadDistrict()
        {
            BusinessLayer.Member ObjMember = new BusinessLayer.Member();
            DataTable dt = ObjMember.GetDistrict();

            if (dt != null)
            {
                ddlDistrict.DataSource = dt;
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictId";
                ddlDistrict.DataBind();
            }

            ListItem li = new ListItem("--SELECT--", "0");
            ddlMember.Items.Insert(0, li);
        }

        protected void ClearControls()
        {
            SubscriptionId = 0;
            ltrMsg.Text = "";
            lblAmountPaid.Text = "";
            ddlMember.SelectedIndex = 0;
            txtAmount.Text = "";
            txtEntryDate.Text = "";
            //txtNarration.Text = "";

            //dgvSubscriptionList.DataBind();
        }

        protected void LoadSubscriptionList()
        {
            //BusinessLayer.Subscription objSubscription = new BusinessLayer.Subscription();
            //Entity.Subscription subscription = new Entity.Subscription();
            //DataTable dt = new DataTable();

            //subscription.MemberId = int.Parse(ddlMember.SelectedValue);
            //subscription.FinancialYearId = 0;
            //subscription.EntryDate = (!String.IsNullOrEmpty(txtTransactionFromDate.Text)) ? Convert.ToDateTime(txtTransactionFromDate.Text) : DateTime.MinValue;
            //subscription.EntryDateTo = (!String.IsNullOrEmpty(txtTransactionToDate.Text)) ? Convert.ToDateTime(txtTransactionToDate.Text) : DateTime.MinValue;
            //subscription.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            //subscription.MobileNo = "";

            //dt = objSubscription.Subscription_GetAll(subscription);
            //if (dt != null)
            //{
            //    dgvSubscriptionList.DataSource = dt;
            //    dgvSubscriptionList.DataBind();
            //}
        }
       


        protected void dgvSubscriptionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //dgvSubscriptionList.PageIndex = e.NewPageIndex;
            //LoadSubscriptionList();
        }

        protected void dgvSubscriptionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Ed")
            //{
            //    SubscriptionId = Int64.Parse(e.CommandArgument.ToString());
            //    BusinessLayer.Subscription objSubscription = new BusinessLayer.Subscription();
            //    DataTable dt = new DataTable();

            //    dt = objSubscription.Subscription_GetBySubscriptionId(SubscriptionId);

            //    ddlYear.SelectedValue = dt.Rows[0]["FinancialYearId_FK"].ToString();
            //    ddlMember.SelectedValue = dt.Rows[0]["MemberId_FK"].ToString();
            //    txtAmount.Text = dt.Rows[0]["Amount"].ToString();
            //    txtEntryDate.Text = Convert.ToDateTime(dt.Rows[0]["EntryDate"].ToString()).ToString("dd MMM yyyy");
            //    txtNarration.Text = dt.Rows[0]["Narration"].ToString();
            //    txtMrNo.Text = dt.Rows[0]["MRNo"].ToString();
            //}
            //else if (e.CommandName == "Del")
            //{
            //    SubscriptionId = Int64.Parse(e.CommandArgument.ToString());
            //    BusinessLayer.Subscription objSubscription = new BusinessLayer.Subscription();

            //    int i = objSubscription.Subscription_Delete(SubscriptionId);
            //    if (i > 0)
            //    {
            //        LoadSubscriptionList();
            //        ClearControls();
            //        ltrMsg.Text = "Deleted successfully...";
            //    }
            //    else
            //    {
            //        ltrMsg.Text = "Sorry! can not delete.";
            //    }
            //}
        }

        protected void ddlMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlMember.SelectedIndex == 0)
            //    dgvSubscriptionList.DataBind();
            //else
            //    LoadSubscriptionList();

            //BusinessLayer.Subscription objSubscription = new BusinessLayer.Subscription();
            //DataTable dt = new DataTable();

            //dt = objSubscription.GetMemberPaidAmount_byFinancialYear(int.Parse(ddlMember.SelectedValue), int.Parse(ddlYear.SelectedValue));

            //if (dt != null)
            //    lblAmountPaid.Text = "Balance: " + dt.Rows[0]["Amount"].ToString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //BusinessLayer.Subscription objSubscription = new BusinessLayer.Subscription();
                //Entity.Subscription subscription = new Entity.Subscription();

                //subscription.SubscriptionId = SubscriptionId;
                //subscription.FinancialYearId = int.Parse(ddlYear.SelectedValue);
                //subscription.MemberId = int.Parse(ddlMember.SelectedValue);
                //subscription.Amount = decimal.Parse(txtAmount.Text);
                //subscription.EntryDate = DateTime.Parse(txtEntryDate.Text);
                //subscription.Narration = txtNarration.Text.Trim();
                //subscription.CreatedBy = Session["UserId"].ToString();
                //subscription.MRNo = txtMrNo.Text.Trim();

                //int i = objSubscription.Subscription_Save(subscription);
                //if (i > 0)
                //{
                //    LoadSubscriptionList();
                //    ltrMsg.Text = "Saved successfully...";
                //    //SendNewSubscriptionAlert(ddlYear.SelectedItem.ToString(), ddlMember.SelectedItem.ToString(), txtAmount.Text);
                //    ClearControls();
                //}
                //else
                //{
                //    ltrMsg.Text = "Sorry! can not save.";
                //}
            }
            catch
            {
                //    ltrMsg.Text = "Sorry! can not save.";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           // LoadSubscriptionList();
        }

        protected void dgvSubscriptionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //totalAmount = 0;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    totalAmount += Convert.ToDecimal(((DataTable)dgvSubscriptionList.DataSource).Rows[e.Row.RowIndex]["Amount"].ToString());
            //}

            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");

            //    lblTotalAmount.Text = Convert.ToString(totalAmount);
            //}
        }

    }
}