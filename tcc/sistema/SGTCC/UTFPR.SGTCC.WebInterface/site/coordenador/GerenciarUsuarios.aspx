<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="GerenciarUsuarios.aspx.vb"
    Title="SGTCC - Gerencia de Usuarios" Inherits="UTFPR.SGTCC.WebInterface.MainUsuarios" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <br />
    <label class="cssLabel">Coordenador, clique em um dos icones abaixo para acessar a área desejada:</label>
    <br />
    <br />
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkMeuPerfil" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/meuPerfil_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/meuPerfil_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/meuPerfil_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/meuPerfil_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/meuPerfil_0.gif") %>'"
                border="0" alt="Meu Perfil" title="Meu Perfil" />
            </asp:LinkButton>
    </div>
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkNovoUsuario" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/novoUsuario_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/novoUsuario_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/novoUsuario_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/novoUsuario_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/novoUsuario_0.gif") %>'"
                border="0" alt="Novo Usuário" title="Novo Usuário" />
            </asp:LinkButton>
    </div>
</asp:Content> 
