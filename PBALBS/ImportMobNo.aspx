<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ImportMobNo.aspx.cs" Inherits="PBALBS.ImportMobNo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Validation() {
            if (document.getElementById('<%=txMobNo.ClientID %>').value == '') {
                alert('Enter Mobile No'); return false;
            }
            else { return true; }
        }
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ToolkitScriptManager ID="ToolScript1" runat="server">
</asp:ToolkitScriptManager>

<asp:UpdatePanel ID="UP1" runat="server">
    <ContentTemplate>
        <table width="90%" align="center">
            <tr>
                <td align="left" class="label">
                    Enter Mobile Numbers in Comma(',') Separated Way. i.e 9836550711,9874433667,9836634433 etc
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:TextBox ID="txMobNo" runat="server" CssClass="textbox" Width="722px" 
                        Height="200px" TextMode="MultiLine"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txMobNo" FilterType="Custom" ValidChars="0123456789,">
                    </asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Import" 
                        OnClientClick="javascript:return Validation();" onclick="btnSave_Click" />
                    
                </td>
            </tr>
            <tr>
                <td align="left" class="label">
                    <asp:Literal ID="ltrMsg" runat="server" Mode="PassThrough"></asp:Literal>
                </td>
            </tr>
             <tr>
                <td align="left">
                    <asp:TextBox ID="txtMobNoExport" runat="server" CssClass="textbox" Width="722px" 
                        Height="297px" TextMode="MultiLine"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="btnExport" runat="server" Text="Export Active Numbers" 
                        CssClass="button" onclick="btnExport_Click" />
                   
                </td>
            </tr>
            
        </table>
    </ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
