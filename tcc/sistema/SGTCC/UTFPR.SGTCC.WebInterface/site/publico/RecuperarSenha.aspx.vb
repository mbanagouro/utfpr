Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: RecuperaSenha.                                                  <BR/>
''' Objetivo.....: Code-Behind da página para recuperação de senha do usuário.     <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class RecuperarSenha
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Evento click do botão Enviar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Try
            Me.RecuperarSenha()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que executa a recuperação da senha
    ''' </summary>
    Private Sub RecuperarSenha()

        ' Declara os objetos
        Dim objUsuario As Usuario

        Try
            ' Instancia o objeto
            objUsuario = New Usuario
            objUsuario = objUsuario.SelecionarUsuarioPorMatriculaEmail(CInt(Me.txtMatricula.Text.Trim), _
                                                                       Me.txtEmail.Text.Trim)

            If objUsuario Is Nothing Then
                ' TODO: Enviar mensagem de usuário não existente
            Else
                Me.EnviarEmail(objUsuario)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método de envio de e-mail
    ''' </summary>
    ''' <param name="objUsuario">Usuario</param>
    Private Sub EnviarEmail(ByVal objUsuario As Usuario)
        ' TODO: implementar envio de email
    End Sub

#End Region

End Class