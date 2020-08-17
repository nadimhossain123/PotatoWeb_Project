using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;



namespace PBALBS
{
    public partial class Payment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MemberId"] != null && Request.QueryString["MemberId"].ToString().Trim().Length > 0 && Request.QueryString["TransactionId"] != null && Request.QueryString["TransactionId"].ToString().Trim().Length > 0)
                {
                    Entity.Payment epm = new Entity.Payment();
                    BusinessLayer.Payment bpm = new BusinessLayer.Payment();
                    epm.MemberId = Convert.ToInt32(Request.QueryString["MemberId"]);
                    epm=bpm.GetMemberDetails(epm.MemberId);
                    epm.TransactionId = Request.QueryString["TransactionId"].ToString();
                    epm.Amount = bpm.GetPaymentDetails(Convert.ToInt32(epm.TransactionId));
                    epm.MerchantKey = "LZgpuu";
                    epm.MerchantSalt = "pUrqUKy1";
                    epm.ProductInfo = "Subscription Fees";
                    epm.Hash = "";
                    epm.udf5 = "BOLT_KIT_ASP.NET";




                    //string surl = ((HttpContext.Current.Request.ServerVariables["HTTPS"] != "" && HttpContext.Current.Request.ServerVariables["HTTP_HOST"] != "off") || HttpContext.Current.Request.ServerVariables["SERVER_PORT"] == "443") ? "https://" : "http://";
                    string surl = "http://";
                    surl += HttpContext.Current.Request.ServerVariables["HTTP_HOST"] 
                        //+
                        //HttpContext.Current.Request.ServerVariables["REQUEST_URI"] 
                        + "/Response.aspx";
                    Session.Add("surl", surl);

                    Random r = new Random();
                    string txnid = "Txn" + r.Next(100, 9999);
                    Session.Add("txnid", epm.TransactionId);

                    //epm.TransactionId = txnid;
                    epm.SUrl = surl;
                    byte[] hash;
                    //string postData = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
                    //dynamic data = JsonConvert.DeserializeObject(postData);
                    string d = epm.MerchantKey + "|" + epm.TransactionId + "|" + epm.Amount + "|" + epm.ProductInfo + "|" + epm.FName + "|" + epm.Email + "|||||" + epm.udf5 + "||||||" + epm.MerchantSalt;
                    var datab = Encoding.UTF8.GetBytes(d);
                    using (SHA512 shaM = new SHA512Managed())
                    {
                        hash = shaM.ComputeHash(datab);
                    }

                    StringBuilder result = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        result=result.Append(hash[i].ToString("X2").ToLower());
                    }

                    epm.Hash = result.ToString();






                    Session.Add("FName", epm.FName);
                    Session.Add("Email", epm.Email);
                    Session.Add("Mobile", epm.Mobile);
                    Session.Add("Amount", epm.Amount);
                    Session.Add("MerchantKey", epm.MerchantKey);
                    Session.Add("MerchantSalt", epm.MerchantSalt);
                    Session.Add("ProductInfo", epm.ProductInfo);
                    Session.Add("Hash", epm.Hash);

                    //Session.Add("Hash", "7e93aacf9f953177c69bcd4e98f5065e31b302a39ee74627d410aca92de37a41a320456170fb059e37e8562308bd994013a9977297c2127ece8966c9e9b138d4");




                }
            }
        }
    }
}
