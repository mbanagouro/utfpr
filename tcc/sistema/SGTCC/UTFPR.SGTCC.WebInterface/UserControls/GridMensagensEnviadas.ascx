<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridMensagensEnviadas.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.GridMensagensEnviadas" %>

<asp:GridView ID="gdvMensagensEnviadas" runat="server" CellPadding="2" CellSpacing="1"
AutoGenerateColumns="False" GridLines="None" CssClass="cssGridGeral"
AllowPaging="True" PageSize="10" >
    <FooterStyle CssClass="cssGridFooter" />
    <RowStyle CssClass="cssGridRow"/>
    <SelectedRowStyle CssClass="cssGridSelectedRow" />
    <PagerStyle CssClass="cssGridPager" />
    <HeaderStyle CssClass="cssGridHeader" />
    <EditRowStyle CssClass="cssGridEditRow" />
    <AlternatingRowStyle CssClass="cssAlternatingRow" />
    
    <Columns>
        <asp:TemplateField HeaderImageUrl="~/imagens/icones/img_hpri.png">
            <ItemTemplate>
                <asp:HiddenField ID="hdnPrioridade" runat="server"
                Value='<%# eval("Prioridade") %>' />
                <asp:Image ID="imgPrioridade" runat="server" 
                BorderStyle="None"/>                                                    
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="17px" />
        </asp:TemplateField>        
        
        <asp:TemplateField HeaderImageUrl="~/imagens/icones/img_hmail.png">
            <ItemTemplate>
                <asp:HiddenField ID="hdnLido" runat="server"
                Value='<%# eval("MensagemLida") %>' />
                <asp:Image ID="imgLido" runat="server" 
                BorderStyle="None"/>                                                    
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="17px" />
        </asp:TemplateField>   

        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Para">
            <ItemTemplate>
                <%# Formatar(eval("Usuarios")) %>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Assunto">
            <ItemTemplate>
                <asp:LinkButton ID="btnVerMensagemEnv" runat="server" 
                Text='<%# eval("Assunto") %>'
                CommandArgument='<%# eval("Codigo") %>' CommandName="VerMensagem" ></asp:LinkButton>                                    
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="300px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Data/Hora">
            <ItemTemplate>
                <%# eval("Data") %>
            </ItemTemplate>
            <ItemStyle Width="140px" HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
    
    <EmptyDataTemplate>
        Não há mensagens Enviadas
    </EmptyDataTemplate>
    <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" Height="60px" />
    
    <PagerSettings Visible="False" />
</asp:GridView>                    

<asp:Panel ID="pnlPaginacao" CssClass="cssGridFooter" runat="server">
    <div style="padding-top: 3px; float: left; margin-left: 5px;">
        Página <asp:Label ID="lblPagAtual" runat="server"></asp:Label> 
        de     <asp:Label ID="lblTotalPag" runat="server"></asp:Label> 
    </div>
    
    <div style="padding-top: 3px; float: right; margin-right: 5px;">
        <asp:LinkButton ID="lnkAnterior" runat="server">Anterior</asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="lnkProxima" runat="server">Próximo</asp:LinkButton>
    </div>
</asp:Panel>  

<div id="divAviso" visible="false" runat="server">
    <asp:Label ID="lblMsgGrid" runat="server" Text="Falha ao carregar as mensagems enviadas"></asp:Label>
</div>