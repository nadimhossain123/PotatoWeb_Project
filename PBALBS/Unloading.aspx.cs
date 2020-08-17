using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class Unloading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ClearControls();
            }

        }

        protected void LodUnloading()
        {
            BusinessLayer.PotatoLoadingUnloading ObjRate = new BusinessLayer.PotatoLoadingUnloading();
            String Year = ddlYear.SelectedValue;
            int Month = Convert.ToInt32(ddlMonth.SelectedValue);
            DataTable dt = ObjRate.GetUnloadingByMonthAndYear(Month,Year);
            if (dt != null)
            {
                dgvDistrict.DataSource = dt;
                dgvDistrict.DataBind();
            }
            lbl1.Text = "";
        }

        protected void ClearControls()
        {
            LodUnloading();
            ddlYear.SelectedIndex = 0;
            lbl1.Text = "";
        }



        protected string FitRate(string Rate)
        {
            string FinalRate = Rate.ToString();
            return FinalRate;
        }



        protected void Save()
        {
            BusinessLayer.PotatoLoadingUnloading ObjRate = new BusinessLayer.PotatoLoadingUnloading();

            DataTable dt = new DataTable();
            dt.Columns.Add("DistrictId");
            dt.Columns.Add("Unloading");
            dt.Columns.Add("Month");
            dt.Columns.Add("Year");
            DataRow dr;

            foreach (GridViewRow row in dgvDistrict.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string DistrictId = dgvDistrict.DataKeys[row.RowIndex].Value.ToString();
                    string UnLoading = FitRate(((TextBox)row.FindControl("txtUnloading")).Text.Trim());
                   

                    dr = dt.NewRow();
                    dr["DistrictId"] = DistrictId;
                    dr["Month"] = ddlMonth.SelectedValue;
                    dr["Unloading"] = UnLoading;
                    dr["Year"] = ddlYear.SelectedValue;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
            }

            ObjRate.SaveUnloading(dt);
            lbl1.Text = "Unloding Entry saved/Updated successfully";

        }
        protected void Edit()
        {
            LodUnloading();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LodUnloading();
        }
    }
}