using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class SMSTrigger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (HttpContext.Current.User.IsInRole("Customer"))
                {
                    provider.Visible = false;
                }
                LoadCurrentProvider();
                LoadTriggerList();
            }
        }

        protected void LoadTriggerList()
        {
            try
            {
                BusinessLayer.SMSTrigger ObjSMSTrigger = new BusinessLayer.SMSTrigger();
                
                DataTable dt = ObjSMSTrigger.GetAll();
                if (dt != null)
                {
                    dgvTrigger.DataSource = dt;
                    dgvTrigger.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgvTrigger_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Literal)e.Row.FindControl("ltrSl")).Text = (e.Row.RowIndex + 1).ToString();
            }
        }

        protected void rbtnProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CurrentProvider = rbtnProvider.SelectedValue.Trim();
            BusinessLayer.Provider ObjProvider = new BusinessLayer.Provider();
            ObjProvider.Save(CurrentProvider);
            LoadCurrentProvider();

        }

        protected void LoadCurrentProvider()
        {
            BusinessLayer.Provider ObjProvider = new BusinessLayer.Provider();
            rbtnProvider.SelectedValue = ObjProvider.GetCurrentProvider();
        }
    }
}
