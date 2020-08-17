<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="MemberDetails.aspx.cs" Inherits="PBALBS.MemberDetails" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Validation() {
            var field = document.getElementById('<%=txtExpirationDate.ClientID%>');
            if (field.value != '' && isValidDate(field.value) == false) {
                alert('Enter Expiration Date In DD/MM/YYYY Format');
                field.focus();
                return false;
            }

            else { return true; }
        }

        function UpdateValidation() {
            var field = document.getElementById('<%=txtNewEndDate.ClientID%>');
            if (field.value == '' || isValidDate(field.value) == false) {
                alert('Enter New End Date In DD/MM/YYYY Format');
                field.focus();
                return false;
            }

            else { return true; }
        }

        function isValidDate(s) {
            // format D(D)/M(M)/(YY)YY
            var dateFormat = /^\d{1,4}[\.|\/|-]\d{1,2}[\.|\/|-]\d{1,4}$/;

            if (dateFormat.test(s)) {
                // remove any leading zeros from date values
                s = s.replace(/0*(\d*)/gi, "$1");
                var dateArray = s.split(/[\.|\/|-]/);

                // correct month value
                dateArray[1] = dateArray[1] - 1;

                // correct year value
                if (dateArray[2].length < 4) {
                    // correct year value
                    dateArray[2] = (parseInt(dateArray[2]) < 50) ? 2000 + parseInt(dateArray[2]) : 1900 + parseInt(dateArray[2]);
                }

                var testDate = new Date(dateArray[2], dateArray[1], dateArray[0]);
                if (testDate.getDate() != dateArray[0] || testDate.getMonth() != dateArray[1] || testDate.getFullYear() != dateArray[2]) {
                    return false;
                } else {
                    return true;
                }
            } else {
                return false;
            }
        }

        function ActivateNow(field) {
            var role = document.getElementById('<%=hidden_role.ClientID%>').value;
            if (role == 'Admin' || role == 'Bibhas') {
                if (field.title == 'Activated') {
                    return false;
                }
                else if (field.title == 'Activate Now') {
                    return confirm('Do you want to activate ' + field.innerHTML + ' ?');
                }
            }
            else {
                alert('Sorry! Only Administrator Can Change This');
                return false;
            }
        }

        function ValidateRole(type) {
            var role = document.getElementById('<%=hidden_role.ClientID%>').value;
            if (role == 'Admin' || role == 'Bibhas') {
                if (type == 'E')
                    return true;
                else if (type == 'D')
                    return confirm('Are You Sure?');
            }
            else {
                alert('Sorry! Only Administrator Can Change This');
                return false;
            }
        }

        function CheckAll(checkbox) {
            var gv = document.getElementById('<%=dgvMember.ClientID%>');
            var arr = gv.getElementsByTagName("input");
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].type == 'checkbox') {
                    if (checkbox.checked == true) {
                        arr[i].checked = true;
                    }
                    else {
                        arr[i].checked = false;
                    }
                }
            }
        }

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:HiddenField ID="hidden_role" runat="server" />
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
                <asp:Button ID="btnDownload" runat="server" CssClass="button" Text="Download" OnClick="btnDownload_Click" />
            </td>
        </tr>
    </table>
    <br />
    <div>
        <asp:CheckBox ID="chk" runat="server" Text="Select All" onclick="javascript:CheckAll(this);"
            TabIndex="18" />
    </div>
    <table width="100%" align="center">
        <tr>
            <td align="center">
                <asp:GridView ID="dgvMember" runat="server" Width="100%" AllowPaging="true" PageSize="200"
                    CellSpacing="2" GridLines="Both" DataKeyNames="MemberId" AutoGenerateColumns="false"
                    OnPageIndexChanging="dgvMember_PageIndexChanging" OnRowEditing="dgvMember_RowEditing"
                    OnRowDeleting="dgvMember_RowDeleting" OnRowDataBound="dgvMember_RowDataBound"
                    OnRowCommand="dgvMember_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sl No." HeaderStyle-Width="15px">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="15px"></HeaderStyle>
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
                        <asp:BoundField DataField="IsPortalMember" HeaderText="Portal Membership" HeaderStyle-Width="65px" />
                        <asp:BoundField DataField="PortalMemberAmt" HeaderText="Amt" />
                        <asp:BoundField DataField="IsYearlySMSSubscriber" HeaderText="SMS Subscriber" HeaderStyle-Width="65px" />
                        <asp:BoundField DataField="SMSSubscriberAmt" HeaderText="Amt" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit" OnClientClick="javascript:return ValidateRole('E');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                                    OnClientClick="javascript:return ValidateRole('D');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                New End Date(DD/MM/YYYY):
            </td>
            <td>
                <asp:TextBox ID="txtNewEndDate" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="Update" OnClick="btnUpdate_Click"
                    OnClientClick="javascript:return UpdateValidation();" />
            </td>
        </tr>
    </table>
</asp:Content>
