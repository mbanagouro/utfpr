
''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Download.                                                       <BR/>
''' Objetivo.....: Code-Behind da p�gina de download de arquivos.                  <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Download
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da p�gina
    ''' </summary>
    ''' <param name="sender">Objeto que cont�m informa��es sobre o disparador do evento</param>
    ''' <param name="e">Objeto que cont�m as informa��es sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arquivoCaminhoCompleto As String
        Dim nomeArquivo As String

        If String.IsNullOrEmpty(Session("ArquivoDownload").ToString.Trim) Then
            ' Redireciona o usu�rio para a p�gina padr�o
            Response.Redirect(My.Resources.UrlMaps.Home)
        Else
            ' Pega o caminho completo do arquivo que est� na sess�o
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
                Response.Write("Estranho, o arquivo n�o existe mais...")
            End If
        End If

    End Sub

#End Region

End Class
