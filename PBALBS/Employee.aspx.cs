using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class Employee : System.Web.UI.Page
    {
        ListItem li = new ListItem("All", "0");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {

                LoadEmployeeList();
            }
        }

        private void LoadEmployeeList()
        {
            int BranchId = 1;
            int DesignationId = 1;
            string FName = txtFName.Text;

            BusinessLayer.EmployeeMaster objEmployeeMaster = new BusinessLayer.EmployeeMaster();
            DataTable DT = objEmployeeMaster.GetAll(BranchId, DesignationId, FName);

            dgvEmployeeMaster.DataSource = DT;
            dgvEmployeeMaster.DataBind();

            //if (!HttpContext.Current.User.IsInRole(Entity.Utility.USER_ROLE_MODIFICATION))
            //    dgvEmployeeMaster.Columns[8].Visible = false;

            //if (!HttpContext.Current.User.IsInRole(Entity.Utility.USER_MODIFICATION))
            //    dgvEmployeeMaster.Columns[9].Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEmployeeList();
        }

        protected void dgvEmployeeMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int EmployeeId = Convert.ToInt32(dgvEmployeeMaster.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("addeditEmployee.aspx?id=" + EmployeeId);
        }

        protected void dgvEmployeeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvEmployeeMaster.PageIndex = e.NewPageIndex;
            LoadEmployeeList();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("addeditemployee.aspx");
        }
    }
}