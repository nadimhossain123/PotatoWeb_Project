<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Circular.aspx.cs" Inherits="PBALBS.Circular" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     function Validation() {
         if (document.getElementById('<%=txtCircular.ClientID %>').value == '') {
                alert('Message Body is Blank'); return false;
            }
            
         else {
             return confirm('Are You Sure?');
         }
     }

     function ValidationForSendingNotification() {
        
              return confirm('Are You Sure?');
          
      }

    

     document.onmousedown = disableclick;
     status = "Right Click Disabled";
     function disableclick(event) {
         if (event.button == 2) {
             alert(status);
             return false;
         }
     }
    </script>
    
    <style type="text/css">
        .style1
        {
            width: 60%;
            border-style: ridge;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolScript1" runat="server">
    </asp:ToolkitScriptManager>
   

     <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <%--<table width="95%" align="center">
                <tr>
                    <td align="center" style="font-family:Tahoma; font-weight:8px; color:Red; font-weight:bold;">
                        If any of the rate is 0, then it is not mandatory to fill all the textbox with 000. If you leave any textbox blank, then that rate will be considered as 0.
                    </td>
                </tr>
            </table>--%>
           
                  
                        <table  align="center">
                            

                            <tr>
                                <td align="center" >
                                    <asp:label id="Label1" runat="server">Add New Circular</asp:label>
                                </td>
                            </tr>

                           <tr><td align="center">
                            <HTMLEditor:Editor ID="txtCircular" runat="server" Height="350px"  Width="700px" class="form-control"  />
                               </td></tr>

                               <tr>
                                   <td align="center" >
                                    <asp:label id="lblMsg" runat="server"></asp:label>
                                </td>
                                <td align="right" > 
                                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Save" OnClientClick="javascript:return Validation();"
                    OnClick="btnSave_Click" />

                                <asp:Button ID="Button2" runat="server" CssClass="button" Text="Send Notification" OnClientClick="javascript:return ValidationForSendingNotification();"
                    OnClick="btnSendNotification_Click" />

                           </td>
                           </tr>
                           

                         </table>

            <table width="60%" align="center">
                <tr>
                                <td align="center" width="90%">
                        <asp:GridView ID="grdViewCircular" Width="400px" runat="server" AutoGenerateColumns="false"  AllowPaging="false"
                         GridLines="none" BorderColor="#1398ED" 
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="8">
                            <Columns >
                         <asp:BoundField headerText="Circular Date" DataField="CircularDate"/>
                         <asp:BoundField headerText="Circular" DataField="CircularBody"/>
                           </Columns>
                            <HeaderStyle CssClass="HeaderStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                 </td/</tr>
                      
             </table>
                
         
        </ContentTemplate>
   </asp:UpdatePanel> 

</asp:Content>
