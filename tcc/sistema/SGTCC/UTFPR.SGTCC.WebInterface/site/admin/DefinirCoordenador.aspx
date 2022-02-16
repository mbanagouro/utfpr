<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="DefinirCoordenador.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.DefinirCoordenador"
    title="SGTCC - Definir Coordenador" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

<div style="height:50px; width: auto;">
    <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento
    obrigatório!</label>
</div>

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<table style="width:auto;" cellpadding="5" cellspacing="0">
	<tr>
		<td style="text-align:right;">
		    <label class="cssLabel">Coordenador Atual:</label>     
		</td>
		<td style="text-align:left;">
			<asp:Label ID="lblCoordenadorAtual" runat="server" Font-Bold="True" Text=""></asp:Label> 
		</td>
	</tr>
	<tr>
	    <td>
	        <label class="cssLabel">Novo Coordenador:</label>     
	    </td>
	    <td>
	        <asp:DropDownList ID="droplistProfessores" runat="server" Width="250" CssClass="cssTextBox"/>
	    </td>
	    <td>
	        <asp:CompareValidator runat="server" id="CompareValidator1" ControlToValidate="droplistProfessores"
                                  ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer">
                 Selecione um professor.
            </asp:CompareValidator>
	    </td>
	    
	</tr>
    <tr>
        <td style="text-align:right;" colspan="2">
            <asp:Button ID="btnCadastrar" runat="server" Text="Salvar" CssClass="cssBotaoLaranja"/>
        </td>
    </tr>    			
</table>

</asp:Content>
