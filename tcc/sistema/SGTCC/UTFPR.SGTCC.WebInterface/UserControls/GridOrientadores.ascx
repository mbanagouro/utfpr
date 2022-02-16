<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridOrientadores.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.GridOrientadores" %>

<div style="width: 500px;">
    <asp:GridView ID="grdOrientadores" runat="server" CellPadding="2" CellSpacing="1"
    AutoGenerateColumns="False" GridLines="None" CssClass="cssGridGeral"
    DataKeyNames="" AllowPaging="True" PageSize="10" >
        <FooterStyle CssClass="cssGridFooter" />
        <RowStyle CssClass="cssGridRow"/>
        <SelectedRowStyle CssClass="cssGridSelectedRow"  />
        <PagerStyle CssClass="cssGridPager" />
        <HeaderStyle CssClass="cssGridHeader" />
        <EditRowStyle CssClass="cssGridEditRow" />
        <AlternatingRowStyle CssClass="cssAlternatingRow" />
        
        <EmptyDataTemplate>
            Não existem orientadore(s) disponíveis
        </EmptyDataTemplate>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" Height="60px" />
        
        <Columns>
            <asp:TemplateField HeaderText="Professor">
                <ItemTemplate>
                    <asp:Label ID="lblProfessor" runat="server" Text='<%# eval("Nome") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80%" />
            </asp:TemplateField>                            
            
            <asp:TemplateField HeaderText="Quant. Orientandos">
                <ItemTemplate>
                    <asp:Label ID="lblQuantidadeAlunos" runat="server" Text='<%# eval("QuantidadeOrientandos") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20%" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        
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
</div>