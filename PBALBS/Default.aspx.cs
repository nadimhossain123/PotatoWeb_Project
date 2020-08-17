using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PBALBS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserId"] = null;
                Session["BranchId"] = null;
                txtUserName.Focus();
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        protected void UserLogin()
        {
            string u = txtUserName.Text.Trim();
            string p = txtPassword.Text.Trim();
            BusinessLayer.EmployeeMaster ObjEmployee = new BusinessLayer.EmployeeMaster();
            Entity.EmployeeMaster Employee = new Entity.EmployeeMaster();
            Employee = ObjEmployee.AuthenticateUser(u);

            if (Employee != null)
            {
                if (BusinessLayer.Cryptography.Decrypt(Employee.Password) == p)
                {
                    string UserId = Employee.EmployeeId.ToString();
                    FormsAuthenticationTicket Authticket = new FormsAuthenticationTicket(
                                                               1,
                                                               UserId,
                                                               DateTime.Now,
                                                               DateTime.Now.AddMinutes(240),
                                                               false,
                                                               UserId,
                                                               FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(Authticket);
                    HttpCookie Authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    if (Authticket.IsPersistent)
                        Authcookie.Expires = Authticket.Expiration;
                    Response.Cookies.Add(Authcookie);

                    System.Web.Caching.Cache cacheObject = System.Web.HttpContext.Current.Cache;
                    cacheObject.Insert(UserId, Employee.Roles);

                    Session["UserId"] = Employee.EmployeeId;
                    Session["Role"] = Employee.DesignationId;
                    Session.Timeout = 240;
                    Response.Redirect("AddEditBlock.aspx");
                }
            }
            txtUserName.Text = "";
            txtPassword.Focus();

        }
    }
}