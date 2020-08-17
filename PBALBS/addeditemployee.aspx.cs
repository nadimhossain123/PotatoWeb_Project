using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_addeditemployee : System.Web.UI.Page
{

    public int EmployeeId
    {
        get { return Convert.ToInt32(ViewState["EmployeeId"]); }
        set { ViewState["EmployeeId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            //if (!HttpContext.Current.User.IsInRole(Entity.Utility.USER_CREATION))
            //    Response.Redirect("../Login.aspx");

            
            if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim().Length > 0)
            {
                EmployeeId = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
                //PopulateEmployeeMaster();
            }
            else
            {
                ClearControls();
            }
        }
    }

    private void ClearControls()
    {
        EmployeeId = 0;
        ltrMsg.Text = "";
        btnSave.Text = "Save";

        txtEmail.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        BoxAccountDetails.Visible = true;

        txtFName.Text = "";
        txtLName.Text = "";
        txtContactNo.Text = "+91";
    }

    //private void PopulateEmployeeMaster()
    //{
    //    BusinessLayer.EmployeeMaster objEmployeeMaster = new BusinessLayer.EmployeeMaster();
    //    Entity.EmployeeMaster employeeMaster = new Entity.EmployeeMaster();
    //    employeeMaster = objEmployeeMaster.GetById(EmployeeId);

    //    if (employeeMaster != null)
    //    {
    //        txtEmail.Text = employeeMaster.Email.ToString();
    //        BoxAccountDetails.Visible = false;

    //        txtFName.Text = employeeMaster.FName.ToString();
    //        txtLName.Text = employeeMaster.LName.ToString();
    //        txtContactNo.Text = employeeMaster.ContactNo.ToString();
    //        txtAddress.Text = employeeMaster.Address.ToString();
    //        ChkIsActive.Checked = employeeMaster.Status;

    //        ltrMsg.Text = "";
    //        btnSave.Text = "Update";
    //    }
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        BusinessLayer.EmployeeMaster objEmployeeMaster = new BusinessLayer.EmployeeMaster();
        Entity.EmployeeMaster employeeMaster = new Entity.EmployeeMaster();
        employeeMaster.EmployeeId = EmployeeId;
        employeeMaster.FName = txtFName.Text.Trim();
        employeeMaster.LName = txtLName.Text.Trim();
        employeeMaster.Email = txtEmail.Text.Trim();
        employeeMaster.ContactNo = txtContactNo.Text.Trim();
        employeeMaster.BranchId = 1;
        employeeMaster.DesignationId = Convert.ToInt32(ddlRole.SelectedValue);
        //employeeMaster.Address = txtAddress.Text.Trim();
        employeeMaster.Status = ChkIsActive.Checked;
        employeeMaster.Password = BusinessLayer.Cryptography.Encrypt(txtPassword.Text.Trim());
        employeeMaster.CreatedBy = 1;// Convert.ToInt32(Session["UserId"]);
        int RowsAffected = objEmployeeMaster.Save(employeeMaster);

        if (RowsAffected > 0)
        {
            if (EmployeeId == 0)
                ClearControls();

            ltrMsg.Text = "Employee Information Saved Successfully";
        }
        else
        {
            ltrMsg.Text = "Employee Exists";
        }
    }
}
