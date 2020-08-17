<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PBALBS.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Validation() {
            if (document.getElementById('<%=txtUserName.ClientID %>').value == '') {
                alert('Username ?');
                return false;
            }
            else if (document.getElementById('<%=txtPassword.ClientID %>').value == '') {
                alert('Password ?');
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login-wrapper" class="clearfix" style="margin-top: -127px; top: 50%; position: absolute;
        margin-left: -248px; left: 50%;">
        <div class="main-col">
            <img src="assets/img/login.png" alt="" class="logo_img" />
            <div class="panel">
                <p class="heading_main">
                    Account Login</p>
                <label for="login_name">
                    Login</label>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="login-textbox" Width="260px"></asp:TextBox>
                <label for="login_password">
                    Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="login-textbox" TextMode="Password"
                    Width="260px"></asp:TextBox>
                <div class="submit_sect">
                    <asp:Button ID="btnLogIn" runat="server" CssClass="btn btn-beoro-3" Text="Sign In"
                        OnClick="btnLogIn_Click" OnClientClick="return Validation();" Width="270px" />
                </div>
            </div>
        </div>
        <div class="login_links">
            <asp:Label ID="lblUser" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
