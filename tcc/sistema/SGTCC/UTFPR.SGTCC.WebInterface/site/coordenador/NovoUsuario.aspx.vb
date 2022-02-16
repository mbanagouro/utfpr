Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: NovoUsuario.                                                    <BR/>
''' Objetivo.....: Code-Behind da página novo usuário.                             <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class NovoUsuario
    Inherits System.Web.UI.Page

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
                ' Executa o método para carregar o combo do tipo de usuário
                Me.CarregaComboUsuarios()
                ' Executa o método para carregar os estados
                Me.CarregaComboEstados()
                ' Executa o método para carregar cidades
                Me.CarregaComboCidadesDoEstado()
            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Evento de seleção do combo de estados
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub ddlEstados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEstados.SelectedIndexChanged

        Try
            ' Executa o método para carregar cidades
            Me.CarregaComboCidadesDoEstado()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Evento do click do botão cadastrar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub btnCadastrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCadastrar.Click

        Try
            Me.CadastrarUsuario()
        Catch ex As DuplicateKeyException
            lblMensagem.Text = ex.Message
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Evento do link Gerenciar TCC
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkGerenciarTCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGerenciarTCC.Click
        Response.Redirect(My.Resources.UrlMaps.GerenciarTCC)
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para carregar o combo do Tipo Usuário
    ''' </summary>
    Private Sub CarregaComboUsuarios()

        ' Carrega o combo do tipo de usuário
        With Me.ddlUsuario
            .Items.Add(New ListItem("Selecione Usuário -----", "0"))
            .Items.Add(New ListItem("Aluno", CInt(TipoUsuario.Aluno).ToString.Trim))
            .Items.Add(New ListItem("Professor", CInt(TipoUsuario.Professor).ToString.Trim))
        End With

    End Sub

    ''' <summary>
    ''' Método para carregar o combo de Estados
    ''' </summary>
    Private Sub CarregaComboEstados()

        Try
            ' Limpa o combo Estados
            Me.ddlEstados.Items.Clear()

            With Me.ddlEstados
                .DataSource = Estado.ListaEstados() ' Função que retorna uma coleção de estados
                .DataTextField = "Nome"
                .DataValueField = "Codigo"
                .DataBind()
                .Items.Insert(0, New ListItem("Selecione um Estado -----", "0"))
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método para carregar o combo de cidades a partir do estado selecionado
    ''' </summary>
    Private Sub CarregaComboCidadesDoEstado()

        Try
            ' Limpa o combo cidades
            Me.ddlCidades.Items.Clear()

            ' Pega o código do estado selecionado
            Dim intEstadoSelecionado As Integer = CInt(Me.ddlEstados.SelectedItem.Value)

            ' Se selecionado a primeira ocorrência, desabilita o combo cidade
            If intEstadoSelecionado = 0 Then
                Me.ddlCidades.Items.Add(New ListItem("Selecione uma Cidade -----", "0"))
                Me.ddlCidades.Enabled = False
                Exit Sub
            Else
                ' Se não, habilita o combo
                Me.ddlCidades.Enabled = True
            End If

            ' Carrega o combo de cidades
            With Me.ddlCidades
                .DataSource = Cidade.ListaCidades(intEstadoSelecionado) ' Função que retorna uma coleção de cidades
                .DataTextField = "Nome"
                .DataValueField = "Codigo"
                .DataBind()
                .Items.Insert(0, New ListItem("Selecione uma Cidade -----", "0"))
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método para cadastrar um novo usuário no sistema
    ''' </summary>
    Private Sub CadastrarUsuario()

        ' Declara os objetos
        Dim objUsuario As Usuario

        Try
            ' Instancia os objetos
            objUsuario = New Usuario

            ' Executa o método cadastrar passando os parâmetros
            objUsuario.CadastrarUsuario(CInt(Me.txtMatricula.Text.Trim), _
                                        Me.txtNome.Text.Trim, _
                                        Me.txtEmail.Text.Trim, _
                                        Me.txtTelefone.Text.Trim, _
                                        Me.txtCelular.Text.Trim, _
                                        CType(Me.ddlUsuario.SelectedItem.Value, TipoUsuario), _
                                        CInt(Me.ddlCidades.SelectedItem.Value))

            ' Envia mensagem de secesso ao usuário
            Me.lblMensagem.Text = "Usuário cadastrado com sucesso!"

            ' Executa o método para limpar os campos da tela
            Me.LimparCampos()

        Catch ex As DuplicateKeyException
            Me.lblMensagem.Text = ex.Message
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método para limpar os campos da telas
    ''' </summary>
    Private Sub LimparCampos()

        ' Limpa os campos de entrada
        Me.txtMatricula.Text = String.Empty
        Me.txtNome.Text = String.Empty
        Me.txtEmail.Text = String.Empty
        Me.txtTelefone.Text = String.Empty
        Me.txtCelular.Text = String.Empty

        ' Inicializa o combo usuário
        Me.ddlUsuario.SelectedIndex = 0
        ' Inicializa o combo estados
        Me.ddlEstados.SelectedIndex = 0
        ' Executa o método de carregar cidades
        Me.CarregaComboCidadesDoEstado()

    End Sub

#End Region

End Class