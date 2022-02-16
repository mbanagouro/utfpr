Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Collections.Generic
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloAP

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Estado.                                                         <BR/>
    ''' Objetivo.....: Responsável por manipular os estados existentes do território   <BR/>
    '''                nacional.                                                       <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class Estado

#Region "Propriedades"

        ''' <summary>
        ''' Código
        ''' </summary>
        Private _codigoEstado As Integer
        Public Property Codigo() As Integer
            Get
                Return Me._codigoEstado
            End Get
            Set(ByVal value As Integer)
                Me._codigoEstado = value
            End Set
        End Property

        ''' <summary>
        ''' Nome do Estado
        ''' </summary>
        Private _nomeEstado As String
        Public Property Nome() As String
            Get
                Return Me._nomeEstado
            End Get
            Set(ByVal value As String)
                Me._nomeEstado = value
            End Set
        End Property

        ''' <summary>
        ''' Sigla do Estado
        ''' </summary>
        Private _siglaEstado As String
        Public Property Sigla() As String
            Get
                Return _siglaEstado
            End Get
            Set(ByVal value As String)
                _siglaEstado = value
            End Set
        End Property

#End Region

#Region "Construtores"

        ''' <summary>
        ''' Construtor Padrão
        ''' </summary>
        Public Sub New()
            Me.Codigo = 0
            Me.Nome = String.Empty
            Me.Sigla = String.Empty
        End Sub

        ''' <summary>
        ''' Construtor da classe
        ''' </summary>
        ''' <param name="codEstado">Código do estado</param>
        Public Sub New(ByVal codEstado As Integer)
            Me.Codigo = codEstado
        End Sub

        ''' <summary>
        ''' Construtor da classe
        ''' </summary>
        ''' <param name="codEstado">Código do estado</param>
        ''' <param name="nomeEstado">Nome do estado</param>
        Public Sub New(ByVal codEstado As Integer, _
                       ByVal nomeEstado As String)
            Me.Codigo = codEstado
            Me.Nome = nomeEstado
        End Sub

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Função que retorna as cidades referentes ao código do Estado informado.
        ''' </summary>
        ''' <returns>Retorna uma coleção de objetos Estado</returns>
        Public Shared Function ListaEstados() As List(Of Estado)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim lstEstados As List(Of Estado)

            Try
                ' Define um objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()
                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_EstadoSelecionarTodos")
                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Cria uma coleção de objetos Estado
                lstEstados = New List(Of Estado)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Instancia um objeto Estado e inicializa com valores do banco
                        Dim objEstado As New Estado(CInt(drResults(InfoTabelas.EST_CODIGO)), _
                                                    drResults(InfoTabelas.EST_NOME).ToString.Trim)

                        ' Adiciona um objeto Cidade na coleção
                        lstEstados.Add(objEstado)

                    End While
                Else
                    ' Se não foram encontradas cidades é lançado uma exceção
                    Throw New NotFoundException("Não foram encontrados estados cadastrados!")
                End If

                ' Retorna a coleção de estados
                Return lstEstados

            Catch ex As NotFoundException
                Log.GravarLog("Estado", "ListaEstados", ex.Message, TipoErro.Critico)
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Estado", "ListaEstados", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da memória
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

#End Region

    End Class

End Namespace

