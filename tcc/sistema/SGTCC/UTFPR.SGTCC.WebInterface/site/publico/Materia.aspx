<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Materia.aspx.vb"
    Title="SGTCC - Dúvidas freqüentes" Inherits="UTFPR.SGTCC.WebInterface.Materia" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <br />
    <label class="cssLabel">Clique em um dos icones abaixo para acessar a área desejada:</label>
    <br />
    <br />
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkProposta" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasProposta_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasProposta_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasProposta_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasProposta_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasProposta_0.gif") %>'"
                border="0" alt="Proposta" title="Proposta" />
            </asp:LinkButton>
    </div>
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkDefesa" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasDefesa_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasDefesa_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasDefesa_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasDefesa_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/duvidasDefesa_0.gif") %>'"
                border="0" alt="Defesa" title="Defesa" />
            </asp:LinkButton>
    </div>

    <div style="float: left;">
            <asp:LinkButton ID="lnkDatasImportantes" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/datasImportantes_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/datasImportantes_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/datasImportantes_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/datasImportantes_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/datasImportantes_0.gif") %>'"
                border="0" alt="Datas Importantes" title="Datas Importantes" />
            </asp:LinkButton>
    </div>
    
        <div style="float: left;">
            <asp:LinkButton ID="lnkOrientadores" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/relOrientadores_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relOrientadores_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relOrientadores_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relOrientadores_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relOrientadores_0.gif") %>'"
                border="0" alt="Relatório de Orientadores" title="Relatório de Orientadores" />
            </asp:LinkButton>
    </div>
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkSituacao" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/relSituacao_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relSituacao_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relSituacao_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relSituacao_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relSituacao_0.gif") %>'"
                border="0" alt="Relatório de Situação" title="Relatório de Situação" />
            </asp:LinkButton>
    </div>


</asp:Content> 

