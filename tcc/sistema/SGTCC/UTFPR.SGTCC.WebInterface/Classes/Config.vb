Imports System.Web.Configuration
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' 
''' </summary>
Public Class Config

#Region "Propriedades"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>Nome Coordenador Atual</returns>
    Public Shared ReadOnly Property NomeCoordenadorAtual() As String
        Get
            Return WebConfigurationManager.AppSettings.Get("keyNomeCoordAtual").ToString.Trim
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>Email Coordenador Atual</returns>
    Public Shared ReadOnly Property EmailCoordenadorAtual() As String
        Get
            Return WebConfigurationManager.AppSettings.Get("keyMailCoordAtual").ToString.Trim
        End Get
    End Property

#End Region

#Region "Métodos Públicos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nome">Nome do coordenador</param>
    ''' <param name="email">Email do coordenador</param>
    Public Shared Sub GravaCoordenadorAtual(ByVal nome As String, ByVal email As String)

        Try

            Dim webConfig As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration("~")
            Dim appSettings As AppSettingsSection = webConfig.AppSettings

            If Not nome Is Nothing AndAlso Not nome.Trim = String.Empty Then
                appSettings.Settings("keyNomeCoordAtual").Value = nome.Trim
            End If

            If Not email Is Nothing AndAlso Not email.Trim = String.Empty Then
                appSettings.Settings("keyMailCoordAtual").Value = email.Trim
            End If

            webConfig.Save()

        Catch ex As Exception
            Log.GravarLog("Config", "GravaCoordenadorAtual", ex.Message, TipoErro.Inesperado)
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtPropostaIni"></param>
    ''' <param name="dtPropostaFim"></param>
    ''' <param name="dtEntregaPropostaIni"></param>
    ''' <param name="dtEntregaPropostaFim"></param>
    ''' <param name="dtDefesaIni"></param>
    ''' <param name="dtDefesaFim"></param>
    ''' <param name="dtEntregaDefesaIni"></param>
    ''' <param name="dtEntregaDefesaFim"></param>
    Public Shared Sub GravaPeriodoBancas(ByVal dtPropostaIni As Date, ByVal dtPropostaFim As Date, _
                                         ByVal dtEntregaPropostaIni As Date, ByVal dtEntregaPropostaFim As Date, _
                                         ByVal dtDefesaIni As Date, ByVal dtDefesaFim As Date, _
                                         ByVal dtEntregaDefesaIni As Date, ByVal dtEntregaDefesaFim As Date)

        Try
            Dim webConfig As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration("~")
            Dim appSettings As AppSettingsSection = webConfig.AppSettings

            ' Data da apresentação das Propostas
            appSettings.Settings("keyDataPropostaInicio").Value = dtPropostaIni.ToString()
            appSettings.Settings("keyDataPropostaFim").Value = dtPropostaFim.ToString()

            ' Data de entrega das Propostas
            appSettings.Settings("keyDataEntregaPropostaInicio").Value = dtEntregaPropostaIni.ToString()
            appSettings.Settings("keyDataEntregaPropostaFim").Value = dtEntregaPropostaFim.ToString()

            ' Data da apresentação das Defesas
            appSettings.Settings("keyDataDefesaInicio").Value = dtDefesaIni.ToString()
            appSettings.Settings("keyDataDefesaFim").Value = dtDefesaFim.ToString()

            ' Data da entrega das Defesas
            appSettings.Settings("keyDataEntregaDefesaInicio").Value = dtEntregaDefesaIni.ToString()
            appSettings.Settings("keyDataEntregaDefesaFim").Value = dtEntregaDefesaFim.ToString()

            webConfig.Save()

        Catch ex As Exception
            Log.GravarLog("Config", "GravaPeriodoBancas", ex.Message, TipoErro.Inesperado)
            Throw ex
        End Try

    End Sub

#End Region

End Class
