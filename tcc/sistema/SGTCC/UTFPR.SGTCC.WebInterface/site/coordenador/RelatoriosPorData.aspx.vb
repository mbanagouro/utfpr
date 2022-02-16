Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum
Imports Microsoft.Reporting.WebForms

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Relatorio TCC                                                   <BR/>
''' Objetivo.....: Pagina para geração do relatorio principal de Tcc/Bancas        <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class RelatorioTCC
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkRelBanca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRelBanca.Click
        Session("tipoRelatorio") = "Bancas"
        EnviaReportParameters()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lnkRelAprovados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRelAprovados.Click
        Session("tipoRelatorio") = "Aprovados"
        Me.EnviaReportParameters()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub EnviaReportParameters()

        'Verifica se a data inicial não foi informada, passar menor valor possível
        If txtDataInicio.Text = String.Empty Then
            Session("dataInicio") = CDate("01/01/1900")
        Else
            Session("dataInicio") = CDate(txtDataInicio.Text)
        End If
        'Verifica se a data final não foi informada, passar maior valor possível
        If txtDataFim.Text = String.Empty Then
            Session("dataFim") = Date.MaxValue
        Else
            Session("dataFim") = CDate(txtDataFim.Text)
        End If

        Response.Redirect(My.Resources.UrlMaps.VisualizaRelatorio)

    End Sub

#End Region

End Class