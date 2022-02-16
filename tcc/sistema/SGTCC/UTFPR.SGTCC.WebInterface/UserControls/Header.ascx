<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Header.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.Header" %>

<!-- Logo UTFPR -->
<div id="logo" title="UTFPR - Universidade Tecnol gica Federadl do Paran ">
</div>

<!-- Topo e Barra de Login -->
<div id="headerBar">
    <div id="userLogIn" runat="server">
       <b><asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label></b>
       | 
       <asp:LinkButton ID="lnkPerfil" runat="server" CausesValidation="False" EnableViewState="False">Perfil</asp:LinkButton>
       | 
       <asp:LinkButton ID="lnkLogout" runat="server" CausesValidation="False" EnableViewState="False">Sair</asp:LinkButton>
    </div>
    <div id="userLogOut" runat="server">
       <asp:LinkButton ID="lnkdEntrar" runat="server" CausesValidation="False" EnableViewState="False">Entrar</asp:LinkButton>
    </div>
</div>