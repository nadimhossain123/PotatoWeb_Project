<%@ Page Title="Unloading" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Unloading.aspx.cs" Inherits="PBALBS.Unloading" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function validation() {
            if (document.getElementById("<%=ddlYear.ClientID %>").selectedIndex == 0) {
                alert('Please select Year');
                document.getElementById("<%=ddlYear.ClientID %>").focus();
                return false;
            }
            else if (document.getElementById("<%=ddlMonth.ClientID %>").selectedIndex == 0) {
                alert('Please select Month');
                document.getElementById("<%=ddlMonth.ClientID %>").focus();
                return false;
            }
            else
                return confirm('Are You Sure?');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ToolkitScriptManager ID="Script1" runat="server">
     </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UP1" runat="server">
   <ContentTemplate>
       <table width="45%" align="center">
          <tr>
             
                                <td align="right" width="10%"><b>Select Month:</b></td>
                                <td align="left" width="10%">
                                      <asp:DropDownList ID="ddlMonth" runat="server" CssClass="dropdown">
                                      <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                      <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                      <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                      <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                      <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                      <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                      <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                      <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                      <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                      <asp:ListItem Value="9" Text="Sep"></asp:ListItem>
                                      <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                      <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                      <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                               </asp:DropDownList>
                               </td>
                                <td align="right" width="10%"><b>Select Year:</b></td>
                                <td align="left" width="10%">
                                      <asp:DropDownList ID="ddlYear" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                      <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                      <asp:ListItem Value="2012" Text="2012"></asp:ListItem>
                                      <asp:ListItem Value="2013" Text="2013"></asp:ListItem>
                                      <asp:ListItem Value="2014" Text="2014"></asp:ListItem>
                                      <asp:ListItem Value="2015" Text="2015"></asp:ListItem>
                                      <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
                                      <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
                                      <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                      <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                                      <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                      <asp:ListItem Value="2021" Text="2020"></asp:ListItem>
                                      <asp:ListItem Value="2022" Text="2020"></asp:ListItem>
                               </asp:DropDownList>
                               </td>

                            </tr>
                       
    </table>
    <table align="center">
        <tr>
           <td align="center" width="90%">  
           <asp:GridView ID="dgvDistrict" runat="server" AutoGenerateColumns="false" Width="80%" AllowPaging="false"
           GridLines="none" BorderColor="#1398ED" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="DistrictId">
                <Columns>
                <asp:BoundField DataField="DistrictName" HeaderText="District" />
                    <asp:TemplateField HeaderText="Loading" ItemStyle-Width="80px">
                    <ItemTemplate>
                         <asp:TextBox ID="txtLoading" runat="server" CssClass="textbox" Width="50px"  Enabled="false" Text='<%#Bind("Loading") %>'></asp:TextBox>
                         <asp:FilteredTextBoxExtender ID="ftb2" runat="server" TargetControlID="txtLoading" FilterType="Numbers">
                         </asp:FilteredTextBoxExtender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unloading" ItemStyle-Width="80px">
                    <ItemTemplate>
                         <asp:TextBox ID="txtUnloading" runat="server" CssClass="textbox" Width="50px"  Text='<%#Bind("Unloading") %>'></asp:TextBox>
                         <asp:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtUnloading" FilterType="Numbers">
                         </asp:FilteredTextBoxExtender>
                    </ItemTemplate>
                </asp:TemplateField>
               </Columns>
               <HeaderStyle CssClass="HeaderStyle" />
               <RowStyle CssClass="RowStyle" />
               <AlternatingRowStyle CssClass="AltRowStyle" />
            </asp:GridView>
            </td>
            </tr>
            <tr>
               <td align="center">
               <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" onclick="btnSave_Click" />
               &nbsp;
               <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Edit" onclick="btnEdit_Click" />
               &nbsp;
               <asp:Button ID="btnReset" runat="server" CssClass="button" Text="Cancel" onclick="btnReset_Click" />
               </td>
            </tr>
        <br />
        <br />
        <br />
        <tr><td><asp:Label ID="lbl1" runat="server" Font-Size="Medium" BackColor="Yellow" Font-Bold="true"></asp:Label></td></tr>
   </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
