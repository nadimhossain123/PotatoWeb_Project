<%@ Page Title="Subscription List" Language="C#" MasterPageFile="~/Master.Master"
    AutoEventWireup="true" CodeBehind="SubscriptionList.aspx.cs" Inherits="PBALBS.SubscriptionList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Req
        {
            color: Red;
            font-weight: bold;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
    <table width="100%" align="center">
        <tr>
            <td align="left" class="label" width="10%">
                Member Name
            </td>
            <td align="left" class="label" width="10%">
                Reference
            </td>
            <td align="left" class="label" width="10%">
                District
            </td>
            <td align="left" class="label" width="10%">
                Block
            </td>
            <td align="left" class="label" width="10%">
                Mobile No
            </td>
            <td align="left" class="label" width="15%">
                Expiration(DD/MM/YYYY)
            </td>
            <td align="left" class="label" width="5%">
                Amt
            </td>
            <td align="left" class="label" width="10%">
            </td>
            <td align="left" class="label" width="7%">
            </td>
            <td align="left" class="label" width="18%">
            </td>
        </tr>
        <tr>
            <td align="left" class="label" width="10%">
                <asp:TextBox ID="txtMemberName" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
            </td>
            <td align="left" class="label" width="10%">
                <asp:TextBox ID="txtFormNo" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
            </td>
            <td align="left" class="label" width="10%">
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="dropdown" DataValueField="DistrictId"
                    DataTextField="DistrictName" Width="100px">
                </asp:DropDownList>
            </td>
            <td align="left" width="10%">
                <asp:TextBox ID="txtBlockName" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
            </td>
            <td align="left" class="label" width="10%">
                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="textbox" Width="100px" MaxLength="10"></asp:TextBox>
            </td>
            <td align="left" class="label" width="15%">
                <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="CalendarStyle"
                    PopupPosition="Right" Format="dd/MM/yyyy" TargetControlID="txtExpirationDate"
                    OnClientDateSelectionChanged="" Enabled="True">
                </asp:CalendarExtender>
            </td>
            <td align="left" class="label" width="5%">
                <asp:TextBox ID="txtSMSSubscriberAmt" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="ftb2" runat="server" TargetControlID="txtSMSSubscriberAmt"
                    FilterType="Numbers">
                </asp:FilteredTextBoxExtender>
            </td>
            <td align="left" class="label" width="10%">
                <asp:DropDownList ID="ddlExpiration" runat="server">
                    <asp:ListItem Text="All" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Active" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Expired" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="left" width="7%">
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" OnClientClick="javascript:return Validation();"
                    OnClick="btnSearch_Click" />
            </td>
            <td align="left" width="18%">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <table width="100%" align="center">
        <tr>
            <td align="center">
                <asp:GridView ID="dgvMember" runat="server" Width="100%" AllowPaging="true" PageSize="200"
                    CellSpacing="2" GridLines="Both" DataKeyNames="MemberId" AutoGenerateColumns="false"
                    OnPageIndexChanging="dgvMember_PageIndexChanging" OnRowDataBound="dgvMember_RowDataBound"
                    >
                    <Columns>
                       <asp:TemplateField HeaderText="Sl No." HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="45px"></HeaderStyle>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Member Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMemberName" runat="server" Text='<%#Bind("MemberName") %>'
                                    CommandName="Activate" OnClientClick="javascript:return ActivateNow(this);"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FormNo" HeaderText="Reference" />
                        <asp:BoundField DataField="DistrictName" HeaderText="District" />
                        <asp:BoundField DataField="BlockName" HeaderText="Block" />
                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:HiddenField ID="HidIsExpired" runat="server" Value='<%#Bind("IsExpired") %>'>
                                </asp:HiddenField>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                        <%--<asp:BoundField DataField="IsLifeMembership" HeaderText="Life Membership" />
                        <asp:BoundField DataField="LifeMembershipAmt" HeaderText="Amt" />--%>
                        <asp:BoundField DataField="IsYearlySMSSubscriber" HeaderText="SMS Subscriber" />
                        <asp:BoundField DataField="SMSSubscriberAmt" HeaderText="Amt" />
                        
                    </Columns>
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
