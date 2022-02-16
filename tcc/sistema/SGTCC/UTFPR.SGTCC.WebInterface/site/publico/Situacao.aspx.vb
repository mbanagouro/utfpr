Imports UTFPR.SGTCC.Negocio.ModuloCA

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Situacao.                                                       <BR/>
''' Objetivo.....: Code-Behind da página da pesquisa de situação do aluno.         <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Situacao
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            ' Método que carrega o combo de situação
            Me.CarregarCmbStatus()
            ' Grid irá carregar todos os alunos
            Me.CarregaGridSituacao(String.Empty, CType(ddlStatusTcc.SelectedValue, StatusTCC))
        End If

    End Sub

    ''' <summary>
    ''' Evento click do botão Buscar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.CarregaGridSituacao(txtNome.Text.Trim, CType(ddlStatusTcc.SelectedValue, StatusTCC))
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega o combo status
    ''' </summary>
    Private Sub CarregarCmbStatus()

        With ddlStatusTcc
            .Items.Add(New ListItem("Todos ---", "0"))
            .Items.Add(New ListItem("Proposta", CInt(StatusTCC.Proposta).ToString.Trim))
            .Items.Add(New ListItem("Banca", CInt(StatusTCC.Banca).ToString.Trim))
            .Items.Add(New ListItem("Matriculado", CInt(StatusTCC.Matriculado).ToString.Trim))
            .Items.Add(New ListItem("Desistente", CInt(StatusTCC.Desistente).ToString.Trim))
            .Items.Add(New ListItem("Aprovado", CInt(StatusTCC.Aprovado).ToString.Trim))
            .SelectedValue = "0"
        End With

    End Sub

    ''' <summary>
    ''' Método que carrega o grid de situação do aluno
    ''' </summary>
    Private Sub CarregaGridSituacao(ByVal nomeUsuario As String, ByVal status As StatusTCC)
        Me.grdSituacaoAluno.CarregarGridAlunos(nomeUsuario, status)
    End Sub

#End Region

End Class