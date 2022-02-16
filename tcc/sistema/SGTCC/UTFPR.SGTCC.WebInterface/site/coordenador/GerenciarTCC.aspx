<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="GerenciarTCC.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.ConsultarTCC"
 Title="SGTCC - Consulta de Trabalho de Conclusão de Curso" %>

<%@ Register src="~/UserControls/GridGerenciarTcc.ascx" tagname="GridGerenciarTcc" tagprefix="uc1" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <fieldset>
    <legend>Filtros: </legend>
        <table style="width:auto;" cellpadding="5" cellspacing="0">
        <tr>
		    <td style="text-align:right;"><label class="cssLabel">Tema:</label></td>
		    <td style="text-align:left;">
			    <asp:TextBox runat="server" ID="txtTema" MaxLength="150" Width="350px" CssClass="cssTextBox"></asp:TextBox>
		    </td>
	    </tr>
	    <tr>
		    <td style="text-align:right;"><label class="cssLabel">Orientador:</label></td>
		    <td style="text-align:left;">
			    <asp:DropDownList ID="ddlProfessores" runat="server" Width="250"  CssClass="cssTextBox"/>
		    </td>
	    </tr>
	    <tr>
		    <td style="text-align:right;"><label class="cssLabel">Aluno:</label></td>
		    <td style="text-align:left;">
			    <asp:DropDownList ID="ddlAlunos" runat="server" Width="250" CssClass="cssTextBox"/>
			    <asp:Label ID="lblErroDuasMatriculas" CssClass="cssError" runat="server" ></asp:Label>
		    </td>
	    </tr>
        <tr>
            <td style="text-align:right;"><label class="cssLabel">Status:</label></td>
            <td style="text-align:left;">
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chbStatus01" runat="server" CssClass="cssLabel" Text="Proposta" /> 
                        </td>
                        <td>
                            <asp:CheckBox ID="chbStatus02" runat="server" CssClass="cssLabel" Text="Matriculado" /> 
                        </td>
                        <td>
                            <asp:CheckBox ID="chbStatus03" runat="server" CssClass="cssLabel" Text="Banca" /> 
                        </td>
                        <td>
                            <asp:CheckBox ID="chbStatus04" runat="server" CssClass="cssLabel" Text="Aprovado" /> 
                        </td>
                        <td>
                            <asp:CheckBox ID="chbStatus05" runat="server" CssClass="cssLabel" Text="Desistente" /> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>	
        <tr>
            <td style="text-align:right;" colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="cssBotaoLaranja"/>
            </td>
            <td style="text-align:right;" colspan="2">
                <asp:Button ID="btnNovoTCC" runat="server" Text="Novo TCC" CssClass="cssBotaoLaranja"/>
            </td>
        </tr>    		
        </table>
    </fieldset>

    <uc1:GridGerenciarTcc ID="gridGerenciarTcc" runat="server" />

    <br />
    <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Text=""></asp:Label>
</asp:Content>