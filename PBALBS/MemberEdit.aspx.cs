using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class MemberEdit : System.Web.UI.Page
    {
        public int MemberId
        {
            get { return Convert.ToInt32(ViewState["MemberId"]); }
            set { ViewState["MemberId"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadDistrict();
                //LoadBlock();
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim().Length > 0)
                {
                    MemberId = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
                    LoadMemberDetails();
                }
                else
                {
                    ClearControls();
                }
            }
        }

        protected void LoadDistrict()
        {
            BusinessLayer.District ObjDistrict = new BusinessLayer.District();
            DataTable dt = ObjDistrict.GetAll();
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["DistrictId"] = "0";
                dr["DistrictName"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
                ddlDistrict.DataSource = dt;
                ddlDistrict.DataBind();
            }
        }

        protected void LoadBlock()
        {
            BusinessLayer.Block ObjBlock = new BusinessLayer.Block();
            DataTable dt = ObjBlock.GetAll();
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["BlockId"] = "0";
                dr["BlockName"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
                //ddlBlock.DataSource = dt;
                //ddlBlock.DataBind();
            }
        }
        protected void LoadMemberDetails()
        {
            BusinessLayer.Member ObjMember = new BusinessLayer.Member();
            Entity.Member Member = new Entity.Member();
            Member = ObjMember.GetAllById(MemberId);
            if (Member != null)
            {
                txtMemberName.Text = Member.MemberName;
                ddlDistrict.SelectedValue = Member.DistrictId.ToString();
                txtBlockName.Text = Member.BlockName;
                txtMobileNo.Text = Member.MobileNo;
                txtStartDate.Text = Member.StartDate.ToString("dd/MM/yyyy");
                txtEndDate.Text = Member.EndDate.ToString("dd/MM/yyyy");
                txtFormNo.Text = Member.FormNo;
                txtFirmName.Text = Member.FirmName;
                txtAddress.Text = Member.Address;
                txtPin.Text = Member.Pin;
                txtLandLine.Text = Member.LandLine;
                ChkLifeMemberShip.Checked = Member.IsLifeMembership;
                ChkSMSSubscriber.Checked = Member.IsYearlySMSSubscriber;
                txtLifeMembershipAmt.Text = String.Format("{0:0.##}", Member.LifeMembershipAmt);
                txtSMSSubscriberAmt.Text = String.Format("{0:0.##}", Member.SMSSubscriberAmt);

                ltrMsg.Text = "";
            }
        }

        protected void ClearControls()
        {
            MemberId = 0;
            ltrMsg.Text = "";
            txtMemberName.Text = "";
            ddlDistrict.SelectedValue = "0";
            txtBlockName.Text = "";
            txtMobileNo.Text = "";
            txtStartDate.Text = "15/04/2012";
            txtEndDate.Text = "01/07/2013";
            txtFormNo.Text = "";
            txtFirmName.Text = "";
            txtAddress.Text = "";
            txtPin.Text = "";
            txtLandLine.Text = "";
            ChkLifeMemberShip.Checked = true;
            ChkSMSSubscriber.Checked = true;
            txtLifeMembershipAmt.Text = "0";
            txtSMSSubscriberAmt.Text = "0";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BusinessLayer.Member ObjMember = new BusinessLayer.Member();
            Entity.Member Member = new Entity.Member();
            Member.MemberId = MemberId;
            Member.MemberName = txtMemberName.Text.Trim();
            Member.FormNo = txtFormNo.Text.Trim();
            Member.FirmName = txtFirmName.Text.Trim();
            Member.Address = txtAddress.Text.Trim();
            Member.BlockName = txtBlockName.Text;
            Member.DistrictId = int.Parse(ddlDistrict.SelectedValue.Trim());
            Member.Pin = txtPin.Text.Trim();
            Member.MobileNo = txtMobileNo.Text.Trim();
            Member.LandLine = txtLandLine.Text.Trim();

            string[] SDate = txtStartDate.Text.Trim().Split('/');
            Member.StartDate = Convert.ToDateTime(SDate[1].Trim() + "/" + SDate[0].Trim() + "/" + SDate[2].Trim() + " 00:00:00");

            string[] EDate = txtEndDate.Text.Trim().Split('/');
            Member.EndDate = Convert.ToDateTime(EDate[1].Trim() + "/" + EDate[0].Trim() + "/" + EDate[2].Trim() + " 00:00:00");

            Member.IsLifeMembership = ChkLifeMemberShip.Checked;
            Member.IsYearlySMSSubscriber = ChkSMSSubscriber.Checked;
            Member.LifeMembershipAmt = (txtLifeMembershipAmt.Text.Trim().Length == 0) ? 0 : decimal.Parse(txtLifeMembershipAmt.Text.Trim());
            Member.SMSSubscriberAmt = (txtSMSSubscriberAmt.Text.Trim().Length == 0) ? 0 : decimal.Parse(txtSMSSubscriberAmt.Text.Trim());

            ObjMember.Save(Member);
            ClearControls();
            ltrMsg.Text = "Member Information Saved/Updated Successfully";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}