<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="NovoUsuario.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.NovoUsuario" 
    title="SGTCC - Novo Usuário" %>
    
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="height:20px; width: auto;">
    <label class="cssObserv">Observação: Os campos com asterisco (*) são de preenchimento obrigatório!</label>
</div>

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<br />

<div style="float: left;">
<fieldset style="width:550px;">
    <legend>Informe os Dados do Novo Usuário</legend>

    <table style="width:auto;" cellpadding="5" cellspacing="0">
        <tr>
            <td align="right"><label class="cssLabel">*Tipo Usuário:</label></td>
            <td>
                <asp:DropDownList ID="ddlUsuario" runat="server" AutoPostBack="false" CssClass="cssTextBox" ></asp:DropDownList>
            </td>
            <td align="left">
                <asp:CompareValidator runat="server" 
                    id="cpvUsuario" ControlToValidate="ddlUsuario"
                    ValueToCompare="0" Display="Static" Operator="NotEqual" Type="String">Selecione 
                um Tipo de Usuário.</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">*Nº Matrícula:</label></td>
            <td align="left">
                <asp:TextBox ID="txtMatricula" runat="server" MaxLength="8" CssClass="cssTextBox"></asp:TextBox>
                <cc1:MaskedEditExtender ID="meeMatricula" runat="server" MaskType="Number" 
                    Mask="99999999" TargetControlID="txtMatricula" PromptCharacter="" 
                    AutoComplete="False">
                </cc1:MaskedEditExtender>                
            </td>
            <td align="left">
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="txtMatricula" id="rfvMatricula"
                    Display="Static">Preencha a matrícula.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">*Nome Completo:</label></td>
            <td align="left">
                <asp:TextBox ID="txtNome" runat="server" MaxLength="100" Width="225px" CssClass="cssTextBox"></asp:TextBox>
            </td>
            <td align="left"> 
                <asp:RequiredFieldValidator runat="server" id="rfvNome" 
                    ControlToValidate="txtNome" Display="Static">Preencha o Nome.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">*Email:</label></td>
            <td align="left">
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" Width="225px" CssClass="cssTextBox"></asp:TextBox>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator runat="server" id="rfvEmail" 
                    ControlToValidate="txtEmail" Display="Dynamic">Preencha o Email.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">O Email 
                informado é inválido.</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">Telefone:</label></td>
            <td colspan="2"><asp:TextBox ID="txtTelefone" runat="server" CssClass="cssTextBox"></asp:TextBox>
                <cc1:MaskedEditExtender ID="meeTelefone" runat="server" 
                    Mask="(99) 9999-9999" MaskType="Number" TargetControlID="txtTelefone">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">Celular:</label></td>
            <td colspan="2"><asp:TextBox ID="txtCelular" runat="server" CssClass="cssTextBox"></asp:TextBox>
                <cc1:MaskedEditExtender ID="meeCelular" runat="server" 
                    Mask="(99) 9999-9999" MaskType="Number" TargetControlID="txtCelular">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">*Estado:</label></td>
            <td align="left">
                <asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="True" CssClass="cssTextBox"></asp:DropDownList>
            </td>
            <td align="left">
                <asp:CompareValidator runat="server" Text="Selecione um Estado."                             
                id="cpvEstados" ControlToValidate="ddlEstados" 
                ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="right"><label class="cssLabel">*Cidade:</label></td>
            <td align="left">
                <asp:UpdatePanel ID="updPanelCmbCidade" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlEstados" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCidades" runat="server" CssClass="cssTextBox"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left">
                <asp:CompareValidator runat="server" Text="Selecione uma Cidade." id="cpvCidades" 
                    ControlToValidate="ddlCidades" 
                    ValueToCompare="0" Display="Static" Operator="NotEqual" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>
	    <tr><td style="height:25px;" colspan="3"></td></tr>
        <tr>
            <td style="text-align:center;" colspan="2">
        	    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" 
                    CssClass="cssBotaoLaranja" EnableViewState="False" />
       	    </td>
        </tr>                   
    </table>
</fieldset>		
</div> 

<div style="float: left;">
    <fieldset style="width: 100%;">
        <legend>Acesso Rápido</legend>
        
        <div style="float: left;">
                <asp:LinkButton ID="lnkGerenciarTCC" runat="server" CausesValidation="False">
                    <img src="<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_0.gif") %>" 
                    onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_1.gif") %>'"
                    onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_0.gif") %>'"
                    onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_2.gif") %>'"
                    onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/botoes/GerenciarTCC_0.gif") %>'"
                    border="0" alt="Gerenciar TCC" title="Gerenciar TCC" />
                </asp:LinkButton>
        </div>        
    </fieldset>
</div>				

<br/>

</asp:Content>
