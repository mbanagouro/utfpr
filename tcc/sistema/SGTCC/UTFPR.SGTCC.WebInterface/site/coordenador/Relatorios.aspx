<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Relatorios.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Relatorios" 
    title="SGTCC - Relatorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <label class="cssLabel">Clique em um dos icones abaixo para acessar o relatório:</label>
    <br />
    <br />
    
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
    
    <div style="float: left;">
            <asp:LinkButton ID="lnkRelDocs" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/relDocsData_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocsData_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocsData_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocsData_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relDocsData_0.gif") %>'"
                border="0" alt="Relatórios por Data" title="Relatórios por Data" />
            </asp:LinkButton>
    </div>
    


</asp:Content>
