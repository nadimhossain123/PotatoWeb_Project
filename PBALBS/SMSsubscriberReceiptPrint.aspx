<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="SMSsubscriberReceiptPrint.aspx.cs" Inherits="PBALBS.SMSsubscriberReceiptPrint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


    
     <div class="ticket" id="myDiv" style="margin-left:700px;margin-right:0px;" >
         <table class="centered" style="width:250px"><tr><td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/logo.jpg" alt="App Logo" class="centered"/><br />
            <h2 class="centered" > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;P.B.P.A.B.S  </h2>
                <p><b>Daily Potato Market Rate<br/>
                           &
                   Monthly Loaing-Unloading Report</b><br/>
                </p>
               <p>Received with thanks from <br /><asp:label id="lblName" runat="server" ></asp:label><br/>
                  (M):<asp:label id="lblMobile" runat="server" ></asp:label>&nbsp;&nbsp; Unit:<asp:label id="lblUnit" runat="server" ></asp:label><br />
                   Dist:<asp:label id="lblDistrict" runat="server" ></asp:label><br/>
                   the Membership Charge of Rs. <asp:label id="lblAmount" runat="server" ></asp:label><br/>
                   for (1)Daily Market Price<br />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(2)All India Market rate & Loading-Unloading Report<br />
                   up to <asp:label id="lblYear" runat="server" ></asp:label>

                </p>
            
            <p class="centered">Helpline:95631 53631 (10 am-6 pm)
                <br/>Download-PBPABS Notification App
                <br /><img src="../images/PlayStoreLogo.jpg" alt="PlayStore Logo" class="centered"/></p>
            </td> </tr>
         </table>

            <input type="button" value="Print" onclick="window.print();"/>
        
        </div>
       
       <%-- <button id="btnPrint" class="hidden-print">Print</button>
        <script src="script.js"></script>--%>
         

