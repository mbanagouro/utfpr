Imports System.IO
Imports System.Text

Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Log.                                                            <BR/>
    ''' Objetivo.....: Classe responsável por gerar logs de erro do sistema.           <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class Log

#Region "Atributos"

        ''' <summary>
        ''' Caminho físico do log
        ''' </summary>
        Private Const caminhoLog As String = "C:/"
        ''' <summary>
        ''' Constante com o nome do arquivo de log
        ''' </summary>
        Private Const nomeArquivoLog As String = "log_SGTCC.txt"

#End Region

#Region "Propriedades"


#End Region

#Region "Construtores"

        ''' <summary>
        ''' Construtor padrão
        ''' </summary>
        ''' <remarks>Esta classe não pode ser instanciada</remarks>
        Private Sub New()
            MyBase.New()
        End Sub

#End Region

#Region "Métodos"

        ''' <summary>
        ''' Método que grava um log de erro
        ''' </summary>
        ''' <param name="classe">Nome da Classe</param>
        ''' <param name="rotina">Nome da rotina</param>
        ''' <param name="mensagem">Mensagem de erro</param>
        ''' <param name="tpErro">Tipo do erro</param>
        ''' <remarks></remarks>
        Public Shared Sub GravarLog(ByVal classe As String, _
                                    ByVal rotina As String, _
                                    ByVal mensagem As String, _
                                    ByVal tpErro As TipoErro)

            Dim log As String = String.Empty

            Try

                log = MontaMensagem(classe, rotina, mensagem, tpErro)

                ' Verifica se o diretório existe
                If Directory.Exists(caminhoLog) Then

                    Dim arquivo As StreamWriter = File.AppendText(caminhoLog & nomeArquivoLog)
                    arquivo.WriteLine(log)
                    arquivo.Close()

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Método que monta a mensagem que será gravada no log
        ''' </summary>
        ''' <param name="classe">Nome da Classe</param>
        ''' <param name="rotina">Nome da Rotina</param>
        ''' <param name="mensagem">Mensagem de erro</param>
        ''' <param name="tpErro">Tipo do erro</param>
        ''' <returns>String</returns>
        ''' <remarks>Este método é chamado internamente</remarks>
        Private Shared Function MontaMensagem(ByVal classe As String, _
                                              ByVal rotina As String, _
                                              ByVal mensagem As String, _
                                              ByVal tpErro As TipoErro) As String

            Dim log As New StringBuilder

            log.Append(DateTime.Now.ToString())

            If tpErro = TipoErro.Inesperado Then
                log.Append(": Ocorreu um erro Inesperado na classe ")
            ElseIf tpErro = TipoErro.Critico Then
                log.Append(": Ocorreu um erro Crítico na classe ")
            End If

            log.Append(classe)
            log.Append(", Rotina " & rotina & ": ")
            log.Append(mensagem)

            Return log.ToString

        End Function

#End Region

    End Class

End Namespace