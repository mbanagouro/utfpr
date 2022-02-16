Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum
Imports Microsoft.Reporting.WebForms

''' <summary>
''' 
''' </summary>
Partial Public Class RelatorioBanca
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Session("tipoRelatorio").ToString = "Bancas" Then
                MontaReportBanca()
            Else
                If Session("tipoRelatorio").ToString = "Aprovados" Then
                    MontaReportAprovados()
                Else
                    lblMensagem.Text = "Tipo de Relatório informado não implementado. Contactar o analista! Tipo Banca: " & Session("tipoRelatorio").ToString
                End If
            End If
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para carga e envio do Relatório de Bancas/TCC
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MontaReportBanca()

        'Criacao de variaveis e objetos
        Dim objTCC As New TCC
        Dim dataInicio As Date
        Dim dataFim As Date
        Dim objDataset As New DataSet("DataSet1_proc_SelecionarRelTCC")

        Try
            dataInicio = CDate(Session("dataInicio"))
            dataFim = CDate(Session("dataFim"))

            'Atribui o nome do relatório a ser apresentado
            rvwTCC.LocalReport.ReportPath = "site\coordenador\Relatorios\ReportBancas.rdlc"

            'Obtem o dataset retornado com os dados
            objDataset = objTCC.BuscarDadosRelatorioTCC(dataInicio, dataFim)

            Dim objReportDataSource As New ReportDataSource("DataSet1_proc_SelecionarRelTCC", objDataset.Tables(0))

            'Limpa o datasource do relatorio
            rvwTCC.LocalReport.DataSources.Clear()

            If objDataset.Tables(0).Rows.Count = 0 Then
                lblMensagem.Text = "Não foram encontrados Registros!"
                rvwTCC.Visible = False
            Else
                rvwTCC.LocalReport.DataSources.Add(objReportDataSource)
                rvwTCC.Visible = True
            End If

            rvwTCC.LocalReport.Refresh()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub MontaReportAprovados()

        'Criacao de variaveis e objetos
        Dim objTCC As New TCC
        Dim dataInicio As Date
        Dim dataFim As Date
        Dim objDataset As New DataSet("Aprovados_proc_SelecionarRelAprovados")

        Try
            dataInicio = CDate(Session("dataInicio"))
            dataFim = CDate(Session("dataFim"))

            'Limpa o datasource do relatorio
            rvwTCC.LocalReport.DataSources.Clear()

            'Atribui o nome do relatório a ser apresentado
            rvwTCC.LocalReport.ReportPath = "site\coordenador\Relatorios\ReportAprovados.rdlc"

            'Obtem o dataset retornado com os dados
            objDataset = objTCC.BuscarDadosRelatorioAprovados(dataInicio, dataFim)

            Dim objReportDataSource As New ReportDataSource("DataSet1_proc_SelecionarRelAprovados", objDataset.Tables(0))

            If objDataset.Tables(0).Rows.Count = 0 Then
                lblMensagem.Text = "Não foram encontrados Registros!"
                rvwTCC.Visible = False
            Else
                rvwTCC.LocalReport.DataSources.Add(objReportDataSource)
                rvwTCC.Visible = True
            End If

            rvwTCC.LocalReport.Refresh()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class