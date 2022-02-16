Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Collections.Generic
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloAP

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Cidade.                                                         <BR/>
    ''' Objetivo.....: Responsável por manipular as cidades existentes do território   <BR/>
    '''                nacional.                                                       <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class Cidade

#Region "Propriedades"

        ''' <summary>
        ''' Código
        ''' </summary>
        Private _codigoCidade As Integer
        Public Property Codigo() As Integer
            Get
                Return Me._codigoCidade
            End Get
            Set(ByVal value As Integer)
                Me._codigoCidade = value
            End Set
        End Property

        ''' <summary>
        ''' Nome da Cidade
        ''' </summary>
        Private _nomeCidade As String
        Public Property Nome() As String
            Get
                Return Me._nomeCidade
            End Get
            Set(ByVal value As String)
                Me._nomeCidade = value
            End Set
        End Property

        ''' <summary>
        ''' Objeto Estado
        ''' </summary>
        Private _objEstadoCidade As Estado
        Public Property Estado() As Estado
            Get
                Return Me._objEstadoCidade
            End Get
            Set(ByVal value As Estado)
                Me._objEstadoCidade = value
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
        End Sub

        ''' <summary>
        ''' Construtor que cria uma nova cidade inicializando com seu código
        ''' </summary>
        ''' <param name="codCidade">Código da cidade</param>
        Public Sub New(ByVal codCidade As Integer)
            Me.Codigo = codCidade
        End Sub

        ''' <summary>
        ''' Construtor que cria uma nova cidade inicializando com seu código e nome
        ''' </summary>
        ''' <param name="codCidade">Código da cidade</param>
        ''' <param name="nomeCidade">Nome da cidade</param>
        Public Sub New(ByVal codCidade As Integer, ByVal nomeCidade As String)
            Me.Codigo = codCidade
            Me.Nome = nomeCidade
        End Sub

#End Region

#Region "Métodos Públicos"

        ''' <summary>
        ''' Função que retorna as cidades referentes ao código do Estado informado.
        ''' </summary>
        ''' <param name="codigoEstado">Código identificador do estado</param>
        ''' <returns>Lista de Cidade</returns>
        Public Shared Function ListaCidades(ByVal codigoEstado As Integer) As List(Of Cidade)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim lstCidades As List(Of Cidade)

            Try
                ' Define um objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()
                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_CidadeSelecionarPorEstado")
                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@FK_codigoEstado", DbType.Int32, codigoEstado)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Cria uma coleção de objetos Cidade
                lstCidades = New List(Of Cidade)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Instancia um objeto Cidade e inicializa com valores do banco
                        Dim objCidade As New Cidade(CInt(drResults(InfoTabelas.CID_CODIGO)), _
                                                    drResults(InfoTabelas.CID_NOME).ToString.Trim)

                        ' Adiciona um objeto Cidade na coleção
                        lstCidades.Add(objCidade)

                    End While
                Else
                    ' Se não foram encontradas cidades é lançado uma exceção
                    Throw New NotFoundException("Não foram encontradas cidades para o estado de código " & codigoEstado & "!")
                End If

                ' Retorna a coleção de cidades
                Return lstCidades

            Catch ex As NotFoundException
                Log.GravarLog("Cidade", "ListaCidades", ex.Message, TipoErro.Critico)
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Cidade", "ListaCidades", ex.Message, TipoErro.Inesperado)
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