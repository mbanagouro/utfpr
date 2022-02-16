Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloCA
    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Banca                                                           <BR/>
    ''' Objetivo.....: Responsável por gerenciar as Ações relacionado à Banca          <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class Banca
        Implements INegocioPersistencia

#Region "Propriedades"

        ''' <summary>
        ''' Tipo da Banca
        ''' </summary>
        Private _tipoBanca As Integer
        Public Property TipoBanca() As Integer
            Get
                Return Me._tipoBanca
            End Get
            Set(ByVal value As Integer)
                Me._tipoBanca = value
            End Set
        End Property

        ''' <summary>
        ''' Data da Apresentação
        ''' </summary>
        Private _dataApresentacao As DateTime
        Public Property Data() As DateTime
            Get
                Return Me._dataApresentacao
            End Get
            Set(ByVal value As DateTime)
                Me._dataApresentacao = value
            End Set
        End Property

        ''' <summary>
        ''' Local da apresentação
        ''' </summary>
        Private _salaBanca As String
        Public Property Local() As String
            Get
                Return Me._salaBanca
            End Get
            Set(ByVal value As String)
                Me._salaBanca = value
            End Set
        End Property

        ''' <summary>
        ''' Professor Avaliador 01
        ''' </summary>
        ''' <remarks></remarks>
        Private _objConvidado1 As Professor
        Public Property Convidado01() As Professor
            Get
                Return Me._objConvidado1
            End Get
            Set(ByVal value As Professor)
                Me._objConvidado1 = value
            End Set
        End Property

        ''' <summary>
        ''' Professor Avaliador 02
        ''' </summary>
        ''' <remarks></remarks>
        Private _objConvidado2 As Professor
        Public Property Convidado02() As Professor
            Get
                Return Me._objConvidado2
            End Get
            Set(ByVal value As Professor)
                Me._objConvidado2 = value
            End Set
        End Property

        ''' <summary>
        ''' Objeto TCC
        ''' </summary>
        ''' <remarks></remarks>
        Private _objTCC As TCC
        Public Property TCC() As TCC
            Get
                Return Me._objTCC
            End Get
            Set(ByVal value As TCC)
                Me._objTCC = value
            End Set
        End Property

#End Region

#Region "Construtores"

        ''' <summary>
        ''' Construtor Padrão
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub

#End Region

#Region "Funções e Métodos"
        ''' <summary>
        ''' Método para atualizar uma Banca
        ''' </summary>
        Public Sub Atualizar() Implements Comum.INegocioPersistencia.Atualizar

            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_BancaAtualizar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@tipoBanca", DbType.Int32, Me.TipoBanca)
                objDtBase.AddInParameter(objCommand, "@codigoTcc", DbType.Int32, Me.TCC.Codigo)
                objDtBase.AddInParameter(objCommand, "@dataBanca", DbType.DateTime, Me.Data)
                objDtBase.AddInParameter(objCommand, "@salaBanca", DbType.String, Me.Local)
                objDtBase.AddInParameter(objCommand, "@matriculaConv1", DbType.Int32, Me.Convidado01.Matricula)
                objDtBase.AddInParameter(objCommand, "@matriculaConv2", DbType.Int32, Me.Convidado02.Matricula)

                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Throw ex
            End Try


        End Sub

        ''' <summary>
        ''' Método para exluir uma Banca
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Excluir() Implements Comum.INegocioPersistencia.Excluir

            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_BancaExcluir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@tipoBanca", DbType.Int32, Me.TipoBanca)
                objDtBase.AddInParameter(objCommand, "@codigoTcc", DbType.Int32, Me.TCC.Codigo)

                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Médoto para cadastro de uma Banca
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Salvar() Implements Comum.INegocioPersistencia.Salvar
            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_BancaInserir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@tipoBanca", DbType.Int32, Me.TipoBanca)
                objDtBase.AddInParameter(objCommand, "@codigoTcc", DbType.Int32, Me.TCC.Codigo)
                objDtBase.AddInParameter(objCommand, "@dataBanca", DbType.DateTime, Me.Data)
                objDtBase.AddInParameter(objCommand, "@salaBanca", DbType.String, Me.Local)
                objDtBase.AddInParameter(objCommand, "@matriculaConv1", DbType.Int32, Me.Convidado01.Matricula)
                objDtBase.AddInParameter(objCommand, "@matriculaConv2", DbType.Int32, Me.Convidado02.Matricula)

                'Persiste os dados no banco de dados
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        ''' <summary>
        ''' Função de busca de quantidade de bancas de um TCC já cadastrado no sistema
        ''' </summary>
        ''' <returns>Retorna numero intero com quantidade de bancas</returns>
        Public Function BuscarQtdeBancasCadastradas() As Integer
            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_BancaCountPorCodigoTcc")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoTCC", DbType.Int32, Me.TCC.Codigo)

                Dim datasetAux As DataSet = objDtBase.ExecuteDataSet(objCommand)
                'Retorna a quantidade de Bancas Cadastradas
                Return CInt(datasetAux.Tables(0).Rows(0).Item("qtdeBanca"))

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' Função dpara Verificar se já existe uma banca cadastrada no horário informado
        ''' </summary>
        ''' <returns>Retorna um numero inteiro </returns>
        ''' <remarks>Caso seja retornado zeros, não existe banca cadastrada na data/horario informado. Diferente de zero, tratar como erro</remarks>
        Public Function VerificarDuplicidadeBanca() As Integer
            Try

                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_BancaVerificaDuplicidadeHorario")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@dataBanca", DbType.DateTime, Me.Data)

                ' Executa a query retornando um SqlDataReader
                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                If drResult.HasRows() Then
                    ' Faz a leitura do DataReader
                    drResult.Read()

                    Return CType(drResult("totalBancas"), Integer)
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' Função de Busca de Banca por tipo (Proposta ou Defesa)
        ''' </summary>
        ''' <param name="tipoBanca">Tipo da Banca</param>
        ''' <param name="codigoTcc">Código do TCC</param>
        ''' <returns>retorna um objeto Banca</returns>
        Public Function BuscaBancaPorTipo(ByVal tipoBanca As Integer, ByVal codigoTcc As Integer) As Banca
            Try

                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_BancaSelecionar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@tipoBanca", DbType.Int64, tipoBanca)
                objDtBase.AddInParameter(objCommand, "@codigoTcc", DbType.Int64, codigoTcc)

                ' Executa a query retornando um SqlDataReader
                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                Dim objBanca As New Banca
                Dim objProfessor01 As New Professor
                Dim objProfessor02 As New Professor

                If drResult.HasRows() Then

                    ' Faz a primeira leitura do DataReader
                    drResult.Read()

                    objBanca.TipoBanca = tipoBanca
                    objBanca.Local = drResult(InfoTabelas.BANCA_SALA).ToString.Trim
                    objBanca.Data = CDate(drResult(InfoTabelas.BANCA_DATA))
                    objProfessor01.Matricula = CInt(drResult(InfoTabelas.BANPROF_MATRICULA))
                    objBanca.Convidado01 = objProfessor01

                    drResult.Read()

                    objProfessor02.Matricula = CInt(drResult(InfoTabelas.BANPROF_MATRICULA))
                    objBanca.Convidado02 = objProfessor02

                Else
                    objBanca = Nothing
                End If

                Return objBanca

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

    End Class
End Namespace

