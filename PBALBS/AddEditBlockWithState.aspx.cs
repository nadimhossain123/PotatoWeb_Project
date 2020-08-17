using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class AddEditBlockWithState : System.Web.UI.Page
    {
        public int BlockWithStateId
        {
            get { return Convert.ToInt32(ViewState["BlockWithStateId"].ToString()); }
            set { ViewState["BlockWithStateId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BlockWithStateId = 0;
                LoadState();
                LoadBlockList();
            }
        }

        protected void LoadState()
        {
            BusinessLayer.State ObjState = new BusinessLayer.State();
            DataTable dt = ObjState.GetAll();
            ViewState["State"] = dt;
        }

        protected void LoadBlockList()
        {
            BusinessLayer.Block ObjBlock = new BusinessLayer.Block();
            DataTable dt = ObjBlock.GetAllBlockWithState();
            DataRow dr = dt.NewRow();
            dr["BlockWithStateId"] = "0";
            dr["StateId"] = "0";
            dr["BlockName"] = "";
            dt.Rows.InsertAt(dr, 0);

            dgvBlock.DataSource = dt;
            dgvBlock.DataBind();
        }

        protected void dgvBlock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int BlockWithStateId = Convert.ToInt32(dgvBlock.DataKeys[e.Row.RowIndex].Values["BlockWithStateId"].ToString());
                int StateId = Convert.ToInt32(dgvBlock.DataKeys[e.Row.RowIndex].Values["StateId"].ToString());
                ((LinkButton)e.Row.FindControl("lnkUpdate")).CommandArgument = e.Row.RowIndex.ToString();

                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlState");
                ddl.DataSource = (DataTable)ViewState["State"];
                ddl.DataBind();

                if (BlockWithStateId == 0)
                {
                    ((LinkButton)e.Row.FindControl("lnkUpdate")).Text = "Add";
                    ((CheckBox)e.Row.FindControl("ChkSelect")).Visible = false;

                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lnkUpdate")).Text = "Update";
                    ddl.SelectedValue = StateId.ToString();
                }
            }
        }

        protected void dgvBlock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            BlockWithStateId = Convert.ToInt32(dgvBlock.DataKeys[e.RowIndex].Values["BlockWithStateIdId"].ToString());
            BusinessLayer.Block ObjBlock = new BusinessLayer.Block();
            ObjBlock.DeleteFromBlockWithState(BlockWithStateId);
            LoadBlockList();

        }

        protected void dgvBlock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddUpdate"))
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                BlockWithStateId = Convert.ToInt32(dgvBlock.DataKeys[RowIndex].Values["BlockWithStateId"].ToString());

                BusinessLayer.Block ObjBlock = new BusinessLayer.Block();
                Entity.Block Block = new Entity.Block();
                Block.BlockId = BlockWithStateId;
                Block.StateId = int.Parse(((DropDownList)dgvBlock.Rows[RowIndex].FindControl("ddlState")).SelectedValue);
                Block.BlockName = ((TextBox)dgvBlock.Rows[RowIndex].FindControl("txtBlock")).Text;
                ObjBlock.SaveBlockWithState(Block);
                LoadBlockList();

            }
        }

        protected void btnExchange_Click(object sender, EventArgs e)
        {
            int[] arr = new int[2];
            int i = 0;
            foreach (GridViewRow row in dgvBlock.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)row.FindControl("ChkSelect");
                    if (chk.Checked == true)
                    {
                        arr[i] = int.Parse(dgvBlock.DataKeys[row.RowIndex].Value.ToString());
                        i += 1;
                    }

                }
            }

            BusinessLayer.Block ObjBlock = new BusinessLayer.Block();
            ObjBlock.Exchange_BlockWithState(arr[0], arr[1]);
            LoadBlockList();
        }
    }
}