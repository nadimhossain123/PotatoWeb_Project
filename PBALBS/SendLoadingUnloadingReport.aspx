<%@ Page Title="SendLoadingUnloadingReport" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SendLoadingUnloadingReport.aspx.cs" Inherits="PBALBS.SendLoadingUnloadingReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Validation() {
            if (document.getElementById('<%=txtMsg.ClientID %>').value == '') {
                alert('Message Body is Blank'); return false;
            }
            else if (document.getElementById('<%=Hidden1.ClientID %>').value == '1') {
                return confirm('Message has been sent for today. Do you want to send it again?');
            }
            else {
                return confirm('Are You Sure?');
            }
        }

        function Preview(textarea) {
            document.getElementById('<%=txtMsgPreview.ClientID %>').value = textarea.value;
        }


        function EnableButton() {
            var locked = document.getElementById('<%=Hidden1.ClientID %>').value;
            if (locked == "1") {
                var mobile = document.getElementById('<%=txtMobNo.ClientID %>').value.trim();
                if (mobile.length > 0)
                    document.getElementById('<%=btnSendSMS.ClientID %>').style.display = 'block';
                else
                    document.getElementById('<%=btnSendSMS.ClientID %>').style.display = 'none';
            }
        }
        function Count() {

            var str = document.getElementById('<%=txtMsg.ClientID %>').value;
            var n = str.length + (str.match(new RegExp("\n", "g")) || []).length;
            if (n < 159) {
                var z = 1
            }
            else if (n < 304) {
                var z = 2
            }
            else if (n < 450) {
                var z = 3
            }
            else if (n < 608) {
                var z = 4
            }
            document.getElementById('<%=lblCharacter.ClientID %>').value = n;

            document.getElementById('<%=txtCredit.ClientID %>').value = z;
        }
   
        document.onmousedown = disableclick;
        status = "Right Click Disabled";
        function disableclick(event) {
            if (event.button == 2) {
                alert(status);
                return false;
            }
        }
    </script>
    
    <style type="text/css">
        .style1
        {
            width: 60%;
            border-style: ridge;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="Hidden1" runat="server" />
    <table width="80%" align="center">
        <tr>
            <td align="center">
                <asp:Literal ID="ltrMsg" runat="server" Mode="PassThrough"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="80%" align="left">
                    <tr>
                        
                        <td align="left" width="10%">
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="dropdown">
                                <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                <asp:ListItem Value="9" Text="Sep"></asp:ListItem>
                                <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left" width="10%">
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="dropdown">
                                <asp:ListItem Value="2012" Text="2012"></asp:ListItem>
                                <asp:ListItem Value="2013" Text="2013"></asp:ListItem>
                                <asp:ListItem Value="2014" Text="2014"></asp:ListItem>
                                <asp:ListItem Value="2015" Text="2015"></asp:ListItem>
                                <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
                                <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
                                <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                                <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="10%" align="left">
                            <asp:Button ID="btnGetMsg" runat="server" CssClass="button" Text="Get Message" OnClick="btnGetMsg_Click" />
                        </td>
                        <td width="40%" align="right" >
                           <b>SMS Balance:</b> <strong>
                                <asp:Label ID="lblBalance" runat="server"></asp:Label></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="80%" align="center">
        <tr>
            <td align="left" class="label" colspan="2">
                Enter Mobile Numbers:<br />
                (Keep this field blank to fetch mobile numbers from database)
            </td>
        </tr>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <tr>
            <td align="left">
                <asp:TextBox ID="txtMobNo" runat="server" CssClass="textbox" onkeyup="EnableButton();"
                    Width="550px" Height="120px" TextMode="MultiLine"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtMobNo"
                    FilterType="Custom" ValidChars="0123456789,">
                </asp:FilteredTextBoxExtender>
            </td>
            <td align="left" class="Preview" width="40%">
                <h3>
                    SMS Credit Slab</h3>
                <table class="style1">
                    <tr>
                        <td>
                            0 - 158
                        </td>
                        <td>
                            1 Credit
                        </td>
                    </tr>
                    <tr>
                        <td>
                            159 - 303
                        </td>
                        <td>
                            2 Credit
                        </td>
                    </tr>
                    <tr>
                        <td>
                            304 - 449
                        </td>
                        <td>
                            3 Credit
                        </td>
                    </tr>
                    <tr>
                        <td>
                            450 - 607
                        </td>
                        <td>
                            4 Credit
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" class="label" colspan="2">
                Message Body:
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <table width="100%" align="center">
                    <tr>
                        <td align="left" width="60%">
                            <asp:TextBox ID="txtMsg" runat="server" CssClass="textbox" Width="550px" Height="160px"
                                TextMode="MultiLine" onkeyup="Preview(this); return Count();" ></asp:TextBox>
                        </td>
                        <td align="left" class="Preview" width="40%">
                            <asp:TextBox ID="txtMsgPreview" runat="server" CssClass="textbox" TextMode="MultiLine"
                                Height="60px" Width="162px" ReadOnly="true">
                            </asp:TextBox>
                            <br />
                            Character:
                            <%-- <asp:Label ID="lblCharacter" runat="server"></asp:Label>--%>
                            <asp:TextBox ID="lblCharacter" runat="server" BackColor="#E5E5E5" BorderStyle="None"
                                Font-Bold="True"></asp:TextBox><br />
                                Credit:
                            <asp:TextBox ID="txtCredit" runat="server"  BackColor="#E5E5E5" BorderStyle="None"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" class="label" colspan="2">
                No Of Members at a time
                <asp:DropDownList ID="ddlNoOfMember" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="50" Text="50"></asp:ListItem>
                    <asp:ListItem Value="40" Text="40"></asp:ListItem>
                    <asp:ListItem Value="30" Text="30"></asp:ListItem>
                    <asp:ListItem Value="20" Text="20"></asp:ListItem>
                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                Unlocked Button
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" />
                <br />
                <br />
                <asp:Button ID="btnSendSMS" runat="server" CssClass="button" Text="Send SMS" OnClientClick="javascript:return Validation();"
                    OnClick="btnSendSMS_Click" />
                 <br />
                <asp:Button ID="btnSendNotification" runat="server" CssClass="button" Text="Send Notification" OnClick="btnSendNotification_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
