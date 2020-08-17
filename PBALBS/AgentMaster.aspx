<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="AgentMaster.aspx.cs" Inherits="PBALBS.AgentMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     function Validation() {
         if (document.getElementById('<%=txtName.ClientID %>').value == '')
             return ShowMsg("Enter Name");
         else if (document.getElementById('<%=txtEmail.ClientID %>').value == '')
             return ShowMsg("Enter Email");
         else if (document.getElementById('<%=txtPassword.ClientID %>').value == '')
             return ShowMsg("Enter Password");
         else
             return true;
     }

     function ShowMsg(str) {
         alert(str);
         return false;
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table width="60%" align="center" style="border:2px solid black; padding:10px; background:white">
        <tr>
            <td colspan="4" style="text-align: center">
                <h1>
                    Add New Agent</h1>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="30px">
                Name<span style="color: Red">*</span> &nbsp;&nbsp;&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="txtName" runat="server" Height="20px" TabIndex="1" MaxLength="50"
                    Width="250px"></asp:TextBox>
            </td>
            <td align="right" height="30px">
                Email<span style="color: Red">*</span> &nbsp;&nbsp;&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmail" runat="server" Height="20px" TabIndex="2" MaxLength="100"
                    Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" height="30px">
                ContactNo &nbsp;&nbsp;&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="txtContactNo" runat="server" Height="20px" TabIndex="3" MaxLength="50"
                    Width="250px"></asp:TextBox>
            </td>
            <td align="right" height="30px">
                Password<span style="color: Red">*</span> &nbsp;&nbsp;&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="txtPassword" runat="server" Height="20px" TabIndex="4" MaxLength="50"
                    Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="button" OnClientClick="return Validation();"
                    Text="Save" Width="80px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                    CssClass="button" CausesValidation="false" Width="80px" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="dgvAgent" runat="server" Width="60%" align="center" AutoGenerateColumns="False"
        DataKeyNames="AgentId" OnRowDeleting="dgvAgent_RowDeleting" OnRowEditing="dgvAgent_RowEditing"
        CellPadding="4" GridLines="None" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
            <asp:BoundField DataField="Password" HeaderText="Password" />
            <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="edit_icon.gif" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="delete_icon.gif" />
        </Columns>
        <HeaderStyle CssClass="HeaderStyle" />
        <RowStyle CssClass="RowStyle" />
        <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>
</asp:Content>
