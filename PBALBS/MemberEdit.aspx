<%@ Page Title="Member" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="MemberEdit.aspx.cs" Inherits="PBALBS.MemberEdit" %>

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

        function CalculateEndDate() {
            var field = document.getElementById('<%=txtStartDate.ClientID %>');
            var field1 = document.getElementById('<%=txtEndDate.ClientID %>');
            if (field.value != '' && isValidDate(field.value) == true) {
                var s = field.value;
                s = s.replace(/0*(\d*)/gi, "$1");
                var dateArray = s.split(/[\.|\/|-]/);
                dateArray[2] = parseInt(dateArray[2]) + 1;
                field1.value = dateArray[0] + '/' + dateArray[1] + '/' + dateArray[2];
                field1.focus();

            }
            else {

                field.focus();
            }
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

        function Validation() {

            if (document.getElementById('<%=txtMobileNo.ClientID %>').value == '') {
                alert('Enter Mobile No'); return false;
            }
            else if (document.getElementById('<%=txtMobileNo.ClientID %>').value.length != 10) {
                alert('Mobile No Should Be 10 Digit Number'); return false;
            }
            else if (document.getElementById('<%=txtStartDate.ClientID %>').value == '') {
                alert('Enter Start Date'); return false;
            }
            else if (document.getElementById('<%=txtEndDate.ClientID %>').value == '') {
                alert('Enter End Date'); return false;
            }

            else if (isValidDate(document.getElementById('<%=txtStartDate.ClientID %>').value) == false) {
                alert('Enter Start Date in DD/MM/YYYY Format'); return false;
            }
            else if (isValidDate(document.getElementById('<%=txtEndDate.ClientID %>').value) == false) {
                alert('Enter End Date in DD/MM/YYYY Format'); return false;
            }

            else { return confirm("Are you sure?"); }

        }

        function Verify(MobNo) {
            if (MobNo != '') {
                if (window.XMLHttpRequest) {
                    xmlHttp = new XMLHttpRequest();
                }
                else // for older IE 5/6
                {
                    xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                var url = "Verify.aspx?MobNo=" + MobNo;
                xmlHttp.open("GET", url, false);
                xmlHttp.onreadystatechange = function () {
                    if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                        document.getElementById("txtVerify").innerHTML = xmlHttp.responseText;
                    }
                }
                xmlHttp.send();

            }
            else {
                document.getElementById("txtVerify").innerHTML = '';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
    <table width="100%" align="center">
        <tr style="background-color: Red; color: White;">
            <td colspan="2" align="center">
                <asp:Literal ID="ltrMsg" runat="server" Mode="PassThrough"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" width="50%" style="border-right: solid 1px #000; padding-right: 10px;"
                valign="top">
                <table width="100%" align="center">
                    <tr>
                        <td align="center" colspan="2" style="color: Red; font-size: 15px;">
                            <b>Mandatory Fields</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Member Name:<span class="Req"> *</span>
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtMemberName" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            District:<span class="Req"> *</span>
                        </td>
                        <td align="left" width="70%">
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="dropdown" DataValueField="DistrictId"
                                DataTextField="DistrictName">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Block:<%--<span class="Req"> *</span>--%>
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtBlockName" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                            <%--<asp:DropDownList ID="ddlBlock" runat="server" CssClass="dropdown" DataValueField="BlockId"
                                DataTextField="BlockName">
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Mobile No:<span class="Req"> *</span>
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="textbox" Width="120px" MaxLength="10"
                                onblur="javascript:Verify(this.value);"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftb2" runat="server" TargetControlID="txtMobileNo"
                                FilterType="Numbers">
                            </asp:FilteredTextBoxExtender>
                            <span class="Msg" id="txtVerify"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Start Date:<span class="Req"> *</span>
                        </td>
                        <td align="left" width="70%">
                            <asp:UpdatePanel ID="UP1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox" Width="120px" onblur="javascript:CalculateEndDate()"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="CalendarStyle"
                                        PopupPosition="Right" Format="dd/MM/yyyy" TargetControlID="txtStartDate" OnClientDateSelectionChanged=""
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            End Date:<span class="Req"> *</span>
                        </td>
                        <td align="left" width="70%">
                            <asp:UpdatePanel ID="UP2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="CalendarStyle"
                                        PopupPosition="Right" Format="dd/MM/yyyy" TargetControlID="txtEndDate" OnClientDateSelectionChanged=""
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" width="50%" style="padding-left: 5px;">
                <table width="100%" align="center">
                    <tr>
                        <td align="center" colspan="2" style="color: Green; font-size: 15px;">
                            <b>Non-Mandatory Fields</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Form No:
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtFormNo" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Firm Name:
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtFirmName" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Address:
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" Width="250px" TextMode="MultiLine"
                                Height="40px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Pin:
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtPin" runat="server" CssClass="textbox" Width="120px" MaxLength="6"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtPin" FilterType="Numbers">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Landline No:
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtLandLine" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Is Life Membership:
                        </td>
                        <td align="left" width="70%">
                            <asp:CheckBox ID="ChkLifeMemberShip" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Life Membership Amt:
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtLifeMembershipAmt" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftb3" runat="server" TargetControlID="txtLifeMembershipAmt"
                                FilterType="Numbers">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Is Yearly SMS Subscriber:
                        </td>
                        <td align="left" width="70%">
                            <asp:CheckBox ID="ChkSMSSubscriber" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            SMS Subscriber Amt:
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtSMSSubscriberAmt" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftb4" runat="server" TargetControlID="txtSMSSubscriberAmt"
                                FilterType="Numbers">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClientClick="javascript:return Validation()"
                    OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Reset" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
