<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="PBALBS.Response" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            font-family: Calibri;
            font-size: 14px;
        }

        .style1 {
            width: 100%;
        }

        .style2 {
            width: 100%;
            font-family: Verdana;
            font-size: 13px;
        }

        .style4 {
            font-size: x-large;
        }

        .style5 {
            font-size: large;
        }

        .auto-style1 {
            width: 269px;
        }
    </style>
</head>
<body <%--onload="window.print()" style="cursor: pointer; width: 700px" onclick="window.print()"--%>>
    <form id="form1" runat="server">
        <div align="center" style="width: 700px; padding: 10px; margin-left: auto; margin-right: auto; border: solid 1px #000;">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <table class="style1">
                            <tr>
                                <td width="25%" align="center">
                                    
                                </td>
                                <td align="center" width="50%">
                                    <img alt="" width="100px" src="../images/logo.jpg" /><br />
                                    <strong><span class="style4">PASCHIM BANGA PRAGATISHIL ALU BYABASAYEE SAMITY</span></strong><br />
                                    <label>
                                       </label><br />
                                </td>
                                <td width="25%"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4" align="center">
                        <h2 style="color:blue">Subscription Payment Reciept<br />
                            <br />
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <b>Member Name: </b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblMemberName" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <b>Mobile No: </b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                    </td>
                   
                </tr>
                <%--<tr>
                    
                </tr>--%>
                <tr>
                    <td align="left">
                        <b>Transaction No: </b>
                    </td>
                    <td  align="left">
                        <asp:Label ID="lblTransactionNo" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <b>Email: </b>
                    </td>
                    <td  align="left">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td align="left">
                        <b>Payment Date: </b>
                    </td>
                    <td  align="left">
                        <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
                    </td>
                     <td  align="left">
                        <b>Financial Year</b>
                    </td>
                    <td  align="left">
                        <asp:Label ID="lblFinancialYear" runat="server"></asp:Label>
                    </td>
                </tr>
                
               

                <%--<tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>--%>
            </table>
            <table class="style1" style="border: solid; border-color: black;">
                <tr style="border-bottom: thin">
                    <td>
                        <asp:GridView ID="dgvFeeHead" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-hover"
                            GridLines="None" DataKeyNames="SubscriptionCategoryId">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subscription">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubscriptionCategoryName" runat="server" Text='<%# Bind("SubscriptionCategoryName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Discount Ammount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscountAmount" runat="server" Text='<%# Bind("DiscountAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                               <%-- <asp:TemplateField HeaderText="Actual Payable Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActualAmount" runat="server" Text='<%# Bind("PayableAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <EmptyDataTemplate>
                                <p>No Data Found</p>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="HeaderStyle" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <table class="style1" style="border: solid; border-color: black;">
                <tr style="border-bottom: thin">
                    <%--<td align="left" width="50%">

                        <b>Subscription Details </b>
                    </td>
                    <td align="left">

                        <b>Amount </b>
                    </td>--%>
                </tr>
                <tr style="border-bottom: thin">
                    <td align="left">Total Subscription Amount*
                    </td>
                    <td align="left">
                        <b><asp:Label ID="lblTotalFees" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <td align="left">Total Amount in Words:
                    </td>
                    <td align="left">
                        <b><asp:Label ID="lblTotalAmountInWord" runat="server"></asp:Label></b>
                    </td>
                </tr>
            </table>
            <table width="100%">

                <tr>
                    <td colspan="4">
                        <hr />
                        <br />
                        <br />

                    </td>
                </tr>

                <%--<tr>
                    <td align="left">This payment acknowledgement receipt has to be submitted 
                 to the college at the time of document verification along with the other documents.<br />
                        <br />
                    </td>
                </tr>--%>

                <%--<tr>
                    <td align="left">Date : <b>
                        <asp:Label ID="lblDate" runat="server"></asp:Label></b></br>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left">Time : <b>
                        <asp:Label ID="lblTime" runat="server"></asp:Label></b></br>
                    </td>
                </tr>
                <tr>
                    <td align="center">THIS IS SYSTEM GENERATED STATEMENT. HENCE DOES NOT REQUIRE SIGNATURE.
                    </td>
                </tr>--%>
                <tr>
                    <td>
                    <p >
                    <br />
                    <span style="color:red" ><b>শর্তাবলী</b></span><br />
                    ১ ) SMS পরিষেবা ১ লা মার্চ থেকে ২৪ শে ডিসেম্বর পর্যন্ত চালু থাকবে ।<br />
                    ২) সমস্ত রবিবার , ছুটির দিন এবং বেশীর ভাগ কোল্ড স্টোরেজ বন্ধ থাকার সময় পরিষেবা বন্ধ থাকে ।<br />
                    ৩) বিশেষ কারণে সরকারী / রাজ্য কমিটির নির্দেশ থাকলে পরিষেবা সাময়িক ভাবে বন্ধ থাকবে ।<br />
                    ৪) প্রতিদিন রাত ৮ টা থেকে ১০ টার মধ্যে বাজার দরের SMS দেওয়া হয় এবং মান্থলি লােডিং - আনলােডিং রিপাের্ট মাসের শেষে দেওয়া হয় ।<br />
                    ৫ ) আপনার মােবাইল নম্বর বন্ধ অথবা পরিবর্তন করলে অবশ্যই আমাদের জানাতে হবে এবং পরিষেবা বন্ধ করতে চাইলে জানুয়ারী মাসে জানিয়ে দিতে হবে । অন্যথায় নির্দিষ্ট গ্রাহক মূল্য প্রদান করতে হবে ।<br />
                    ৬ ) গ্রাহক মূল্য প্রতি বছর ২০ শে ফেব্রুয়ারীর মধ্যে , পরিষেবা শুরুর পূর্বে জমা করে পরিষেবা সচল রাখতে সহযােগিতা করুন ।<br />
                    ৭ ) SMS প্রদত্ত Approx বাজার দর বা Approx লােডিং - আনলােডিং রিপাের্ট ব্যবসার নির্ধারক নয় । ব্যবসায়িক পদক্ষেপের পূর্বে নির্দিষ্ট স্থানের বাজার দর ও তথ্য যাচাই করুন ।<br />
                    ৮ ) রাজ্য কমিটির অনুমতি সাপেক্ষে SMS- এর তারিখ , গ্রাহক মূল্য এবং বাজার দর ও রিপাের্ট ( Approx ) নির্ধারিত ।<br />
                    
                </p>
                 </td>
                </tr>
            </table>
        </div>
    </form>
    <div >
        <input type="button" value="Save" onclick="window.print();" style="position:center" />
    </div>
</body>

    
</html>


