<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="MainTCC.aspx.vb" 
    Title="SGTCC - Tela Principal do TCC" Inherits="UTFPR.SGTCC.WebInterface.MainTCC" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <br />
    <label class="cssLabel">Coordenador, clique em um dos icones abaixo para acessar a área desejada:</label>
    <br />
    <br />
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkGerenciarTCC" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_0.gif") %>'"
                border="0" alt="Gerenciar TCC" title="Gerenciar TCC" />
            </asp:LinkButton>
    </div>
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkRelDocs" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/relDocs_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocs_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocs_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocs_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocs_0.gif") %>'"
                border="0" alt="Relatórios e Documentos" title="Relatórios e Documentos" />
            </asp:LinkButton>
    </div>
</asp:Content> 