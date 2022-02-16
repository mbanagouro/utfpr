Imports UTFPR.SGTCC.Negocio.Comum
Imports UTFPR.SGTCC.Negocio.ModuloAP

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Login                                                           <BR/>
''' Objetivo.....: Autentica e autoriza o usuário na aplicação.                    <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Public Class Login
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Separador de quebra
    ''' </summary>
    Private strQuebra As Char = "±"c

#End Region

#Region "Propriedades"

    ''' <summary>
    ''' Retorna a matrícula do usuário armazenado na autenticação
    ''' </summary>
    Public ReadOnly Property Matricula() As Integer
        Get
            Dim arr() As String = User.Identity.Name.Split(Me.strQuebra)
            Return CInt(arr(0))
        End Get
    End Property

    ''' <summary>
    ''' Retorna o nome do usuário armazenado na autenticação
    ''' </summary>
    Public ReadOnly Property NomeUsuario() As String
        Get
            Dim arr() As String = User.Identity.Name.Split(Me.strQuebra)
            Return arr(1).Trim
        End Get
    End Property

#End Region

#Region "Construtores"

    ''' <summary>
    ''' Construtor padrão
    ''' </summary>
    Public Sub New()
        MyBase.New()
    End Sub

#End Region

#Region "Métodos Públicos"

    ''' <summary>
    ''' Função para efetuar o login do usuário no sistema
    ''' </summary>
    ''' <param name="matricula">Número da matrícula</param>
    ''' <param name="senha">Senha informada pelo usuário</param>
    Public Sub Logar(ByVal matricula As Integer, ByVal senha As String)

        ' Declara os objetos
        Dim objUsuario As Usuario

        Try
            ' Instancia os objetos
            objUsuario = New Usuario()

            ' Recupera o usuário cadastrado no sistema
            objUsuario = objUsuario.SelecionarUsuarioPorLogin(matricula, senha.Trim)

            ' Verifica se o objeto Usuario existe
            If objUsuario Is Nothing Then
                Throw New NotFoundException("Usuário não existe ou Nª da matrícula e senha incorretos!")
            End If

            ' Executa o método para autenticar o usuário
            Me.AutenticarUsuario(objUsuario.Matricula.ToString.Trim, objUsuario.Nome.Trim, objUsuario.Tipo.ToString.Trim)

        Catch ex As NotFoundException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método para dar logout do usuário no sistema
    ''' </summary>
    Public Sub Deslogar()
        ' Executa o método para destruir todas as variáveis de sessão
        Me.DestruirSessao()
        ' Executa o método de logout da classe FormsAuthentication
        FormsAuthentication.SignOut()
    End Sub

    ''' <summary>
    ''' Função que verifica se o usuário está autenticado na aplicação
    ''' </summary>
    ''' <returns>True ou False</returns>
    Public Function IsAutenticado() As Boolean
        Return User.Identity.IsAuthenticated
    End Function

    ''' <summary>
    ''' Função que verifica se o usuário possui permissão a uma determinada regra
    ''' </summary>
    ''' <param name="regra"></param>
    ''' <returns>True ou False</returns>
    Public Function IsPermissao(ByVal regra As String) As Boolean
        Return User.IsInRole(regra)
    End Function

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para autenticar e autorizar o usuário no sistema
    ''' </summary>
    ''' <param name="matricula">Nº da Matrícula</param>
    ''' <param name="nome">Nome do usuário</param>
    ''' <param name="tipoUsuario">Tipo do usuário</param>
    Private Sub AutenticarUsuario(ByVal matricula As String, ByVal nome As String, ByVal tipoUsuario As String)

        FormsAuthentication.Initialize()

        Dim strChave As String = Me.MontaChave(matricula, nome)
        Dim Auth As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, strChave, DateTime.Now, DateTime.Now.AddMinutes(20), False, tipoUsuario, FormsAuthentication.FormsCookiePath)

        Dim hash As String = FormsAuthentication.Encrypt(Auth)
        Dim cookie As New HttpCookie(FormsAuthentication.FormsCookieName, hash)

        HttpContext.Current.Response.Cookies.Add(cookie)

    End Sub

    ''' <summary>
    ''' Método que monta a chave que será armazenada na autenticação
    ''' </summary>
    ''' <param name="matricula">Nº da Matrícula</param>
    ''' <param name="nome">Nome do usuário</param>
    ''' <returns>Chave</returns>
    Private Function MontaChave(ByVal matricula As String, ByVal nome As String) As String
        Return matricula & Me.strQuebra & nome
    End Function

    ''' <summary>
    ''' Método para destruir todas as variáveis de sessão do sistema
    ''' </summary>
    Private Sub DestruirSessao()
        Session.Contents.RemoveAll()
    End Sub

#End Region

End Class



