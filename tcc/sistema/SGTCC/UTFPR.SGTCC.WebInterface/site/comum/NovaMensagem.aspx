<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="NovaMensagem.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.NovaMensagem" 
    title="SGTCC - Nova Mensagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="height:20px; width: auto;">
    <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento obrigatório!</label>
</div>

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" Font-Bold="True" runat="server" Text=""></asp:Label>
</div>

<table style="width:auto;" cellpadding="5" cellspacing="0">
    <tr>
        <td style="text-align: right;">
            <label class="cssLabel">Para:</label>
        </td>
        <td style="text-align: left;" colspan="2">
            <asp:DropDownList ID="ddlDestinatario" runat="server">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td style="text-align: right;">
            <label class="cssLabel">*Assunto:</label>
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="txtAssunto" CssClass="cssTextBox" MaxLength="100" runat="server" Width="200px">
            </asp:TextBox>
            &nbsp;
            
            <asp:RequiredFieldValidator ID="rfvAssunto" runat="server" 
            ControlToValidate="txtAssunto">Preencha o Assunto</asp:RequiredFieldValidator>
        </td>
    </tr>
    
    <tr>
        <td style="text-align: right;"> 
            <label class="cssLabel">Prioridade:</label>
        </td>
        <td style="text-align: left;">
            <asp:DropDownList ID="ddlPrioridade" runat="server">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td style="text-align: right;" valign="top">
            <label class="cssLabel">*Mensagem:</label>
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="txtMensagem" CssClass="cssTextBox" runat="server" Width="500px" Height="200px">
            </asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="rfvMensagem" runat="server" 
            ControlToValidate="txtMensagem">Preencha a Mensagem</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;" colspan="2">
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="cssBotaoLaranja"/>
        </td>
    </tr>    
</table>

</asp:Content>
