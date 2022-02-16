
''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Download.                                                       <BR/>
''' Objetivo.....: Code-Behind da página de download de arquivos.                  <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Download
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arquivoCaminhoCompleto As String
        Dim nomeArquivo As String

        If String.IsNullOrEmpty(Session("ArquivoDownload").ToString.Trim) Then
            ' Redireciona o usuário para a página padrão
            Response.Redirect(My.Resources.UrlMaps.Home)
        Else
            ' Pega o caminho completo do arquivo que está na sessão
            arquivoCaminhoCompleto = Session("ArquivoDownload").ToString.Trim

            ' Se o arquivo existir
            If System.IO.File.Exists(arquivoCaminhoCompleto) Then
                nomeArquivo = System.IO.Path.GetFileName(arquivoCaminhoCompleto)

                Response.Clear()
                Response.ContentType = "application/octet-stream"
                Response.AddHeader("Content-Disposition", _
                                   "attachment;filename=""" & nomeArquivo & """")
                Response.WriteFile(arquivoCaminhoCompleto)
                Response.End()
            Else
                Response.Write("Estranho, o arquivo não existe mais...")
            End If
        End If

    End Sub

#End Region

End Class
