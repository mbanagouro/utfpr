<%@ Page Language="vb" AutoEventWireup="false" Culture="pt-BR" MasterPageFile="~/Template.Master" CodeBehind="GerenciarArquivos.aspx.vb" Inherits="UTFPR.SGTCC.WebInterface.GerenciarArquivos" 
    title="SGTCC - Gerenciar Trabalhos" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width: 100%; clear: both; text-align: center; padding-bottom: 10px; padding-top: 10px;">
    &nbsp;<asp:Label ID="lblMensagem" CssClass="cssError" EnableViewState="False" runat="server" ></asp:Label>
</div>

<div style="float: left; background-color:Scrollbar; height: 1px; width:100%;"></div>

<table style="width: 100%; height: 370px;" cellpadding="0" cellspacing="2">
    <tr>
		<td style="vertical-align: top; width: 200px;">
			<table style="width: 100%; height:100%;" cellpadding="0" cellspacing="5">
				<tr>
					<td style="vertical-align: top; width: 200px;">
						<div style="width: 210px; height: 340px; overflow: auto;">
				            <asp:TreeView ID="tvArquivos" runat="server" NodeIndent="15" ShowLines="False">
				                <ParentNodeStyle CssClass="cssParentNode" />
				                <HoverNodeStyle CssClass="cssHoverNode" />
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
					    <asp:Panel ID="pnlIncluir" runat="server">
			                <label class="cssLabel">Criar Pasta:</label> 
			                <asp:TextBox ID="txtNomePasta" runat="server" CssClass="cssTextBox" EnableViewState="False"></asp:TextBox>                    
			                <asp:Button ID="btnNovaPasta" runat="server" Text="Nova Pasta" CssClass="cssBotaoLaranja" />
			                &nbsp;&nbsp;&nbsp;
    			            
			                <label class="cssLabel">Enviar Arquivo:</label> 
			                <asp:FileUpload ID="fleEnviarArquivo" runat="server" CssClass="cssTextBox" EnableViewState="False"/>
			                &nbsp;
			                <asp:Button ID="btnEnviarArquivo" runat="server" Text="Enviar" CssClass="cssBotaoLaranjaPequeno" />
			            </asp:Panel>
					</td>
				</tr>

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
			                    
			                    <EmptyDataTemplate>
			                        Não há arquivos nem sub-pastas nesta pasta
			                    </EmptyDataTemplate>
			                    <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" Height="60px" />
			                    
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
			                                <asp:Panel ID="pnlEditar" runat="server" 
			                                Visible='<%# MostrarPainel(eval("CaminhoFisico")) %>' >
			                                    <asp:TextBox ID="txtNomePasta" runat="server" 
			                                    Text='<%# eval("Nome") %>' CssClass="cssTextBox"></asp:TextBox>
			                                    <asp:Button ID="btnEditar" runat="server" Text="Salvar"
			                                    CommandArgument='<%# eval("CaminhoFisico") %>'
			                                    CommandName="SalvarNome" CssClass="cssBotaoLaranjaPequeno"/>
			                                    <asp:Button ID="btnCancelarEdicao" runat="server" Text="Cancelar" 
			                                    CommandName="CancelarEdicao" CssClass="cssBotaoLaranjaPequeno" />
			                                </asp:Panel>
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
			                        
			                        <asp:CommandField SelectImageUrl="~/imagens/icones/edititem.gif" 
			                        ShowSelectButton="True" ButtonType="Image" 
			                        ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />
			                        
			                        <asp:TemplateField>
			                            <ItemTemplate>
			                                <asp:ImageButton ID="btnApagar" runat="server" 
			                                ImageUrl="~/imagens/icones/delete.gif"
			                                CommandArgument='<%# eval("CaminhoFisico") %>' 
			                                CommandName="Apagar"
			                                ToolTip="Excluir"
			                                AlternateText="Botão Excluir"
			                                OnClientClick="return confirm('Deseja confirmar a exclusão?\nCaso seja pasta todos os arquivos e sub pastas serão excluídos!');" />
			                            </ItemTemplate>
			                            <ItemStyle Width="30px" HorizontalAlign="Center" />
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
			            </asp:Panel>
			            
			            <asp:Panel ID="pnlArquivo" runat="server" Visible="False">
			                <br />
			                <br />
			                <asp:Image runat="server" ID="imgIcoArquivo"/>
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
