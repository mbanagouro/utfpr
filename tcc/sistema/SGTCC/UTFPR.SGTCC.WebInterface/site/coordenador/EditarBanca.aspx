<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditarBanca.aspx.vb"
   Title="SGTCC - Alterar Banca" Inherits="UTFPR.SGTCC.WebInterface.EditarBanca" %>

<%@ Register Assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <asp:ScriptManager ID="scrManager" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div style="height:50px; width: auto;">
        <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento
        obrigatório!</label>
    </div>

<table style="width:auto;" cellpadding="5" cellspacing="0">
	<tr>
		<td style="text-align:right;"><label class="cssLabel">Aluno:</label></td>
		<td style="text-align:left;">
			<asp:Label ID="lblAluno" runat="server" CssClass="cssLabel"></asp:Label>
		</td>
		<td style="text-align:left;">
		</td>
	</tr>
	
	<tr>
		<td style="text-align:right;"><label class="cssLabel">Orientador:</label></td>
		<td style="text-align:left;">
			<asp:Label ID="lblOrientador" runat="server" CssClass="cssLabel"></asp:Label>
		</td>
		<td style="text-align:left;">
		    <asp:HiddenField ID="hfOrientador" runat="server" />
		</td>
	</tr>
	
	<tr>
		<td style="text-align:right;"><label class="cssLabel">Tema:</label></td>
		<td style="text-align:left;">
			<asp:Label ID="lblTema" runat="server" CssClass="cssLabel"></asp:Label>
		</td>
		<td style="text-align:left;">
		</td>
	</tr>

	<tr>
		<td style="text-align:right;"><label class="cssLabel">*Tipo da banca:</label></td>
		<td style="text-align:left;">
			    <asp:Label ID="lblTipoBanca" runat="server" CssClass="cssLabel"></asp:Label>
		</td>
		<td style="text-align:left;">
        </td>
	</tr>
	<tr>
		<td style="text-align:right;">
		    <label class="cssLabel">Local: </label>
		</td>
		<td style="text-align:left;">
			    <asp:TextBox ID="txtLocal" runat="server" MaxLength="15" CssClass="cssTextBox">
			    </asp:TextBox>
		</td>
	</tr>
	<tr>
		<td style="text-align:right;"><label class="cssLabel">*Prof.º Convidado 1:</label></td>
		<td style="text-align:left;">
			    <asp:DropDownList ID="ddlProfConvidado1" runat="server" Width="250"  CssClass="cssTextBox"/>
		</td>
		<td style="text-align:left;">
			
            <asp:CompareValidator runat="server" 
                id="CompareValidator1" ControlToValidate="ddlProfConvidado1"
                ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer">Selecione um professor.
            </asp:CompareValidator>
        </td>
	</tr>
	
	<tr>
		<td style="text-align:right;"><label class="cssLabel">*Prof.º Convidado 2:</label></td>
		<td style="text-align:left;">
			    <asp:DropDownList ID="ddlProfConvidado2" runat="server" Width="250"  CssClass="cssTextBox"/>
		</td>
		<td style="text-align:left;">
            <asp:CompareValidator runat="server" 
                id="CompareValidator2" ControlToValidate="ddlProfConvidado2"
                ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer">Selecione um professor.
            </asp:CompareValidator>
            
        </td>
	</tr>
	<tr>
	    <td></td>
	    <td>
	        <asp:CompareValidator runat="server" 
                id="cvProfessores" ControlToValidate="ddlProfConvidado2" ControlToCompare="ddlProfConvidado1"
                 ValueToCompare="ddlProfConvidado1.SelectedValue" Display="Static" Operator="NotEqual" Type='Integer'>
                Banca deve ter dois convidados diferentes.
            </asp:CompareValidator>
	    </td>
	    <td></td>
	</tr>

	<tr>
		<td style="text-align:right;">
		    <label class="cssLabel">*Data:</label>
		</td>
		<td style="text-align:left;">
			    <asp:TextBox ID="txtData" runat="server" MaxLength="10" CssClass="cssTextBox">
			    </asp:TextBox>
			    
			    <asp:ImageButton ID="imbCalendar" runat="server" ImageUrl="~/imagens/botoes/calendar.png" ImageAlign="AbsBottom" />
			    
			    <cc1:MaskedEditExtender ID="meeData" runat="server" MaskType="Date" 
                    Mask="99/99/9999" TargetControlID="txtData" ErrorTooltipEnabled="true" CultureName="pt-BR"
                    MessageValidatorTip="true" AutoComplete="False"> 
                </cc1:MaskedEditExtender>
		       
		        <cc1:CalendarExtender runat="server" TargetControlID="txtData" Animated="true" ID="meeCalendar"
		             PopupButtonID="imbCalendar">
		        </cc1:CalendarExtender>
		</td>
		<td style="text-align:left;">
			<cc1:MaskedEditValidator ID="mevData" runat="server" ControlExtender="meeData" ControlToValidate="txtData"
			        IsValidEmpty="false"  
                    EmptyValueMessage="Preencha a Data." InvalidValueMessage="Data inválida." Display="Dynamic">
            </cc1:MaskedEditValidator>
		</td>
	</tr>
	<tr>
		<td style="text-align:right;">
		    <label class="cssLabel">*Horário:</label>
		</td>
		<td style="text-align:left;">
			    <asp:DropDownList ID="ddlHora" runat="server" Width="80px"  CssClass="cssTextBox"/>
		</td>
		<td style="text-align:left;">
			<asp:CompareValidator runat="server" 
                id="CompareValidator3" ControlToValidate="ddlHora"
                ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer">Selecione um horário.
            </asp:CompareValidator>
		</td>
	</tr>
	<tr>
	    <td colspan="3"></td>
	</tr>
    <tr>
        <td style="text-align:right;" colspan="3">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="cssBotaoLaranja"/>
        </td>
    </tr>
</table>
<br />
<asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Text=""></asp:Label>
</asp:Content>