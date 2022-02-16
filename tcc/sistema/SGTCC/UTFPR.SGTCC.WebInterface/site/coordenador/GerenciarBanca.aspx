<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GerenciarBanca.aspx.vb"
    MasterPageFile="~/Template.Master" Title="SGTCC - Gerência de Bancas" Inherits="UTFPR.SGTCC.WebInterface.GerenciarBanca" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <fieldset>
    <legend>Informações do TCC </legend>
        <table style="width: auto;" cellpadding="5" cellspacing="0">
            <tr>
                <td style="text-align: right;">
                    <label class="cssLabel">Aluno:</label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblAluno" runat="server" CssClass="cssLabel"></asp:Label>
                </td>
                <td style="text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <label class="cssLabel">Orientador:</label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblOrientador" runat="server" CssClass="cssLabel"></asp:Label>
                </td>
                <td style="text-align: left;">
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <label class="cssLabel">Tema:</label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblTema" runat="server" CssClass="cssLabel"></asp:Label>
                </td>
                <td style="text-align: left;">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="2">
                    <asp:Button ID="btnNovaBanca" runat="server" Text="Nova Banca" CssClass="cssBotaoLaranja" />
                </td>
            </tr>
        </table>
    </fieldset>
    
    <br />   
    
    <fieldset>
    <legend>Bancas </legend>
        <table style="width: auto;" cellpadding="5" cellspacing="0">
            <tr>
                <td style="text-align: left;">
                    <asp:Panel runat="server" ID="pnlProposta" Visible="false" Enabled="false" >
                        <fieldset>
                        <legend>Proposta </legend>
                            <table style="width: auto;" cellpadding="5" cellspacing="0">
                                 <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel"> Local: </label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblLocalProposta" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel">Prof.º Convidado 1:</label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblConvidado01Proposta" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel">Prof.º Convidado 2:</label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblConvidado02Proposta" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel">Data:</label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblDataProposta" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Button ID="btnDeletarProposta" runat="server" Text="Excluir" CssClass="cssBotaoLaranja" />
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Button ID="btnAlterarProposta" runat="server" Text="Alterar" CssClass="cssBotaoLaranja" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
                <td style="text-align: left;">
                    <asp:Panel runat="server" ID="pnlDefesa" Visible="false" Enabled="false">
                        <fieldset>
                        <legend>Defesa</legend>    
                            <table style="width: auto;" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel">Local: </label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblLocalDefesa" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel">Prof.º Convidado 1:</label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblConvidado01Defesa" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel">Prof.º Convidado 2:</label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblConvidado02Defesa" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <label class="cssLabel">Data:</label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblDataDefesa" runat="server" CssClass="cssLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                <td style="text-align: right;">
                                        <asp:Button ID="btnDeletarDefesa" runat="server" Text="Excluir" CssClass="cssBotaoLaranja" />
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Button ID="btnAlterarDefesa" runat="server" Text="Alterar" CssClass="cssBotaoLaranja" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
            </tr>   
    </table> 
    
    <br />
    <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Text=""></asp:Label>
    <br />
    </fieldset>
</asp:Content>
