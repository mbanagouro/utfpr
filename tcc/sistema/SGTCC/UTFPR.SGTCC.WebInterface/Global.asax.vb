Imports System.Web.SessionState
Imports System.Security.Principal

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    ''' <summary>
    ''' Efetua a autenticação do usuário a cada requisição
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use

        ' Verifica se o objeto User não é nulo
        If Not (HttpContext.Current.User Is Nothing) Then
            ' Verifica se o User está autenticado
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                ' Verifica se o tipo do User é FormsIdentity 
                If TypeOf HttpContext.Current.User.Identity Is FormsIdentity Then
                    ' Recupera a identidade do User
                    Dim fi As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
                    ' Recupera o Ticket do User
                    Dim fat As FormsAuthenticationTicket = fi.Ticket

                    ' Recupera as regras do User em um array
                    Dim astrRoles As String() = fat.UserData.Split("|"c)
                    ' Passa as informações das regras para o User
                    HttpContext.Current.User = New GenericPrincipal(fi, astrRoles)
                End If
            End If
        End If
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        '' Fires when an error occurs
        '' Resgata o erro, salva no context
        'Me.Context.Items.Add("Error", Me.Context.Error)
        '' Chama a página de erro
        'Me.Server.Transfer("~/site/erro/Erro.aspx")
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class