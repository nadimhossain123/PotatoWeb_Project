using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PBALBS
{
    public partial class PotatoRateDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                rbtnHorz.Checked = true;
                LoadRateChart();
                
            }
        }

        protected void LoadRateChart()
        {
            if (rbtnHorz.Checked == true)
            {
                LoadRateChartHorizontally();
            }
            else if (rbtnVertical.Checked == true)
            {
                LoadRateChartVertically();
            }
        }

        protected void LoadRateChartHorizontally()
        {
            DataTable dt = new DataTable();
            BusinessLayer.PotatoRate ObjRate = new BusinessLayer.PotatoRate();
            string StartDate = ddlMonth.SelectedValue.Trim() + "/01/" + ddlYear.SelectedValue.Trim() + " 00:00:00";
            string EndDate = ddlMonth.SelectedValue.Trim() + "/" + ReturnEndDay() + "/" + ddlYear.SelectedValue.Trim() + " 00:00:00";
            
            DataSet ds = ObjRate.GetAll(StartDate, EndDate);

            int count = 0;
            int day = 1;
            int i = 0;
            DataRow dr;
            
            foreach (DataTable table in ds.Tables)
            {
                if (count == 0)
                {
                    dt.Columns.Add("Block");
                    foreach(DataRow row in table.Rows)
                    {
                        dr = dt.NewRow();
                        dr[0] = row[0].ToString();
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    count = 1;
                }

                dt.Columns.Add(day.ToString() + "/" + ddlMonth.SelectedValue.Trim() + "/" + ddlYear.SelectedValue.Trim());
                i = 0;
                foreach (DataRow row in table.Rows)
                {
                    dt.Rows[i][dt.Columns.Count - 1]=row[1].ToString();
                    dt.AcceptChanges();
                    i += 1;
                }
                day += 1;
            }


            StringBuilder sb = new StringBuilder();
            sb.Append(@"<table cellspacing='0' rules='all' border='0' style='border-color:#1398ED;border-width:1px;border-style:Solid;width:100%;border-collapse:collapse;'>");
            sb.Append(@"<tr class='HeaderStyle'>");
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(@"<th scope='col'>" + col.ColumnName + "</th>");
            }
            sb.Append(@"</tr>");
            foreach (DataRow row in dt.Rows)
            {
               sb.Append(@"<tr class='RowStyle'>");
               for (int colindex = 0; colindex < dt.Columns.Count; colindex++)
               {
                   sb.Append(@"<td>" + row[colindex].ToString() + "</td>");
               }
               sb.Append(@"</tr>");
            }
            sb.Append(@"</table>");
            ltrChart.Text = sb.ToString();
  
        }


        protected void LoadRateChartVertically()
        {
            DataTable dt = new DataTable();
            BusinessLayer.PotatoRate ObjRate = new BusinessLayer.PotatoRate();
            string StartDate = ddlMonth.SelectedValue.Trim() + "/01/" + ddlYear.SelectedValue.Trim() + " 00:00:00";
            string EndDate = ddlMonth.SelectedValue.Trim() + "/" + ReturnEndDay() + "/" + ddlYear.SelectedValue.Trim() + " 00:00:00";

            DataSet ds = ObjRate.GetAll(StartDate, EndDate);
            DataRow dr;
            int day = 1;

            dt.Columns.Add("Date");
            for (int colcount = 0; colcount < ds.Tables.Count; colcount++)
            {
                dr = dt.NewRow();
                dr[0] = day.ToString() + "/" + ddlMonth.SelectedValue.Trim() + "/" + ddlYear.SelectedValue.Trim();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                day += 1;
            }

           
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dt.Columns.Add(row[0].ToString());
                dt.AcceptChanges();
            }

            int rowIndex =-1;
            int colIndex;
            
            foreach (DataTable table in ds.Tables)
            {
                rowIndex += 1;
                colIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    colIndex += 1;
                    dt.Rows[rowIndex][colIndex] = row[1].ToString();
                }
            }


            StringBuilder sb = new StringBuilder();
            sb.Append(@"<table cellspacing='0' rules='all' border='0' style='border-color:#1398ED;border-width:1px;border-style:Solid;width:100%;border-collapse:collapse;'>");
            sb.Append(@"<tr class='HeaderStyle'>");
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(@"<th scope='col'>" + col.ColumnName + "</th>");
            }
            sb.Append(@"</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append(@"<tr class='RowStyle'>");
                for (int colindex = 0; colindex < dt.Columns.Count; colindex++)
                {
                    sb.Append(@"<td>" + row[colindex].ToString() + "</td>");
                }
                sb.Append(@"</tr>");
            }
            sb.Append(@"</table>");
            ltrChart.Text = sb.ToString();

        }


        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            LoadRateChart();
        }

        protected int ReturnEndDay()
        {
            int month = int.Parse(ddlMonth.SelectedValue.Trim());
            int year = int.Parse(ddlYear.SelectedValue.Trim());

            int lastday=0;
            switch (month)
            {
                case 1: lastday = 31;
                    break;
                case 2: lastday = ((year % 4) == 0) ? 29 : 28;
                    break;
                case 3: lastday = 31;
                    break;
                case 4: lastday = 30;
                    break;
                case 5: lastday = 31;
                    break;
                case 6: lastday = 30;
                    break;
                case 7: lastday = 31;
                    break;
                case 8: lastday = 31;
                    break;
                case 9: lastday = 30;
                    break;
                case 10: lastday = 31;
                    break;
                case 11: lastday = 30;
                    break;
                case 12: lastday = 31;
                    break;
                    
            }

            return lastday;
        }

        protected void rbtnHorz_CheckedChanged(object sender, EventArgs e)
        {
            LoadRateChart();
        }

        protected void rbtnVertical_CheckedChanged(object sender, EventArgs e)
        {
            LoadRateChart();
        }
    }
}
