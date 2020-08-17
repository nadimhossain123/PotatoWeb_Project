using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class CapacityMaster : System.Web.UI.Page
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
            DataTable dt = ObjRate.GetCapacityAndLoadingByYear(Year);
            
            if (dt != null)
            {
                dgvDistrict.DataSource = dt;
                dgvDistrict.DataBind();
            }
            lbl2.Text = "";
        }

        protected void ClearControls()
        {
            LodUnloading();
            ddlYear.SelectedIndex = 0;
            lbl2.Text = "";
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
            dt.Columns.Add("Capacity");
            dt.Columns.Add("Loading");
            dt.Columns.Add("Year");
            
            DataRow dr;

            foreach (GridViewRow row in dgvDistrict.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string DistrictId = dgvDistrict.DataKeys[row.RowIndex].Value.ToString();
                    string Capacity = FitRate(((TextBox)row.FindControl("txtCapacity")).Text.Trim());
                    string Loading = FitRate(((TextBox)row.FindControl("txtLoading")).Text.Trim());
                    

                    dr = dt.NewRow();
                    dr["DistrictId"] = DistrictId;
                    dr["Capacity"] = Capacity;
                    dr["Loading"] = Loading;
                    dr["Year"] = ddlYear.SelectedValue;
                   
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
            }

            ObjRate.Save(dt);
           

        }
        protected void Edit()
        {
            LodUnloading();
        }
            protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            lbl2.Text = "Capacity and Loading Saved/Updated Successfully";
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