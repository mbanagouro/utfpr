Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: EditarAviso                                                     <BR/>
''' Objetivo.....: Code-Behind da página de editar um aviso já existente.          <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class EditarAviso
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Código identificador do aviso
    ''' </summary>
    Private codigoAviso As Integer

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
                ' Recupera o código
                Me.RecuperaCodigoSessao()
                ' Executa o método que irá carregar o aviso na tela
                Me.CarregarAviso()

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Evento do click do botão Atualizar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnAtualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtualizar.Click
        Me.AtualizarAviso()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que recupera o código do aviso da sessão
    ''' </summary>
    Private Sub RecuperaCodigoSessao()

        ' Recupera o código da sessão
        If Not Session("codigoAviso") Is Nothing OrElse Session("codigoAviso").ToString = String.Empty Then
            Me.codigoAviso = CInt(Session("codigoAviso"))
        Else
            Response.Redirect(My.Resources.UrlMaps.GerenciarAvisos)
        End If

        ' Armazena na variável hidden
        Me.hdnCodigoAviso.Value = Me.codigoAviso.ToString.Trim

    End Sub

    ''' <summary>
    ''' Método que carrega as informações do aviso na tela
    ''' </summary>
    Private Sub CarregarAviso()

        ' Declara os objetos
        Dim objAviso As Aviso

        Try
            ' Instancia o objeto
            objAviso = New Aviso

            ' Recupera o objeto com as informações do aviso
            objAviso = objAviso.SelecionarPorCodigo(Me.codigoAviso)

            ' Carrega os campos na tela
            Me.txtTitulo.Text = objAviso.Titulo.Trim
            Me.txtConteudo.Value = objAviso.Conteudo.Trim
            Me.lblDataPublicacao.Text = objAviso.DataPublicacao.ToString("dd/MM/yyyy")

        Catch ex As Exception
            ' Em caso de erro, uma mensagem é enviada para o usuário
            lblMensagem.Text = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' Método que atualiza o aviso na base
    ''' </summary>
    Private Sub AtualizarAviso()

        ' Declara os objetos
        Dim objAviso As Aviso

        Try
            ' Instancia o objeto
            objAviso = New Aviso

            ' Recupera o código do campo hidden
            Me.codigoAviso = CInt(hdnCodigoAviso.Value)

            ' Executa o método para atualizar o aviso na base
            objAviso.AtualizaAviso(Me.codigoAviso, _
                                   Me.txtTitulo.Text.Trim, _
                                   Me.txtConteudo.Value.Trim)

            ' Exibe a mensagem de aviso na tela
            lblMensagem.Text = "Aviso atualizado com sucesso."

        Catch ex As Exception
            ' Em caso de erro, uma mensagem é enviada para o usuário
            lblMensagem.Text = ex.Message
        End Try

    End Sub

#End Region

End Class