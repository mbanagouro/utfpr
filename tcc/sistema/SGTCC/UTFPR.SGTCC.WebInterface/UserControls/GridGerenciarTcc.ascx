<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridGerenciarTcc.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.GridGerenciarTcc" %>

<asp:GridView ID="gdvGerenciarTcc" runat="server" CellPadding="2" CellSpacing="1"
AutoGenerateColumns="False" GridLines="None" CssClass="cssGridGeral" 
AllowPaging="True" PageSize="10" >
    <FooterStyle CssClass="cssGridFooter" />
    <RowStyle CssClass="cssGridRow"/>
    <SelectedRowStyle CssClass="cssGridSelectedRow"  />
    <PagerStyle CssClass="cssGridPager" />
    <HeaderStyle CssClass="cssGridHeader" />
    <EditRowStyle CssClass="cssGridEditRow" />
    <AlternatingRowStyle CssClass="cssAlternatingRow" />
    
    <Columns>
        <asp:TemplateField HeaderText="Tema" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblTema" runat="server" Text='<% #eval("Tema") %>'> 
                </asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Aluno" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblAluno" runat="server" Text='<% #eval("Aluno.Nome") %>'> 
                </asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Orientador" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblOrientador" runat="server" Text='<% #eval("Orientador.Nome") %>'> 
                </asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblStatus" runat="server" Text='<% #eval("Status") %>'> 
                </asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
                    
        <asp:TemplateField HeaderText="Data Inicio" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
            <ItemTemplate>
                <asp:Label ID="lblDataInicio" runat="server" Text='<% # FormatDateTime( eval("DataInicio") ,DateFormat.ShortDate) %>'> 
                </asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Data Entrega" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
            <ItemTemplate>
                <asp:Label ID="lblDataEntrega" runat="server" Text='<%# FormatDateTime( eval("DataFim") ,DateFormat.ShortDate) %>'> 
                </asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnDetBanca" runat="server" 
                    ImageUrl="~/Imagens/Icones/img_consultar.gif" 
                    CommandArgument='<%# eval("Codigo") %>' 
                    CommandName="DetalharBanca"
                    ToolTip="Detalhar Banca"
                    AlternateText="Detalhar Banca" />
            </ItemTemplate>
            <ItemStyle Width="30px" HorizontalAlign="Center" />
        </asp:TemplateField>
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEditarTcc" runat="server" 
                    ImageUrl="~/Imagens/Icones/edititem.gif" 
                    CommandArgument='<%# eval("Codigo") %>' 
                    CommandName="EditarTcc"
                    ToolTip="Editar Tcc"
                    AlternateText="Editar Tcc" />
            </ItemTemplate>
            <ItemStyle Width="30px" HorizontalAlign="Center" />
        </asp:TemplateField>

    </Columns>
    
    <EmptyDataTemplate>
        Não há Trabalho(s) cadastrado(s).
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

<asp:HiddenField ID="hdntema" runat="server" />
<asp:HiddenField ID="hdnstatus01" runat="server" />
<asp:HiddenField ID="hdnstatus02" runat="server" />
<asp:HiddenField ID="hdnstatus03" runat="server" />
<asp:HiddenField ID="hdnstatus04" runat="server" />
<asp:HiddenField ID="hdnstatus05" runat="server" />
<asp:HiddenField ID="hdnmatricula" runat="server" />

