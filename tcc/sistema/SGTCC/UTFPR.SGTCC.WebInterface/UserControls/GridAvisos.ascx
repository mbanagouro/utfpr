<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridAvisos.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.GridAvisos" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:GridView ID="gdvAvisos" runat="server" CellPadding="2" CellSpacing="1"
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
        <asp:TemplateField HeaderText="Autor">
            <ItemTemplate>
                <asp:Label ID="lblNome" runat="server" Text='<%# eval("Usuario.Nome") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Título">
            <ItemTemplate>
                <asp:Label ID="lblTitulo" runat="server" Text='<%# eval("Titulo") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Data/Hora">
            <ItemTemplate>
                <asp:Label ID="lblDataHora" runat="server"
                Text='<%# eval("DataPublicacao") %>' ></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="140px" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        
       <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnVisualizar" runat="server" 
                ImageUrl="~/imagens/icones/img_consultar.gif"
                CommandArgument='<%# eval("Codigo") %>' 
                CommandName="Visualizar"
                ToolTip="Visualizar"
                AlternateText="Botão Visualizar" />
            </ItemTemplate>
            <ItemStyle Width="30px" HorizontalAlign="Center" />
        </asp:TemplateField>

       <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnEditar" runat="server" 
                ImageUrl="~/imagens/icones/edititem.gif"
                CommandArgument='<%# eval("Codigo") %>' 
                CommandName="Editar"
                ToolTip="Editar"
                AlternateText="Botão Editar" />
            </ItemTemplate>
            <ItemStyle Width="30px" HorizontalAlign="Center" />
        </asp:TemplateField>
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btnApagar" runat="server" 
                ImageUrl="~/imagens/icones/delete.gif"
                CommandArgument='<%# eval("Codigo") %>' 
                CommandName="Apagar"
                ToolTip="Excluir"
                AlternateText="Botão Excluir"
                OnClientClick="return confirm('Deseja confirmar a exclusão do aviso?');" />
            </ItemTemplate>
            <ItemStyle Width="30px" HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
    
    <EmptyDataTemplate>
        Não há avisos publicados
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
    <asp:Label ID="lblMsgGrid" runat="server" Text="Falha ao carregar os avisos"></asp:Label>
</div>