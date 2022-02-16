Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: EventoAgenda.                                                   <BR/>
''' Objetivo.....: Code-Behind da página de cadastro, alteração e exclusão de      <BR/>
'''                eventos na agenda.                                              <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class EventoAgenda
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ' Declara os objetos
            Dim objEvento As Evento

            Try

                ' Se o parâmetro estiver vazio, retorna para a Agenda
                If Session("dataEvento") Is Nothing OrElse Session("dataEvento").ToString.Trim = String.Empty Then
                    RedirecionaAgenda()
                End If

                ' Recupera a data da QueryString
                Dim dataEvento As Date = CDate(Session("dataEvento"))

                ' Joga a data no campo da tela
                Me.lblData.Text = dataEvento.ToString("dd/MM/yyyy")
                Me.hdnData.Value = dataEvento.ToString("dd/MM/yyyy")

                ' Instancia o objeto
                objEvento = New Evento
                ' Busca o evento
                objEvento = Me.BuscarEvento(dataEvento)
                ' Carrega a tela
                Me.CarregaTela(objEvento)

            Catch ex As Exception
                lblMensagem.Text = "Falha ao carregar o evento!"
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Evento do botão Salvar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

        Try
            ' Executa o método para cadastrar um novo evento
            Me.CadastrarEvento()
        Catch ex As Exception
            lblMensagem.Text = "Falha ao cadastrar o evento!"
        End Try

    End Sub

    ''' <summary>
    ''' Evento do botão Atualizar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnAtualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtualizar.Click

        Try
            ' Executa o método que irá atualizar o evento
            Me.AtualizarEvento()
        Catch ex As Exception
            lblMensagem.Text = "Falha ao atualizar o evento!"
        End Try

    End Sub

    ''' <summary>
    ''' Evento do botão Excluir
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcluir.Click

        Try
            ' TODO: Não foi possível excluir o evento
            Me.ExcluirEvento()
        Catch ex As Exception
            lblMensagem.Text = "Falha ao excluir o evento!"
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que busca o evento selecionado
    ''' </summary>
    ''' <param name="dataEvento">Data do evento</param>
    ''' <returns>Evento</returns>
    Private Function BuscarEvento(ByVal dataEvento As Date) As Evento

        ' Declara os objetos
        Dim objLogin As Login
        Dim objEvento As Evento

        Try
            ' Instancia o objeto
            objEvento = New Evento
            objLogin = New Login

            ' Retorna o evento selecionado
            Return objEvento.SelecionarEventoPorData(objLogin.Matricula, dataEvento)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Método que carrega a tela com os dados do Evento
    ''' </summary>
    ''' <param name="objEvento">Evento</param>
    Private Sub CarregaTela(Optional ByVal objEvento As Evento = Nothing)

        If objEvento Is Nothing Then
            ' Habilita o botão Salvar
            Me.btnSalvar.Visible = True
        Else
            ' Carrega os campos da tela
            Me.txtTitulo.Text = objEvento.NomeEvento
            Me.txtDescricao.Text = objEvento.DescricaoEvento
            ' Habilita os botões Atualizar e Excluir
            Me.btnAtualizar.Visible = True
            Me.btnExcluir.Visible = True
        End If

    End Sub

    ''' <summary>
    ''' Método que cadastra o evento
    ''' </summary>
    Private Sub CadastrarEvento()

        ' Declara os objetos
        Dim objLogin As Login
        Dim objEvento As Evento

        Try
            ' Instancia os objetos
            objLogin = New Login
            objEvento = New Evento

            ' Executa o método que irá cadastrar o evento
            objEvento.CadastrarEvento(objLogin.Matricula, _
                                      Me.txtTitulo.Text.Trim, _
                                      Me.txtDescricao.Text.Trim, _
                                      CDate(Me.hdnData.Value))

            Me.RedirecionaAgenda()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método que atualiza o evento 
    ''' </summary>
    Private Sub AtualizarEvento()

        ' Declara os objetos
        Dim objLogin As Login
        Dim objEvento As Evento

        Try
            ' Instancia os objetos
            objLogin = New Login
            objEvento = New Evento

            ' Executa o método que irá atualizar o evento
            objEvento.AtualizarEvento(objLogin.Matricula, _
                                      Me.txtTitulo.Text.Trim, _
                                      Me.txtDescricao.Text.Trim, _
                                      CDate(hdnData.Value))

            Me.RedirecionaAgenda()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método que exclui o evento
    ''' </summary>
    Private Sub ExcluirEvento()

        ' Declara os objetos
        Dim objLogin As Login
        Dim objEvento As Evento

        Try
            ' Instancia os objetos
            objLogin = New Login
            objEvento = New Evento

            ' Executa o método que irá excluir o evento
            objEvento.ExcluirEvento(objLogin.Matricula, CDate(Me.hdnData.Value))

            Me.RedirecionaAgenda()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Redireciona para a página de agenda
    ''' </summary>
    Private Sub RedirecionaAgenda()
        Response.Redirect(My.Resources.UrlMaps.Agenda)
    End Sub

#End Region

End Class