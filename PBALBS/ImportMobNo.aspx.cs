using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace PBALBS
{
    public partial class ImportMobNo : System.Web.UI.Page
    {
        public int ValidNo
        {
            get { return Convert.ToInt32(ViewState["ValidNo"]); }
            set { ViewState["ValidNo"] = value; }
        }
        public int InValidNo
        {
            get { return Convert.ToInt32(ViewState["InValidNo"]); }
            set { ViewState["InValidNo"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                txMobNo.Text = "";
                txtMobNoExport.Text = "";
                ltrMsg.Text = "";
                txMobNo.Focus();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            ValidNo = 0;
            InValidNo = 0;
            string MobNoList = txMobNo.Text.Trim();
            if (MobNoList.LastIndexOf(',') == MobNoList.Length - 1)
            {
                MobNoList = MobNoList.Trim().Substring(0, MobNoList.Length - 1);
            }

            string[] arrMob = MobNoList.Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("MobileNo");
            DataRow dr;

            for (int i = 0; i < arrMob.Length; i++)
            {
                if (arrMob[i].Length == 10)
                {
                    dr = dt.NewRow();
                    dr["MobileNo"] = arrMob[i].Trim();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                    ValidNo += 1;
                }
                else
                {
                    InValidNo += 1;
                    sb.Append(arrMob[i].Trim() + ",");
                }

            }

            if (dt.Rows.Count > 0)
            {
                BusinessLayer.Member ObjMember = new BusinessLayer.Member();
                ObjMember.BulkMobNoInsert(dt);
            }
            ltrMsg.Text = "Mobile Numbers Imported Successfully <br />Valid Nos: " + ValidNo.ToString() + "<br />Invalid Nos: " + InValidNo.ToString() + " (" + sb.ToString() + ")";



        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            txtMobNoExport.Text = "";
            StringBuilder sb = new StringBuilder();
            int count = 0;
            BusinessLayer.Member ObjMember = new BusinessLayer.Member();
            DataTable dt = ObjMember.getMobileNumbers();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                count += 1;
                if (count == 50)
                {
                    sb.Append(dt.Rows[i][0].ToString() + "\n\n\n");
                    count = 0;
                }
                else
                {
                    sb.Append(dt.Rows[i][0].ToString() + ",");
                }
            }

            string MobList = sb.ToString();
            if (MobList.LastIndexOf(',') == MobList.Length - 1)
            {
                MobList = MobList.Trim().Substring(0, MobList.Length - 1);
            }

            txtMobNoExport.Text = MobList;
           
        }

        
    }
}
