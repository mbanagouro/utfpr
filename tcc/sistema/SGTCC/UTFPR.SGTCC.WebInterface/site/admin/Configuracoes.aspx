<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Configuracoes.aspx.vb" MasterPageFile="~/Template.Master"
Title="SGTCC - Configurações do Sistema" Inherits="UTFPR.SGTCC.WebInterface.Configuracoes" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <br />
    <label class="cssLabel">Coordenador, clique em um dos icones abaixo para acessar a área desejada:</label>
    <br />
    <br />
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkDefCoordenador" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/defCoordenador_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/defCoordenador_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/defCoordenador_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/defCoordenador_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/defCoordenador_0.gif") %>'"
                border="0" alt="Definir Coordenador" title="Definir Coordenador" />
            </asp:LinkButton>
    </div>
</asp:Content> 