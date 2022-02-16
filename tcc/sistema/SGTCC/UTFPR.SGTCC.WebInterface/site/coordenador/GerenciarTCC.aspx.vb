Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: GerenciarTcc                                                    <BR/>
''' Objetivo.....: Tela principal para o gerenciamento do TCC                      <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class ConsultarTCC
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'Declaração do objeto TCC
            Dim objTcc As New TCC

            Try
                'Montagem dos Combos
                Me.CarregarCamposFiltro()

                Me.CarregarGridFiltrado()
            Catch ex As Exception
                lblMensagem.Text = ex.Message
            End Try

        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.CarregarGridFiltrado()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnNovoTCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovoTCC.Click
        'Redirecionar para a página de novo TCC
        Response.Redirect(My.Resources.UrlMaps.NovoTCC)
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Médoto para carregar os combos do filtro
    ''' </summary>
    Private Sub CarregarCamposFiltro()
        Me.CarregarComboProfessores()
        Me.CaregarComboAlunos()
    End Sub

    ''' <summary>
    ''' Método para carregar o combo de professores
    ''' </summary>
    Private Sub CarregarComboProfessores()
        Try
            'Cria o objeto Usuario
            Dim objProfessor As New Professor

            'Definir as colunas de Nome e Valor (Codigo matricula)
            ddlProfessores.DataValueField = "Matricula"
            ddlProfessores.DataTextField = "Nome"

            'Carregar a dropList
            ddlProfessores.DataSource = objProfessor.SelecionarTodosProfessores()
            ddlProfessores.DataBind()

            ddlProfessores.Items.Insert(0, (New ListItem("-----", "0")))
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para montagem do combo de Alunos
    ''' </summary>
    Private Sub CaregarComboAlunos()
        Try
            'cria o objeto Usuario
            Dim objAluno As New Aluno()

            'Carregar a dropList
            ddlAlunos.DataSource = objAluno.SelecionarTodosAlunos()
            ddlAlunos.DataValueField = "Matricula"
            ddlAlunos.DataTextField = "Nome"
            ddlAlunos.DataBind()

            ddlAlunos.Items.Insert(0, (New ListItem("-----", "0")))
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CarregarGridFiltrado()

        'Declaração de variáveis e objetos
        Dim objTcc As New TCC
        Dim tema As String = String.Empty
        Dim status01 As Integer = 0
        Dim status02 As Integer = 0
        Dim status03 As Integer = 0
        Dim status04 As Integer = 0
        Dim status05 As Integer = 0
        Dim matricula As Integer = 0

        Try
            'Montagem do Tema
            tema = "%" & txtTema.Text & "%"

            'Verificações para montegem dos Status
            If chbStatus01.Checked Then
                status01 = 1
            End If

            If chbStatus02.Checked Then
                status02 = 2
            End If

            If chbStatus03.Checked Then
                status03 = 3
            End If

            If chbStatus04.Checked Then
                status04 = 4
            End If

            If chbStatus05.Checked Then
                status05 = 5
            End If

            If status01 = 0 And status02 = 0 And status03 = 0 And status04 = 0 And status05 = 0 Then
                status01 = 1
                status02 = 2
                status03 = 3
                status04 = 4
                status05 = 5
            End If

            'Tratamento de erro para caso seja selecionado um aluno e um professor na área de filtro
            If Not ddlProfessores.SelectedValue = "0" And Not ddlAlunos.SelectedValue = "0" Then
                Throw New DuasMatriculasSelecionadasException("Duas Matriculas Selecionadas")
            Else
                lblErroDuasMatriculas.Text = String.Empty
                If Not ddlProfessores.SelectedValue = "0" Then
                    matricula = CInt(ddlProfessores.SelectedValue)
                Else
                    matricula = CInt(ddlAlunos.SelectedValue)
                End If
            End If

            gridGerenciarTcc.CarregarGridTCC(tema, status01, status02, status03, _
                                            status04, status05, matricula)

        Catch dm As DuasMatriculasSelecionadasException
            'When Not ddlProfessores.SelectedValue = 0 And Not ddlAlunos.SelectedValue = 0
            lblErroDuasMatriculas.Text = "Selecione apenas o Orientador ou o Aluno"
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

#End Region

End Class