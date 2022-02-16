Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: GerenciarAvisos                                                 <BR/>
''' Objetivo.....: Code-Behind da página que gerencia os avisos no sistema.        <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class GerenciarAvisos
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub GerenciarAvisos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.CarregaGridAvisos()
        End If

    End Sub

    ''' <summary>
    ''' Evento do botão Novo Aviso
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnNovoAviso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovoAviso.Click
        Response.Redirect(My.Resources.UrlMaps.NovoAviso)
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que executa o carregamento da grid de avisos
    ''' </summary>
    Private Sub CarregaGridAvisos()
        Me.grvAvisos.CarregarGridAvisos()
    End Sub

#End Region

End Class