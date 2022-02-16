Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Collections.Generic
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloAP

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Evento.                                                         <BR/>
    ''' Objetivo.....: Classe responsável por gerenciar a agenda do usuário.           <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    ''' <remarks>Classe que implementa a interface INegocioPersistencia</remarks>
    Public Class Evento
        Implements INegocioPersistencia

#Region "Propriedades"

        ''' <summary>
        ''' Código
        ''' </summary>
        Private _codigoEvento As Integer
        Public Property Codigo() As Integer
            Get
                Return Me._codigoEvento
            End Get
            Set(ByVal value As Integer)
                Me._codigoEvento = value
            End Set
        End Property

        ''' <summary>
        ''' Data do Evento
        ''' </summary>
        Private _dataEvento As Date
        Public Property Data() As Date
            Get
                Return Me._dataEvento
            End Get
            Set(ByVal value As Date)
                Me._dataEvento = value
            End Set
        End Property

        ''' <summary>
        ''' Descrição do Evento
        ''' </summary>
        Private _descricaoEvento As String
        Public Property DescricaoEvento() As String
            Get
                Return Me._descricaoEvento
            End Get
            Set(ByVal value As String)
                Me._descricaoEvento = value
            End Set
        End Property

        ''' <summary>
        ''' Nome do Evento
        ''' </summary>
        Private _nomeEvento As String
        Public Property NomeEvento() As String
            Get
                Return Me._nomeEvento
            End Get
            Set(ByVal value As String)
                Me._nomeEvento = value
            End Set
        End Property

        ''' <summary>
        ''' Objeto Usuário
        ''' </summary>
        Private objUsuario As Usuario
        Public Property Usuario() As Usuario
            Get
                Return Me.objUsuario
            End Get
            Set(ByVal value As Usuario)
                Me.objUsuario = value
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
        ''' Método para cadastrar um evento
        ''' </summary>
        ''' <param name="matriculaUsuario">Número da Matrícula do usuário</param>
        ''' <param name="nomeEvento">Nome do Evento</param>
        ''' <param name="descricaoEvento">Descrição do Evento</param>
        ''' <param name="dataEvento">Data do Evento</param>
        Public Sub CadastrarEvento(ByVal matriculaUsuario As Integer, _
                                   ByVal nomeEvento As String, _
                                   ByVal descricaoEvento As String, _
                                   ByVal dataEvento As Date)

            Me.Usuario = New Usuario(matriculaUsuario)
            Me.NomeEvento = nomeEvento
            Me.DescricaoEvento = descricaoEvento
            Me.Data = dataEvento

            Try

                ' Executa o método para cadastrar
                Me.Salvar()

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método para atualizar um evento
        ''' </summary>
        ''' <param name="matriculaUsuario">Número da Matrícula do usuário</param>
        ''' <param name="nomeEvento">Nome do Evento</param>
        ''' <param name="descricaoEvento">Descrição do Evento</param>
        ''' <param name="dataEvento">Data do Evento</param>
        Public Sub AtualizarEvento(ByVal matriculaUsuario As Integer, _
                                   ByVal nomeEvento As String, _
                                   ByVal descricaoEvento As String, _
                                   ByVal dataEvento As Date)

            Me.Usuario = New Usuario(matriculaUsuario)
            Me.NomeEvento = nomeEvento
            Me.DescricaoEvento = descricaoEvento
            Me.Data = dataEvento

            Try

                ' Executa o método para atualizar
                Me.Atualizar()

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método para excluir um evento
        ''' </summary>
        ''' <param name="matriculaUsuario">Número da Matrícula do usuário</param>
        ''' <param name="dataevento">Data do Evento</param>
        Public Sub ExcluirEvento(ByVal matriculaUsuario As Integer, ByVal dataevento As Date)

            Me.Usuario = New Usuario(matriculaUsuario)
            Me.Data = dataevento

            Try

                ' Executa o método de exclusão
                Me.Excluir()

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Função que retorna os eventos de um determinado usuário
        ''' </summary>
        ''' <param name="matriculaUsuario">Número da Matrícula do usuário</param>
        ''' <returns>Lista de Eventos</returns>
        Public Function SelecionarEventos(ByVal matriculaUsuario As Integer) As List(Of Evento)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim lstEventos As List(Of Evento)

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_EventoSelecionarTodos")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, matriculaUsuario)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma coleção de objetos Evento
                lstEventos = New List(Of Evento)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Cria um objeto Evento
                        Dim objEvento As New Evento

                        ' Carrega as informações do evento
                        objEvento.NomeEvento = drResults(InfoTabelas.AGE_NOME).ToString.Trim
                        objEvento.Data = CDate(drResults(InfoTabelas.AGE_DATA))

                        ' Adiciona o evento na coleção
                        lstEventos.Add(objEvento)

                    End While
                End If

                ' Retorna a coleção de eventos
                Return lstEventos

            Catch ex As Exception
                Log.GravarLog("Evento", "SelecionarEventos", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Função que retorna os últimos eventos de um determinado usuário
        ''' </summary>
        ''' <param name="matriculaUsuario">Número da Matrícula do usuário</param>
        ''' <returns>Lista de Eventos</returns>
        Public Function SelecionarProximosEventos(ByVal matriculaUsuario As Integer) As List(Of Evento)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim lstEventos As List(Of Evento)

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_EventoSelecionarProximosEventos")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, matriculaUsuario)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma coleção de objetos Evento
                lstEventos = New List(Of Evento)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then

                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Cria um objeto Evento
                        Dim objEvento As New Evento

                        ' Carrega as informações do evento
                        objEvento.NomeEvento = drResults(InfoTabelas.AGE_NOME).ToString.Trim
                        objEvento.Data = CDate(drResults(InfoTabelas.AGE_DATA))

                        ' Adiciona o evento na coleção
                        lstEventos.Add(objEvento)

                    End While

                End If

                ' Retorna a coleção de eventos
                Return lstEventos

            Catch ex As Exception
                Log.GravarLog("Evento", "SelecionarProximosEventos", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Função que retorna um evento
        ''' </summary>
        ''' <param name="matriculaUsuario">Número da Matrícula do usuário</param>
        ''' <param name="dataEvento">Data do Evento</param>
        ''' <returns>Objeto Evento</returns>
        Public Function SelecionarEventoPorData(ByVal matriculaUsuario As Integer, ByVal dataEvento As Date) As Evento

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim objEvento As Evento

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_EventoSelecionarPorData")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, matriculaUsuario)
                objDtBase.AddInParameter(objCommand, "@dataEvento", DbType.Date, dataEvento)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Cria um objeto Evento
                objEvento = New Evento

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows() Then
                    ' Faz a leitura do DataReader
                    drResults.Read()

                    ' Carrega as informações do evento
                    objEvento.Usuario = New Usuario(CInt(drResults(InfoTabelas.USU_MATRICULA)))

                    objEvento.NomeEvento = drResults(InfoTabelas.AGE_NOME).ToString.Trim
                    objEvento.DescricaoEvento = drResults(InfoTabelas.AGE_DESCRICAO).ToString.Trim
                    objEvento.Data = CDate(drResults(InfoTabelas.AGE_DATA))
                Else

                    ' Se não houver evento, deixa o objeto nulo
                    objEvento = Nothing

                End If

                ' Retorna um objeto Evento
                Return objEvento

            Catch ex As Exception
                Log.GravarLog("Evento", "SelecionarEventoPorData", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

#End Region

#Region "Métodos Privados"

        ''' <summary>
        ''' Método que atualiza um evento
        ''' </summary>
        ''' <remarks>Método implementado da interface INegocioPersistencia</remarks>
        Private Sub Atualizar() Implements INegocioPersistencia.Atualizar

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_EventoAtualizar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, Me.Usuario.Matricula)
                objDtBase.AddInParameter(objCommand, "@nomeEvento", DbType.String, Me.NomeEvento)
                objDtBase.AddInParameter(objCommand, "@descricaoEvento", DbType.String, Me.DescricaoEvento)
                objDtBase.AddInParameter(objCommand, "@dataEvento", DbType.DateTime, Me.Data)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Evento", "Atualiza", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' Método que exclui um evento
        ''' </summary>
        ''' <remarks>Método implementado da interface INegocioPersistencia</remarks>
        Private Sub Excluir() Implements INegocioPersistencia.Excluir

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_EventoExcluir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, Me.Usuario.Matricula)
                objDtBase.AddInParameter(objCommand, "@dataEvento", DbType.DateTime, Me.Data)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Evento", "Excluir", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' Método que cadastra um novo evento
        ''' </summary>
        ''' <remarks>Método implementado da interface INegocioPersistencia</remarks>
        Private Sub Salvar() Implements INegocioPersistencia.Salvar

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_EventoInserir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, Me.Usuario.Matricula)
                objDtBase.AddInParameter(objCommand, "@nomeEvento", DbType.String, Me.NomeEvento)
                objDtBase.AddInParameter(objCommand, "@descricaoEvento", DbType.String, Me.DescricaoEvento)
                objDtBase.AddInParameter(objCommand, "@dataEvento", DbType.DateTime, Me.Data)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Evento", "Salvar", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

#End Region

    End Class

End Namespace




