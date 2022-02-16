Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: NovaMensagem.                                                   <BR/>
''' Objetivo.....: Code-Behind da página de nova mensagem.                         <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class NovaMensagem
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Armazena a quantidade de destinatários para que o usuário logado possa
    ''' mandar mensagens
    ''' </summary>
    Private qtdDestinatarios As Integer

#End Region

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Se a página estiver sendo carregada pela primeira vez
        If Not Page.IsPostBack Then

            ' Declara os objetos
            Dim objLogin As Login

            ' Instancia os objetos
            objLogin = New Login

            ' Executa o método para carregar o combo com os destinatários possíveis
            Me.CarregarComboDestinatarios(objLogin.Matricula)
            ' Executa o método para carregar o combo com as prioridades existentes
            Me.CarregarComboPrioridade()

        End If

    End Sub

    ''' <summary>
    ''' Evento do click do botão Enviar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        ' Declara os objetos
        Dim selecionado As Integer

        Try

            ' Pega o índice da seleção do combo destinatário
            selecionado = Me.ddlDestinatario.SelectedIndex
            ' Pega a quantidade de destinatários
            Me.qtdDestinatarios = Me.ddlDestinatario.Items.Count

            ' Verifica se está enviando para mais de um destinatário ou não
            If Me.qtdDestinatarios > 1 And selecionado = 0 Then
                ' Executa o método para enviar a mensagem para todos os destinatários
                Me.EnviarTodos()
            Else
                ' Executa o método para enviar a mensagem para só um destinatário
                Me.Enviar()
            End If

            Me.LimparCampos()

        Catch ex As NotFoundException
            Throw ex
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega o combo com os destinatários
    ''' </summary>
    ''' <param name="matricula">Número da matrícula</param>
    Private Sub CarregarComboDestinatarios(ByVal matricula As Integer)

        ' Está executando da usuario só para teste
        Dim objTcc As TCC

        Try
            ' Instancia os objetos
            objTcc = New TCC

            ' Popula o combo destinatário
            With Me.ddlDestinatario
                .DataSource = objTcc.SelecionarAlunoOrientadorTcc(matricula)
                .DataTextField = "Nome"
                .DataValueField = "Matricula"
                .DataBind()
            End With

            ' Se o combo possui mais de uma ocorrência, insere na primeira ocorrência
            ' a opção 'Todos'
            If Me.ddlDestinatario.Items.Count > 1 Then
                Me.ddlDestinatario.Items.Insert(0, New ListItem("Todos -----", "0"))
                Me.ddlDestinatario.SelectedIndex = 0
            End If

        Catch ex As NotFoundException
            lblMensagem.Text = "Você não possui nenhum destinatário para o envio de mensagens"
        Catch ex As Exception
            lblMensagem.Text = "Falha no carregamento do combo de destinatários"
        End Try

    End Sub

    ''' <summary>
    ''' Método que carrega o combo de prioridades
    ''' </summary>
    Private Sub CarregarComboPrioridade()

        ' Popula o combo de prioridades
        With Me.ddlPrioridade
            .Items.Add(New ListItem("Normal", CInt(PrioridadeMensagem.Normal).ToString.Trim))
            .Items.Add(New ListItem("Importate", CInt(PrioridadeMensagem.Importante).ToString.Trim))
            .Items.Add(New ListItem("Urgente", CInt(PrioridadeMensagem.Urgente).ToString.Trim))
        End With

    End Sub

    ''' <summary>
    ''' Método que envia a mensagem ao destinatário especificado
    ''' </summary>
    Private Sub Enviar()

        ' Instancia os objetos
        Dim objMensagem As Mensagem
        Dim objLogin As Login

        ' Recupera o número da matrícula do combo
        Dim matDestinatario As Integer

        Try
            ' Instancia os objetos
            objMensagem = New Mensagem
            objLogin = New Login

            ' Recupera a matricula do combo selecionado
            matDestinatario = Convert.ToInt32(Me.ddlDestinatario.SelectedValue)

            ' Executa o método de enviar mensagm passando os parâmetros
            objMensagem.EnviarMensagem(objLogin.Matricula, _
                                       Me.txtAssunto.Text, _
                                       CType(Me.ddlPrioridade.SelectedValue, PrioridadeMensagem), _
                                       Me.txtMensagem.Text, _
                                       matDestinatario)

            ' Exibe mensagem de sucesso na tela
            Me.lblMensagem.Text = "Mensagem enviada com sucesso!"

        Catch ex As Exception
            lblMensagem.Text = "Falha ao enviar a mensagem!"
        End Try

    End Sub

    ''' <summary>
    ''' Método que envia a mensagem a todos os destinatário disponíveis para esse usuário
    ''' </summary>
    Private Sub EnviarTodos()

        ' Instancia os objetos
        Dim objMensagem As Mensagem
        Dim objLogin As Login

        ' Pega a quantidade de ocorrências do combo
        Dim ocorrencias As Integer = Me.qtdDestinatarios - 2
        ' Cria-se um array com a quantidade exata de ocorrências
        Dim destinatarios(ocorrencias) As Integer

        Try
            ' Instancia os objetos
            objMensagem = New Mensagem
            objLogin = New Login

            ' Percorre os itens do combo capturando os números de matrícula de cada destinatário
            ' e armazena no array
            Dim contador As Integer = 0
            For Each item As ListItem In Me.ddlDestinatario.Items
                If Convert.ToInt32(item.Value) <> 0 Then
                    destinatarios(contador) = Convert.ToInt32(item.Value)
                    contador = contador + 1
                End If
            Next

            ' Executa o método de enviar mensagm passando os parâmetros
            objMensagem.EnviarMensagem(objLogin.Matricula, _
                                       Me.txtAssunto.Text, _
                                       CType(Me.ddlPrioridade.SelectedValue, PrioridadeMensagem), _
                                       Me.txtMensagem.Text, _
                                       destinatarios)

            ' Exibe mensagem de sucesso na tela
            Me.lblMensagem.Text = "Mensagem enviada para todos os destinatários com sucesso!"

        Catch ex As Exception
            lblMensagem.Text = "Falha ao enviar a mensagem para todos!"
        End Try

    End Sub

    ''' <summary>
    ''' Método que limpa os campos da tela
    ''' </summary>
    Private Sub LimparCampos()
        ' Inicia os combos
        Me.ddlDestinatario.SelectedIndex = 0
        Me.ddlPrioridade.SelectedIndex = 0
        ' Limpa os campos de entrada
        Me.txtAssunto.Text = String.Empty
        Me.txtMensagem.Text = String.Empty
    End Sub

#End Region

End Class