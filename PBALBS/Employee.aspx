<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="PBALBS.Employee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Script1" runat="server">
    </asp:ScriptManager>
   
    <asp:UpdateProgress ID="UProgress1" runat="server" AssociatedUpdatePanelID="UP1">
        <ProgressTemplate>
            <div class="overlay">
                <img style="top: 50%; position: relative;" src="../Images/ajax-loader.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
           
                <br />
                <table width="80%" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="label">
                            First Name
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFName" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Employee" 
                                CssClass="button" onclick="btnAddNew_Click"/>
                            </td>
                    </tr>
                </table>
                <br />
                <table width="80%" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td>
                            <asp:GridView ID="dgvEmployeeMaster" runat="server" Width="100%" 
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="20" CellPadding="0" CellSpacing="0"
                                DataKeyNames="EmployeeId" OnPageIndexChanging="dgvEmployeeMaster_PageIndexChanging"
                                OnRowEditing="dgvEmployeeMaster_RowEditing">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL" ItemStyle-Width="15px">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FName" HeaderText="First Name" />
                                    <asp:BoundField DataField="LName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="Email" HeaderText="Username" />
                                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                    <asp:TemplateField HeaderText="Active" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkIsActive" runat="server" Enabled="false" Checked='<%#Convert.ToBoolean(Eval("Status")) %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField ItemStyle-Width="15px">
                                        <ItemTemplate>
                                            <a href='#' onclick="openMyModal('EmployeeRoleMapping.aspx?id=<%# Eval("EmployeeId") %>'); return false;">
                                                <img src="../Images/plus-icon.png" title="Add Role" width="15px" height="15px" />
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField ItemStyle-Width="15px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/edit_icon.gif" CommandName="Edit"
                                                Width="15px" Height="15px" />
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr class="RowStyle">
                                            <td>
                                                No Record Found
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="HeaderStyle" HorizontalAlign="Left" />
                                <RowStyle CssClass="RowStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <PagerStyle CssClass="pagin" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
