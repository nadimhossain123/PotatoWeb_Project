<%@ Page Title="Member" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="True"
    CodeBehind="AddEditMember.aspx.cs" Inherits="PBALBS.AddEditMember" %>

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


        function enableMembership() {
            if (document.getElementById('<%=ChkLifeMemberShip.ClientID %>').checked == true)
                document.getElementById('<%=txtLifeMembershipAmt.ClientID %>').disabled = false;

            else
                document.getElementById('<%=txtLifeMembershipAmt.ClientID %>').disabled = true;
        }

       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
    <table width="100%" align="center">
        <tr style="color: White;">
            <td colspan="2" align="center">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="textbox" Width="120px" MaxLength="10"></asp:TextBox>
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
                    <tr>
                        <td align="left" width="30%" class="label">
                            Is Mobile App Activated:
                        </td>
                        <td align="left" width="70%">
                            <asp:CheckBox ID="ChkMobileAppActivated" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td align="left" width="30%" class="label">
                            Device Id(For Mobile App):
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtDeviceId" runat="server" CssClass="textbox" Width="250px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Password(For Mobile App):
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
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
                            Reference:
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
                            <asp:TextBox ID="txtLifeMembershipAmt" runat="server" CssClass="textbox" Width="120px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="ftb3" runat="server" TargetControlID="txtLifeMembershipAmt"
                                FilterType="Numbers">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="30%" class="label">
                            Is Portal Member:
                        </td>
                        <td align="left" width="70%">
                            <asp:CheckBox ID="chkPortalMember" runat="server" />
                            <asp:TextBox ID="txtPortalAmount" runat="server" CssClass="textbox" Width="120px"
                                placeholder="Membership Amount"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPortalAmount"
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
                    <tr>
                        <td align="left" width="30%" class="label">
                            Approve Payment:
                        </td>
                        <td align="left" width="70%">
                            <asp:CheckBox ID="chkApprovePayment" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSaveWithOutSms" runat="server" CssClass="button" Text="Save Without SMS"
                    OnClick="btnSaveWithOutSms_Click" />
                &nbsp;
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save With SMS" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Reset" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
