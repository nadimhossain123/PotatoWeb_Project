<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true"
    Inherits="admin_addeditemployee" CodeBehind="addeditemployee.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function Validation() {
            var text = document.getElementById('<%=btnSave.ClientID %>').value;
            if (text == 'Save')
                return AccountDetailValidation();
            else
                return BasicDetailValidation();
        }

        function AccountDetailValidation() {
            if (document.getElementById('<%=txtEmail.ClientID %>').value == '')
                return ShowMsg("Enter Username");
            else if (document.getElementById('<%=txtPassword.ClientID %>').value == '')
                return ShowMsg("Enter Password");
            else if (document.getElementById('<%=txtPassword.ClientID %>').value != document.getElementById('<%=txtConfirmPassword.ClientID %>').value)
                return ShowMsg("Password Do Not Match");
            else
                return BasicDetailValidation();
        }

        function BasicDetailValidation() {
            if (document.getElementById('<%=txtFName.ClientID %>').value == '')
                return ShowMsg("Enter First Name");
            else if (document.getElementById('<%=txtLName.ClientID %>').value == '')
                return ShowMsg("Enter Last Name");
            else if (document.getElementById('<%=txtContactNo.ClientID %>').value == '')
                return ShowMsg("Enter Contact Number");
            else
                return true;
        }

        function ShowMsg(str) {
            alert(str);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="Script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <table width="100%" align="center">
                <tr>
                    <td align="center">
                        <div style="width: 700px;" align="center">
                            <br />
                            <asp:Literal ID="ltrMsg" runat="server" Mode="PassThrough"></asp:Literal>
                            <br />
                            <fieldset id="BoxAccountDetails" runat="server">
                                <legend><b>Account Details</b></legend>
                                <br />
                                <table width="100%" cellpadding="0" cellspacing="5">
                                    <tr>
                                        <td width="25%" class="label">
                                            Username :<span class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="260px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            Password :<span class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="260px" TextMode="Password"
                                                MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            Confirm Password :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="textbox" Width="260px"
                                                TextMode="Password" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </fieldset>
                            <br />
                            <br />
                            <fieldset id="BoxBasicDetails" runat="server">
                                <legend><b>Basic Details</b></legend>
                                <br />
                                <table width="100%" cellpadding="0" cellspacing="5">
                                    <tr>
                                        <td width="25%" class="label">
                                            First Name :<span class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFName" runat="server" CssClass="textbox" Width="260px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            Last Name :<span class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLName" runat="server" CssClass="textbox" Width="260px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            Contact No :<span class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="textbox" Width="260px" MaxLength="13"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            Role :<span class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="dropdown" Width="265px">
                                                <asp:ListItem Value="0" Text="--SELECT--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Admin"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Management"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Agent"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            Active :
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkIsActive" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </fieldset>
                            <br />
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="25%">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClientClick="return Validation();"
                                            OnClick="btnSave_Click" Width="120px" />&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Reset" OnClick="btnCancel_Click"
                                            Width="120px" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
