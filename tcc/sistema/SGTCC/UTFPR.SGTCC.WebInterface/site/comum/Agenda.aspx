<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Agenda.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Agenda" 
    title="SGTCC - Agenda Pessoal" %>

<%@ Register src="~/UserControls/Calendario.ascx" tagname="Calendario" tagprefix="uc1" %>
<%@ Register src="~/UserControls/ListarUltimosEventosAgenda.ascx" tagname="ListarUltimosEventosAgenda" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<table style="width: 100%; height: 350px;" border="0" cellpadding="0" cellspacing="5">
    <tr>
        <td style="width: 200px;" valign="top">
            <uc2:ListarUltimosEventosAgenda ID="ListarUltimosEventosAgenda1" runat="server" />
        </td>
        
        <td style="background-color:Scrollbar; width:1px; height:100%;"></td>
        
        <td valign="top">
            <uc1:Calendario ID="calAgenda" runat="server" />
        </td>         
    </tr>
</table>     

</asp:Content>
