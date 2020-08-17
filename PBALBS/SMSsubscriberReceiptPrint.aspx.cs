using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PBALBS
{
    public partial class SMSsubscriberReceiptPrint : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = "<u>Nadim Hossain Molla</u>";
            lblMobile.Text = "<u>9083731946</u>";
            lblUnit.Text = "<u>Unit1</u>";
            lblDistrict.Text = "<u>South 24 Parganas</u>";
            lblAmount.Text = "<u>100/-</u>";
            lblYear.Text = "<u>2020</u>";
        }

        
    }
}