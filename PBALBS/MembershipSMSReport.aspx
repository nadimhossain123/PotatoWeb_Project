<%@ Page Title="Membership SMS Report" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MembershipSMSReport.aspx.cs" Inherits="PBALBS.MembershipSMSReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <table width="70%" align="center">
                <tr id="provider" runat="server">
                    <td align="left">
                        <asp:RadioButtonList ID="rbtnProvider" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="rbtnProvider_SelectedIndexChanged" CssClass="label" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Mvayoo" Text="Mvayoo"></asp:ListItem>
                            <asp:ListItem Value="ACL" Text="ACL"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:GridView ID="dgvTrigger" runat="server" AllowPaging="false"
                            AutoGenerateColumns="false" Width="100%"
                            DataKeyNames="SMSTriggerId" CellSpacing="2" GridLines="None"
                            OnRowDataBound="dgvTrigger_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltrSl" runat="server" Mode="PassThrough"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                <asp:BoundField DataField="TriggerDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="TriggerDate" HeaderText="Time" DataFormatString="{0:hh:mm tt}" />
                                <asp:BoundField DataField="NoOfTrigger" HeaderText="No" />
                                <asp:BoundField DataField="CharCount" HeaderText="Character" />
                            </Columns>
                            <HeaderStyle CssClass="HeaderStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />

                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
