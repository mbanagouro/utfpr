<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Perfil.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Perfil" 
    title="SGTCC - Perfil" %>
    
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>        
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="height:30px; width: auto;">
    <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento
    obrigatório!</label>
</div>

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" Font-Bold="True" runat="server" Text=""></asp:Label>
</div>

<div style="width:510px; float: left;">
    <fieldset>
        <legend>Alterar Perfil</legend>

        <table style="width:100%;" cellpadding="4" cellspacing="0">
            <tr>
                <td style="text-align:right;"><label class="cssLabel">Nº Matrícula:</label></td>
                <td style="text-align:left;">
                    <asp:Label ID="lblMatricula" Font-Bold="True" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">*Nome Completo:</label></td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtNome" runat="server" MaxLength="100" Width="225px" CssClass="cssTextBox"></asp:TextBox>
                </td>
                <td style="text-align:left;">
                    <asp:RequiredFieldValidator runat="server" id="rfvNome" ValidationGroup="A"
                        ControlToValidate="txtNome" Display="Static">Preencha o Nome.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">*Email:</label></td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" Width="225px" CssClass="cssTextBox"></asp:TextBox>
                </td>
                <td style="text-align:left;">
                    <asp:RequiredFieldValidator runat="server" id="rfvEmail" ValidationGroup="A"
                        ControlToValidate="txtEmail" Display="Dynamic">Preencha o Email.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                        ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="A"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">O Email 
                    informado é inválido.</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">Telefone:</label></td>
                <td style="text-align:left;" colspan="2"><asp:TextBox ID="txtTelefone" runat="server" CssClass="cssTextBox"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="meeTelefone" runat="server" 
                        Mask="(99) 9999-9999" MaskType="Number" TargetControlID="txtTelefone">
                    </cc1:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">Celular:</label></td>
                <td style="text-align:left;" colspan="2"><asp:TextBox ID="txtCelular" runat="server" CssClass="cssTextBox"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="meeCelular" runat="server" 
                        Mask="(99) 9999-9999" MaskType="Number" TargetControlID="txtCelular">
                    </cc1:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">*Estado:</label></td>
                <td style="text-align:left;">
                    <asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="True" CssClass="cssTextBox"></asp:DropDownList>
                </td>
                <td style="text-align:left;">                    
                    <asp:CompareValidator runat="server" Text="Selecione um Estado."                             
                    id="cpvEstados" ControlToValidate="ddlEstados" ValidationGroup="A"
                    ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">*Cidade:</label></td>
                <td style="text-align:left;">
                    <asp:UpdatePanel ID="updPanelCmbCidade" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlEstados" EventName="" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCidades" runat="server" CssClass="cssTextBox"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="text-align:left;">                    
                    <asp:CompareValidator runat="server" Text="Selecione uma Cidade." id="cpvCidades" 
                        ControlToValidate="ddlCidades" ValidationGroup="A"
                        ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr><td style="height:25px;" colspan="3"></td></tr>
            <tr>
                <td style="text-align:center;" colspan="3">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" ValidationGroup="A" CssClass="cssBotaoLaranjaPequeno"/>
                </td>
            </tr>  
        </table>    
    </fieldset>
</div>

<div style="float: left; width: 440px;">
    <fieldset>
        <legend>Alterar Senha</legend>
        
        <table style="width:auto;" cellpadding="4" cellspacing="0">
            <tr>
                <td style="text-align:right;"><label class="cssLabel">*Senha Atual:</label></td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtSenhaAtual" runat="server" TextMode="Password" 
                        MaxLength="10" CssClass="cssTextBox"></asp:TextBox>
                </td>
                <td style="text-align:left;">                        
                    <asp:RequiredFieldValidator ID="rfvSenhaAtual" runat="server" ValidationGroup="B"
                        ControlToValidate="txtSenhaAtual">Preencha a senha atual.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">*Senha Nova:</label></td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtSenhaNova" runat="server" TextMode="Password" 
                        MaxLength="10" CssClass="cssTextBox"></asp:TextBox>
                </td>
                <td style="text-align:left;">                        
                    <asp:RequiredFieldValidator ID="rfvSenhaNova" runat="server" ValidationGroup="B"
                        ControlToValidate="txtSenhaNova" Display="Dynamic">Preencha a nova 
                    senha.</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtSenhaAtual" ControlToValidate="txtSenhaNova" ValidationGroup="B"
                        Display="Dynamic" Operator="NotEqual">A senha nova não deve ser igual a 
                    atual.</asp:CompareValidator>                
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="cssLabel">*Confirmar Senha Nova:</label></td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtConfirmSenhaNova" runat="server" TextMode="Password" 
                        MaxLength="10" CssClass="cssTextBox"></asp:TextBox>
                </td>
                <td style="text-align:left; word-break: break-word;">                        
                    <asp:RequiredFieldValidator ID="rfvConfirmNova" runat="server" ValidationGroup="B"
                        Display="Dynamic" ControlToValidate="txtConfirmSenhaNova">Preencha a confirmação da nova senha.</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cpvComfirmSenhaNova" runat="server" Display="Dynamic" ValidationGroup="B"
                        ControlToValidate="txtConfirmSenhaNova" ControlToCompare="txtSenhaNova">Senha diferente da
                    senha nova.</asp:CompareValidator>
                </td>
            </tr>     
            <tr><td style="height:25px;" colspan="3"></td></tr>      
            <tr>
                <td colspan="3" align="center">
        	        <asp:Button ID="btnSalvarNovaSenha" runat="server" Text="Salvar" ValidationGroup="B" CssClass="cssBotaoLaranjaPequeno" />
                </td>
            </tr>           
        </table>        
    </fieldset>
</div>

</asp:Content>
