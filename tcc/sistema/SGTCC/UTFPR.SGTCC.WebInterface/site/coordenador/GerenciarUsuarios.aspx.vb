
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Partial Public Class MainUsuarios
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkMeuPerfil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMeuPerfil.Click
        Response.Redirect(My.Resources.UrlMaps.Perfil)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkNovoUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNovoUsuario.Click
        Response.Redirect(My.Resources.UrlMaps.NovoUsuario)
    End Sub

#End Region

End Class