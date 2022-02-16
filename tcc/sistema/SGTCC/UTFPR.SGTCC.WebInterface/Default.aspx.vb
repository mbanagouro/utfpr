
''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: _Default.                                                       <BR/>
''' Objetivo.....: Code-Behind da página padrão do sistema.                        <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class _Default
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Redireciona para a página principal do sistema
        Response.Redirect(My.Resources.UrlMaps.Home)
    End Sub

#End Region

End Class