Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloCA

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: TCC                                                             <BR/>
    ''' Objetivo.....: Responsável por gerenciar as Ações relacionados ao TCC          <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class TCC
        Implements INegocioPersistencia

#Region "Propriedades e Atributos"
        ''' <summary>
        ''' Código do TCC
        ''' </summary>
        Private _codigoTCC As Integer
        Public Property Codigo() As Integer
            Get
                Return Me._codigoTCC
            End Get
            Set(ByVal value As Integer)
                Me._codigoTCC = value
            End Set
        End Property

        ''' <summary>
        ''' Tema
        ''' </summary>
        Private _temaTCC As String
        Public Property Tema() As String
            Get
                Return Me._temaTCC
            End Get
            Set(ByVal value As String)
                Me._temaTCC = value
            End Set
        End Property

        ''' <summary>
        ''' Status
        ''' </summary>
        Private _statusTCC As StatusTCC
        Public Property Status() As StatusTCC
            Get
                Return Me._statusTCC
            End Get
            Set(ByVal value As StatusTCC)
                Me._statusTCC = value
            End Set
        End Property

        ''' <summary>
        ''' Data de Início
        ''' </summary>
        Private _dataInicio As DateTime
        Public Property DataInicio() As DateTime
            Get
                Return Me._dataInicio
            End Get
            Set(ByVal value As Date)
                Me._dataInicio = value
            End Set
        End Property

        ''' <summary>
        ''' Data de Entrega
        ''' </summary>
        Private _dataFim As DateTime
        Public Property DataFim() As DateTime
            Get
                Return Me._dataFim
            End Get
            Set(ByVal value As Date)
                Me._dataFim = value
            End Set
        End Property

        ''' <summary>
        ''' Nota da Proposta
        ''' </summary>
        Private _notaProposta As Integer
        Public Property NotaProposta() As Integer
            Get
                Return Me._notaProposta
            End Get
            Set(ByVal value As Integer)
                Me._notaProposta = value
            End Set
        End Property

        ''' <summary>
        ''' Nota final do TCC
        ''' </summary>
        Private _notaFinal As Integer
        Public Property NotaFinal() As Integer
            Get
                Return Me._notaFinal
            End Get
            Set(ByVal value As Integer)
                Me._notaFinal = value
            End Set
        End Property

        ''' <summary>
        '''Objeto Aluno 
        ''' </summary>
        Private _objAluno As Aluno
        Public Property Aluno() As Aluno
            Get
                Return Me._objAluno
            End Get
            Set(ByVal value As Aluno)
                Me._objAluno = value
            End Set
        End Property

        ''' <summary>
        ''' Objeto Professor (Orientador)
        ''' </summary>
        Private _objOrientador As Professor
        Public Property Orientador() As Professor
            Get
                Return Me._objOrientador
            End Get
            Set(ByVal value As Professor)
                Me._objOrientador = value
            End Set
        End Property

#End Region

#Region "Construtor"

        ''' <summary>
        ''' Construtor padrão
        ''' </summary>
        Public Sub New()

        End Sub

        ''' <summary>
        ''' Construtor alternativo
        ''' </summary>
        ''' <param name="codigo">Codigo do TCC</param>
        Public Sub New(ByVal codigo As Integer)
            Me.Codigo = codigo
        End Sub

#End Region

#Region "Funções e Métodos"

        ''' <summary>
        ''' Método de atualização do TCC
        ''' </summary>
        Public Sub AtualizarTCC() Implements Comum.INegocioPersistencia.Atualizar

            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_TccAtualizar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoTCC", DbType.Int32, Me._codigoTCC)
                objDtBase.AddInParameter(objCommand, "@matriculaAluno", DbType.Int32, Me._objAluno.Matricula)
                objDtBase.AddInParameter(objCommand, "@matriculaOrientador", DbType.Int32, Me._objOrientador.Matricula)
                objDtBase.AddInParameter(objCommand, "@temaTcc", DbType.String, Me._temaTCC)
                objDtBase.AddInParameter(objCommand, "@statusTcc", DbType.Int32, Me._statusTCC)
                objDtBase.AddInParameter(objCommand, "@notaProposta", DbType.Int32, Me._notaProposta)
                objDtBase.AddInParameter(objCommand, "@notaFinalTcc", DbType.Int32, Me._notaFinal)

                If Me.DataInicio = DateTime.MinValue Then
                    objDtBase.AddInParameter(objCommand, "@dataInicioTcc", DbType.DateTime, DBNull.Value)
                Else
                    objDtBase.AddInParameter(objCommand, "@dataInicioTcc", DbType.DateTime, Me.DataInicio)
                End If

                If Me.DataFim = DateTime.MinValue Then
                    objDtBase.AddInParameter(objCommand, "@dataFinalTcc", DbType.DateTime, DBNull.Value)
                Else
                    objDtBase.AddInParameter(objCommand, "@dataFinalTcc", DbType.DateTime, Me.DataFim)
                End If

                'Executa a procedure
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("TCC", "AtualizarTCC", ex.Message, TipoErro.Critico)
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método para exclusão de TCC (Não implementado)
        ''' </summary>
        Public Sub ExcluirTCC() Implements Comum.INegocioPersistencia.Excluir
            Throw New NotImplementedException("Método não possui implementação")
        End Sub

        ''' <summary>
        ''' Método de persistencia de dados (Não implementado)
        ''' </summary>
        Public Sub Salvar() Implements INegocioPersistencia.Salvar
            Throw New NotImplementedException("Método não possui implementação")
        End Sub

        ''' <summary>
        ''' Método para cadastrar um TCC na base de dados
        ''' </summary>
        ''' <param name="matriculaAluno">Nº da Matrícula do Aluno</param>
        ''' <param name="matriculaOrientador">Nº da Matrícula do Professor</param>
        Public Sub CadastrarTCC(ByVal matriculaAluno As Integer, ByVal matriculaOrientador As Integer)
            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_TccInserir")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaAluno", DbType.Int32, matriculaAluno)
                objDtBase.AddInParameter(objCommand, "@matriculaOrientador", DbType.Int32, matriculaOrientador)
                objDtBase.AddInParameter(objCommand, "@temaTcc", DbType.String, Me.Tema)
                objDtBase.AddInParameter(objCommand, "@statusTcc", DbType.Int32, Me.Status)

                'Atribuir os valores para as datas
                If Me.DataInicio = DateTime.MinValue Then
                    objDtBase.AddInParameter(objCommand, "@dataInicioTcc", DbType.DateTime, DBNull.Value)
                Else
                    objDtBase.AddInParameter(objCommand, "@dataInicioTcc", DbType.DateTime, Me.DataInicio)
                End If

                If Me.DataFim = DateTime.MinValue Then
                    objDtBase.AddInParameter(objCommand, "@dataFinalTcc", DbType.DateTime, DBNull.Value)
                Else
                    objDtBase.AddInParameter(objCommand, "@dataFinalTcc", DbType.DateTime, Me.DataFim)
                End If

                'Persistir os dados no banco de dados
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("TCC", "CadastrarTCC", ex.Message, TipoErro.Critico)
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Função para buscar um TCC pelo seu código
        ''' </summary>
        ''' <param name="codigo">Código do TCC</param>
        ''' <returns>Retorna objeto TCC carregado</returns>
        Public Function SelecionarTCCporCodigo(ByVal codigo As Integer) As TCC
            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_TccSelecionar")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoTCC", DbType.Int32, codigo)

                ' Executa a query retornando um SqlDataReader
                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia um objeto Usuario
                Dim objTcc As New TCC

                If drResult.HasRows() Then

                    ' Faz a leitura do DataReader
                    drResult.Read()

                    objTcc.Codigo = codigo
                    objTcc.Tema = drResult(InfoTabelas.TCC_TEMA).ToString.Trim
                    objTcc.Status = CType(drResult(InfoTabelas.TCC_STATUS), StatusTCC)
                    objTcc.NotaProposta = CInt(drResult(InfoTabelas.TCC_NOTAPROP))
                    objTcc.NotaFinal = CInt(drResult(InfoTabelas.TCC_NOTAFINAL))

                    If drResult(InfoTabelas.TCC_DTINI) Is DBNull.Value Then
                        objTcc.DataInicio = Date.MinValue
                    Else
                        objTcc.DataInicio = CDate(drResult(InfoTabelas.TCC_DTINI))
                    End If

                    If drResult(InfoTabelas.TCC_DTFIM) Is DBNull.Value Then
                        objTcc.DataFim = Date.MinValue
                    Else
                        objTcc.DataFim = CDate(drResult(InfoTabelas.TCC_DTFIM))
                    End If

                    objTcc.Aluno = Me.BuscarCodigoAlunoPorTcc(codigo)
                    objTcc.Orientador = Me.BuscarCodigoProfessorPorTcc(codigo)

                Else
                    objTcc = Nothing
                End If

                Return objTcc

            Catch ex As Exception
                Log.GravarLog("TCC", "SelecionarTCCporCodigo", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Buscar o aluno cadastrado em um TCC
        ''' </summary>
        ''' <param name="codigo">Código do TCC</param>
        ''' <returns>retorna um objeto Aluno</returns>
        Public Function BuscarCodigoAlunoPorTcc(ByVal codigo As Integer) As Aluno
            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_UsuarioAlunoSelecionarPorTcc")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoTCC", DbType.Int32, codigo)

                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)
                Dim objAluno As New Aluno

                'Caso tenha sido retornado algum registro é carregado o objeto Aluno
                If drResult.HasRows() Then

                    drResult.Read()
                    'Carrega os dados retornados no objeto
                    objAluno.Matricula = CInt(drResult(InfoTabelas.USU_MATRICULA))
                    objAluno.Nome = drResult(InfoTabelas.USU_NOME).ToString.Trim
                Else
                    objAluno = Nothing
                End If

                'Retorna um aluno
                Return objAluno
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' Buscar o professor cadastrado em um TCC
        ''' </summary>
        ''' <param name="codigo">Código do TCC</param>
        ''' <returns>retorna um objeto Professor</returns>
        Public Function BuscarCodigoProfessorPorTcc(ByVal codigo As Integer) As Professor
            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_UsuarioProfessorSelecionarPorTcc")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoTCC", DbType.Int32, codigo)

                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)
                Dim objProfessor As New Professor

                If drResult.HasRows() Then

                    drResult.Read()

                    objProfessor.Matricula = CInt(drResult(InfoTabelas.USU_MATRICULA))
                    objProfessor.Nome = drResult(InfoTabelas.USU_NOME).ToString.Trim
                Else

                    objProfessor = Nothing

                End If

                Return objProfessor

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' Função que retorna os aluno que estão vinculados ao orientador ou vice-versa
        ''' </summary>
        ''' <param name="matricula">Número da matrícula</param>
        ''' <returns>Retorna uma coleção de objetos usuários</returns>
        ''' <remarks>
        ''' Explicando melhor a função:
        ''' - Informando o número de matrícula de um usuário 'ALUNO', a função irá retornar
        '''   o orientador que está vinculado a este.
        ''' - Informando o número de matrícula de um usuário 'PROFESSOR', a função irá retornar
        '''   os alunos que estão vinculados a este.
        ''' </remarks>
        Public Function SelecionarAlunoOrientadorTcc(ByVal matricula As Integer) As List(Of Usuario)

            Try

                ' Define um objeto DataVase
                Dim dtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim dbComm As DbCommand = dtBase.GetStoredProcCommand("proc_TccAlunoOrientadorSelecionar")

                ' Define os parametros usados na stored procedure
                dtBase.AddInParameter(dbComm, "@matriculaUsuario", DbType.Int32, matricula)

                ' Executa a query retornando um SqlDataReader
                Dim drResults As SqlDataReader = DirectCast(dtBase.ExecuteReader(dbComm), SqlDataReader)

                ' Instancia uma coleção de objetos Usuario
                Dim colUsuarios As New List(Of Usuario)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then
                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Cria um objeto Usuario passando alguns dados para o construtor
                        Dim objUsuario As New Usuario(CInt(drResults(InfoTabelas.USU_MATRICULA)), _
                                                      drResults(InfoTabelas.USU_NOME).ToString.Trim)

                        ' Adiciona um objto Usuario à coleção
                        colUsuarios.Add(objUsuario)

                    End While
                End If

                ' Retorna a coleção de objetos
                Return colUsuarios

            Catch ex As NotFoundException
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Usuario", "SelecionarAlunoOrientadorTcc", ex.Message, TipoErro.Critico)
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Método para buscar TODOS os TCC's cadastrados na base de dados
        ''' </summary>
        ''' <returns>Retorna uma lista de TCC's</returns>
        Public Function SelecionarTodosTCC() As List(Of TCC)
            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_TccSelecionarTodos")

                ' Executa a query retornando um SqlDataReader
                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                Dim lstTcc As New List(Of TCC)

                If drResult.HasRows() Then

                    While drResult.Read
                        ' Instancia um objeto TCC
                        Dim objTcc As New TCC

                        objTcc.Codigo = CInt(drResult(InfoTabelas.TCC_CODIGO))
                        objTcc.Tema = drResult(InfoTabelas.TCC_TEMA).ToString.Trim
                        objTcc.Status = CType(drResult(InfoTabelas.TCC_STATUS), StatusTCC)
                        objTcc.NotaProposta = CInt(drResult(InfoTabelas.TCC_NOTAPROP))
                        objTcc.NotaFinal = CInt(drResult(InfoTabelas.TCC_NOTAFINAL))

                        If drResult(InfoTabelas.TCC_DTINI) Is DBNull.Value Then
                            objTcc.DataInicio = Date.MinValue
                        Else
                            objTcc.DataInicio = CDate(drResult(InfoTabelas.TCC_DTINI))
                        End If

                        If drResult(InfoTabelas.TCC_DTFIM) Is DBNull.Value Then
                            objTcc.DataFim = Date.MinValue
                        Else
                            objTcc.DataFim = CDate(drResult(InfoTabelas.TCC_DTFIM))
                        End If

                        objTcc.Aluno = Me.BuscarCodigoAlunoPorTcc(objTcc.Codigo)
                        objTcc.Orientador = Me.BuscarCodigoProfessorPorTcc(objTcc.Codigo)

                        lstTcc.Add(objTcc)

                    End While
                Else
                    lstTcc = Nothing
                End If

                Return lstTcc

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Função de busca de TCC, filtrando os dados
        ''' </summary>
        ''' <param name="tema">Tema</param>
        ''' <param name="status01">StatusTCC = 1</param>
        ''' <param name="status02">StatusTCC = 2</param>
        ''' <param name="status03">StatusTCC = 3</param>
        ''' <param name="status04">StatusTCC = 4</param>
        ''' <param name="status05">StatusTCC = 5</param>
        ''' <param name="matricula">Código de Matrícula Aluno/Professor</param>
        ''' <returns>Retorna uma lista de TCC's</returns>
        Public Function SelecionarFiltradoTodosTCC(ByVal tema As String, _
                                                   ByVal status01 As Integer, _
                                                   ByVal status02 As Integer, _
                                                   ByVal status03 As Integer, _
                                                   ByVal status04 As Integer, _
                                                   ByVal status05 As Integer, _
                                                   ByVal matricula As Integer) As List(Of TCC)
            Try
                ' Define o objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_TccSelecionarFiltro")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@tema", DbType.String, tema)
                objDtBase.AddInParameter(objCommand, "@status1", DbType.Int32, status01)
                objDtBase.AddInParameter(objCommand, "@status2", DbType.Int32, status02)
                objDtBase.AddInParameter(objCommand, "@status3", DbType.Int32, status03)
                objDtBase.AddInParameter(objCommand, "@status4", DbType.Int32, status04)
                objDtBase.AddInParameter(objCommand, "@status5", DbType.Int32, status05)
                objDtBase.AddInParameter(objCommand, "@matricula", DbType.Int32, matricula)

                ' Executa a query retornando um SqlDataReader
                Dim drResult As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                Dim lstTcc As New List(Of TCC)

                If drResult.HasRows() Then

                    While drResult.Read
                        ' Instancia um objeto TCC
                        Dim objTcc As New TCC

                        objTcc.Codigo = CInt(drResult(InfoTabelas.TCC_CODIGO))
                        objTcc.Tema = drResult(InfoTabelas.TCC_TEMA).ToString.Trim
                        objTcc.Status = CType(drResult(InfoTabelas.TCC_STATUS), StatusTCC)
                        objTcc.NotaProposta = CInt(drResult(InfoTabelas.TCC_NOTAPROP))
                        objTcc.NotaFinal = CInt(drResult(InfoTabelas.TCC_NOTAFINAL))

                        If drResult(InfoTabelas.TCC_DTINI) Is DBNull.Value Then
                            objTcc.DataInicio = Date.MinValue
                        Else
                            objTcc.DataInicio = CDate(drResult(InfoTabelas.TCC_DTINI))
                        End If

                        If drResult(InfoTabelas.TCC_DTFIM) Is DBNull.Value Then
                            objTcc.DataFim = Date.MinValue
                        Else
                            objTcc.DataFim = CDate(drResult(InfoTabelas.TCC_DTFIM))
                        End If

                        objTcc.Aluno = Me.BuscarCodigoAlunoPorTcc(objTcc.Codigo)
                        objTcc.Orientador = Me.BuscarCodigoProfessorPorTcc(objTcc.Codigo)

                        lstTcc.Add(objTcc)

                    End While
                Else
                    lstTcc = Nothing
                End If

                Return lstTcc

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Buscar todos os alunos de um determinado status de TCC
        ''' </summary>
        ''' <param name="nomeUsuario">Nome do Aluno</param>
        ''' <param name="statusTcc">Status</param>
        ''' <returns></returns>
        Public Function ConsultaSituacaoTcc(ByVal nomeUsuario As String, ByVal statusTcc As StatusTCC) As List(Of TCC)
            Try
                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_AlunosSelecionarPorStatusTcc")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@nomeUsuario", DbType.String, "%" & nomeUsuario & "%")
                objDtBase.AddInParameter(objCommand, "@statusTcc", DbType.Int32, statusTcc)

                ' Executa a query retornando um SqlDataReader
                Dim drResults As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Cria uma coleção de objetos TCC
                Dim lstTcc As New List(Of TCC)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then

                    ' Lê o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Instancia um objeto Tcc e inicializa com valores do banco
                        Dim objTcc As New TCC()

                        objTcc.Status = DirectCast(drResults(InfoTabelas.TCC_STATUS), StatusTCC)

                        objTcc.NotaProposta = CInt(drResults(InfoTabelas.TCC_NOTAPROP))
                        objTcc.NotaFinal = CInt(drResults(InfoTabelas.TCC_NOTAFINAL))

                        objTcc.Aluno = New Aluno(CInt(drResults(InfoTabelas.USU_MATRICULA)), _
                                                 drResults(InfoTabelas.USU_NOME).ToString.Trim)

                        ' Adiciona um objeto Tcc na coleção
                        lstTcc.Add(objTcc)

                    End While

                    ' Retorna a coleção de Tcc's
                    Return lstTcc

                Else
                    lstTcc = Nothing
                End If

                Return lstTcc

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Função que retorno todos os campos para montagem do relatório de TCC/Banca
        ''' </summary>
        ''' <param name="dataInicio">Data Inicio filtro</param>
        ''' <param name="dataFim">Data Fim filtro</param>
        ''' <returns>Retorno um dataset para carregar o report</returns>
        Public Function BuscarDadosRelatorioTCC(ByVal dataInicio As Date, ByVal dataFim As Date) As DataSet
            Try

                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_SelecionarRelTCC")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@dataini", DbType.DateTime, dataInicio)
                objDtBase.AddInParameter(objCommand, "@datafim", DbType.DateTime, dataFim)

                Return objDtBase.ExecuteDataSet(objCommand)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' Função que retorno todos os campos para montagem do relatório de Aprovados
        ''' </summary>
        ''' <param name="dataInicio">Data Inicio filtro</param>
        ''' <param name="dataFim">Data Fim filtro</param>
        ''' <returns>Retorno um dataset para carregar o report de Aprovados</returns>
        Public Function BuscarDadosRelatorioAprovados(ByVal dataInicio As Date, ByVal dataFim As Date) As DataSet
            Try

                ' Define um objeto DataBase
                Dim objDtBase As Database = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                Dim objCommand As DbCommand = objDtBase.GetStoredProcCommand("proc_SelecionarRelAprovados")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@dataini", DbType.DateTime, dataInicio)
                objDtBase.AddInParameter(objCommand, "@datafim", DbType.DateTime, dataFim)

                Return objDtBase.ExecuteDataSet(objCommand)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

    End Class

End Namespace