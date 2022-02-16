Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Collections.Generic
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloAP

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Aviso.                                                          <BR/>
    ''' Objetivo.....: Responsável por gerenciar os avisos para os alunos.             <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    ''' <remarks>Classe que implementa a interface INegocioPersistencia</remarks>
    Public Class Aviso
        Implements INegocioPersistencia

#Region "Propriedades"

        ''' <summary>
        ''' Código do Aviso
        ''' </summary>
        Private _codigoAviso As Integer
        Public Property Codigo() As Integer
            Get
                Return Me._codigoAviso
            End Get
            Set(ByVal value As Integer)
                Me._codigoAviso = value
            End Set
        End Property

        ''' <summary>
        ''' Título do Aviso
        ''' </summary>
        Private _tituloAviso As String
        Public Property Titulo() As String
            Get
                Return Me._tituloAviso.Trim
            End Get
            Set(ByVal value As String)
                Me._tituloAviso = value.Trim
            End Set
        End Property

        ''' <summary>
        ''' Conteúdo do Aviso
        ''' </summary>
        Private _conteudoAviso As String
        Public Property Conteudo() As String
            Get
                Return Me._conteudoAviso.Trim
            End Get
            Set(ByVal value As String)
                Me._conteudoAviso = value.Trim
            End Set
        End Property

        ''' <summary>
        ''' Data de Publicação
        ''' </summary>
        Private _dataPublicacaoAviso As Date
        Public Property DataPublicacao() As Date
            Get
                Return Me._dataPublicacaoAviso
            End Get
            Set(ByVal value As Date)
                Me._dataPublicacaoAviso = value
            End Set
        End Property

        ''' <summary>
        ''' Objeto Usuário
        ''' </summary>
        Private _objUsuario As Usuario
        Public Property Usuario() As Usuario
            Get
                Return _objUsuario
            End Get
            Set(ByVal value As Usuario)
                _objUsuario = value
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

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Método que persiste um novo aviso na base de dados
        ''' </summary>
        ''' <param name="matriculaUsuario">Número da matrícula</param>
        ''' <param name="tituloAviso">Título do aviso</param>
        ''' <param name="conteudoAviso">Conteúdo do Aviso</param>
        Public Sub CadastrarAviso(ByVal matriculaUsuario As Integer, ByVal tituloAviso As String, ByVal conteudoAviso As String)

            Me.Usuario = New Usuario(matriculaUsuario)
            Me.Titulo = tituloAviso.Trim
            Me.Conteudo = conteudoAviso.Trim

            Try
                ' Executa o método Salvar() que fará a persistência na base de dados
                Me.Salvar()
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método que atualiza as informações do aviso
        ''' </summary>
        ''' <param name="codigoAviso">Código identificador do aviso</param>
        ''' <param name="tituloAviso">Título do aviso</param>
        ''' <param name="conteudoAviso">Conteúdo do aviso</param>
        Public Sub AtualizaAviso(ByVal codigoAviso As Integer, ByVal tituloAviso As String, ByVal conteudoAviso As String)

            Me.Codigo = codigoAviso
            Me.Titulo = tituloAviso.Trim
            Me.Conteudo = conteudoAviso.Trim

            Try
                ' Executa o método Atualizar() que fará a persistência das atualizações na base de dados
                Me.Atualizar()
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método que exclui o aviso da base
        ''' </summary>
        ''' <param name="codigoAviso">Código identificador do aviso</param>
        Public Sub ExcluirAviso(ByVal codigoAviso As Integer)

            Me.Codigo = codigoAviso

            Try
                ' Executa o método Excluir() que irá excluir o aviso da base
                Me.Excluir()
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Função que retorna um aviso informando o seu código
        ''' </summary>
        ''' <param name="codigoAviso">Código identificador do aviso</param>
        ''' <returns>Objeto Aviso</returns>
        Public Function SelecionarPorCodigo(ByVal codigoAviso As Integer) As Aviso

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim objAviso As Aviso

            Try
                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_AvisoSelecionarPorCodigo")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoAviso", DbType.Int32, codigoAviso)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia um objeto Aviso
                objAviso = New Aviso()

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows() Then
                    ' Faz a leitura do DataReader
                    drResults.Read()

                    ' Carrega as propriedades do Aviso
                    objAviso.Codigo = CInt(drResults(InfoTabelas.AVI_CODIGO))
                    objAviso.Titulo = drResults(InfoTabelas.AVI_TITULO).ToString.Trim
                    objAviso.Conteudo = drResults(InfoTabelas.AVI_CONTEUDO).ToString.Trim
                    objAviso.DataPublicacao = CDate(drResults(InfoTabelas.AVI_DTPUBLICACAO))

                    objAviso.Usuario = New Usuario(CInt(drResults(InfoTabelas.USU_MATRICULA)), _
                                                   drResults(InfoTabelas.USU_NOME).ToString.Trim)
                Else
                    ' Se não encontrar o aviso, deixa o objeto nulo
                    objAviso = Nothing
                End If

                ' Retorna um objeto Aviso
                Return objAviso

            Catch ex As NotFoundException
                Log.GravarLog("Aviso", "SelecionarPorCodigo", ex.Message, TipoErro.Critico)
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Aviso", "SelecionarPorCodigo", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Função que retorna todos os avisos cadastrados na base
        ''' </summary>
        ''' <returns>Lista de Avisos</returns>
        Public Function SelecionarTodosAvisos() As List(Of Aviso)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim lstAvisos As List(Of Aviso)

            Try
                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_AvisoSelecionarTodos")

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma coleção de objetos Aviso
                lstAvisos = New List(Of Aviso)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Chama o método que irá carregar a lista com os avisos
                    lstAvisos = Me.CarregarListAvisos(drResults)
                End If

                ' Retorna a coleção de avisos
                Return lstAvisos

            Catch ex As Exception
                Log.GravarLog("Aviso", "SelecionarTodosAvisos", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Função que retorna somente os últimos avisos cadastrados
        ''' </summary>
        ''' <returns>Lista de avisos</returns>
        Public Function SelecionarUltimosAvisos() As List(Of Aviso)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno 
            Dim lstAvisos As List(Of Aviso)

            Try
                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_AvisoSelecionarUltimos")

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma coleção de objetos Aviso
                lstAvisos = New List(Of Aviso)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Chama o método que irá carregar a lista com os avisos
                    lstAvisos = Me.CarregarListAvisos(drResults)
                End If

                ' Retorna a coleção de avisos
                Return lstAvisos

            Catch ex As Exception
                Log.GravarLog("Aviso", "SelecionarUltimosAvisos", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

#Region "Métodos Privados"

        ''' <summary>
        ''' Carrega uma lista de avisos
        ''' </summary>
        ''' <param name="drResults">DataReader com os resultados</param>
        ''' <returns>Lista de Avisos</returns>
        Private Function CarregarListAvisos(ByVal drResults As SqlDataReader) As List(Of Aviso)

            'Retorno
            Dim lstAvisos As List(Of Aviso)

            Try
                ' Instancia a lista de avisos
                lstAvisos = New List(Of Aviso)

                ' Lê o DataReader enquanto possuir registros
                While drResults.Read

                    ' Cria um objeto Aviso
                    Dim objAviso As New Aviso

                    ' Carrega as propriedades do objeto Aviso
                    objAviso.Codigo = CInt(drResults(InfoTabelas.AVI_CODIGO))
                    objAviso.Titulo = drResults(InfoTabelas.AVI_TITULO).ToString.Trim
                    objAviso.Conteudo = drResults(InfoTabelas.AVI_CONTEUDO).ToString.Trim
                    objAviso.DataPublicacao = CDate(drResults(InfoTabelas.AVI_DTPUBLICACAO))

                    objAviso.Usuario = New Usuario(drResults(InfoTabelas.USU_NOME).ToString.Trim)

                    ' Adiciona um objeto Aviso a coleção
                    lstAvisos.Add(objAviso)

                End While

                ' Retorna a coleção preenchida
                Return lstAvisos

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Método que persiste os dados do aviso na base de dados
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
                objCommand = objDtBase.GetStoredProcCommand("proc_AvisoInserir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@FK_matriculaUsuario", DbType.String, Me.Usuario.Matricula)
                objDtBase.AddInParameter(objCommand, "@tituloAviso", DbType.String, Me.Titulo)
                objDtBase.AddInParameter(objCommand, "@conteudoAviso", DbType.String, Me.Conteudo)
                objDtBase.AddInParameter(objCommand, "@dataPublicacaoAviso", DbType.DateTime, DateTime.Now)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Aviso", "Salvar", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' Método que atualiza os dados do aviso na base de dados
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
                objCommand = objDtBase.GetStoredProcCommand("proc_AvisoAtualizar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoAviso", DbType.Int32, Me.Codigo)
                objDtBase.AddInParameter(objCommand, "@tituloAviso", DbType.String, Me.Titulo)
                objDtBase.AddInParameter(objCommand, "@conteudoAviso", DbType.String, Me.Conteudo)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Aviso", "Atualizar", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' Método que exclui o aviso na base de dados
        ''' </summary>
        ''' <remarks>
        ''' Método implementado da inteface INegocioPersistencia
        ''' </remarks>
        Private Sub Excluir() Implements INegocioPersistencia.Excluir

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try
                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_AvisoExcluir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoAviso", DbType.Int32, Me.Codigo)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Aviso", "Excluir", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace