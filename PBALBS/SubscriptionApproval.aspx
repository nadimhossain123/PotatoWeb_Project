<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="SubscriptionApproval.aspx.cs" Inherits="PBALBS.SubscriptionApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
    <fieldset id="BoxAccountDetails" runat="server">
        <legend><b>Subscription Details</b></legend>
        <table width="100%" align="center">
            <tr>
                <td>
                    Year :
                </td>
                <td>
                    Member :
                </td>
                <td>
                    Status :
                </td>
                <td>
                    Block :
                </td>
                <td>
                    Mobile No :
                </td>
                <td>
                    Amount :
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="dropdown" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMember" runat="server" CssClass="dropdown" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="150px" CssClass="dropdown">
                        <asp:ListItem Value="2">--SELECT--</asp:ListItem>
                        <asp:ListItem Value="1">Approved</asp:ListItem>
                        <asp:ListItem Value="0">Pending</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBlock" runat="server" CssClass="dropdown" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtMobNo" runat="server" CssClass="textbox" Width="140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="textbox" Width="140px"></asp:TextBox>
                    <%-- <asp:DropDownList ID="ddlAmount" runat="server" CssClass="dropdown" Width="150px">
                    </asp:DropDownList>--%>
                </td>
                <td align="right">
                    <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" Width="120px"
                        OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:GridView ID="dgvSubscriptionList" runat="server" Width="100%" AllowPaging="True"
                        PageSize="100" CellSpacing="2" DataKeyNames="SubscriptionId,MemberId_FK" AutoGenerateColumns="False"
                        OnPageIndexChanging="dgvSubscriptionList_PageIndexChanging" EnableModelValidation="True"
                        OnRowEditing="dgvSubscriptionList_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl No." HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="45px"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FinancialYear" HeaderText="Year" ItemStyle-Width="80px"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="EntryDate" HeaderText="Transaction Date" DataFormatString="{0:dd MMM yyyy}"
                                ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedOn" HeaderText="Entry Date" DataFormatString="{0:dd MMM yyyy}"
                                ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="MemberName" HeaderText="Member" ItemStyle-Width="300px">
                                <ItemStyle Width="300px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Narration" HeaderText="Narration" FooterStyle-HorizontalAlign="Right">
                                <FooterStyle HorizontalAlign="Right"></FooterStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Amount" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%# Eval("Amount")%>
                                </ItemTemplate>
                                <%--<FooterTemplate>
                            <asp:Label ID="lblTotalAmount" runat="server" Text="0.00" Font-Bold="true"></asp:Label>
                        </FooterTemplate>--%>
                                <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                <ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PaymentStatus" HeaderText="Approval Status" ItemStyle-HorizontalAlign="Center">
                                <FooterStyle HorizontalAlign="Center"></FooterStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedBy" HeaderText="Created By" FooterStyle-HorizontalAlign="Right" />
                            <%--<asp:TemplateField ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Ed" CommandArgument='<%# Eval("SubscriptionId,MemberId_FK") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:CommandField ShowEditButton="True" EditText="Approve" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <EmptyDataTemplate>
                            <span style="border: 1px solid #dsgdfg; width: 100%; font-size: 14px; font-style: italic">
                                No Transaction Found...</span>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
