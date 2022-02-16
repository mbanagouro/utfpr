Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Perfil.                                                         <BR/>
''' Objetivo.....: Code-Behind da página de editar os dados pessoais do usuário.   <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Perfil
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Objeto Usuario
    ''' </summary>
    Private objUsuario As Usuario
    ''' <summary>
    ''' Número da matrícula
    ''' </summary>
    Private matricula As Integer

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

            Try
                ' Executa o método de carregar o combo de estados
                Me.CarregaComboEstados()

                ' Executa o método de carregar os dados pessoais do usuário
                Me.CarregarPerfil()

                ' Posiciona o combo estado com o valor que está cadastrado
                Me.ddlEstados.SelectedValue = Me.objUsuario.Cidade.Estado.Codigo.ToString.Trim

                ' Executa o método de carregar o combo de cidades
                Me.CarregaComboCidadesDoEstado()

                ' Posiciona o combo cidade com o valor que está cadastrado
                Me.ddlCidades.SelectedValue = Me.objUsuario.Cidade.Codigo.ToString.Trim

            Catch ex As NotFoundException
                lblMensagem.Text = ex.Message
            Catch ex As Exception
                lblMatricula.Text = ex.Message
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Evento disparado pela seleção do combo estado
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub ddlEstados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEstados.SelectedIndexChanged

        Try
            ' Executa o método de carregar o combo de cidades
            Me.CarregaComboCidadesDoEstado()
        Catch ex As Exception
            lblMatricula.Text = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' Evento do click do botão Salvar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalvar.Click

        Try
            ' Executa o método atualizar os dados do usuário
            Me.AtualizarUsuario()
        Catch ex As Exception
            lblMensagem.Text = "Falha em atualizar os dados do perfil!"
        End Try

    End Sub

    ''' <summary>
    ''' Evento do click do botão de salvar senha
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub btnSalvarNovaSenha_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalvarNovaSenha.Click

        Try

            ' Executa o método para atualizar a senha
            Me.AtualizarSenhaUsuario()

        Catch ex As ArgumentException
            Me.lblMensagem.Text = ex.Message
        Catch ex As Exception
            lblMensagem.Text = "Falha em atualizar a nova senha!"
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega os dados do usuário na tela
    ''' </summary>
    Private Sub CarregarPerfil()

        ' Declara os objetos
        Dim objLogin As Login

        Try
            ' Instancia os objetos
            objLogin = New Login
            Me.objUsuario = New Usuario

            ' Recupera o número de matrícula do usuário logado da sessão
            Me.matricula = objLogin.Matricula

            ' Retorna um objeto usuário a partir da matrícula informada
            Me.objUsuario = Me.objUsuario.SelecionarUsuarioPorMatricula(Me.matricula)

            ' Verifica se o objeto Usuario existe
            If Me.objUsuario Is Nothing Then
                Throw New NotFoundException("Usuário não encontrado ou inexistente!")
            End If

            ' Carrega os campos da tela
            Me.lblMatricula.Text = Me.objUsuario.Matricula.ToString.Trim
            Me.txtNome.Text = Me.objUsuario.Nome
            Me.txtEmail.Text = Me.objUsuario.Email
            Me.txtTelefone.Text = Me.objUsuario.Telefone
            Me.txtCelular.Text = Me.objUsuario.Celular

        Catch ex As NotFoundException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método que carrega o combo de estados
    ''' </summary>
    Private Sub CarregaComboEstados()

        Try
            ' Limpa o combo Estados
            ddlEstados.Items.Clear()

            ' Popula o combo estado
            With ddlEstados
                .DataSource = Estado.ListaEstados() ' Executa o método que irá retornar uma coleção com todos estados
                .DataTextField = "Nome"
                .DataValueField = "Codigo"
                .DataBind()
                .Items.Insert(0, New ListItem("-- Selecione um Estado --", "0"))
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Throw New Exception("Falha ao carregar o combo de estados")
        End Try

    End Sub

    ''' <summary>
    ''' Método que carrega o combo cidade a partir do estado selecionado
    ''' </summary>
    Private Sub CarregaComboCidadesDoEstado()

        Try
            ' Limpa o combo Cidades
            Me.ddlCidades.Items.Clear()

            ' Pega o código do Estado selecionado
            Dim intEstadoSelecionado As Integer = CInt(Me.ddlEstados.SelectedItem.Value)

            ' Se selecionado a primeira ocorrência, desabilita o combo cidade
            If intEstadoSelecionado = 0 Then
                Me.ddlCidades.Items.Add(New ListItem("-- Selecione uma Cidade --", "0"))
                Me.ddlCidades.Enabled = False
                Exit Sub
            Else
                Me.ddlCidades.Enabled = True
            End If

            ' Popula o combo estado
            With Me.ddlCidades
                .DataSource = Cidade.ListaCidades(intEstadoSelecionado) ' Executa o método que irá retornar uma coleção com as cidades
                .DataTextField = "Nome"
                .DataValueField = "Codigo"
                .DataBind()
                .Items.Insert(0, New ListItem("-- Selecione uma Cidade --", "0"))
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Throw New Exception("Falha ao carregar o combo de cidades")
        End Try

    End Sub

    ''' <summary>
    ''' Método para atualizar o usuário na base de dados
    ''' </summary>
    Private Sub AtualizarUsuario()

        ' Declara os objetos
        Dim objUsuario As Usuario

        Try
            ' Instancia os objetos
            objUsuario = New Usuario

            ' Executa o método atualizar
            objUsuario.AtualizarUsuario(CInt(Me.lblMatricula.Text.Trim), _
                                        Me.txtNome.Text.Trim, _
                                        Me.txtEmail.Text.Trim, _
                                        Me.txtTelefone.Text.Trim, _
                                        Me.txtCelular.Text.Trim, _
                                        CInt(Me.ddlCidades.SelectedItem.Value))

            ' Envia mensagem de sucesso para a tela
            Me.lblMensagem.Text = "Usuário atualizado com sucesso!"

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método para atualizar a senha do usuário
    ''' </summary>
    Private Sub AtualizarSenhaUsuario()

        ' Declara os objetos
        Dim objUsuario As Usuario
        Dim objLogin As Login
        Dim matricula As Integer

        Try

            ' Instancia o objeto Usuario
            objUsuario = New Usuario
            objLogin = New Login

            ' Recupera a matrícula do usuário da sessão e atribui a variável
            matricula = objLogin.Matricula

            ' Executa o método para atualizar senha passando os parâmetros
            objUsuario.AtualizarSenha(matricula, Me.txtSenhaAtual.Text.Trim, Me.txtSenhaNova.Text.Trim)

            ' Exibe mensagem de sucesso na tela
            Me.lblMensagem.Text = "Senha atualizada com sucesso!"

            ' Executa o método para limpar os campos
            Me.LimparCamposSenha()

        Catch ex As ArgumentException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método para limpar os campos de entrada na tela
    ''' </summary>
    Private Sub LimparCamposSenha()
        ' Inicializa os campos de entrada
        Me.txtSenhaAtual.Text = String.Empty
        Me.txtSenhaNova.Text = String.Empty
        Me.txtConfirmSenhaNova.Text = String.Empty
    End Sub

#End Region

End Class