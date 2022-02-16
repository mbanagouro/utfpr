
''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: MainTCC                                                         <BR/>
''' Objetivo.....: Tela principal de TCC                                           <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class MainTCC
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkGerenciarTCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGerenciarTCC.Click
        Response.Redirect(My.Resources.UrlMaps.GerenciarTCC)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkRelDocs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRelDocs.Click
        Response.Redirect(My.Resources.UrlMaps.Relatorios)
    End Sub

#End Region

End Class