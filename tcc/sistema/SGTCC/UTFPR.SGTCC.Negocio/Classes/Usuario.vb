Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Collections.Generic
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloAP

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Usuario.                                                        <BR/>
    ''' Objetivo.....: Classe responsável por manipular e acessar aos dados            <BR/>
    '''                dos usuários.                                                   <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class Usuario
        Implements INegocioPersistencia

#Region "Propriedades"

        ''' <summary>
        ''' Nº Matrícula
        ''' </summary>
        Private _matriculaUsuario As Integer
        Public Property Matricula() As Integer
            Get
                Return Me._matriculaUsuario
            End Get
            Set(ByVal value As Integer)
                Me._matriculaUsuario = value
            End Set
        End Property

        ''' <summary>
        ''' Nome do Usuário
        ''' </summary>
        Private _nomeUsuario As String
        Public Property Nome() As String
            Get
                Return Me._nomeUsuario
            End Get
            Set(ByVal value As String)
                Me._nomeUsuario = value.Trim()
            End Set
        End Property

        ''' <summary>
        ''' Email do Usuário
        ''' </summary>
        Private _emailUsuario As String
        Public Property Email() As String
            Get
                Return Me._emailUsuario
            End Get
            Set(ByVal value As String)
                Me._emailUsuario = value.Trim()
            End Set
        End Property

        ''' <summary>
        ''' Senha do Usuário
        ''' </summary>
        Private _senhaUsuario As String
        Public Property Senha() As String
            Get
                Return Me._senhaUsuario
            End Get
            Set(ByVal value As String)
                Me._senhaUsuario = value.Trim().ToLower()
            End Set
        End Property

        ''' <summary>
        ''' Nº Telefone
        ''' </summary>
        Private _telefoneUsuario As String
        Public Property Telefone() As String
            Get
                Return Me._telefoneUsuario
            End Get
            Set(ByVal value As String)
                Me._telefoneUsuario = value.Trim()
            End Set
        End Property

        ''' <summary>
        '''  Nº Celular
        ''' </summary>
        Private _celularUsuario As String
        Public Property Celular() As String
            Get
                Return Me._celularUsuario
            End Get
            Set(ByVal value As String)
                Me._celularUsuario = value.Trim()
            End Set
        End Property

        ''' <summary>
        '''  Tipo do Usuário
        ''' </summary>
        Private _tipoUsuario As TipoUsuario
        Public Property Tipo() As TipoUsuario
            Get
                Return Me._tipoUsuario
            End Get
            Set(ByVal value As TipoUsuario)
                Me._tipoUsuario = value
            End Set
        End Property

        ''' <summary>
        ''' Objeto Cidade
        ''' </summary>
        Private _objCidade As Cidade
        Public Property Cidade() As Cidade
            Get
                Return Me._objCidade
            End Get
            Set(ByVal value As Cidade)
                Me._objCidade = value
            End Set
        End Property

#End Region

#Region "Construtores"

        ''' <summary>
        ''' Construtor Padrão
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' Construtor que cria um usuário com um código de matricula informados
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        Public Sub New(ByVal matricula As Integer)
            Me.Matricula = matricula
        End Sub

        ''' <summary>
        ''' Construtor que cria um usuário com o nome informado
        ''' </summary>
        ''' <param name="nome">Nome do usuário</param>
        Public Sub New(ByVal nome As String)
            Me.Nome = nome
        End Sub

        ''' <summary>
        ''' Construtor que cria um usuário com um código de matricula e nome informados
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <param name="nome">Nome do usuário</param>
        Public Sub New(ByVal matricula As Integer, ByVal nome As String)
            Me.Matricula = matricula
            Me.Nome = nome
        End Sub

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Método para cadastrar um novo usuário no sistema.
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <param name="nome">Nome do usuário</param>
        ''' <param name="email">Endereço de Email</param>
        ''' <param name="telefone">Número do Telefone</param>
        ''' <param name="celular">Número do Celular</param>
        ''' <param name="tipo">Código identificador do tipo do usuário</param>
        ''' <param name="codigoCidade">Código identificador da cidade</param>
        Public Sub CadastrarUsuario(ByVal matricula As Integer, _
                                    ByVal nome As String, _
                                    ByVal email As String, _
                                    ByVal telefone As String, _
                                    ByVal celular As String, _
                                    ByVal tipo As TipoUsuario, _
                                    ByVal codigoCidade As Integer)

            ' Carrega as propriedades do objeto
            Me.Matricula = matricula
            Me.Nome = nome
            Me.Senha = "123"
            Me.Email = email
            Me.Telefone = telefone
            Me.Celular = celular
            Me.Tipo = tipo
            Me.Cidade = New Cidade(codigoCidade)

            Try
                ' Recupera o usuário da base de dados
                Dim objUsuario As Usuario = Me.RecuperaUsuario(Me.Matricula)

                ' Verifica se usuário já existe na base de dados
                If objUsuario Is Nothing Then
                    Me.Salvar()
                Else
                    Throw New DuplicateKeyException("O usuário da matrícula " & Me.Matricula & " já possui cadastro no sistema!")
                End If

            Catch ex As DuplicateKeyException
                Throw ex
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método para atualizar os dados do usuário.
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <param name="nome">Nome do usuário</param>
        ''' <param name="email">Endereço de Email</param>
        ''' <param name="telefone">Número do Telefone</param>
        ''' <param name="celular">Número do Celular</param>
        ''' <param name="codigoCidade">Código identificador da cidade</param>
        Public Sub AtualizarUsuario(ByVal matricula As Integer, _
                                    ByVal nome As String, _
                                    ByVal email As String, _
                                    ByVal telefone As String, _
                                    ByVal celular As String, _
                                    ByVal codigoCidade As Integer)

            ' Carrega as propriedades do objeto
            Me.Matricula = matricula
            Me.Nome = nome
            Me.Email = email
            Me.Telefone = telefone
            Me.Celular = celular
            Me.Cidade = New Cidade(codigoCidade)

            Try
                ' Chama o método Atualizar para atualizar o usuário na base
                Me.Atualizar()
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método para redefinir a senha do usuário.
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <param name="senhaAtual">Senha atual do usuário</param>
        ''' <param name="senhaNova">Nova senha informada pelo usuário</param>
        Public Sub AtualizarSenha(ByVal matricula As Integer, ByVal senhaAtual As String, ByVal senhaNova As String)

            Me.Matricula = matricula

            ' Verifica se a senha atual informada está correta
            If Not IsSenhaAtual(senhaAtual) Then
                Throw New ArgumentException("A senha atual informada está incorreta!")
            End If

            Me.Senha = senhaNova

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_UsuarioAtualizarSenha")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, Me.Matricula)
                objDtBase.AddInParameter(objCommand, "@senhaUsuario", DbType.String, Security.Cifrar(Me.Senha.Trim.ToLower))

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch argEx As ArgumentException
                Throw argEx
            Catch ex As Exception
                Log.GravarLog("Usuario", "AtualizarSenha", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera o objeto da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' Função que retorna as informações de um determinado usuário por meio do
        ''' número da matrícula e senha.
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <returns>Objeto Usuario</returns>
        Public Function SelecionarUsuarioPorMatricula(ByVal matricula As Integer) As Usuario

            Try
                Return Me.RecuperaUsuario(matricula)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Função que retorna as informações de um determinado usuário por meio do
        ''' número da matrícula e senha.
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <param name="senha">Senha do usuário</param>
        ''' <returns>Objeto Usuario</returns>
        Public Function SelecionarUsuarioPorLogin(ByVal matricula As Integer, ByVal senha As String) As Usuario

            Try
                If (matricula = 0) And (senha Is Nothing Or senha.Trim = String.Empty) Then
                    Throw New ValidaException("Favor informe a matrícula e a senha!")
                ElseIf matricula = 0 Then
                    Throw New ValidaException("Favor informe a matrícula!")
                ElseIf senha Is Nothing OrElse senha.Trim = String.Empty Then
                    Throw New ValidaException("Favor informe senha!")
                End If

                Return Me.RecuperaUsuario(matricula, senha.Trim.ToLower)

            Catch valEx As ValidaException
                Throw valEx
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Função que retorna as informações de um determinado usuário por meio do
        ''' número da matrícula e senha.
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <param name="email">Email do usuário</param>
        ''' <returns>Objeto Usuario</returns>
        Public Function SelecionarUsuarioPorMatriculaEmail(ByVal matricula As Integer, ByVal email As String) As Usuario

            Try
                Return Me.RecuperaUsuario(matricula, Nothing, email.Trim)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

#End Region

#Region "Métodos Privados"

        ''' <summary>
        ''' Função que retorna as informações de um determinado usuário por meio 
        ''' do número da matrícula.
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <param name="senha">Parâmetro opcional: senha do usuário</param>
        ''' <param name="email">Parâmetro opcional: email do usuário</param>
        ''' <returns>Objeto Usuario</returns>
        Private Function RecuperaUsuario(ByVal matricula As Integer, _
                                         Optional ByVal senha As String = Nothing, _
                                         Optional ByVal email As String = Nothing) As Usuario

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResult As SqlDataReader = Nothing

            ' Retorno
            Dim objUsuario As Usuario

            Try
                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()
                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_UsuarioSelecionar")
                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, matricula)

                If Not senha Is Nothing AndAlso Not senha.Trim = String.Empty Then
                    objDtBase.AddInParameter(objCommand, "@senhaUsuario", DbType.String, Security.Cifrar(senha.Trim.ToLower))
                Else
                    objDtBase.AddInParameter(objCommand, "@senhaUsuario", DbType.String, DBNull.Value)
                End If

                If Not email Is Nothing AndAlso Not email.Trim = String.Empty Then
                    objDtBase.AddInParameter(objCommand, "@emailUsuario", DbType.String, email.ToString.Trim)
                Else
                    objDtBase.AddInParameter(objCommand, "@emailUsuario", DbType.String, DBNull.Value)
                End If

                ' Executa a query retornando um SqlDataReader
                drResult = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia um objeto Usuario
                objUsuario = New Usuario()

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResult.HasRows() Then

                    ' Faz a leitura do DataReader
                    drResult.Read()

                    ' Carrega as propriedades do usuário
                    objUsuario.Matricula = CInt(drResult(InfoTabelas.USU_MATRICULA))
                    objUsuario.Nome = drResult(InfoTabelas.USU_NOME).ToString.Trim
                    objUsuario.Email = drResult(InfoTabelas.USU_EMAIL).ToString.Trim
                    objUsuario.Senha = drResult(InfoTabelas.USU_SENHA).ToString.Trim
                    objUsuario.Telefone = drResult(InfoTabelas.USU_TEL).ToString.Trim
                    objUsuario.Celular = drResult(InfoTabelas.USU_CEL).ToString.Trim
                    objUsuario.Tipo = CType(drResult(InfoTabelas.USU_TIPO), TipoUsuario)

                    objUsuario.Cidade = New Cidade(CInt(drResult(InfoTabelas.CID_CODIGO)), _
                                                   drResult(InfoTabelas.CID_NOME).ToString.Trim)

                    objUsuario.Cidade.Estado = New Estado(CInt(drResult(InfoTabelas.EST_CODIGO)), _
                                                          drResult(InfoTabelas.EST_NOME).ToString.Trim)

                Else
                    ' Se não retornar usuário, atribui nulo pro objeto
                    objUsuario = Nothing
                End If

                ' Retorna o objeto Usuário para a aplicação cliente
                Return objUsuario

            Catch ex As Exception
                Log.GravarLog("Usuario", "RecuperaUsuario", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Método que persiste os dados do usuário na base de dados
        ''' </summary>
        ''' <remarks>
        ''' Método implementado da inteface INegocioPersistencia
        ''' </remarks>
        Private Sub Salvar() Implements INegocioPersistencia.Salvar

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try
                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_UsuarioInserir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, Me.Matricula)
                objDtBase.AddInParameter(objCommand, "@nomeUsuario", DbType.String, Me.Nome)
                objDtBase.AddInParameter(objCommand, "@senhaUsuario", DbType.String, Security.Cifrar(Me.Senha))
                objDtBase.AddInParameter(objCommand, "@emailUsuario", DbType.String, Me.Email)
                objDtBase.AddInParameter(objCommand, "@telefoneUsuario", DbType.String, Me.Telefone)
                objDtBase.AddInParameter(objCommand, "@celularUsuario", DbType.String, Me.Celular)
                objDtBase.AddInParameter(objCommand, "@tipoUsuario", DbType.Int32, Me.Tipo)
                objDtBase.AddInParameter(objCommand, "@codigoCidade", DbType.Int32, Me.Cidade.Codigo)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Usuario", "Salvar", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' Método que atualiza os dados do usuário na base de dados
        ''' </summary>
        ''' <remarks>
        ''' Método implementado da inteface INegocioPersistencia
        ''' </remarks>
        Private Sub Atualizar() Implements INegocioPersistencia.Atualizar

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try
                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_UsuarioAtualizar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, Me.Matricula)
                objDtBase.AddInParameter(objCommand, "@nomeUsuario", DbType.String, Me.Nome)
                objDtBase.AddInParameter(objCommand, "@emailUsuario", DbType.String, Me.Email)
                objDtBase.AddInParameter(objCommand, "@telefoneUsuario", DbType.String, Me.Telefone)
                objDtBase.AddInParameter(objCommand, "@celularUsuario", DbType.String, Me.Celular)
                objDtBase.AddInParameter(objCommand, "@FK_codigoCidade", DbType.String, Me.Cidade.Codigo)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Usuario", "Atualizar", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' Método que exclui um usuário da base de dados
        ''' </summary>
        ''' <remarks>
        ''' Método implementado da inteface INegocioPersistencia
        ''' </remarks>
        Private Sub ExcluirUsuario() Implements INegocioPersistencia.Excluir
            Throw New NotImplementedException("Este método ainda não possui implementação!")
        End Sub

        ''' <summary>
        ''' Método que valida se a senha atual informada pelo usuário é a mesma que
        ''' está cadastrada.
        ''' </summary>
        ''' <param name="senhaAtual">Senha atual do usuário</param>
        ''' <returns>Retorna True se a senha for a mesma da base, senão retorna False</returns>
        ''' <remarks></remarks>
        Private Function IsSenhaAtual(ByVal senhaAtual As String) As Boolean

            ' Declara os objetos
            Dim objUsuario As Usuario

            Try
                ' Busca o usuário na base
                objUsuario = Me.SelecionarUsuarioPorMatricula(Me.Matricula)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If Not objUsuario Is Nothing Then
                    ' Se a senha atual não for igual a senha que está cadastrada no banco
                    ' é retornado false
                    If Not senhaAtual.Equals(Security.Decifrar(objUsuario.Senha)) Then
                        Return False
                    End If
                Else
                    ' Se não encontrou nenhum usuário a exceção é lançada
                    Throw New NotFoundException("O usuário da matrícula " & Me.Matricula & "não foi encontrado!")
                End If

                Return True

            Catch ex As NotFoundException
                Log.GravarLog("Usuario", "VerificarSenha", ex.Message, TipoErro.Critico)
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Usuario", "VerificarSenha", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Function

#End Region

    End Class

End Namespace

