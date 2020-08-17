using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class ApiConfiguration : System.Web.UI.Page
    {
        public int SMSAPIId
        {
            get { return Convert.ToInt32(ViewState["SMSAPIId"]); }
            set { ViewState["SMSAPIId"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                LoadAPIList();
            }
        }

        protected void LoadAPIList()
        {
            BusinessLayer.ApiConfiguration ObjApi = new BusinessLayer.ApiConfiguration();
            DataTable dt = ObjApi.GetAll();
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToBoolean(dr["IsActive"]) == true)
                {
                    rblApiConfig.SelectedValue = dr["SMSAPIId"].ToString();
                }
            }
            if (dt != null)
            {
                rblApiConfig.DataSource=dt;
                rblApiConfig.DataTextField = "SMSProvider";
                rblApiConfig.DataValueField = "SMSAPIId";
                rblApiConfig.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BusinessLayer.ApiConfiguration ObjApi = new BusinessLayer.ApiConfiguration();
            foreach (ListItem li in rblApiConfig.Items)
            {
                if (li.Selected == true)
                {
                    int SMSAPIId = Convert.ToInt32(li.Value);
                    int RowsAffected = ObjApi.Save(SMSAPIId);
                    if (RowsAffected > 0)
                    {
                        lblMsg.Text = "Updated Successfully";

                    }
                }
            }
            LoadAPIList();
        }
    }
}