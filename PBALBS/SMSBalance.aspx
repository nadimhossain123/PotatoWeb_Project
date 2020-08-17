<%@ Page Title="SMS Balance" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="SMSBalance.aspx.cs" Inherits="PBALBS.SMSBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="60%" align="center" style="border:2px solid black; padding:10px; background:white">
        <tr>
            <td colspan="2" style="text-align: center">
                <h1>
                    SMS Balance</h1>
            </td>
        </tr>
        <tr>
            <td>
                Balance
            </td>
            <td>
                <asp:TextBox ID="txtBalance" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Expense Balance
            </td>
            <td>
                <asp:TextBox ID="txtExpanceBalance" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Available Balance
            </td>
            <td>
                <asp:Label ID="lblAvailable" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
