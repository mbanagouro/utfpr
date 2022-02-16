<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Correio.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Correio" 
    title="SGTCC - Correio" %>

<%@ Register src="~/UserControls/GridMensagensEnviadas.ascx" tagname="GridMensagensEnviadas" tagprefix="uc1" %>
<%@ Register src="~/UserControls/GridMensagensRecebidas.ascx" tagname="GridMensagensRecebidas" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<table style="width: 100%; height: 340px;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 150px;" valign="top">
            <div>
                <label class="cssTitulo">Pastas</label>
            </div>
            <br /><br />
            
            <div style="clear: both;">
                <asp:LinkButton ID="lnkRecebidas" runat="server" EnableViewState="False">
                    <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/recebidas_0.png") %>" 
                    onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/recebidas_1.png") %>'"
                    onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/recebidas_0.png") %>'"
                    onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/recebidas_2.png") %>'"
                    onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/recebidas_0.png") %>'"
                    border="0" alt="Mensagens Recebidas" title="Mensagens Recebidas" />                    
                </asp:LinkButton>
            </div>
            <div style="clear: both;">
                <asp:LinkButton ID="lnkEnviadas" runat="server" EnableViewState="False">
                    <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/enviadas_0.png") %>" 
                    onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/enviadas_1.png") %>'"
                    onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/enviadas_0.png") %>'"
                    onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/enviadas_2.png") %>'"
                    onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/enviadas_0.png") %>'"
                    border="0" alt="Mensagens Enviadas" title="Mensagens Enviadas" />                     
                </asp:LinkButton>
            </div>
            <br />
            <div style="clear: both; background-color:Scrollbar; height: 1px; width:90%;"></div>
            <br />
            <div style="clear: both;">
                <asp:LinkButton ID="lnkNovaMensagem" PostBackUrl="NovaMensagem.aspx" runat="server">
                    <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/nova_mensagem_0.png") %>" 
                    onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/nova_mensagem_1.png") %>'"
                    onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/nova_mensagem_0.png") %>'"
                    onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/nova_mensagem_2.png") %>'"
                    onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/nova_mensagem_0.png") %>'"
                    border="0" alt="Nova Mensagem" title="Nova Mensagem" />                   
                </asp:LinkButton>
            </div>
        </td>
        
        <td style="background-color:Scrollbar; width:1px; height:90%;"></td>
        
        <td valign="top">
            <table style="width: 100%" border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td class="cssTitulo">
                        <asp:Image ID="imgIconeTipoMensagens" ImageUrl="" runat="server" />
                        Mensagens <asp:Label ID="lblMsgEnvRec" CssClass="cssTitulo" runat="server" Text=""></asp:Label>
                        <div style="clear: both; background-color:Scrollbar; height: 1px; width:100%;"></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <!-- GridView de Mensagens Recebidas -->
                        <asp:Panel ID="pnlMensagensRecebidas" runat="server" Visible="False">
                            <uc1:GridMensagensRecebidas ID="ucMensRec" runat="server" />
                        </asp:Panel>

                        <!-- GridView de Mensagens Enviadas -->
                        <asp:Panel ID="pnlMensagensEnviadas" runat="server" Visible="False">
                            <uc1:GridMensagensEnviadas ID="ucMensEnv" runat="server" />                  
                        </asp:Panel>
                    </td>
                </tr>
            </table>        
        </td>
    </tr>
</table>

</asp:Content>
