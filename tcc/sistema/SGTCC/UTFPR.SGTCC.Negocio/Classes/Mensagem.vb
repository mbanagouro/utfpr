Imports System.Data.Common
Imports System.Data.SqlClient
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Collections.Generic
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace ModuloAP

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Mensagem.                                                       <BR/>
    ''' Objetivo.....: Classe respons�vel por gerenciar as mensagens entre os usu�rios.<BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    ''' <remarks>Classe que implementa a interface INegocioPersistencia</remarks>
    Public Class Mensagem
        Implements INegocioPersistencia

#Region "Atributos"

        ''' <summary>
        ''' C�digo da �ltima mensagem inserida no banco
        ''' </summary>
        Private _ultimoCodigoMensagem As Integer

#End Region

#Region "Propriedades"

        ''' <summary>
        ''' C�digo
        ''' </summary>
        Private _codigoMensagem As Integer
        Public Property Codigo() As Integer
            Get
                Return Me._codigoMensagem
            End Get
            Set(ByVal value As Integer)
                Me._codigoMensagem = value
            End Set
        End Property

        ''' <summary>
        ''' Matricula do Remetente
        ''' </summary>
        Private _matriculaRemetente As Integer
        Public Property MatriculaRemetente() As Integer
            Get
                Return Me._matriculaRemetente
            End Get
            Set(ByVal value As Integer)
                Me._matriculaRemetente = value
            End Set
        End Property

        ''' <summary>
        ''' Assunto da Mensagem
        ''' </summary>
        Private _assuntoMensagem As String
        Public Property Assunto() As String
            Get
                Return Me._assuntoMensagem
            End Get
            Set(ByVal value As String)
                Me._assuntoMensagem = value.Trim
            End Set
        End Property

        ''' <summary>
        ''' Conteudo da Mensagem
        ''' </summary>
        Private _conteudoMensagem As String
        Public Property Conteudo() As String
            Get
                Return Me._conteudoMensagem
            End Get
            Set(ByVal value As String)
                Me._conteudoMensagem = value
            End Set
        End Property

        ''' <summary>
        ''' Data da Mensagem
        ''' </summary>
        Private _dataMensagem As Date
        Public Property Data() As Date
            Get
                Return Me._dataMensagem
            End Get
            Set(ByVal value As Date)
                Me._dataMensagem = value
            End Set
        End Property

        ''' <summary>
        ''' Prioridade da Mensagem
        ''' </summary>
        Private _prioridadeMensagem As PrioridadeMensagem
        Public Property Prioridade() As PrioridadeMensagem
            Get
                Return Me._prioridadeMensagem
            End Get
            Set(ByVal value As PrioridadeMensagem)
                Me._prioridadeMensagem = value
            End Set
        End Property

        ''' <summary>
        ''' Indicador de Mensagem Lida
        ''' </summary>
        Private _lidoMensagem As StatusMensagem
        Public Property MensagemLida() As StatusMensagem
            Get
                Return Me._lidoMensagem
            End Get
            Set(ByVal value As StatusMensagem)
                Me._lidoMensagem = value
            End Set
        End Property

        ''' <summary>
        ''' Lista de Usu�rios
        ''' </summary>
        Private _lstUsuarios As New List(Of Usuario)
        Public Property Usuarios() As List(Of Usuario)
            Get
                Return Me._lstUsuarios
            End Get
            Set(ByVal value As List(Of Usuario))
                Me._lstUsuarios = value
            End Set
        End Property

#End Region

#Region "Construtores"

        ''' <summary>
        ''' Construtor Padr�o
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' Construtor que cria uma mensagem vinculando o seu remetente
        ''' </summary>
        ''' <param name="matriculaRemetente">N�mero da matr�cula</param>
        ''' <param name="nomeRemetente">Nome do usu�rio</param>
        ''' <param name="assunto">Assunto da mensagem</param>
        ''' <param name="prioridade">C�digo identificador de prioridade da mensagem</param>
        ''' <param name="conteudo">Conte�do da mensagem</param>
        ''' <param name="data">Data de envio da mensagem</param>
        Private Sub New(ByVal matriculaRemetente As Integer, _
                        ByVal nomeRemetente As String, _
                        ByVal assunto As String, _
                        ByVal prioridade As PrioridadeMensagem, _
                        ByVal conteudo As String, _
                        ByVal data As Date)

            Me._lstUsuarios.Add(New Usuario(matriculaRemetente, nomeRemetente))
            Me.Assunto = assunto
            Me.Prioridade = prioridade
            Me.Conteudo = conteudo
            Me.Data = data

        End Sub

        ''' <summary>
        ''' Construtor que monta uma mensagem j� existente vinculando o seu remetente
        ''' </summary>
        ''' <param name="matriculaRemetente">N�mero da matr�cula</param>
        ''' <param name="nomeRemetente">Nome do usu�rio</param>
        ''' <param name="assunto">Assunto da mensagem</param>
        ''' <param name="prioridade">C�digo identificador de prioridade da mensagem</param>
        ''' <param name="conteudo">Conte�do da mensagem</param>
        ''' <param name="data">Data de envio da mensagem</param>
        ''' <param name="lido">C�digo identificador de mensagem lida ou n�o lida</param>
        Private Sub New(ByVal matriculaRemetente As Integer, _
                        ByVal nomeRemetente As String, _
                        ByVal assunto As String, _
                        ByVal prioridade As PrioridadeMensagem, _
                        ByVal conteudo As String, _
                        ByVal data As Date, _
                        ByVal lido As StatusMensagem)

            Me._lstUsuarios.Add(New Usuario(matriculaRemetente, nomeRemetente))
            Me.Assunto = assunto
            Me.Prioridade = prioridade
            Me.Conteudo = conteudo
            Me.Data = data
            Me.MensagemLida = lido

        End Sub

#End Region

#Region "M�todos P�blicos"

        ''' <summary>
        ''' M�todo que faz o envio da mensagem aos destint�rios
        ''' </summary>
        ''' <param name="matriculaRemetente">N�mero da matr�cula</param>
        ''' <param name="assunto">Assunto da mensagem</param>
        ''' <param name="prioridade">C�digo identificador de prioridade da mensagem</param>
        ''' <param name="conteudo">Conte�do da mensagem</param>
        ''' <param name="matriculaDestinatarios">N�mero de matr�cula dos destinat�rios</param>
        Public Sub EnviarMensagem(ByVal matriculaRemetente As Integer, _
                                  ByVal assunto As String, _
                                  ByVal prioridade As PrioridadeMensagem, _
                                  ByVal conteudo As String, _
                                  ByVal ParamArray matriculaDestinatarios() As Integer)

            ' Carrega os dados da mensagem nas propriedades
            Me.MatriculaRemetente = matriculaRemetente
            Me.Assunto = assunto
            Me.Prioridade = prioridade
            Me.Conteudo = conteudo

            Try

                ' Executa o m�todo Salvar() para persistencia na base de dados
                Me.Salvar()

                ' Para cada n�mero de matr�cula do array � feito o vincula da mensagem
                ' a cada um deles.
                For Each matriculaDestinatario As Integer In matriculaDestinatarios
                    Me.VincularMensagem(matriculaDestinatario)
                Next

            Catch ex As Exception
                Log.GravarLog("Mensagem", "EnviarMensagem", ex.Message, TipoErro.Inesperado)
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Fun��o que retorna as mensagens recebidas
        ''' </summary>
        ''' <param name="matricula">N�mero da matr�cula</param>
        ''' <returns>Lista de Mensagem</returns>
        Public Function SelecionarRecebidas(ByVal matricula As Integer) As List(Of Mensagem)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim lstMensagens As List(Of Mensagem)

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_MensagemSelecionarRecebidas")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaDestinatario", DbType.Int32, matricula)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma cole��o de objetos Mensagem
                lstMensagens = New List(Of Mensagem)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then

                    ' L� o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Cria um objeto Mensagem
                        Dim objMensagem As New Mensagem
                        ' Cria uma cole��o de usuarios
                        Dim lstUsuarios As New List(Of Usuario)

                        ' Adiciona o usu�rio remetente
                        lstUsuarios.Add(New Usuario(DirectCast(drResults(InfoTabelas.USU_MATRICULA), Integer), _
                                                    drResults(InfoTabelas.USU_NOME).ToString.Trim))

                        ' Carrega as informa��es da mensagem
                        objMensagem.Usuarios = lstUsuarios
                        objMensagem.Codigo = DirectCast(drResults(InfoTabelas.MEN_CODIGO), Integer)
                        objMensagem.Assunto = drResults(InfoTabelas.MEN_ASSUNTO).ToString.Trim
                        objMensagem.Prioridade = DirectCast(drResults(InfoTabelas.MEN_PRIORIDADE), PrioridadeMensagem)
                        objMensagem.Data = DirectCast(drResults(InfoTabelas.MEN_DATA), Date)
                        objMensagem.MensagemLida = DirectCast(drResults(InfoTabelas.MEN_LIDO), StatusMensagem)

                        ' Adiciona a mensagem na cole��o
                        lstMensagens.Add(objMensagem)

                    End While

                End If

                ' Retorna a cole��o de mensagens
                Return lstMensagens

            Catch ex As Exception
                Log.GravarLog("Mensagem", "SelecionarRecebidas", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da mem�ria
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Fun��o que retorna uma mensagem recebida por meio do seu c�digo identificador
        ''' </summary>
        ''' <param name="codMensagem">C�digo identificador da mensagem</param>
        ''' <returns>Objeto Mensagem</returns>
        Public Function SelecionarRecebidaPorCodigo(ByVal codMensagem As Integer) As Mensagem

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim objMensagem As Mensagem = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_MensagemSelecionarRecebidoPorCodigo")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoMensagem", DbType.Int32, codMensagem)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows() Then

                    ' Faz a leitura do DataReader
                    drResults.Read()

                    ' Instancia um objeto Mensagem
                    objMensagem = New Mensagem

                    ' Carrega as informa��es da mensagem
                    objMensagem._lstUsuarios.Add(New Usuario(DirectCast(drResults(InfoTabelas.USU_MATRICULA), Integer), _
                                                             drResults(InfoTabelas.USU_NOME).ToString.Trim))
                    objMensagem.Codigo = DirectCast(drResults(InfoTabelas.MEN_CODIGO), Integer)
                    objMensagem.Assunto = drResults(InfoTabelas.MEN_ASSUNTO).ToString.Trim
                    objMensagem.Conteudo = drResults(InfoTabelas.MEN_CONTEUDO).ToString.Trim
                    objMensagem.Prioridade = DirectCast(drResults(InfoTabelas.MEN_PRIORIDADE), PrioridadeMensagem)
                    objMensagem.Data = DirectCast(drResults(InfoTabelas.MEN_DATA), Date)

                Else

                    ' Atribui nulo ao objeto caso n�o seja encontrado
                    objMensagem = Nothing

                End If

                ' Retorna o objeto Mensagem
                Return objMensagem

            Catch ex As NotFoundException
                Log.GravarLog("Mensagem", "SelecionarRecebidaPorCodigo", ex.Message, TipoErro.Critico)
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Mensagem", "SelecionarRecebidaPorCodigo", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da mem�ria
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Fun��o que retorna as mensagens enviadas pelo Usu�rio
        ''' </summary>
        ''' <param name="matricula">N�mero da matr�cula</param>
        ''' <returns>Lista de Mensagem</returns>
        Public Function SelecionarEnviadas(ByVal matricula As Integer) As List(Of Mensagem)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno 
            Dim lstMensagens As New List(Of Mensagem)

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_MensagemSelecionarEnviadas")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@matriculaRemetente", DbType.Int32, matricula)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma cole��o de objetos Mensagem
                lstMensagens = New List(Of Mensagem)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then

                    ' Faz a leitura do DataReader
                    While drResults.Read

                        ' Instancia um objeto Mensagem
                        Dim objMensagem As New Mensagem

                        ' Carrega as informa��es da mensagem
                        objMensagem.Usuarios = Me.SelecionarDestinatarios(DirectCast(drResults(InfoTabelas.MEN_CODIGO), Integer))
                        objMensagem.Codigo = DirectCast(drResults(InfoTabelas.MEN_CODIGO), Integer)
                        objMensagem.Assunto = drResults(InfoTabelas.MEN_ASSUNTO).ToString.Trim
                        objMensagem.Prioridade = DirectCast(drResults(InfoTabelas.MEN_PRIORIDADE), PrioridadeMensagem)
                        objMensagem.Data = DirectCast(drResults(InfoTabelas.MEN_DATA), Date)
                        objMensagem.MensagemLida = DirectCast(drResults(InfoTabelas.MEN_LIDO), StatusMensagem)

                        ' Adiciona a mensagem a cole��o de mensagens
                        lstMensagens.Add(objMensagem)

                    End While

                End If

                ' Retorna cole��o de mensagens
                Return lstMensagens

            Catch ex As Exception
                Log.GravarLog("Mensagem", "SelecionarEnviadas", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da mem�ria
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

        ''' <summary>
        ''' Fun��o que retorna uma mensagem enviada por meio do seu c�digo identificador
        ''' </summary>
        ''' <param name="codMensagem">C�digo identificador da mensagem</param>
        ''' <returns>Objeto Mensagem</returns>
        Public Function SelecionarEnviadaPorCodigo(ByVal codMensagem As Integer) As Mensagem

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            ' Retorno
            Dim objMensagem As Mensagem = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_MensagemSelecionarEnviadoPorCodigo")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoMensagem", DbType.Int32, codMensagem)

                ' Executa a query retornando um SqlDataReader
                Dim drResults As SqlDataReader = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows() Then

                    ' Faz a leitura do DataReader
                    drResults.Read()

                    ' Instancia um objeto Mensagem
                    objMensagem = New Mensagem

                    ' Carrega as informa��es da mensagem
                    objMensagem.Usuarios = Me.SelecionarDestinatarios(DirectCast(drResults(InfoTabelas.MEN_CODIGO), Integer))
                    objMensagem.Codigo = DirectCast(drResults(InfoTabelas.MEN_CODIGO), Integer)
                    objMensagem.Assunto = drResults(InfoTabelas.MEN_ASSUNTO).ToString.Trim
                    objMensagem.Conteudo = drResults(InfoTabelas.MEN_CONTEUDO).ToString.Trim
                    objMensagem.Prioridade = DirectCast(drResults(InfoTabelas.MEN_PRIORIDADE), PrioridadeMensagem)
                    objMensagem.Data = DirectCast(drResults(InfoTabelas.MEN_DATA), Date)

                Else

                    ' Se n�o encontrou a mensagem move nulo para o objeto
                    objMensagem = Nothing

                End If

                ' Retorna objeto Mensagem
                Return objMensagem

            Catch ex As NotFoundException
                Log.GravarLog("Mensagem", "SelecionarEnviadaPorCodigo", ex.Message, TipoErro.Inesperado)
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Mensagem", "SelecionarEnviadaPorCodigo", ex.Message, TipoErro.Inesperado)
                Throw New Exception
            Finally

                ' Libera os objetos da mem�ria
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

#End Region

#Region "M�todos Privados"

        ''' <summary>
        ''' M�todo que associa a mensagem gravada no banco para o seu(s) destinat�rio(s)
        ''' </summary>
        ''' <param name="matriculaDestinatario">N�mero da matr�cula</param>
        Private Sub VincularMensagem(ByVal matriculaDestinatario As Integer)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_MensagemEnviar")

                ' Define os parametros de entrada da Stored Procedure
                objDtBase.AddInParameter(objCommand, "@codigoMensagem", DbType.Int32, Me._ultimoCodigoMensagem)
                objDtBase.AddInParameter(objCommand, "@matriculaDestinatario", DbType.Int32, matriculaDestinatario)

                ' Executa a Stored Procedure
                objDtBase.ExecuteNonQuery(objCommand)

            Catch ex As Exception
                Log.GravarLog("Mensagem", "VincularMensagem", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da mem�ria 
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' M�todo que persiste os dados da mensagem na base de dados
        ''' </summary>
        ''' <remarks>
        ''' M�todo implementado da inteface INegocioPersistencia
        ''' </remarks>
        Private Sub Salvar() Implements INegocioPersistencia.Salvar

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_MensagemSalvar")

                ' Define os parametros de entrada da Stored Procedure
                objDtBase.AddInParameter(objCommand, "@matriculaRemetente", DbType.Int32, Me.MatriculaRemetente)
                objDtBase.AddInParameter(objCommand, "@assuntoMensagem", DbType.String, Me.Assunto)
                objDtBase.AddInParameter(objCommand, "@prioridadeMensagem", DbType.Int32, Me.Prioridade)
                objDtBase.AddInParameter(objCommand, "@conteudoMensagem", DbType.String, Me.Conteudo)

                ' Define os parametros de sa�da da Stored Procedure
                objDtBase.AddOutParameter(objCommand, "@ultimoCodigoMensagem", DbType.Int32, 0)

                ' Executa a Stored Procedure
                objDtBase.ExecuteNonQuery(objCommand)

                ' Armazena o c�digo da �ltima mensagem inserida retornado pela Stored Procedure
                Me._ultimoCodigoMensagem = DirectCast(objDtBase.GetParameterValue(objCommand, "@ultimoCodigoMensagem"), Integer)

            Catch ex As Exception
                Log.GravarLog("Mensagem", "Salvar", ex.Message, TipoErro.Critico)
                Throw ex
            Finally

                ' Libera os objetos da mem�ria
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Sub

        ''' <summary>
        ''' M�todo que atualiza os dados da mensagem na base de dados
        ''' </summary>
        ''' <remarks>
        ''' M�todo implementado da inteface INegocioPersistencia
        ''' </remarks>
        Private Sub Atualizar() Implements INegocioPersistencia.Atualizar
            Throw New NotImplementedException("Este m�todo n�o possui implementa��o!")
        End Sub

        ''' <summary>
        ''' M�todo que exclui a mensagem na base de dados
        ''' </summary>
        ''' <remarks>
        ''' M�todo implementado da inteface INegocioPersistencia
        ''' </remarks>
        Private Sub ExcluirMensagem() Implements INegocioPersistencia.Excluir
            Throw New NotImplementedException("Este m�todo n�o possui implementa��o!")
        End Sub

        ''' <summary>
        ''' Fun��o que retorna o(s) destinat�rio(s) de uma determinada mensagem
        ''' </summary>
        ''' <param name="codMensagem">C�digo identificador da mensagem</param>
        ''' <returns>Lista de Usuario</returns>
        Private Function SelecionarDestinatarios(ByVal codMensagem As Integer) As List(Of Usuario)

            ' Declara os objetos
            Dim objDtBase As Database = Nothing
            Dim objCommand As DbCommand = Nothing
            Dim drResults As SqlDataReader = Nothing

            ' Retorno
            Dim lstUsuarios As List(Of Usuario)

            Try

                ' Define o objeto DataBase
                objDtBase = DatabaseFactory.CreateDatabase()

                ' Define um objeto DbCommand para executar a stored procedure
                objCommand = objDtBase.GetStoredProcCommand("proc_MensagemSelecionarDestinatarios")

                ' Define os parametros usados na stored procedure
                objDtBase.AddInParameter(objCommand, "@codigoMensagem", DbType.Int32, codMensagem)

                ' Executa a query retornando um SqlDataReader
                drResults = DirectCast(objDtBase.ExecuteReader(objCommand), SqlDataReader)

                ' Instancia uma cole��o de objetos Usuario
                lstUsuarios = New List(Of Usuario)

                ' Verifica se o DataReader possui linhas retornadas da consulta
                If drResults.HasRows Then

                    ' L� o DataReader enquanto possuir registros
                    While drResults.Read

                        ' Instancia um objeto Usuario
                        Dim user As New Usuario

                        ' Carrega o nome do usu�rio
                        user.Nome = drResults(InfoTabelas.USU_NOME).ToString.Trim

                        ' Adiciona o objeto Usuario na cole��o
                        lstUsuarios.Add(user)

                    End While

                End If

                ' Retorna uma cole��o de objeto Usuario
                Return lstUsuarios

            Catch ex As NotFoundException
                Log.GravarLog("Mensagem", "SelecionarDestinatarios", ex.Message, TipoErro.Critico)
                Throw ex
            Catch ex As Exception
                Log.GravarLog("Mensagem", "SelecionarDestinatarios", ex.Message, TipoErro.Inesperado)
                Throw ex
            Finally

                ' Libera os objetos da mem�ria
                If Not objCommand Is Nothing Then
                    objCommand.Dispose()
                End If

            End Try

        End Function

#End Region

    End Class

End Namespace