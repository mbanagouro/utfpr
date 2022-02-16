''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Relatorios                                                      <BR/>
''' Objetivo.....: Tela contendo os links para os relatorios do Coordenador        <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Relatorios
    Inherits System.Web.UI.Page

#Region "Eventos"

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
    Private Sub lnkRelDocs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRelDocs.Click
        Response.Redirect(My.Resources.UrlMaps.RelatoriosPorData)
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