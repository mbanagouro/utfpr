Imports UTFPR.SGTCC.Negocio.ModuloAP

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: VisualizarMensagem.                                             <BR/>
''' Objetivo.....: Code-Behind da página de visualizar as mensagens.               <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class VisualizarMensagem
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Enumerador do tipo da mensagem
    ''' </summary>
    Private tipoMsg As TipoMensagem
    ''' <summary>
    ''' Código identificador da mensagem
    ''' </summary>
    Private codMensagem As Integer

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

            Me.ValidaEntrada()
            ' Executa o método para carregar a mensagem na tela
            Me.CarregarMensagem()

        End If

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Valida os parâmetros da sessão
    ''' </summary>
    Private Sub ValidaEntrada()

        ' Pega o código da query string
        If Not Session("codigoMensagem") Is Nothing AndAlso _
           Not Session("codigoMensagem").ToString = String.Empty Then
            Me.codMensagem = CInt(Session("codigoMensagem"))
        Else
            Me.codMensagem = 0
        End If

        ' Pega o tipo da mensagem da query string
        If Not Session("tipoMensagem") Is Nothing AndAlso _
           Not Session("tipoMensagem").ToString = String.Empty Then
            Me.tipoMsg = CType(Session("tipoMensagem"), TipoMensagem)
        Else
            Me.tipoMsg = 0
        End If

        ' Se o código da mensagem ou o tipo estiverem vazios
        ' retorna a página de correio
        If codMensagem = 0 Or tipoMsg = 0 Then
            Response.Redirect(My.Resources.UrlMaps.Correio)
        End If

    End Sub

    ''' <summary>
    ''' Método que carrega a mensagem selecionada na tela
    ''' </summary>
    Private Sub CarregarMensagem()

        ' Declara os objetos
        Dim lstUsuarios As List(Of Usuario)
        Dim objMensagem As Mensagem

        Try
            ' Instancia os objetos
            objMensagem = New Mensagem

            ' Verifica o tipo da mensagem
            If Me.tipoMsg = TipoMensagem.Enviada Then
                ' Carrega o objeto Mensagem sendo uma mensagem enviada
                objMensagem = objMensagem.SelecionarEnviadaPorCodigo(Me.codMensagem)
            ElseIf Me.tipoMsg = TipoMensagem.Recebida Then
                ' Carrega o objeto Mensagem sendo uma mensagem recebida
                objMensagem = objMensagem.SelecionarRecebidaPorCodigo(Me.codMensagem)
            End If

            ' Recupera a coleçao de usuários destinatários ou remetentes
            lstUsuarios = objMensagem.Usuarios

            ' Percorre a coleção de usuários e vai concatenando na Label
            For Each Usuario As Usuario In lstUsuarios
                Me.lblRemetente.Text += Usuario.Nome & "; "
            Next

            ' Carrega os controles da tela
            Me.lblAssunto.Text = objMensagem.Assunto
            Me.lblConteudo.Text = objMensagem.Conteudo

        Catch ex As Exception
            Me.lblMensagem.Text = "Falha ao carregar a mensagem!"
            Me.divErro.Style.Add("display", "blocks")
            Me.divMsg.Style.Add("display", "none")
        End Try

    End Sub

#End Region

End Class