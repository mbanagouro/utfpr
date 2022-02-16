<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="RecuperarSenha.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.RecuperarSenha" 
    title="SGTCC - Recuperar Senha" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<label class="cssTitulo">Recupere sua senha</label>

<br /><br /><br />

<label class="cssLabel">Para recuperar a sua senha, informe sua matrícula e o seu email cadastrado no sistema.<br />
Sua nova senha será enviada pelo seu email!</label>

<br /><br /><br />

<fieldset style="width: 500px;">
    <legend>Informe os Dados</legend>
 
    <table style="width:auto;" cellpadding="5" cellspacing="0">
        <tr>
            <td align="right"><label class="cssLabel">*Nº Matrícula:</label></td>
            <td align="left">
                <asp:TextBox ID="txtMatricula" runat="server" MaxLength="8" CssClass="cssTextBox"></asp:TextBox>
                <cc1:MaskedEditExtender ID="meeMatricula" runat="server" MaskType="Number" 
                    Mask="99999999" TargetControlID="txtMatricula" PromptCharacter=""
                    AutoComplete="False">
                </cc1:MaskedEditExtender>                
            </td>
            <td align="left">
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="txtMatricula" id="rfvMatricula"
                    Display="Static">Preencha a matrícula.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">*Email:</label></td>
            <td align="left">
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" Width="225px" CssClass="cssTextBox"></asp:TextBox>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator runat="server" id="rfvEmail" 
                    ControlToValidate="txtEmail" Display="Dynamic">Preencha o Email.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">O Email 
                informado é inválido.</asp:RegularExpressionValidator>
            </td>
        </tr>
	    <tr><td style="height:20px;" colspan="3"></td></tr>
        <tr>
            <td style="text-align:center;" colspan="2">
        	    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                    CssClass="cssBotaoLaranjaPequeno" EnableViewState="False" />
       	    </td>
        </tr>     
    </table>
</fieldset>

</asp:Content>
