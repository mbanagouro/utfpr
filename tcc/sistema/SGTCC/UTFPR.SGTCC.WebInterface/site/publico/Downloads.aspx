<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Downloads.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.Downloads" 
    title="SGTCC - Trabalhos Disponíveis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<table style="width: 100%; height: 370px;" cellpadding="0" cellspacing="2">
    <tr>
		<td style="vertical-align: top; width: 200px;">
			<table style="width: 100%; height:100%;" cellpadding="0" cellspacing="5">
				<tr>
					<td style="vertical-align: top; width: 200px;">
						<div style="width: 210px; height: 340px; overflow: auto;">
				            <asp:TreeView ID="tvArquivos" runat="server" NodeIndent="15" ShowLines="False">
				                <ParentNodeStyle Font-Bold="False" />
				                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
				                <SelectedNodeStyle Font-Bold="True" Font-Underline="False" 
				                HorizontalPadding="0px" VerticalPadding="0px" />
				                <NodeStyle ForeColor="Black" 
				                HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
				            </asp:TreeView>
						</div>
				      </td>
				  </tr>	
			</table>
		</td>
    	<td style="background-color:Scrollbar; width:1px; height:100%;"></td>
        <td style="vertical-align: top;">
			<table style="width: 100%;" cellpadding="0" cellspacing="5">

				<tr>
					<td style="vertical-align: top;">
			            <asp:Panel runat="server" ID="pnlDiretorio" Visible="True" >
			                <asp:GridView ID="gdvArquivoPasta" runat="server" CellPadding="2" CellSpacing="1"
			                AutoGenerateColumns="False" GridLines="None" CssClass="cssGridGeral"
			                DataKeyNames="CaminhoFisico" AllowPaging="True" PageSize="10" >
			                    <FooterStyle CssClass="cssGridFooter" />
			                    <RowStyle CssClass="cssGridRow"/>
			                    <SelectedRowStyle CssClass="cssGridSelectedRow"  />
			                    <PagerStyle CssClass="cssGridPager" />
			                    <HeaderStyle CssClass="cssGridHeader" />
			                    <EditRowStyle CssClass="cssGridEditRow" />
			                    <AlternatingRowStyle CssClass="cssAlternatingRow" />
			                    
			                    <Columns>
			                        <asp:TemplateField>
			                            <ItemTemplate>
			                                <asp:HiddenField ID="hndCaminhoArquivo" runat="server"
			                                Value='<%# eval("CaminhoFisico") %>' />
			                                <asp:Image ID="imgIcone" runat="server" BorderStyle="None"
			                                ImageUrl='<%# eval("Icone") %>' />
			                            </ItemTemplate>
			                            <ItemStyle Width="20px" HorizontalAlign="Center" />
			                        </asp:TemplateField>                            
			                        
			                        <asp:TemplateField HeaderText="Arquivo">
			                            <ItemTemplate>
			                                <asp:LinkButton ID="btnDownload" runat="server" Text='<%# eval("Nome") %>'
			                                CommandArgument='<%# eval("CaminhoFisico") %>' CommandName="Download" ></asp:LinkButton>
			                            </ItemTemplate>
			                        </asp:TemplateField>
			                        
			                        <asp:TemplateField HeaderText="KB">
			                            <ItemTemplate>
			                                <asp:Label ID="lblTamanho" runat="server"
			                                Text='<%# eval("TamanhoKB") %>' ></asp:Label>
			                            </ItemTemplate>
			                            <ItemStyle Width="60px" HorizontalAlign="Center" />
			                            <HeaderStyle HorizontalAlign="Center" />
			                        </asp:TemplateField>
			                        
			                        <asp:TemplateField HeaderText="Data/Hora">
			                            <ItemTemplate>
			                                <asp:Label ID="lblDataCriacao" runat="server"
			                                Text='<%# eval("DataCriacao") %>' ></asp:Label>
			                            </ItemTemplate>
			                            <ItemStyle Width="140px" HorizontalAlign="Center" />
			                        </asp:TemplateField>
			                    </Columns>
			                    
			                    <EmptyDataTemplate>
			                        Não há arquivos nem sub-pastas nesta pasta
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
			            </asp:Panel>
			            
			            <asp:Panel ID="pnlArquivo" runat="server" Visible="False">
			                <br />
			                <br />
			                <asp:Image runat="server" ID="imgIcoArquivo" />
			                <asp:LinkButton runat="server" ID="btnDownload" Text="Baixar Arquivo" >
			                </asp:LinkButton>
			            </asp:Panel>
					
					</td>				
				</tr>
		
			</table>
        </td>
    </tr>
</table>


</asp:Content>
