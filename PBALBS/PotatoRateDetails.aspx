<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PotatoRateDetails.aspx.cs" Inherits="PBALBS.PotatoRateDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Script1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
        
        <table width="100%" align="left">
                <tr>
                     <td align="left" width="5%">
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="dropdown">
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
                                <td align="left" width="5%">
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="2012" Text="2012"></asp:ListItem>
                                        <asp:ListItem Value="2013" Text="2013"></asp:ListItem>
                                        <asp:ListItem Value="2014" Text="2014"></asp:ListItem>
                                        <asp:ListItem Value="2015" Text="2015"></asp:ListItem>
                                        <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
                                        <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
                                        <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                        <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                                        <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="20%" align="left">
                                    <asp:RadioButton ID="rbtnHorz" runat="server" Text="Horizontal" GroupName="a" 
                                        AutoPostBack="true" oncheckedchanged="rbtnHorz_CheckedChanged" />
                                    <asp:RadioButton ID="rbtnVertical" runat="server" Text="Vertical" GroupName="a" 
                                        AutoPostBack="true" oncheckedchanged="rbtnVertical_CheckedChanged" />
                                </td>
                                <td width="10%" align="left">
                                    <asp:Button ID="btnGetPrice" runat="server" CssClass="button" Text="Get Rate Chart" onclick="btnGetPrice_Click" 
                                        />
                                </td>
                                <td width="60%" align="left">
                                </td>
            </tr>
         <tr>
            <td align="left" colspan="5">
                <asp:Literal ID="ltrChart" runat="server" Mode="PassThrough"></asp:Literal>
            </td>
        </tr>
    </table>
   
    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
