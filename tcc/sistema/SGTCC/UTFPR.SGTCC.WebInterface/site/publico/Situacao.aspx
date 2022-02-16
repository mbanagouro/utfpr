<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Situacao.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Situacao" 
    title="SGTCC - Situação dos Trabalhos de Conclusão de Curso" %>

<%@ Register src="../../UserControls/GridSituacaoAluno.ascx" tagname="GridSituacaoAluno" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br />

<div>
    <label class="cssTitulo">Situação dos alunos</label>
</div>

<br /><br />

<div style="clear: both;">
    <label class="cssLabel">Confira abaixo a sua situação junto ao trabalho final.</label>
</div>

<br />

<div style="width: 700px;">

    <fieldset>
        <legend>Filtro de Busca</legend>

        <table style="width:auto;" cellpadding="5" cellspacing="0">
            <tr>
                <td style="text-align: right;">
                    Por Nome:
                </td>
                <td>
                    <asp:TextBox ID="txtNome" Width="250px" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="text-align: right;">
                    Por Status:
                </td>
                <td>
                    <asp:DropDownList Width="255px" ID="ddlStatusTcc" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnBuscar" runat="server" Text="Pesquisar" CssClass="cssBotaoLaranjaPequeno"></asp:Button>
                </td>
            </tr>    
        </table>
    
    </fieldset>    
</div>    
   
<br /><br />

<uc1:GridSituacaoAluno ID="grdSituacaoAluno" runat="server" />

</asp:Content>
