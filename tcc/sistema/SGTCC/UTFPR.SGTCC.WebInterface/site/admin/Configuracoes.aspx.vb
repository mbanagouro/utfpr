
''' <summary>
''' 
''' </summary>
Partial Public Class Configuracoes
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkDefCoordenador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDefCoordenador.Click
        Response.Redirect(My.Resources.UrlMaps.DefinirCoordenador)
    End Sub

#End Region

End Class