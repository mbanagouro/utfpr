
''' <summary>
''' Página de acesso a todos os usuários, contendo links para as dúvidas mas frequentes.
''' </summary>
Partial Public Class Materia
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkDatasImportantes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDatasImportantes.Click
        Response.Redirect(My.Resources.UrlMaps.DatasImportantes)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkDefesa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDefesa.Click
        Response.Redirect(My.Resources.UrlMaps.Defesa)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkProposta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProposta.Click
        Response.Redirect(My.Resources.UrlMaps.Proposta)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkOrientadores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkOrientadores.Click
        Response.Redirect(My.Resources.UrlMaps.Orientadores)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkSituacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSituacao.Click
        Response.Redirect(My.Resources.UrlMaps.SituacaoAluno)
    End Sub

#End Region

End Class