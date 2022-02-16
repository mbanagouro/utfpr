<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="NovoAviso.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.NovoAviso" 
    title="SGTCC - Novo Aviso" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="height:30px; width: auto;">
    <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento
    obrigatório!</label>
</div>

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<table style="width:auto;" cellpadding="5" cellspacing="0">
	<tr>
		<td style="text-align:right;">
		    <label class="cssLabel">*Título:</label>
		</td>
		<td style="text-align:left;">
			<asp:TextBox runat="server" ID="txtTitulo" MaxLength="50" Width="250px" CssClass="cssTextBox"></asp:TextBox>
		</td>
		<td style="text-align:left;">
			<asp:RequiredFieldValidator runat="server" ID="rfvTitulo" Display="Dynamic" ControlToValidate="txtTitulo">Preencha 
            o Título.</asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td style="text-align:right;" valign="top">
		    <label class="cssLabel">*Conteúdo:</label>
		</td>
		<td style="text-align:left;">
            <obout:Editor ID="editor" runat="server" Submit=false PreviewMode=false 
            QuickTyping=false ModeSwitch=false NoUnicode=false ShowQuickFormat=false Appearance=custom >
                <DefaultTable Height="250" Width="500" />
                <Buttons>
                    <obout:Method Name=Copy />
                    <obout:Method Name=Cut />
                    <obout:Method Name=Paragraph />
                    <obout:Method Name=JustifyLeft />
                    <obout:Method Name=JustifyRight />
                    <obout:Method Name=JustifyCenter />
                    <obout:Method Name=JustifyFull />
                    <obout:Method Name=BulletedList />
                    <obout:Method Name=OrderedList />
                    <obout:Method Name=BackColor />
                    <obout:Method Name=BackColorClear />
                    <obout:Method Name=ForeColor />
                    <obout:Method Name=ForeColorClear />
                    <obout:Toggle Name=Bold />
                    <obout:Toggle Name=Italic />
                    <obout:Toggle Name=Underline />
                    <obout:HorizontalSeparator />
                    <obout:Method Name="Undo" />
                    <obout:Method Name="Redo" />
                    <obout:HorizontalSeparator />
                    <obout:Method Name="ClearStyles" />
                    <obout:VerticalSeparator />
                    <obout:Select Name="FontName" />
                    <obout:Select Name="FontSize" />
                </Buttons>                
            </obout:Editor>
		</td>
		<td style="text-align:left;"  valign="top">
            <asp:RequiredFieldValidator ID="rfvConteudo" ControlToValidate="editor" EnableClientScript="True" text="Editor's content is empty" runat="server" />
		</td>
	</tr>
	<tr><td style="height:20px;" colspan="3"></td></tr>
    <tr>
        <td style="text-align:center;" colspan="2">
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="cssBotaoLaranja"/>
        </td>
    </tr>    			
</table>

</asp:Content>
