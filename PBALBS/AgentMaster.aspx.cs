using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class AgentMaster : System.Web.UI.Page
    {
        public int AgentId
        {
            get { return Convert.ToInt32(ViewState["AgentId"]); }
            set { ViewState["AgentId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim().Length > 0)
                {
                    AgentId = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
                    PopulateAgentMaster();
                }

                LoadAgent();
            }
        }


        protected void PopulateAgentMaster()
        {
            BusinessLayer.AgentMaster objAgentMaster = new BusinessLayer.AgentMaster();
            Entity.AgentMaster agentMaster = new Entity.AgentMaster();
            agentMaster = objAgentMaster.GetAgentMasterById(AgentId);
            if (agentMaster != null)
            {
                AgentId = agentMaster.AgentId;
                txtName.Text = agentMaster.Name.ToString();
                txtEmail.Text = agentMaster.Email.ToString();
                txtContactNo.Text = agentMaster.ContactNo.ToString();
                txtPassword.Text = agentMaster.Password.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BusinessLayer.AgentMaster objAgentMaster = new BusinessLayer.AgentMaster();
            Entity.AgentMaster agentMaster = new Entity.AgentMaster();
            agentMaster.AgentId = AgentId;
            agentMaster.Name = txtName.Text.Trim();
            agentMaster.Email = txtEmail.Text.Trim();
            agentMaster.ContactNo = txtContactNo.Text.Trim();
            agentMaster.Password = txtPassword.Text.Trim();
            objAgentMaster.Save(agentMaster);
            LoadAgent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgentMasterInfo.aspx");
        }

        protected void LoadAgent()
        {
            BusinessLayer.AgentMaster objAgent = new BusinessLayer.AgentMaster();
            DataTable dt = objAgent.GetAll();
            if (dt != null)
            {
                dgvAgent.DataSource = dt;
                dgvAgent.DataBind();
            }
        }

        protected void dgvAgent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int AgentId = Convert.ToInt32(dgvAgent.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("AgentMaster.aspx?id=" + AgentId);
        }

        protected void dgvAgent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvAgent.PageIndex = e.NewPageIndex;
            LoadAgent();
        }

        protected void dgvAgent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int AgentId = Convert.ToInt32(dgvAgent.DataKeys[e.RowIndex].Value);
            BusinessLayer.AgentMaster objAgent = new BusinessLayer.AgentMaster();
            objAgent.Delete(AgentId);
            LoadAgent();
        }
    }
}