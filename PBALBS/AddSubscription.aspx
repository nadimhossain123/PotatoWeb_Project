<%@ Page Title="Add/Edit Subscription" Language="C#" MasterPageFile="~/Master.Master"
    AutoEventWireup="true" CodeBehind="AddSubscription.aspx.cs" Inherits="PBALBS.AddSubscription" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Req
        {
            color: Red;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function validation() {
            if (document.getElementById("<%=ddlMember.ClientID %>").selectedIndex == 0) {
                alert('Please select member');
                document.getElementById("<%=ddlMember.ClientID %>").focus();
                return false;
            }
            else if (document.getElementById("<%=txtAmount.ClientID %>").value == '') {
                alert('Please select amount');
                document.getElementById("<%=txtAmount.ClientID %>").focus();
                return false;
            }
            else if (document.getElementById("<%=txtEntryDate.ClientID %>").value == '') {
                alert('Please select transaction date');
                document.getElementById("<%=txtEntryDate.ClientID %>").focus();
                return false;
            }
            else {
                return confirm('Are you sure to save?');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
    <table width="60%" align="center">
        <tr>
            <td align="left" class="label">
                Year:<span class="Req"> *</span>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="dropdown" Width="250px" Height="30px">
                </asp:DropDownList>
            </td>
            <td align="left" class="label">
                Member:<span class="Req"> *</span>
            </td>
            <td align="left" valign="top">
                <%--<asp:DropDownList ID="ddlMember" runat="server" CssClass="dropdown" Width="250px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlMember_SelectedIndexChanged">
                </asp:DropDownList>--%>
                <asp:ComboBox ID="ddlMember" runat="server" CssClass="WindowsStyle" DropDownStyle="DropDown"
                    AutoCompleteMode="SuggestAppend" CaseSensitive="false" Width="250px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlMember_SelectedIndexChanged">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td align="left" class="label">
                Amount:<span class="Req"> *</span>
            </td>
            <td align="left">
                <asp:TextBox ID="txtAmount" runat="server" CssClass="textbox" Width="243px" MaxLength="8"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtAmount_FilteredTextBoxExtender" runat="server"
                    TargetControlID="txtAmount" ValidChars=".0123456789">
                </asp:FilteredTextBoxExtender>
                <br />
            </td>
            <td align="left" class="label">
                Transaction Date:<span class="Req"> *</span>
            </td>
            <td align="left">
                <asp:TextBox ID="txtEntryDate" runat="server" CssClass="textbox" Width="243px" onkeydown="return false;"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="CalendarStyle"
                    PopupPosition="Right" Format="dd MMM yyyy" TargetControlID="txtEntryDate" OnClientDateSelectionChanged=""
                    Enabled="True">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td align="left" class="label">
                Narration
            </td>
            <td>
                <asp:TextBox ID="txtNarration" runat="server" CssClass="textbox" Width="243px" TextMode="MultiLine"
                    Height="50px"></asp:TextBox>
            </td>
            <td align="left" class="label">
                M.R. Number
            </td>
            <td>
                <asp:TextBox ID="txtMrNo" runat="server" CssClass="textbox" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblAmountPaid" runat="server" Font-Italic="true" ForeColor="DarkGreen"
                    Font-Bold="true" Style="margin: 5px"></asp:Label>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click"
                    OnClientClick="return validation()" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Reset" OnClick="btnCancel_Click" />
                &nbsp;
                <asp:Literal ID="ltrMsg" runat="server" Mode="PassThrough"></asp:Literal>
            </td>
        </tr>
    </table>
    <center>
        <div style="width: 94%;">
            <span style="float: left; font-weight: bold">Subscription List:</span><br />
            <table width="80%" align="center">
                <tr>
                    <td>
                        From Transaction Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtTransactionFromDate" runat="server" CssClass="textbox" Width="120px"
                            onkeydown="return false;"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="CalendarStyle"
                            PopupPosition="Right" Format="dd MMM yyyy" TargetControlID="txtTransactionFromDate"
                            OnClientDateSelectionChanged="" Enabled="True">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        To Transaction Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtTransactionToDate" runat="server" CssClass="textbox" Width="120px"
                            onkeydown="return false;"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="CalendarStyle"
                            PopupPosition="Right" Format="dd MMM yyyy" TargetControlID="txtTransactionToDate"
                            OnClientDateSelectionChanged="" Enabled="True">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        Status
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="120px" CssClass="dropdown">
                            <asp:ListItem Value="2">--SELECT--</asp:ListItem>
                            <asp:ListItem Value="1">Approved</asp:ListItem>
                            <asp:ListItem Value="0">Pending</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="dgvSubscriptionList" runat="server" Width="100%" AllowPaging="true"
                PageSize="20" CellSpacing="2" GridLines="Both" DataKeyNames="SubscriptionId"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvSubscriptionList_PageIndexChanging"
                OnRowCommand="dgvSubscriptionList_RowCommand" ShowFooter="true" OnRowDataBound="dgvSubscriptionList_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Sl" HeaderStyle-Width="10px">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FinancialYear" HeaderText="Year" ItemStyle-Width="80px"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="EntryDate" HeaderText="Transaction Date" DataFormatString="{0:dd MMM yyyy}"
                        ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="CreatedOn" HeaderText="Entry Date" DataFormatString="{0:dd MMM yyyy}"
                        ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="MemberName" HeaderText="Member" ItemStyle-Width="250px" />
                    <asp:BoundField DataField="MRNo" HeaderText="MR No" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="Narration" HeaderText="Narration" FooterStyle-HorizontalAlign="Right" />
                    <asp:TemplateField HeaderText="Amount" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%# Eval("Amount")%>
                        </ItemTemplate>
                        <%--<FooterTemplate>
                            <asp:Label ID="lblTotalAmount" runat="server" Text="0.00" Font-Bold="true"></asp:Label>
                        </FooterTemplate>--%>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PaymentStatus" HeaderText="Approval Status" FooterStyle-HorizontalAlign="Right" />
                    <asp:TemplateField ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Ed" CommandArgument='<%# Eval("SubscriptionId") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Del" CommandArgument='<%# Eval("SubscriptionId") %>'
                                OnClientClick="return confirm('Are you sure to delete?')"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <EmptyDataTemplate>
                    <span style="border: 1px solid #dsgdfg; width: 100%; font-size: 14px; font-style: italic">
                        No Transaction Found...</span>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </center>
</asp:Content>
