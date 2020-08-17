<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="ApiConfiguration.aspx.cs" Inherits="PBALBS.ApiConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
        <fieldset id="ApiConfiguration" runat="server">
        <legend><b>Api Configuration</b></legend>
            <table width="70%" align="center">
                <asp:Label ID="lblMsg" runat="server" ForeColor="#009933"></asp:Label>
                <tr>
                    <td align="center">
                        <asp:RadioButtonList ID="rblApiConfig" runat="server" RepeatDirection="Vertical">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td width="10%" align="center">
                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="UPDATE" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
