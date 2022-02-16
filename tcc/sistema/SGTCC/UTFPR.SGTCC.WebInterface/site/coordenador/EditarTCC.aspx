<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditarTCC.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.EditarTCC"
    Title="SGTCC - Editar Trabalho de Conclusão de Curso" %>

<%@ Register Assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <div style="height:50px; width: auto;">
        <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento
        obrigatório!</label>
    </div>
    <fieldset>
    <legend>Editar TCC </legend>
        <table style="width:auto;" cellpadding="5" cellspacing="0">
	        <tr>
		        <td style="text-align:right;"><label class="cssLabel">*Tema:</label></td>
		        <td style="text-align:left;">
			        <asp:TextBox runat="server" ID="txtTema" MaxLength="150" Width="400px" 
                        CssClass="cssTextBox"></asp:TextBox>
		        </td>
		        <td style="text-align:left;">
			        <asp:RequiredFieldValidator runat="server" ID="rfvTema" Display="Dynamic" ControlToValidate="txtTema">Preencha 
                    o Tema.</asp:RequiredFieldValidator>
		        </td>
	        </tr>
	        <tr>
		        <td style="text-align:right;"><label class="cssLabel">*Orientador:</label></td>
		        <td style="text-align:left;">
			            <asp:DropDownList ID="ddlProfessores" runat="server" Width="250"  CssClass="cssTextBox"/>
		        </td>
		        <td style="text-align:left;">
        			
                    <asp:CompareValidator runat="server" 
                        id="cpvProfessor" ControlToValidate="ddlProfessores"
                        ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer">Selecione 
                    um professor orientador.</asp:CompareValidator>
                </td>
	        </tr>
	        <tr>
		        <td style="text-align:right;"><label class="cssLabel">*Aluno:</label></td>
		        <td style="text-align:left;">
			            <asp:DropDownList ID="ddlAluno" runat="server" Width="250"  CssClass="cssTextBox"/>
		        </td>
		        <td style="text-align:left;">
        			
                    <asp:CompareValidator runat="server" 
                        id="CompareValidator1" ControlToValidate="ddlAluno"
                        ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer">Selecione um aluno.
                    </asp:CompareValidator>
                </td>
	        </tr>
	        <tr>
		        <td style="text-align:right;"><label class="cssLabel">Status:</label></td>
		        <td style="text-align:left;">
			            <asp:DropDownList ID="ddlStatus" runat="server" Width="250"  CssClass="cssTextBox"/>
		        </td>
		        <td style="text-align:left;"> </td>
	        </tr>
	        <tr>
		        <td style="text-align:right;"><label class="cssLabel">Data Inicio:</label></td>
		        <td style="text-align:left;">
			            <asp:TextBox ID="txtDataInicio" runat="server" MaxLength="10" CssClass="cssTextBox"></asp:TextBox>
        		    
			            <asp:ImageButton ID="imbCalendar" runat="server" ImageUrl="~/imagens/botoes/calendar.png" ImageAlign="AbsBottom" />
        			    
			            <cc1:MaskedEditExtender ID="meeDataInicio" runat="server" MaskType="Date" 
                            Mask="99/99/9999" TargetControlID="txtDataInicio" ErrorTooltipEnabled="true" CultureName="pt-BR"
                            MessageValidatorTip="true" AutoComplete="False"> 
                        </cc1:MaskedEditExtender>
        		       
		                <cc1:CalendarExtender runat="server" TargetControlID="txtDataInicio" Animated="true" ID="ceeCalendar"
		                     PopupButtonID="imbCalendar">
		                </cc1:CalendarExtender>
		        </td>
		        <td>
		            <cc1:MaskedEditValidator ID="mevDataInicio" runat="server" ControlExtender="meeDataInicio"
		                    ControlToValidate="txtDataInicio" IsValidEmpty="true"  InvalidValueMessage="Data inválida." Display="Dynamic">
                    </cc1:MaskedEditValidator>
		        </td>
	        </tr>
	        <tr>
		        <td style="text-align:right;"><label class="cssLabel">Data Entrega:</label></td>
		        <td style="text-align:left;">
			            <asp:TextBox ID="txtDataEntrega" runat="server" MaxLength="10" CssClass="cssTextBox"></asp:TextBox>
        			
			            <asp:ImageButton ID="imbCalendar2" runat="server" ImageUrl="~/imagens/botoes/calendar.png" ImageAlign="AbsBottom" />
        			    
			            <cc1:MaskedEditExtender ID="meeDataEntrega" runat="server" MaskType="Date" 
                            Mask="99/99/9999" TargetControlID="txtDataEntrega" ErrorTooltipEnabled="true" CultureName="pt-BR"
                            MessageValidatorTip="true" AutoComplete="False"> 
                        </cc1:MaskedEditExtender>
        		       
		                <cc1:CalendarExtender runat="server" TargetControlID="txtDataEntrega" Animated="true" ID="ceeCalendar2"
		                     PopupButtonID="imbCalendar2">
		                </cc1:CalendarExtender>
		        </td>
		        <td>
		            <cc1:MaskedEditValidator ID="mevDataEntrefa" runat="server" ControlExtender="meeDataEntrega"
		                    ControlToValidate="txtDataEntrega" IsValidEmpty="true"  InvalidValueMessage="Data inválida." Display="Dynamic">
                    </cc1:MaskedEditValidator>
		        </td>
	        </tr>

	        <tr>
	            <td style="text-align:right;"><label class="cssLabel">Notas:</label></td>
	            <td> </td>
	        </tr>
	        <tr>
	            <td style="text-align:right;"><label class="cssLabel">Proposta:</label></td>
		        <td style="text-align:left;">
			        <asp:TextBox runat="server" ID="txtNotaProposta" MaxLength="3" Width="40px" 
                        CssClass="cssTextBox"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="meeNotaProposta" runat="server" MaskType="Number"  
                            Mask="999" TargetControlID="txtNotaProposta" PromptCharacter="" 
                            AutoComplete="False">
                    </cc1:MaskedEditExtender>    
		        </td>
	        </tr>
	        <tr>
	            <td style="text-align:right;"><label class="cssLabel">Banca Final:</label></td>
		        <td style="text-align:left;">
			        <asp:TextBox runat="server" ID="txtNotaFinal" MaxLength="3" Width="40px" 
                        CssClass="cssTextBox"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="meeNotaFinal" runat="server" MaskType="Number"  
                            Mask="999" TargetControlID="txtNotaFinal" PromptCharacter="" 
                            AutoComplete="False">
                    </cc1:MaskedEditExtender>
		        </td>
	        </tr>
            <tr>
                <td style="text-align:right;" colspan="2">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="cssBotaoLaranja"/>
                </td>
            </tr>
        </table>
    </fieldset>

    <br />
    <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Text=""></asp:Label>
    
</asp:Content>