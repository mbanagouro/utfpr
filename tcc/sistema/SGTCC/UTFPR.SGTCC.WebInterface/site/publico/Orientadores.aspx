<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Orientadores.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Orientadores" 
    title="SGTCC - Orientadores disponíveis" %>

<%@ Register src="../../UserControls/GridOrientadores.ascx" tagname="GridOrientadores" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br />

<div>
    <label class="cssTitulo">Lista de Orientadores Disponíveis</label>
</div>

<br /><br />

<div style="clear: both;">
    <label class="cssLabel">Confira abaixo os orientadores disponíveis <br />
    Converse com algum deles e procure um tema que seja adequado ao trabalho final.</label>
</div>

<br />

<div>
    <uc1:GridOrientadores ID="grdSOrientadores" runat="server" />
</div>

<br /><br />

</asp:Content>
