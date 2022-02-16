<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditarAviso.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.EditarAviso" 
    title="SGTCC - Editar Aviso" %>
  
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:HiddenField ID="hdnCodigoAviso" runat="server" />

<div style="height:25px; width: auto;">
    <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento
    obrigatório!</label>
</div>

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<div style="width:100%;">

<table style="width:auto;" cellpadding="5" cellspacing="0">
	<tr>
		<td style="text-align:right;"><label class="cssLabel">Data Publicação:</label></td>
		<td style="text-align:left;" colspan="2">
            <asp:Label ID="lblDataPublicacao" runat="server" Text=""></asp:Label>
		</td>
	</tr>		
	<tr>
		<td style="text-align:right;"><label class="cssLabel">*Título:</label></td>
		<td style="text-align:left;">
			<asp:TextBox runat="server" ID="txtTitulo" MaxLength="50" Width="250px" CssClass="cssTextBox"></asp:TextBox>
		</td>
		<td style="text-align:left;">
			<asp:RequiredFieldValidator runat="server" ID="rfvTitulo" Display="Dynamic" ControlToValidate="txtTitulo">Preencha 
            o Título.</asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td style="text-align:right;" valign="top"><label class="cssLabel">*Conteúdo:</label></td>
		<td style="text-align:left;">
            <FCKeditorV2:FCKeditor ID="txtConteudo" runat="server" BasePath="~/fckeditor/" 
            Height="250px" Width="500px">
            </FCKeditorV2:FCKeditor>	
        </td>
		<td style="text-align:left;" valign="top">
			<asp:RequiredFieldValidator runat="server" ID="rfvConteudo" Display="Dynamic" ControlToValidate="txtConteudo">Preencha 
            o Conteúdo.</asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr><td style="height:20px;" colspan="3"></td></tr>
    <tr>
        <td style="text-align:center;" colspan="2">
            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" CssClass="cssBotaoLaranjaPequeno"/>
        </td>
    </tr>    			
</table>

</div>

</asp:Content>
