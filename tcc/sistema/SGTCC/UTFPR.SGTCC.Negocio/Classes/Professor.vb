Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Professor.                                                      <BR/>
    ''' Objetivo.....: Classe de acesso as informações dos professores.                <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Professor
        Inherits Usuario

#Region "Atributos"

#End Region

#Region "Propriedades"

        ''' <summary>
        ''' Quantidade de alunos orientandos
        ''' </summary>
        Dim _quantidadeOrientandos As Integer
        Public Property QuantidadeOrientandos() As Integer
            Get
                Return _quantidadeOrientandos
            End Get
            Set(ByVal value As Integer)
                _quantidadeOrientandos = value
            End Set
        End Property

#End Region

#Region "Construtor"

        ''' <summary>
        ''' 
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="matricula"></param>
        ''' <param name="nome"></param>
        Public Sub New(ByVal matricula As Integer, ByVal nome As String)
            MyBase.New(matricula, nome)
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nome"></param>
        Public Sub New(ByVal nome As String)
            MyBase.New(nome)
        End Sub

#End Region

#Region "Métodos"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="matricula"></param>
        Public Sub AtualizarCoordenador(ByVal matricula As Integer)

            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_CoordenadorAtualizar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int32, matricula)

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Professor", "AtualizarCoordenador", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function SelecionarProfessores() As DataSet

            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_SelecionarProfessores")

                ' Executa a query e retona um dataset
                Return objDtBase.ExecuteDataSet(objCommand)

            Catch ex As Exception
                Log.GravarLog("Professor", "SelecionarProfessores", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="matricula"></param>
        ''' <returns></returns>
        Public Function SelecionarProfessorPorMatricula(ByVal matricula As Integer) As Professor

            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_SelecionarProfessorPorMatricula")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaUsuario", DbType.Int64, matricula)

                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                Dim objProfessor As New Professor

                If drResult.HasRows() Then

                    drResult.Read()

                    objProfessor.Nome = drResult(InfoTabelas.USU_NOME).ToString.Trim
                    objProfessor.Matricula = matricula

                Else
                    objProfessor = Nothing
                End If

                Return objProfessor

            Catch ex As Exception
                Log.GravarLog("Professor", "SelecionarProfessorPorMatricula", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function SelecionarOrientadores() As List(Of Professor)

            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_ProfessorSelecionarOrientadores")

                ' Executa a query retornando um SqlDataReader
                Dim drResults As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma coleção de objetos Usuario
                Dim lstProfessores As New List(Of Professor)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Instancia um objeto Usuario
                        Dim objProfessor As New Professor

                        ' Carrega o nome do usuário
                        objProfessor.Nome = drResults(InfoTabelas.USU_NOME).ToString.Trim
                        objProfessor.QuantidadeOrientandos = DirectCast(drResults("totalOrientandos"), Integer)

                        ' Adiciona o objeto Usuario na coleção
                        lstProfessores.Add(objProfessor)

                    End While
                End If

                ' Retorna uma coleção de objeto Usuario
                Return lstProfessores

            Catch ex As Exception
                Log.GravarLog("Professor", "SelecionarOrientadores", ex.Message, TipoErro.Critico)
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function SelecionarTodosProfessores() As List(Of Professor)

            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_SelecionarTodosProfessores")

                ' Executa a query retornando um SqlDataReader
                Dim drResults As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Cria uma coleção de objetos Professor
                Dim lstProfessor As New List(Of Professor)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Instancia um objeto Estado e inicializa com valores do banco
                        Dim objProfessor As New Professor(CInt(drResults(InfoTabelas.USU_MATRICULA)), _
                                                          drResults(InfoTabelas.USU_NOME).ToString.Trim)

                        ' Adiciona um objeto Cidade na coleção
                        lstProfessor.Add(objProfessor)

                    End While
                End If

                ' Retorna a coleção de estados
                Return lstProfessor

            Catch ex As Exception
                Log.GravarLog("Professor", "SelecionarTodosProfessores", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function SelecionarCoordenadorAtual() As Professor

            Dim drResult As SqlDataReader = Nothing
            Dim objProfessor As Professor

            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_CoordenadorAtualSelecionar")

                ' Executa a query
                objDtBase.ExecuteNonQuery(objCommand)

                ' Executa a query retornando um SqlDataReader
                drResult = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                If drResult.HasRows Then

                    drResult.Read()

                    objProfessor = New Professor()
                    objProfessor.Nome = drResult(InfoTabelas.USU_NOME).ToString.Trim
                    objProfessor.Email = drResult(InfoTabelas.USU_EMAIL).ToString.Trim

                Else
                    objProfessor = Nothing
                End If

                Return objProfessor

            Catch ex As Exception
                Log.GravarLog("Professor", "SelecionarCoordenadorAtual", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Function

#End Region

    End Class

End Namespace



