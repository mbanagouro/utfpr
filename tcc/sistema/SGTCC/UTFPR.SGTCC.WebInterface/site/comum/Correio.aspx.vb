Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Text

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Correio.                                                        <BR/>
''' Objetivo.....: Code-Behind da página de correio.                               <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Correio
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Enumerador do tipo da mensagem
    ''' </summary>
    Dim tipoMsg As TipoMensagem

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
            ' Executa o método para selecionar as mensagens recebidas
            Me.CarregarMensagensRecebidas()
        End If

    End Sub

    ''' <summary>
    ''' Evento do click do link Mensagens Recebidas
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkRecebidas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRecebidas.Click
        ' Executa o método para carregar as mensagens recebidas no GridView
        Me.CarregarMensagensRecebidas()
    End Sub

    ''' <summary>
    ''' Evento do click do link Mensagens Enviadas
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkEnviadas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEnviadas.Click
        ' Executa o método para carregar as mensagens enviadas no GridView
        Me.CarregarMensagensEnviadas()
    End Sub

    ''' <summary>
    ''' Evento do click do link Nova Mensagem
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkNovaMensagem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNovaMensagem.Click
        Response.Redirect(My.Resources.UrlMaps.NovaMensagem)
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para carregar o GridView de mensagen enviadas pelo usuário
    ''' </summary>
    Private Sub CarregarMensagensEnviadas()

        ' Atribui o tipo enviada para a variável global
        Me.tipoMsg = TipoMensagem.Enviada

        ' Exibe o GridView enviadas
        Me.pnlMensagensEnviadas.Visible = True
        Me.pnlMensagensRecebidas.Visible = False

        ' Executa o método para carregar o GridView
        Me.ucMensEnv.CarregarGridMensagens()

        ' Altera o título da Gridview para Mensagens Envidas
        Me.lblMsgEnvRec.Text = "Enviadas"
        Me.imgIconeTipoMensagens.ImageUrl = "~/imagens/icones/email_enviados.png"

    End Sub

    ''' <summary>
    ''' Método para carregar o GridView de mensagen recebidas
    ''' </summary>
    Private Sub CarregarMensagensRecebidas()

        ' Atribui o tipo enviada para a variável global
        Me.tipoMsg = TipoMensagem.Recebida

        ' Exibe o GridView recebidas
        Me.pnlMensagensRecebidas.Visible = True
        Me.pnlMensagensEnviadas.Visible = False

        ' Executa o método para carregar o GridView
        Me.ucMensRec.CarregarGridMensagens()

        ' Altera o título da Gridview para Mensagens Recebidas
        Me.lblMsgEnvRec.Text = "Recebidas"
        Me.imgIconeTipoMensagens.ImageUrl = "~/imagens/icones/email_recebidos.png"

    End Sub

#End Region

End Class