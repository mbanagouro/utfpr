<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Login.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Login1" 
    title="SGTCC - Login" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table style="width: 100%; height: 100%">
    <tr>
        <td align="center">

            <br /><br />
            
            <label class="cssLabel">Se você possui acesso, entre com os dados abaixo!<br />
            Caso contrário, procure o coordenador da matéria para que seja cadastrado seu perfil!</label>
            
            <br /><br />
            
            <fieldset style="width: 400px;">
            <legend>Entrar</legend>

                <div style="width: 100%; height: 10px; background-color: #FF8C00;">&nbsp;</div>

                <table style="width: 400px; height:100%;">
                    <tr>
                        <td valign="bottom" align="center" style="height: 40%;" >
                            <div>
                                &nbsp;<asp:Label ID="lblMensagem" EnableViewState="False" CssClass="cssError" runat="server" Text=""></asp:Label>
                            </div>
                            <table style="width: auto; top: 200px;" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td valign="bottom" align="right" style="height: 10%;" rowspan="4">
                                        <asp:Image ID="imgLogin" runat="server" Height="128px" Width="128px" ImageUrl="~/imagens/masterPage/login.png" /> 
                                    </td>
                                    <td style="text-align:center;" colspan="2"><label class="cssTitulo">Informe os dados para Login</label></td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;" class="cssLabel">Matrícula:</td>
                                    <td style="text-align:left;"><asp:TextBox runat="server" id="txtMatricula" MaxLength="8" CssClass="cssTextBox" TabIndex="1"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;" class="cssLabel">Senha:</td>
                                    <td style="text-align:left; padding-bottom: 0px;">
                                        <asp:TextBox runat="server" id="txtSenha" TextMode="Password" MaxLength="24" CssClass="cssTextBox" TabIndex="2"></asp:TextBox>
                                        <asp:LinkButton runat="server" id="lnkHelp" >
                                            <asp:Image ID="imgHelp" runat="server" ImageUrl="../../imagens/masterPage/help.png" AlternateText="Esqueceu sua senha?" ToolTip="Esqueceu sua senha?" />
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center;" colspan="2">
                                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" UseSubmitBehavior="true" CssClass="cssBotaoLaranjaPequeno" TabIndex="3"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>	
                    </tr>
                </table>
                
                <div style="width: 100%; height: 10px; background-color: #FF8C00;">&nbsp;</div>
            </fieldset>
        </td>
    </tr>
</table>

</asp:Content>
