using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace PBALBS
{
    public partial class Response : System.Web.UI.Page
    {
      
            protected void Page_Load(object sender, EventArgs e)
            {
                
                //Response.Write("<h2>PBALBS Subscription Fees Payment Response</h2>");
                //Response.Write("Key: " + Request.Form["key"] + "<br />");
                //Response.Write("Salt: " + Request.Form["salt"] + "<br />");
                //Response.Write("Txnid: " + Request.Form["txnid"] + "<br />");
               // Response.Write("Txnid: " + Request.Form["txnid"] + "<br />");
                //Response.Write("Amount: " + Request.Form["amount"] + "<br />");
                //Response.Write("Product Info: " + Request.Form["productinfo"] + "<br />");
                //Response.Write("First Name: " + Request.Form["firstname"] + "<br />");
                //Response.Write("Email: " + Request.Form["email"] + "<br />");
                //Response.Write("Myhpayid: " + Request.Form["mihpayid"] + "<br />");
                //Response.Write("Status: " + Request.Form["status"] + "<br />");
                //Response.Write("UDF5: " + Request.Form["udf5"] + "<br />");
                //Response.Write("Hash: " + Request.Form["hash"] + "<br />");




            BusinessLayer.Payment bpm = new BusinessLayer.Payment();
            if (Request.Form["status"] == "success")
            {
                bpm.PaymentSuccess(Convert.ToInt32(Request.Form["txnid"]));
                DataTable Dt = bpm.SubscriptionDetails_GetByTransactionId(Convert.ToInt32(Request.Form["txnid"]));

                //bpm.PaymentSuccess(32);
                //DataTable Dt = bpm.SubscriptionDetails_GetByTransactionId(32);


                dgvFeeHead.DataSource = Dt;
                dgvFeeHead.DataBind();



                lblMemberName.Text = Dt.Rows[0]["MemberName"].ToString();
                lblMobileNo.Text = Dt.Rows[0]["MobileNo"].ToString();
                lblMemberName.Text = Dt.Rows[0]["MemberName"].ToString();
                lblEmail.Text = Request.Form["email"].ToString();
                lblTransactionNo.Text = Dt.Rows[0]["TransactionId"].ToString();
                lblPaymentDate.Text = Dt.Rows[0]["TransactionDate"].ToString();
                lblFinancialYear.Text = Dt.Rows[0]["FinancialYear"].ToString();
                lblTotalFees.Text = Dt.Rows[0]["TotalAmount"].ToString();
                lblTotalAmountInWord.Text = GenerateWordsinRs(Dt.Rows[0]["TotalAmount"].ToString());







               // Response.Write("Save this page as pdf or take a screenshot for proof of your payment: " + "");
            }
            else
            {
                bpm.PaymentFailure(Convert.ToInt32(Request.Form["txnid"]));
               

            }




            }



        private string GenerateWordsinRs(string txtNumber)
        {
            
            decimal numberrs = Convert.ToDecimal(txtNumber);
            CultureInfo ci = new CultureInfo("en-IN");
            string aaa = String.Format("{0:#,##0.##}", numberrs);
            aaa = aaa + " " + ci.NumberFormat.CurrencySymbol.ToString();
            //label6.Text = aaa;


            string input = txtNumber;
            string a = "";
            string b = "";

            // take decimal part of input. convert it to word. add it at the end of method.
            string decimals = "";

            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".") + 1);
                // remove decimal part from input
                input = input.Remove(input.IndexOf("."));

            }
            BusinessLayer.NUMBERSTOWORDS obj = new BusinessLayer.NUMBERSTOWORDS();

            string strWords = obj.NumbersToWords(Convert.ToInt32(input));

            if (!txtNumber.Contains("."))
            {
                a = strWords + " Rupees Only";
            }
            else
            {
                a = strWords + " Rupees";
            }

            if (decimals.Length > 0)
            {
                // if there is any decimal part convert it to words and add it to strWords.
                string strwords2 = obj.NumbersToWords(Convert.ToInt32(decimals));
                b = " and " + strwords2 + " Paisa Only ";
            }

            string Result = a + b;
            return Result;
        }
        //NUMBERTOWORDS.NumbersToWords(Convert.ToInt32(input)); //NUMBERTOWORDS IS A CLASS




    }
}
