<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="VisualizarAviso.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.VisualizarAviso" 
    title="SGTCC - Visualizar Aviso" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="height: 20px;">
    <asp:Label ID="lblMensagem" Font-Bold="True" runat="server" Text=""></asp:Label>
</div>    

<div style="clear: both;" >
    <asp:Label ID="lblTitulo" CssClass="cssTitulo" runat="server"></asp:Label>
    <br /><br />
    <i><asp:Label ID="lblAutor" class="cssLabel" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblDataPublicacao" class="cssLabel" runat="server"></asp:Label></i>
</div>

<br />

<div style="clear: both;">
    <fieldset>
        <legend>Conteúdo</legend>

        <asp:Label ID="lblConteudo" class="cssLabel" runat="server"></asp:Label>
    </fieldset>
</div>

</asp:Content>
