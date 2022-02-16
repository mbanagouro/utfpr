
''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Erro.                                                           <BR/>
''' Objetivo.....: Code-Behind da página de Erro.                                  <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Erro
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Context.Items.Contains("Error") Then

            Dim objException As Exception = DirectCast(Me.Context.Items("Error"), Exception)

            If Not objException Is Nothing Then

                While Not objException.InnerException Is Nothing
                    objException = objException.InnerException
                End While

                Me.lblMsgErro.Text = objException.Message

                Server.ClearError()

            End If

        ElseIf CBool(Request.QueryString("Error")) Then

            Me.lblMsgErro.Text = Server.UrlDecode(Request.QueryString("Error").Trim())

        End If

    End Sub

End Class