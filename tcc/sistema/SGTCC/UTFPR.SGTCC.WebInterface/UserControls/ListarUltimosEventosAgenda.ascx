<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ListarUltimosEventosAgenda.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.ListarUltimosEventosAgenda" %>

<div>
    <label class="cssTitulo">Próximos Eventos</label>
</div>

<br /><br />

<div id="divAviso" visible="false" runat="server">
    <asp:Label ID="lblMsgGrid" runat="server" Text="Nenhum evento recente"></asp:Label>
</div>

<div style="clear: both; overflow: auto; height: 300px; width: 200px;">
    <asp:Repeater ID="rptEventos" runat="server" OnLoad="CarregarEventos">
        <ItemTemplate>
            <label style="font-style:italic;"><%#FormatDateTime(Eval("Data"), DateFormat.LongDate)%></label>
            <br />
            <asp:LinkButton ID="lnkEvento" runat="server"
            CommandArgument='<%#FormatDateTime(Eval("Data"), DateFormat.ShortDate)%>' CommandName='Visualizar'>
               <%#Eval("NomeEvento")%>
            </asp:LinkButton>
        </ItemTemplate>

        <SeparatorTemplate>
            <br />
            <br />
        </SeparatorTemplate>
    </asp:Repeater>
</div>