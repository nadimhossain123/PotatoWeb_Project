using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class Verify : System.Web.UI.Page
    {
        public string MobNo
        {
            get { return ViewState["MobNo"].ToString(); }
            set { ViewState["MobNo"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MobNo"] != null && Request.QueryString["MobNo"].ToString().Trim().Length > 0)
                {
                    MobNo = Request.QueryString["MobNo"].ToString().Trim();
                    Response.Write(VerifyMobNo());
                }
            }
        }

        protected string VerifyMobNo()
        {
            string result="";
            BusinessLayer.Member ObjMember = new BusinessLayer.Member();
            DataTable dt = ObjMember.GetAll("", 0, "", "", MobNo, "", 1,"");
            if (dt.Rows.Count > 0)
            {
                result = MobNo + " Exists";
            }
            return result;
        }

    }
}
