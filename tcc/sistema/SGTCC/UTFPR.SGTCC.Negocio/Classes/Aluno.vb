Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Aluno.                                                          <BR/>
    ''' Objetivo.....: Classe de acesso as informações dos alunos.                     <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Aluno
        Inherits Usuario

#Region "Construtor"

        ''' <summary>
        ''' Construtor padrão
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' Construtor sobrecarregado
        ''' </summary>
        ''' <param name="matricula">número Matricula do usuário</param>
        ''' <param name="nome">Nome do usuário</param>
        Public Sub New(ByVal matricula As Integer, ByVal nome As String)
            MyBase.New(matricula, nome)
        End Sub

#End Region

#Region "Métodos"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function SelecionarTodosAlunos() As List(Of Aluno)

            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_SelecionarTodosAlunos")

                ' Executa a query retornando um SqlDataReader
                Dim drResults As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Cria uma coleção de objetos Estado
                Dim lstAlunos As New List(Of Aluno)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then

                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Instancia um objeto Estado e inicializa com valores do banco
                        Dim objAluno As New Aluno(CInt(drResults(InfoTabelas.USU_MATRICULA)), _
                                                  drResults(InfoTabelas.USU_NOME).ToString.Trim)

                        ' Adiciona um objeto Cidade na coleção
                        lstAlunos.Add(objAluno)

                    End While

                Else

                    ' Se não foram encontradas cidades é lançado uma exceção
                    lstAlunos = Nothing

                End If

                Return lstAlunos

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

    End Class

End Namespace




