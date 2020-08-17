using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class AddEditState : System.Web.UI.Page
    {
        public int StateId
        {
            get { return Convert.ToInt32(ViewState["StateId"].ToString()); }
            set { ViewState["StateId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                StateId = 0;
                LoadStateList();
            }
        }

        protected void LoadStateList()
        {
            BusinessLayer.State ObjState = new BusinessLayer.State();
            DataTable dt = ObjState.GetAll();
            DataRow dr = dt.NewRow();
            dr["StateId"] = "0";
            dr["StateName"] = "";
            dt.Rows.InsertAt(dr, 0);
            dt.AcceptChanges();

            dgvState.DataSource = dt;
            dgvState.DataBind();
        }

        protected void dgvState_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkUpdate")).CommandArgument = e.Row.RowIndex.ToString();


                string ID = dgvState.DataKeys[e.Row.RowIndex].Value.ToString();
                if (int.Parse(ID) == 0)
                {
                    ((LinkButton)e.Row.FindControl("lnkUpdate")).Text = "Add";

                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lnkUpdate")).Text = "Update";

                }

            }
        }

        protected void dgvState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            StateId = Convert.ToInt32(dgvState.DataKeys[e.RowIndex].Value.ToString());
            BusinessLayer.State ObjState = new BusinessLayer.State();
            ObjState.Delete(StateId);
            LoadStateList();
        }

        protected void dgvState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddUpdate"))
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                StateId = Convert.ToInt32(dgvState.DataKeys[RowIndex].Value.ToString());
                BusinessLayer.State ObjState = new BusinessLayer.State();
                Entity.State State = new Entity.State();
                State.StateId = StateId;
                State.StateName = ((TextBox)dgvState.Rows[RowIndex].FindControl("txtState")).Text;
                ObjState.Save(State);
                LoadStateList();

            }
        }
    }
}