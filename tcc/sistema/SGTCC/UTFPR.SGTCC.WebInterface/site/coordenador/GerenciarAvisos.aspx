<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="GerenciarAvisos.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.GerenciarAvisos" 
    title="SGTCC - Gerenciar Avisos" %>

<%@ Register src="../../UserControls/GridAvisos.ascx" tagname="GridAvisos" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br /><br />

<div>
    <asp:Button ID="btnNovoAviso" runat="server" Text="Novo Aviso" CssClass="cssBotaoLaranja" />    
</div>

<br />

<div style="clear: both;">
    <uc1:GridAvisos ID="grvAvisos" runat="server" />
</div>

</asp:Content>
