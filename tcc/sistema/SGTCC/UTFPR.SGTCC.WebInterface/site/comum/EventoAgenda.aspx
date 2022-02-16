<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EventoAgenda.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.EventoAgenda" 
    title="SGTCC - Evento da Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="height:20px; width: auto;">
    <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento obrigatório!</label>
</div>

<div style="height: 20px;">
    <asp:Label ID="lblMensagem" EnableViewState="false" runat="server" Text=""></asp:Label>
</div>

<table style="width: auto;" cellpadding="5" cellspacing="0">
    <tr>
        <td style="text-align:right;">
            <label class="cssLabel">Data:</label>
        </td>
        <td style="text-align:left;" colspan="2">
            <asp:Label ID="lblData" class="cssLabel" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="hdnData" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align:right;">
            <label class="cssLabel">*Título:</label>
        </td>
        <td style="text-align:left;" colspan="2">
            <asp:TextBox ID="txtTitulo" CssClass="cssTextBox" MaxLength="50" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" 
            ErrorMessage="O título do evento deve ser preenchido!"
            ControlToValidate="txtTitulo">
            </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="text-align:right;" valign="top">
            <label class="cssLabel">*Descrição:</label>
        </td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtDescricao" CssClass="cssTextBox" TextMode="MultiLine" 
            MaxLength="750" Width="500px" Height="200px" runat="server"
            Wrap="False"></asp:TextBox>
        </td>
        <td style="text-align:left;" valign="top">
            <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" 
            ErrorMessage="A descrição do evento deve ser preenchida!"
            ControlToValidate="txtDescricao">
            </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2">
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Visible="False" CssClass="cssBotaoLaranjaPequeno"/>
            &nbsp;
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Visible="False" CssClass="cssBotaoLaranjaPequeno"/>
            &nbsp;
            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" Visible="False" CssClass="cssBotaoLaranjaPequeno"/>
        </td>
    </tr>        
</table>

</asp:Content>
