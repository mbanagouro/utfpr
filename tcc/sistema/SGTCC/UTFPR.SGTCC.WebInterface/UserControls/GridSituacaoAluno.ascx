<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridSituacaoAluno.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.GridSituacaoAluno" %>

<div style="width: 800px; clear: both;">

    <asp:GridView ID="grdSituacaoAlunos" runat="server" CellPadding="2" CellSpacing="1"
    AutoGenerateColumns="False" GridLines="None" CssClass="cssGridGeral"
    DataKeyNames="" AllowPaging="True" PageSize="10" AllowSorting="True" >
        <FooterStyle CssClass="cssGridFooter" />
        <RowStyle CssClass="cssGridRow"/>
        <SelectedRowStyle CssClass="cssGridSelectedRow"  />
        <PagerStyle CssClass="cssGridPager" />
        <HeaderStyle CssClass="cssGridHeader" />
        <EditRowStyle CssClass="cssGridEditRow" />
        <AlternatingRowStyle CssClass="cssAlternatingRow" />
        
        <EmptyDataTemplate>
            Nenhum aluno encontrado
        </EmptyDataTemplate>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" Height="60px" />
        
        <Columns>
            <asp:TemplateField HeaderText="Nº Matrícula">
                <ItemTemplate>
                    <asp:Label ID="lblMatricula" runat="server" Text='<%# eval("Aluno.Matricula") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" HorizontalAlign="Center" />
            </asp:TemplateField>                            

            <asp:TemplateField HeaderText="Aluno">
                <ItemTemplate>
                    <asp:Label ID="lblAluno" runat="server" Text='<%# eval("Aluno.Nome") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50%" />
            </asp:TemplateField>                            
            
            <asp:TemplateField HeaderText="Situação">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# eval("Status") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20%" HorizontalAlign="Center" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Nota Proposta">
                <ItemTemplate>
                    <asp:Label ID="lblNotaProposta" runat="server" Text='<%# eval("NotaProposta") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" HorizontalAlign="Center" />
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Nota Final">
                <ItemTemplate>
                    <asp:Label ID="lblNotaFinal" runat="server" Text='<%# eval("NotaFinal") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" HorizontalAlign="Center" />
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

    <asp:HiddenField ID="hdnNome" runat="server" />
    <asp:HiddenField ID="hdnStatus" runat="server" />

    <div id="divAviso" visible="false" runat="server">
        <asp:Label ID="lblMsgGrid" runat="server" Text="Falha ao carregar a lista de situação dos alunos"></asp:Label>
    </div>

</div>