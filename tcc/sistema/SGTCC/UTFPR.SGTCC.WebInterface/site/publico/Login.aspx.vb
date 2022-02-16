Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Login1.                                                         <BR/>
''' Objetivo.....: Code-Behind da página de logon.                                 <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Login1
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Evento do click do botão Entrar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnEntrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEntrar.Click

        Try
            ' Executa o método para efeuar o logon
            Me.Logar()
        Catch ex As NotFoundException
            lblMensagem.Text = ex.Message
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' Evento click do link que redireciona para página de recuperar senha
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub lnkHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHelp.Click
        Me.RedirecionaRecuperaSenha()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para efetuar o logon no sistema
    ''' </summary>
    Private Sub Logar()

        ' Declara os objetos
        Dim objLogin As New Login
        Dim matricula As Integer = 0
        Dim senha As String = String.Empty

        Try

            If Not txtMatricula.Text.Trim = String.Empty Then
                matricula = Convert.ToInt32(txtMatricula.Text.Trim)
            End If

            senha = txtSenha.Text.Trim.ToLower

            ' Instancia um objeto Login
            objLogin = New Login

            ' Executa o método de login
            ' Caso o usuário seja autenticado será redirecionado para a página principal
            objLogin.Logar(matricula, senha)

            Me.RedirecionaHome()

        Catch ex As NotFoundException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método que redireciona para a página Home
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RedirecionaHome()
        Response.Redirect(My.Resources.UrlMaps.Home)
    End Sub

    ''' <summary>
    ''' Método que redireciona para a página de recuperar senha
    ''' </summary>
    Private Sub RedirecionaRecuperaSenha()
        Response.Redirect(My.Resources.UrlMaps.RecuperarSenha)
    End Sub

#End Region

End Class