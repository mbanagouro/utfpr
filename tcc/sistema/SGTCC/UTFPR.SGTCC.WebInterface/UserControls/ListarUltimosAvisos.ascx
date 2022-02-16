<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ListarUltimosAvisos.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.ListarUltimosAvisos" %>

<div id="divTituloUltimosAvisos">
    <asp:Image ID="imgAvisos" runat="server" ImageUrl="~/imagens/icones/avisos.png" /> 
    <div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>
    <label class="cssTitulo">Últimos Avisos</label>
</div>

<br />

<div id="divConteudoAvisos">
    <asp:Repeater ID="rptAvisos" runat="server" OnLoad="CarregarAvisos">
        <ItemTemplate>
            <b>[<%#FormatDateTime(Eval("DataPublicacao"), DateFormat.ShortDate)%>]</b>
            <br />
            <asp:LinkButton ID="lnkAviso" runat="server"
            CommandArgument='<%#Eval("Codigo")%>' CommandName='Visualizar'>
               <%#Eval("Titulo")%>
            </asp:LinkButton>
            <br /><br />
        </ItemTemplate>
    </asp:Repeater>
</div>

<div id="divAviso" visible="false" runat="server">
    <asp:Label ID="lblMsgGrid" runat="server" Text="Nenhum aviso recente"></asp:Label>
</div>