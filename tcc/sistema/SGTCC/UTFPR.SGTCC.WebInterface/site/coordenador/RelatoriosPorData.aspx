<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="RelatoriosPorData.aspx.vb" 
    Title="SGTCC - Relatório de TCC" Inherits="UTFPR.SGTCC.WebInterface.RelatorioTCC" %>

<%@ Register Assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">


        <fieldset>
        <legend>Filtros: </legend>
        <br />
        <label class="cssLabel">Informe o perído desejado ou deixe em branco para listar todos os registros!</label>
        <br />
        <table style="width:auto;" cellpadding="5" cellspacing="0">
            <tr>
                <td colspan="2"></td>
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
		        <td style="text-align:right;"><label class="cssLabel">Data Fim:</label></td>
		        <td style="text-align:left;">
			            <asp:TextBox ID="txtDataFim" runat="server" MaxLength="10" 
                            CssClass="cssTextBox"></asp:TextBox>
        			
		                <asp:ImageButton ID="imbCalendar2" runat="server" ImageUrl="~/imagens/botoes/calendar.png" ImageAlign="AbsBottom" />
        			    
			            <cc1:MaskedEditExtender ID="meeDataFim" runat="server" MaskType="Date" 
                            Mask="99/99/9999" TargetControlID="txtDataFim" ErrorTooltipEnabled="true" CultureName="pt-BR"
                            MessageValidatorTip="true" AutoComplete="False"> 
                        </cc1:MaskedEditExtender>
        		       
		                <cc1:CalendarExtender runat="server" TargetControlID="txtDataFim" Animated="true" ID="ceeCalendar2"
		                     PopupButtonID="imbCalendar2">
		                </cc1:CalendarExtender>
		        </td>
		        <td>
		            <cc1:MaskedEditValidator ID="mevDataEntrefa" runat="server" ControlExtender="meeDataFim"
		                    ControlToValidate="txtDataFim" IsValidEmpty="true"  InvalidValueMessage="Data inválida." Display="Dynamic">
                    </cc1:MaskedEditValidator>
		        </td>
	        </tr>
        </table>
    </fieldset>   

    <fieldset>
        <legend>Relatórios e Documentos </legend>
        
        <br />
        <label class="cssLabel">Clique em um dos ícones abaixo para gerar o relatório!</label>
        <br />
        <br />
        <div style="float: left;">
            <asp:LinkButton ID="lnkRelBanca" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/relBanca_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relBanca_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relBanca_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relBanca_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relBanca_0.gif") %>'"
                border="0" alt="Relatório de Bancas" title="Relatório de Bancas" />
            </asp:LinkButton>
        </div>
        <div style="float: left;">
            <asp:LinkButton ID="lnkRelAprovados" runat="server">
                <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/relAprovados_0.gif") %>" 
                onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relAprovados_1.gif") %>'"
                onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relAprovados_0.gif") %>'"
                onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relAprovados_2.gif") %>'"
                onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/relAprovados_0.gif") %>'"
                border="0" alt="Relatório de Aprovados" title="Relatório de Aprovados" />
            </asp:LinkButton>
        </div>
    </fieldset> 
</asp:Content> 
