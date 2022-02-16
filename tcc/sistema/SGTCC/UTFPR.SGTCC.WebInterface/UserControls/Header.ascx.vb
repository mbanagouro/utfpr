
''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Header.                                                         <BR/>
''' Objetivo.....: Code-Behind do User Control Header.                             <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Header
    Inherits System.Web.UI.UserControl

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ExibeUserInfo()
    End Sub

    ''' <summary>
    ''' Evento do click do link Dados Pessoais
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkPerfil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPerfil.Click
        Response.Redirect(My.Resources.UrlMaps.Perfil)
    End Sub

    ''' <summary>
    ''' Evento do click do link Entrar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkdEntrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkdEntrar.Click
        Response.Redirect(My.Resources.UrlMaps.Login)
    End Sub

    ''' <summary>
    ''' Evento do click do link Sair
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.Click
        Me.Deslogar()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Controle da User Bar
    ''' </summary>
    Private Sub ExibeUserInfo()

        ' Cria o objeto login
        Dim objLogin As New Login

        ' Verifica se possui usuário na sessão
        If objLogin.IsAutenticado Then
            lblUsuario.Text = objLogin.NomeUsuario
            userLogOut.Visible = False
            userLogIn.Visible = True
        Else
            userLogOut.Visible = True
            userLogIn.Visible = False
        End If

    End Sub

    ''' <summary>
    ''' Método que efeuta o logout
    ''' </summary>
    Private Sub Deslogar()

        Dim objLogin As Login

        Try
            ' Cria o objeto login
            objLogin = New Login

            ' Executa o método de logoff
            objLogin.Deslogar()

            ' Executa o método de exibir informações do usuário
            Me.ExibeUserInfo()

            Response.Redirect(My.Resources.UrlMaps.Home)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class