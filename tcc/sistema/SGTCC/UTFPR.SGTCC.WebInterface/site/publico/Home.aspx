<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Home.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Home" 
    title="SGTCC - Home" %>

<%@ Register src="../../UserControls/ListarUltimosAvisos.ascx" tagname="ListarUltimosAvisos" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div id="divTop" style="height: 30px; padding: 5px 5px 5px 5px">
    <div style="float: left;" >
        <label class="cssLabel">Tecnologia em Análise e Desenvolvimento de Sistemas</label><br />
        <label class="cssTitulo">Sistema Gerenciador de Trabalhos de Conclusão de Curso</label>
    </div>
    
    <div style="float: right; text-align: right;" >
        <label class="cssLabel">Professor Responsável</label> <br />
        <b>
            <a id="hlkMailCoordenador" runat="server">
                <asp:Label ID="lblNomeCoordenador" runat="server" Text=""></asp:Label>
            </a>
        </b>
    </div>       
</div> 

<br />   
<div style="background-color:Scrollbar; height: 1px; width:100%;"></div>    
<br />
    
<div id="divLeft" style="float: left; width: 300px; word-wrap: break-word;">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/masterPage/propostas.png" /> 
        <div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>
        <label class="cssTitulo">Datas Propostas</label>   
        <br /><br />
        <label class="cssLabel">
            Entrega: 27 a 31 de outubro de 2008
            <br />
            Bancas: 17 a 28 de novembro de 2008
        </label>      
    </div>
    <br />
    <div style="clear: both;">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/masterPage/banca_final.png" /> 
        <div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>
        <label class="cssTitulo">Datas Banca Final</label>   
        <br /><br />
        <label class="cssLabel">
            Entrega: 27 a 31 de outubro de 2008
            <br />
            Bancas: 17 a 28 de novembro de 2008 
        </label>
    </div>  
    <br />
    <div style="clear: both;">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/imagens/masterPage/como_estou.png" /> 
        <div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>
        <label class="cssTitulo">Como estou?</label>   
        <br /><br />
        <label class="cssLabel">
            Confira <a href="Situacao.aspx">aqui</a> a sua situação junto ao trabalho final.  
        </label>
    </div>        
</div>

<div style="float: left; width:30px;">&nbsp;</div>

<div id="divCenter" style="float: left; width: 300px; word-wrap: brek-word;">
    
    <div>
        <asp:Image ID="imgProgramese" runat="server" ImageUrl="~/imagens/masterPage/programese.png" /> 
        <div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>
        <label class="cssTitulo">Programe-se</label>
        <br /><br />
        <label class="cssLabel">
            Os alunos devem procurar os professores orientadores para defnição dos temas e escrita da proposta com antecedência. 
            Isto para evitar notas baixas na proposta que, seguindo as novas regras do TD do curso, tem peso 3. 
        </label> 
    </div>
    
    <br />
    
    <div style="clear: both;">
        <asp:Image ID="imgCalendario" runat="server" ImageUrl="~/imagens/masterPage/calendario.png" /> 
        <div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>
        <label class="cssTitulo">Calendário</label>        
        <br /><br />
        <label class="cssLabel">
            Confira aqui as datas de propostas e bancas finais para o segundo semestre 2008. 
        </label>
    </div>
    
    <br />
    
    <div style="clear: both;">
        <asp:Image ID="imgOrientadores" runat="server" ImageUrl="~/imagens/masterPage/orientadores.png" /> 
        <div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>
        <label class="cssTitulo">Orientadores</label>   
        <br /><br />
        <label class="cssLabel">
            Conheça <a href="Orientadores.aspx">aqui</a> a lista completa dos professores orientadores. 
            Converse com eles e procure um tema que seja adequado ao trabalho final.
        </label>
        <br />
    </div>
    
</div>

<div style="float: left; width:30px;">&nbsp;</div>

<div id="divRight" style="float: left; width: 260px;">
    <uc1:ListarUltimosAvisos ID="ListarUltimosAvisos1" runat="server" />
</div>
         
</asp:Content>
