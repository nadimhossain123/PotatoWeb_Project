<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PBALBS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Control.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="60%" align="center">
            <tbody>
                <tr>
                    <td align="center">
                        &nbsp;&nbsp;
                        <asp:Login ID="LoginStatus1" runat="server" BorderColor="#777777" BorderWidth="1px"
                            Height="148px" RememberMeText="Remember me next time." LoginButtonStyle-CssClass="button"
                            TextBoxStyle-CssClass="textbox" LabelStyle-CssClass="label" CheckBoxStyle-CssClass="label"
                            TitleTextStyle-CssClass="label" Width="356px" OnAuthenticate="LoginStatus1_Authenticate">
                            <CheckBoxStyle CssClass="label"></CheckBoxStyle>
                            <TextBoxStyle CssClass="textbox"></TextBoxStyle>
                            <LayoutTemplate>
                                <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                    <tr>
                                        <td>
                                            <table cellpadding="0" style="height: 148px; width: 356px;">
                                                <tr>
                                                    <td align="center" class="label" colspan="2">
                                                       <h4> Log In</h>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="label">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="label">
                                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="UserName" runat="server" CssClass="textbox" Width="195px" placeholder="Username"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                            ToolTip="User Name is required." ValidationGroup="LoginStatus1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="label">
                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"  placeholder="Password">Password:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="Password" runat="server" CssClass="textbox" TextMode="Password"  Width="195px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginStatus1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label" colspan="2">
                                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="color: Red;">
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="button"
                                                            Text="Log In" ValidationGroup="LoginStatus1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <LoginButtonStyle CssClass="button"></LoginButtonStyle>
                            <LabelStyle CssClass="label"></LabelStyle>
                            <TitleTextStyle CssClass="label"></TitleTextStyle>
                        </asp:Login>
                        <br />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
