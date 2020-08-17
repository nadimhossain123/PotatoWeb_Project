using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;




namespace PBALBS
{
    public partial class Circular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {

               

                GetCurrentCircular();

            }

        }

        private void GetCurrentCircular()
        {
            BusinessLayer.Circular objCircular = new BusinessLayer.Circular();
            DataTable DT = objCircular.GetCurrentCircular();
            grdViewCircular.DataSource = DT;
            grdViewCircular.DataBind();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string circular = txtCircular.Content.Trim().Replace("'", "''");
            int result;

            BusinessLayer.Circular ObjCircular = new BusinessLayer.Circular();
            result=ObjCircular.Save(circular);

            if(result>0)
            {
                lblMsg.Text = "Circular saved successfully";
            } 
            else
            {
                lblMsg.Text = "Circular can not besaved.Try again later..";
            }

            GetCurrentCircular();







        }




        protected void btnSendNotification_Click(object sender, EventArgs e)
        {
            BusinessLayer.Member ObjMember = new BusinessLayer.Member();
            DataTable dtMembers = ObjMember.getMembersForNotification();
            //int maxNoOfNotification = Convert.ToInt32(BusinessLayer.Common.GetScalarValue("KeyValue", "KeyValueConfig", "KeyCode", "NOOFNOTIFICATION"));
            string ImageUrl = "http://api.wbpoultryfederation.org/Images/PBALBS_LargeIcon.jpg";

            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";


            request.Headers.Add("authorization", "Basic ZGYyY2VlNGYtZDQ5MC00YTIwLWE3YzEtNDdlYTRlZmI3MDBk");

            byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                    + "\"app_id\": \"03b78b0e-44da-4221-ae8c-31003fbc8a6e\","
                                                    + "\"large_icon\" : \" " + ImageUrl + " \", "
                                                    + "\"data\": {\"NotificationType\": \"Circular\"},"
                                                    + "\"contents\": {\"en\": \"PBPABS new Circular/Message published.Please Login to APP and Check in Circular section!!\"},"
                                                    + "\"included_segments\": [\"All\"]}");


            //request.Headers.Add("authorization", "Basic ZGYyY2VlNGYtZDQ5MC00YTIwLWE3YzEtNDdlYTRlZmI3MDBk");

            //byte[] byteArray = Encoding.UTF8.GetBytes("{"
            //                                        + "\"app_id\": \"03b78b0e-44da-4221-ae8c-31003fbc8a6e\","
            //                                        + "\"contents\": {\"en\": \"PBPABS Potato rate published for " + member["Today"].ToString() + ". Please Login to APP and Check!!\"},"
            //                                        + "\"include_player_ids\": [\"" + member["DeviceId"].ToString() + "\"]}");//PlayerId is DeviceID


            string responseContent = null;
            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }

            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }
            lblMsg.Text = "Notification has been sent successfuly..";
        }


    }
}