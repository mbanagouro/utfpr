Imports System.IO
Imports UTFPR.SGTCC.Negocio.ModuloAP

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Downloads.                                                      <BR/>
''' Objetivo.....: Code-Behind da página que disponibiliza os trabalhos de TCC.    <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Downloads
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Constante com o caminho da imagem do icone de pasta
    ''' </summary>
    Private Const ICONE_PASTA As String = "~/imagens/icones/pasta.png"
    ''' <summary>
    ''' Constante com o caminho da imagem do icone da raiz
    ''' </summary>
    Private Const ICONE_RAIZ As String = "~/imagens/icones/raiz.gif"
    ''' <summary>
    ''' Define o caminho físico da raiz
    ''' </summary>
    Private _caminhoDiretorioRaiz As String = Server.MapPath("../../Arquivos/")
    ''' <summary>
    ''' Define o caminho físico do diretório de ícones
    ''' </summary>
    Private _caminhoDiretorioIcones As String = Server.MapPath("../../imagens/icones/")

#End Region

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Try

                Me.CarregarTreeView(_caminhoDiretorioRaiz)
                Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)

            Catch ex As Exception
                lblMensagem.Text = "Falha ao carregar a página"
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Evento da seleção da treeview
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub tvArquivos_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvArquivos.SelectedNodeChanged

        Dim tipoSelecionado As TipoArquivo = TipoArquivo.Indefinido

        tipoSelecionado = VerificarTipo(tvArquivos.SelectedNode.Value)

        pnlArquivo.Visible = False
        pnlDiretorio.Visible = False

        Select Case tipoSelecionado

            Case TipoArquivo.Arquivo
                pnlArquivo.Visible = True

                Dim objArquivo As New FileInfo(tvArquivos.SelectedValue)

                imgIcoArquivo.ImageUrl = RetornaIconeArquivo(objArquivo.Extension)

                btnDownload.Text = " Fazer download do arquivo " & _
                                   objArquivo.Name & _
                                   " (" & FormatNumber(objArquivo.Length / 1024, 0) & "KB)"

            Case TipoArquivo.Pasta
                Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)
                pnlDiretorio.Visible = True

            Case Else
                ' Não faz nada, painéis permanecerão ocultos

        End Select

        gdvArquivoPasta.SelectedIndex = -1

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub gdvArquivoPasta_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvArquivoPasta.RowCommand

        Dim tipoSelecionado As TipoArquivo = TipoArquivo.Indefinido

        If e.CommandName = "Download" Then

            tipoSelecionado = VerificarTipo(CType(e.CommandArgument, String))

            If tipoSelecionado = TipoArquivo.Arquivo Then
                Me.DownloadArquivo(CType(e.CommandArgument, String))
            Else
                Me.RecarregarControles(CType(e.CommandArgument, String))
            End If

        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Me.DownloadArquivo(tvArquivos.SelectedValue)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub lnkProxima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProxima.Click
        gdvArquivoPasta.PageIndex += 1
        Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub lnkAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAnterior.Click
        gdvArquivoPasta.PageIndex -= 1
        Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="valorSelecionado"></param>
    Private Sub CarregarTreeView(ByVal valorSelecionado As String)

        tvArquivos.Nodes.Clear()

        Dim noRaiz As New TreeNode

        With noRaiz
            .Text = "Arquivos"
            .Value = _caminhoDiretorioRaiz
            .ImageUrl = ICONE_RAIZ
            .ExpandAll()
        End With

        If noRaiz.Value = valorSelecionado Then
            noRaiz.Selected = True
        End If

        tvArquivos.Nodes.Add(noRaiz)

        Me.CarregarArquivos(_caminhoDiretorioRaiz, noRaiz, valorSelecionado)
        Me.CarregarItens(_caminhoDiretorioRaiz, noRaiz, valorSelecionado)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="diretorio"></param>
    ''' <param name="noTreeView"></param>
    ''' <param name="valorSelecionado"></param>
    Private Sub CarregarItens(ByVal diretorio As String, ByVal noTreeView As TreeNode, ByVal valorSelecionado As String)

        Dim lstPastas As List(Of DirectoryInfo)
        Dim noPasta As New TreeNode

        lstPastas = Arquivo.ObterDiretorios(diretorio)

        For Each objPasta As DirectoryInfo In lstPastas
            noPasta = New TreeNode

            With noPasta
                .Value = objPasta.FullName
                .Text = objPasta.Name
                .ImageUrl = ICONE_PASTA
                .ExpandAll()
            End With

            If noPasta.Value = valorSelecionado Then
                noPasta.Selected = True
            End If

            noTreeView.ChildNodes.Add(noPasta)

            Me.CarregarItens(objPasta.FullName, noPasta, valorSelecionado)
            Me.CarregarArquivos(objPasta.FullName, noPasta, valorSelecionado)
        Next

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="diretorio"></param>
    ''' <param name="noTreeView"></param>
    ''' <param name="valorSelecionado"></param>
    Private Sub CarregarArquivos(ByVal diretorio As String, ByVal noTreeView As TreeNode, ByVal valorSelecionado As String)

        Dim lstArquivos As List(Of FileInfo)
        Dim noArquivo As New TreeNode

        lstArquivos = Arquivo.ObterArquivos(diretorio)

        For Each objArquivo In lstArquivos
            noArquivo = New TreeNode

            With noArquivo
                .Value = objArquivo.FullName
                .Text = objArquivo.Name
                .ImageUrl = RetornaIconeArquivo(objArquivo.Extension)
                .ExpandAll()
            End With

            If noArquivo.Value = valorSelecionado Then
                noArquivo.Selected = True
            End If

            noTreeView.ChildNodes.Add(noArquivo)
        Next

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="diretorio"></param>
    Public Sub CarregarGridArquivoPasta(ByVal diretorio As String)

        Dim itens As New Collection
        Dim objItem As Arquivo

        ' Carrega as pastas
        Dim lstPasta As List(Of DirectoryInfo)

        lstPasta = Arquivo.ObterDiretorios(diretorio)

        For Each objPasta As DirectoryInfo In lstPasta
            objItem = New Arquivo

            With objItem
                .CaminhoFisico = objPasta.FullName
                .TipoItem = TipoArquivo.Pasta
                .Nome = objPasta.Name
                .DataCriacao = objPasta.CreationTime
                .Icone = ICONE_PASTA
            End With

            itens.Add(objItem)
        Next

        ' Carrega os arquivos
        Dim lstArquivo As List(Of FileInfo)

        lstArquivo = Arquivo.ObterArquivos(diretorio, "*.*", SearchOption.TopDirectoryOnly)

        For Each objArquivo As FileInfo In lstArquivo
            objItem = New Arquivo

            With objItem
                .CaminhoFisico = objArquivo.FullName
                .TipoItem = TipoArquivo.Arquivo
                .Extensao = objArquivo.Extension
                .DataCriacao = objArquivo.CreationTime
                .Nome = objArquivo.Name
                .SomenteLeitura = objArquivo.IsReadOnly
                .TamanhoKB = CInt(objArquivo.Length / 1024)
                .Icone = Me.RetornaIconeArquivo(objArquivo.Extension)
            End With

            itens.Add(objItem)
        Next

        gdvArquivoPasta.DataSource = itens
        gdvArquivoPasta.DataBind()
        Me.ControlePaginacao()

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="extensao"></param>
    ''' <returns></returns>
    Public Function RetornaIconeArquivo(ByVal extensao As String) As String

        Dim strCaminhoIcone As String

        extensao = extensao.ToLower.Substring(1, 3)

        If File.Exists(_caminhoDiretorioIcones & extensao & ".png") Then
            strCaminhoIcone = "~/imagens/icones/" & extensao & ".png"
        Else
            strCaminhoIcone = "~/imagens/icones/" & "file.png"
        End If

        Return strCaminhoIcone

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pastaPai"></param>
    Private Sub RecarregarControles(ByVal pastaPai As String)

        System.Threading.Thread.Sleep(2000)

        Me.CarregarTreeView(pastaPai)

        gdvArquivoPasta.SelectedIndex = -1
        Me.CarregarGridArquivoPasta(pastaPai)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="caminho"></param>
    ''' <returns></returns>
    Private Function VerificarTipo(ByVal caminho As String) As TipoArquivo

        Dim tipoSelecionado As TipoArquivo = TipoArquivo.Indefinido

        If File.Exists(caminho) Then
            tipoSelecionado = TipoArquivo.Arquivo
        Else
            If Directory.Exists(caminho) Then
                tipoSelecionado = TipoArquivo.Pasta
            End If
        End If

        Return tipoSelecionado

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="caminhoArquivo"></param>
    Public Sub DownloadArquivo(ByVal caminhoArquivo As String)

        Session("ArquivoDownload") = caminhoArquivo
        Response.Redirect(My.Resources.UrlMaps.Download)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ControlePaginacao()

        lnkAnterior.Visible = True
        lnkProxima.Visible = True

        If CBool(gdvArquivoPasta.PageIndex + 1 And gdvArquivoPasta.PageCount) Then
            lnkProxima.Visible = False
        End If
        If gdvArquivoPasta.PageIndex = 0 Then
            lnkAnterior.Visible = False
        End If
        If gdvArquivoPasta.PageCount = 0 Then
            pnlPaginacao.Visible = False
        Else
            pnlPaginacao.Visible = True
        End If

        lblTotalPag.Text = gdvArquivoPasta.PageCount.ToString.Trim
        lblPagAtual.Text = CStr(gdvArquivoPasta.PageIndex + 1)

    End Sub

#End Region

End Class