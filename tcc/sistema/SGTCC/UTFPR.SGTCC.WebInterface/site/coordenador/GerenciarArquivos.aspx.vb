Imports System.IO
Imports UTFPR.SGTCC.Negocio.ModuloAP

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: GerenciarArquivos.                                              <BR/>
''' Objetivo.....: Code-Behind da página que gerencia os arquivos do sistema.      <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class GerenciarArquivos
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

        ' Registra o controle para sofrer PostBack
        ScriptManager.GetCurrent(Me).RegisterPostBackControl(btnEnviarArquivo)

        ' Se a página estiver sendo carregada pela primeira vez
        If Not Page.IsPostBack Then

            Try

                ' Executa o método para carregar o TreeView com o valor inicial
                Me.CarregarTreeView(_caminhoDiretorioRaiz)
                ' Executa o método para carregar o GridView com os arquivos do diretório selecionado no TreeView
                Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Evento que trata o valor alterado da TreeView
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub tvArquivos_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvArquivos.SelectedNodeChanged

        ' Cria a variável do tipo do arquivo selecionado como tipo definido
        Dim tipoSelecionado As TipoArquivo = TipoArquivo.Indefinido

        ' Verifica o tipo
        tipoSelecionado = Me.VerificarTipo(tvArquivos.SelectedNode.Value)

        ' Oculta inicialmente os painéis
        pnlArquivo.Visible = False
        pnlDiretorio.Visible = False
        pnlIncluir.Visible = False

        ' Seleciona o tipom se for arquivo, mostra o painel de arquivos,
        ' se for pasta, mostro o de pasta, se não for nenhum, eu não faço nada
        ' e os painéis permanecerão ocultos
        Select Case tipoSelecionado

            Case TipoArquivo.Arquivo

                ' Deixa o painel do arquivo visível
                pnlArquivo.Visible = True

                ' Recupero a informação do arquivo
                Dim objArquivo As New FileInfo(tvArquivos.SelectedValue)

                ' Informo o ícone do arquivo
                imgIcoArquivo.ImageUrl = Me.RetornaIconeArquivo(objArquivo.Extension)

                ' Informa o nome e o tamanho do arquivo para o usuário
                ' por questão de melhor usabilidade
                btnDownload.Text = " Fazer download do arquivo " & _
                                   objArquivo.Name & _
                                   " (" & FormatNumber(objArquivo.Length / 1024, 0) & "KB)"


            Case TipoArquivo.Pasta

                ' Executa o método que irá carregar o GridView 
                Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)
                ' Mostra o painel dos diretórios e o painel dos campos para incluir um novo arquivo ou diretório
                pnlDiretorio.Visible = True
                pnlIncluir.Visible = True

            Case Else
                ' Não faz nada, painéis permanecerão ocultos

        End Select

        ' Inicializa a seleção do GridView
        gdvArquivoPasta.SelectedIndex = -1
        ' Executa o método para ocultar os painéias da GridView
        Me.LimparEstadoPainelGridView()

    End Sub

    ''' <summary>
    ''' Evento que trata o comando enviado GridView
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub gdvArquivoPasta_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvArquivoPasta.RowCommand

        ' Cria a variável do tipo do arquivo selecionado como tipo definido
        Dim tipoSelecionado As TipoArquivo = TipoArquivo.Indefinido

        ' Verifica os casos do comando enviado
        Select Case e.CommandName

            Case "SalvarNome"

                ' Recebe o caminho
                Dim caminho As String = CType(e.CommandArgument, String)
                ' Declara um objeto TextBox
                Dim objTexto As TextBox

                ' Atribui o tipo do arquivo selecionado
                tipoSelecionado = VerificarTipo(caminho)
                ' Faz a referência do campo TextBox da linha selecionada no GridView para o objeto declarado
                objTexto = CType(gdvArquivoPasta.Rows(gdvArquivoPasta.SelectedIndex).FindControl("txtNomePasta"), TextBox)

                ' Se o objeto existir
                If Not IsNothing(objTexto) Then

                    ' Inicializa as variáveis
                    Dim pastaPai As String = String.Empty
                    Dim novoCaminho As String = String.Empty

                    ' Seleciona a pasta pai
                    pastaPai = tvArquivos.SelectedNode.Value

                    ' Monta o novo caminho, pai + texto
                    novoCaminho = pastaPai & "\" & objTexto.Text

                    ' Se o tipo selecionado for um arquivo
                    If tipoSelecionado = TipoArquivo.Arquivo Then

                        ' Verifica se já existe um arquivo com o mesmo nome que foi informado
                        If File.Exists(novoCaminho) Then
                            ' Se sim, exibe mensagem informativa para o usuário
                            lblMensagem.Text = "Este aquivo já existe, digite outro nome."
                            Exit Sub
                        End If

                        ' Para renomear, é preciso usar o comando move
                        File.Move(caminho, novoCaminho)
                        ' Para evitar erro, pode ter um delay de criação
                        ' então dá um tempo até o arquivo realmente existir
                        System.Threading.Thread.Sleep(1000)

                    Else

                        ' Verifica se o novo arquivo já não existe
                        If Directory.Exists(novoCaminho) Then
                            lblMensagem.Text = "Este diretório já existe, digite outro nome."
                            Exit Sub
                        End If

                        ' Para renomear é preciso usar o comando move
                        Directory.Move(caminho, novoCaminho)
                        ' Para evitar erro, pode ter um delay de criação
                        ' então dá um tempo até o arquivo realmente existir
                        System.Threading.Thread.Sleep(1000)

                    End If

                    ' Recarrega os controles
                    Me.RecarregarControles(pastaPai)

                End If

            Case "CancelarEdicao"
                ' Inicializa a linha selecionada
                gdvArquivoPasta.SelectedIndex = -1
                ' Executa o método para carregar a GridView
                Me.CarregarGridArquivoPasta(tvArquivos.SelectedValue)

            Case "Apagar"
                Dim pastaPai As String = String.Empty

                ' Recupera o tipo
                tipoSelecionado = VerificarTipo(CType(e.CommandArgument, String))

                ' Verifica o tipo de arquivo para excluir
                If tipoSelecionado = TipoArquivo.Arquivo Then
                    File.Delete(CType(e.CommandArgument, String))
                Else
                    Directory.Delete(CType(e.CommandArgument, String), True)
                End If

                ' Recarrega os controles
                Me.RecarregarControles(tvArquivos.SelectedValue)

            Case "Download"
                ' Recupera o tipo
                tipoSelecionado = VerificarTipo(CType(e.CommandArgument, String))

                If tipoSelecionado = TipoArquivo.Arquivo Then
                    ' Se for arquivo, eu habilito o download
                    Me.DownloadArquivo(CType(e.CommandArgument, String))
                Else
                    ' Recarrega os controles
                    Me.RecarregarControles(CType(e.CommandArgument, String))
                End If

            Case Else
                ' Não faz nada

        End Select

    End Sub

    ''' <summary>
    ''' Evento invocado quando há uma seleção, ou seja, quando o botão de renomear é ativado
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub gdvArquivoPasta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvArquivoPasta.SelectedIndexChanged

        ' Retorna o painel para o estado inicial
        Me.LimparEstadoPainelGridView()

        ' Otém a grid
        Dim grv As GridView = CType(sender, GridView)

        ' Deixa somente a linha selecionada visível
        gdvArquivoPasta.Rows(grv.SelectedRow.RowIndex).FindControl("pnlEditar").Visible = True
        gdvArquivoPasta.Rows(grv.SelectedRow.RowIndex).FindControl("btnDownload").Visible = False

    End Sub

    ''' <summary>
    ''' Evento do click do botão download
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Me.DownloadArquivo(tvArquivos.SelectedValue)
    End Sub

    ''' <summary>
    ''' Evento do click do botão Nova Pasta
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnNovaPasta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaPasta.Click

        Dim caminhoAtual As String = String.Empty
        Dim novaPasta As String = String.Empty

        If Not String.IsNullOrEmpty(txtNomePasta.Text) Then

            ' Recupera a pasta pai
            caminhoAtual = tvArquivos.SelectedValue

            ' A nova pasta é a pasta pai concatenada com o nome 
            ' da nova pasta
            novaPasta = caminhoAtual & "\" & txtNomePasta.Text

            ' Se o diretório já não existir, cria uma nova
            If Not Directory.Exists(novaPasta) Then
                Directory.CreateDirectory(novaPasta)
            Else
                lblMensagem.Text = "O diretório a ser criado já existe."
            End If

            ' Recarrega os controles
            Me.RecarregarControles(caminhoAtual)

            ' Limpa o TextBox
            txtNomePasta.Text = String.Empty

        Else
            lblMensagem.Text = "Informe o nome do diretório a ser criado."
        End If

    End Sub

    ''' <summary>
    ''' Evento do click de enviar arquivo
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnEnviarArquivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarArquivo.Click

        If fleEnviarArquivo.HasFile Then

            Dim caminhoNovoArquivo As String = String.Empty
            Dim objArquivo As New FileInfo(fleEnviarArquivo.FileName)

            ' Verifica se tipo de arquivo é .doc ou .pdf
            If Not objArquivo.Extension = ".doc" And Not objArquivo.Extension = ".pdf" Then
                lblMensagem.Text = "Somente arquivo .doc ou .pdf."
                Exit Sub
            End If

            ' Monta o caminho do arquivo
            caminhoNovoArquivo = tvArquivos.SelectedValue & "\" & fleEnviarArquivo.FileName

            ' Se o arquivo já não existir
            If Not File.Exists(caminhoNovoArquivo) Then
                ' Salvar o arquivo
                fleEnviarArquivo.SaveAs(caminhoNovoArquivo)
                ' Recarrega os controles
                Me.RecarregarControles(tvArquivos.SelectedValue)
            Else
                lblMensagem.Text = "Já existe um arquivo com o mesmo nome."
            End If

        Else

            lblMensagem.Text = "Informe o arquivo a ser enviado."
            Exit Sub

        End If

    End Sub

    ''' <summary>
    ''' Evento do click do botão Próximo
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub lnkProxima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProxima.Click
        ' Incrementa a página
        gdvArquivoPasta.PageIndex += 1
        ' Carrega novamente o GridView
        Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)
    End Sub

    ''' <summary>
    ''' Evento do click do botão Anterior
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub lnkAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAnterior.Click
        ' Decrementa a página
        gdvArquivoPasta.PageIndex -= 1
        ' Carrega novamente o GridView
        Me.CarregarGridArquivoPasta(tvArquivos.SelectedNode.Value)
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega a TreeView
    ''' </summary>
    ''' <param name="valorSelecionado">Nó selecionado</param>
    Private Sub CarregarTreeView(ByVal valorSelecionado As String)

        Dim noRaiz As New TreeNode

        ' Limpa todos os nós antes de adicionar
        tvArquivos.Nodes.Clear()

        ' Cria um novo nó para a raiz
        With noRaiz
            .Text = "Arquivos"
            .Value = _caminhoDiretorioRaiz
            .ImageUrl = ICONE_RAIZ
            .ExpandAll()
        End With

        ' Verifica se o item está selecionado
        If noRaiz.Value = valorSelecionado Then
            noRaiz.Selected = True
        End If

        ' Adiciona o nó na TreeView
        tvArquivos.Nodes.Add(noRaiz)

        ' Carrega todas as pastas e arquivos
        Me.CarregarArquivos(_caminhoDiretorioRaiz, noRaiz, valorSelecionado)
        Me.CarregarItens(_caminhoDiretorioRaiz, noRaiz, valorSelecionado)

    End Sub

    ''' <summary>
    ''' Método que carrega as pastas do diretório na TreeView
    ''' </summary>
    ''' <param name="diretorio">Caminho do diretório</param>
    ''' <param name="noTreeView">Nó da TreeView que será carregado</param>
    ''' <param name="valorSelecionado">Nó selecionado</param>
    Private Sub CarregarItens(ByVal diretorio As String, ByVal noTreeView As TreeNode, ByVal valorSelecionado As String)

        ' Coleção que irá receber todas as pasta
        Dim lstPastas As List(Of DirectoryInfo)
        Dim noPasta As TreeNode

        ' Recupera todas as pastas do diretório
        lstPastas = Arquivo.ObterDiretorios(diretorio)

        ' Faz um loop por todas as pastas
        For Each objPasta As DirectoryInfo In lstPastas

            ' Cria uma nova pasta
            noPasta = New TreeNode

            With noPasta
                ' O valor é o nome completo
                .Value = objPasta.FullName
                ' Atribui o nome da pasta
                .Text = objPasta.Name
                ' Atribui o icone, que recebe a constante
                .ImageUrl = ICONE_PASTA
                ' Expande todos os itens, como padrão
                .ExpandAll()
            End With

            ' Verifica se o valor selecionado é o mesmo do nó
            If noPasta.Value = valorSelecionado Then
                noPasta.Selected = True
            End If

            ' Adiciona o nó para a pasta
            noTreeView.ChildNodes.Add(noPasta)

            ' Carrega todos os arquivos e pastas da pasta
            CarregarItens(objPasta.FullName, noPasta, valorSelecionado)
            CarregarArquivos(objPasta.FullName, noPasta, valorSelecionado)

        Next

    End Sub

    ''' <summary>
    ''' Método para carregar os arquivos da pasta do TreeView
    ''' </summary>
    ''' <param name="diretorio">Caminho do diretório</param>
    ''' <param name="noTreeView">Nó da TreeView que será carregado</param>
    ''' <param name="valorSelecionado">Nó selecionado</param>
    Private Sub CarregarArquivos(ByVal diretorio As String, ByVal noTreeView As TreeNode, ByVal valorSelecionado As String)

        ' Coleção que irá receber todos os arquivos
        Dim lstArquivos As List(Of FileInfo)
        Dim noArquivo As TreeNode

        ' Recupera todas os arquivos do diretório
        lstArquivos = Arquivo.ObterArquivos(diretorio)

        ' Faz um loop por todos os arquivos
        For Each objArquivo As FileInfo In lstArquivos

            ' Cria um novo nó com o arquivo
            noArquivo = New TreeNode

            With noArquivo
                .Value = objArquivo.FullName
                ' Atribui o nome do arquivo
                .Text = objArquivo.Name
                ' Atribui o icone do arquivo
                .ImageUrl = RetornaIconeArquivo(objArquivo.Extension)
                ' Expande todos os itens, como padrão
                .ExpandAll()
            End With

            ' Verifica se o valor selecionado é o mesmo do nó
            If noArquivo.Value = valorSelecionado Then
                noArquivo.Selected = True
            End If

            ' Adiciona o nó como filho do nó passado
            ' ou seja, dentro da pasta
            noTreeView.ChildNodes.Add(noArquivo)

        Next

    End Sub

    ''' <summary>
    ''' Método que carrega o GridView com as informações do arquivo
    ''' </summary>
    ''' <param name="diretorio">Caminho do diretório</param>
    Private Sub CarregarGridArquivoPasta(ByVal diretorio As String)

        ' Irá receber uma coleção de arquivos para o GridView
        Dim itens As New Collection
        ' Recebe o tipo da classe de arquivos que foi criado
        Dim objItem As Arquivo

        ' ********************
        ' Carrega as pastas
        ' ********************
        ' Coleção que irá receber todas as pastas
        Dim lstPasta As List(Of DirectoryInfo)

        ' Recupera as pastas do diretório
        lstPasta = Arquivo.ObterDiretorios(diretorio)

        ' Faz um loop por todas as pastas
        For Each objPasta As DirectoryInfo In lstPasta

            ' Cria um novo item para a coleção
            objItem = New Arquivo

            With objItem
                ' Atribui o caminho completo da pasta
                .CaminhoFisico = objPasta.FullName
                ' Atribui o tipo como pasta
                .TipoItem = TipoArquivo.Pasta
                ' Atribui o nome
                .Nome = objPasta.Name
                ' Atribui a data de criação do arquivo
                .DataCriacao = objPasta.CreationTime
                ' Atribui o icone
                .Icone = ICONE_PASTA
            End With

            ' Adiciona a pasta a coleção
            itens.Add(objItem)

        Next

        ' ********************
        ' Carrega os arquivos
        ' ********************
        ' Coleção que irá receber todos os arquivos
        Dim lstArquivo As List(Of FileInfo)

        ' Recupera todos os arquivos do diretório
        lstArquivo = Arquivo.ObterArquivos(diretorio, "*.*", SearchOption.TopDirectoryOnly)

        ' Faz um loop por todos os arquivos
        For Each objArquivo As FileInfo In lstArquivo

            ' Cria um novo item para a coleção
            objItem = New Arquivo

            With objItem
                ' Atribui o caminho completo do arquivo
                .CaminhoFisico = objArquivo.FullName
                ' Atribui o tipo como sendo arquivo
                .TipoItem = TipoArquivo.Arquivo
                ' Atribui a extensão do arquivo
                .Extensao = objArquivo.Extension
                ' Atribui a data de criação
                .DataCriacao = objArquivo.CreationTime
                ' Atribui o nome do arquivo
                .Nome = objArquivo.Name
                ' Determina que é somente leitura
                .SomenteLeitura = objArquivo.IsReadOnly
                ' Divide-se por 1024 para pegar o valor em KB
                .TamanhoKB = CInt(objArquivo.Length / 1024)
                ' Atribui o icone
                .Icone = RetornaIconeArquivo(objArquivo.Extension)
            End With

            ' Adiciona o arquivo a coleção
            itens.Add(objItem)

        Next

        ' Informa a fonte de dados ao GridView
        ' no caso é a coleção que foi carregada com os arquivos e pastas
        gdvArquivoPasta.DataSource = itens
        ' Executa o método DataBind para carregar o controle com os dados
        gdvArquivoPasta.DataBind()
        ' Executa o método para paginação
        Me.ControlePaginacao()

    End Sub

    ''' <summary>
    ''' Método que deixa o estado do painel dentro da GridView invisível ou seja, 
    ''' sem ser no método de renomear
    ''' </summary>
    Private Sub LimparEstadoPainelGridView()

        ' Deixa todos os painéis invisíveis
        For count As Integer = 0 To gdvArquivoPasta.Rows.Count - 1

            gdvArquivoPasta.Rows(count).FindControl("pnlEditar").Visible = False
            gdvArquivoPasta.Rows(count).FindControl("btnDownload").Visible = True

        Next

    End Sub

    ''' <summary>
    ''' Método que mostra ou oculta o painel para renomear caso
    ''' o valor selecionado seja o mesmo do caminho, então o painel é mostrado
    ''' </summary>
    ''' <param name="caminho">Caminho do painel que será exibido</param>
    ''' <returns>True ou False</returns>
    Protected Function MostrarPainel(ByVal caminho As String) As Boolean

        If caminho.Equals(gdvArquivoPasta.SelectedValue) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Função que retorna o ícone do arquivo a ser exibido no nó da TreeView
    ''' </summary>
    ''' <param name="extensao">Extensao do arquivo</param>
    ''' <returns>Caminho do ícone da extensão</returns>
    Private Function RetornaIconeArquivo(ByVal extensao As String) As String

        ' Declara a variável de retorno
        Dim strIcone As String

        extensao = Replace(extensao, ".", "")

        ' Verifica se o arquivo existe
        If File.Exists(_caminhoDiretorioIcones & extensao & ".png") Then

            ' Se existir, retorna o ícone correspondente
            strIcone = "~/imagens/icones/" & extensao & ".png"

        Else

            ' Se não existir, retorna um ícone padrão
            strIcone = "~/imagens/icones/" & "file.png"

        End If

        Return strIcone

    End Function

    ''' <summary>
    ''' Método que recarrega os controles
    ''' </summary>
    ''' <param name="pastaPai">Caminho da pasta pai</param>
    Private Sub RecarregarControles(ByVal pastaPai As String)

        ' Ás vezes pode dar erro ao renomear diretório com
        ' muitos arquivos. Uma saída simples é esperar um pouco (2 segundos)
        System.Threading.Thread.Sleep(2000)

        ' Recarrega o TreeView
        Me.CarregarTreeView(pastaPai)

        ' Oculta o painel e exibe o label
        If gdvArquivoPasta.SelectedIndex > 0 Then

            gdvArquivoPasta.Rows(gdvArquivoPasta.SelectedIndex).FindControl("pnlEditar").Visible = True
            gdvArquivoPasta.Rows(gdvArquivoPasta.SelectedIndex).FindControl("btnDownload").Visible = False

        End If

        ' Inicializo a seleção do GridView
        gdvArquivoPasta.SelectedIndex = -1
        ' Recarrega o GridView para mostrar a alteração
        Me.CarregarGridArquivoPasta(pastaPai)

    End Sub

    ''' <summary>
    ''' Método que verifica o tipo do item
    ''' </summary>
    ''' <param name="caminho">Caminho do arquivo</param>
    ''' <returns>Tipo do Arquivo</returns>
    Private Function VerificarTipo(ByVal caminho As String) As TipoArquivo

        ' Inicializo o tipo
        Dim tipoSelecionado As TipoArquivo = TipoArquivo.Indefinido

        ' Verifica se o arquivo existe
        If File.Exists(caminho) Then

            tipoSelecionado = TipoArquivo.Arquivo

        Else

            ' Verifica se o diretório existe
            If Directory.Exists(caminho) Then

                tipoSelecionado = TipoArquivo.Pasta

            End If

        End If

        Return tipoSelecionado

    End Function

    ''' <summary>
    ''' Método que redireciona o usuário para a página de download do arquivo
    ''' </summary>
    ''' <param name="caminhoArquivo">Caminho do arquivo</param>
    Private Sub DownloadArquivo(ByVal caminhoArquivo As String)

        ' Armazena o caminho na sessão
        Session("ArquivoDownload") = caminhoArquivo
        ' Redireciona o usuário
        Response.Redirect(My.Resources.UrlMaps.Download)

    End Sub

    ''' <summary>
    ''' Método que controla a paginação
    ''' </summary>
    Private Sub ControlePaginacao()

        ' Oculta os botões
        lnkAnterior.Visible = True
        lnkProxima.Visible = True

        ' Verifica quais botões serão exibidos
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

        ' Atribui para o label da página o total de páginas
        lblTotalPag.Text = gdvArquivoPasta.PageCount.ToString.Trim
        ' Atribui para o label da página a página atual
        lblPagAtual.Text = CStr(gdvArquivoPasta.PageIndex + 1)

    End Sub

#End Region

End Class