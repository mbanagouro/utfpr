Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: VisualizarAviso.                                                <BR/>
''' Objetivo.....: Code-Behind da página que visualiza o aviso.                    <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class VisualizarAviso
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Código identificador do aviso
    ''' </summary>
    Dim codigoAviso As Integer
    ''' <summary>
    ''' Objeto Aviso
    ''' </summary>
    Dim objAviso As Aviso

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
                Me.RecuperaCodigoAviso()
                ' Executa o método que irá carregar o aviso na tela
                Me.CarregarAviso()
            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Recupera o código da sessão
    ''' </summary>
    Private Sub RecuperaCodigoAviso()
        If Not Session("codigoAviso") Is Nothing AndAlso Not Session("codigoAviso").ToString = String.Empty Then
            Me.codigoAviso = CInt(Session("codigoAviso"))
        Else

        End If
    End Sub

    ''' <summary>
    ''' Método que carrega as informações do aviso na tela
    ''' </summary>
    Private Sub CarregarAviso()

        ' Declara os objetos
        Dim objAviso As Aviso

        Try
            ' Instancia os objetos
            objAviso = New Aviso

            ' Recupera o objeto com as informações do aviso
            objAviso = objAviso.SelecionarPorCodigo(Me.codigoAviso)

            If Not objAviso Is Nothing Then
                ' Carrega os campos na tela
                Me.lblTitulo.Text = objAviso.Titulo.Trim
                Me.lblConteudo.Text = objAviso.Conteudo.Trim
                Me.lblAutor.Text = "Publicado por: " & objAviso.Usuario.Nome
                Me.lblDataPublicacao.Text = "Enviado em: " & FormatDateTime(objAviso.DataPublicacao, DateFormat.LongDate)
            Else
                lblMensagem.Text = "Aviso não existe"
            End If

        Catch ex As Exception
            ' Em caso de erro, uma mensagem é enviada para o usuário
            lblMensagem.Text = ex.Message
        End Try

    End Sub

#End Region

End Class