<%@ Page Title="Add Edit State" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddEditState.aspx.cs" Inherits="PBALBS.AddEditState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
        function Validation(field) {
            var arr = field.parentElement.parentElement.getElementsByTagName("input");
            if (arr.length == 1) {
                if (arr[0].type == 'text') {
                    if (arr[0].value == '') {
                        alert('State Name Required');
                        arr[0].focus();
                        return false;
                    }
                    else {
                        return true;
                    }
                }
            }
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="50%" align="center">
        <tr>
            <td align="center">
                <asp:GridView ID="dgvState" runat="server" Width="100%" AllowPaging="false" 
                    AutoGenerateColumns="false" GridLines="none" BorderColor="#1398ED" BorderStyle="Solid" BorderWidth="1px"
                 DataKeyNames="StateId" onrowdatabound="dgvState_RowDataBound" 
                    onrowcommand="dgvState_RowCommand" onrowdeleting="dgvState_RowDeleting">
                 <Columns>
                    <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <asp:TextBox ID="txtState" runat="server" Width="250px" CssClass="textbox" Text='<%#Bind("StateName") %>' ToolTip='<%#Bind("StateName") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="AddUpdate" OnClientClick="Javascript:return Validation(this);"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                 </Columns>
                 <HeaderStyle CssClass="HeaderStyle" />
                 <RowStyle CssClass="RowStyle" />
                 <AlternatingRowStyle CssClass="AltRowStyle" />
                 </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

