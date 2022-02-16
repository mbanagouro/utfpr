<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="VisualizarMensagem.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.VisualizarMensagem" 
    title="SGTCC - Visualizar Mensagem" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="divErro" runat="server" style="width: 100%; clear: both; display: none; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<div id="divMsg" runat="server" style="clear: both;">
    <table style="width:auto;" cellpadding="5" cellspacing="0">
        <tr>
            <td style="text-align: right;">
                <label class="cssLabel">De:</label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblRemetente" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td style="text-align: right;">
                <label class="cssLabel">Assunto:</label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblAssunto" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <br />
    
    <fieldset style="height: 100%">
        <legend>Mensagem</legend>
        
        <div style="padding: 10px 10px 10px 10px;">
            <asp:Label ID="lblConteudo" runat="server"></asp:Label>
        </div>

    </fieldset>
</div>

</asp:Content>
