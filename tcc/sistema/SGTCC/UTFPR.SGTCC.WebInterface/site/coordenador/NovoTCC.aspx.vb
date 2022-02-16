Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: NovoTCC                                                         <BR/>
''' Objetivo.....: Cadastrar um Novo TCC                                           <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class NovoTCC
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.CarregarComboProfessores()
            Me.CaregarComboAlunos()
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCadastrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCadastrar.Click
        Me.CadastrarTCC()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para cadastrar o TCC na base de dados
    ''' </summary>
    Private Sub CadastrarTCC()

        Try
            Dim objTCC As New TCC

            objTCC.Tema = txtTema.Text
            objTCC.Status = StatusTCC.Proposta

            If txtDataInicio.Text = String.Empty Then
                objTCC.DataInicio = System.DateTime.MinValue
            Else
                objTCC.DataInicio = CType(txtDataInicio.Text, System.DateTime)
            End If

            If txtDataEntega.Text = String.Empty Then
                objTCC.DataFim = System.DateTime.MinValue
            Else
                objTCC.DataFim = CType(txtDataEntega.Text, System.DateTime)
            End If

            'Cadastrar o TCC
            objTCC.CadastrarTCC(CInt(ddlAluno.SelectedValue), CInt(ddlProfessores.SelectedValue))
            'Definir a mensagem de sucesso
            lblMensagem.Text = "Trabalho de Conclusão de Curso cadastrado com sucesso!"
            'Apos o cadastro, resetar todos os campos da tela
            LimparCampos()

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Métodos para carregar o combo de Professores
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

            ddlProfessores.Items.Insert(0, (New ListItem("Selecione o Professor -----", "0")))

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Métodos para carregar o combo de Alunos
    ''' </summary>
    Private Sub CaregarComboAlunos()
        Try
            'cria o objeto Usuario
            Dim objAluno As New Aluno()

            'Carregar a dropList
            ddlAluno.DataSource = objAluno.SelecionarTodosAlunos()
            ddlAluno.DataValueField = "Matricula"
            ddlAluno.DataTextField = "Nome"
            ddlAluno.DataBind()

            ddlAluno.Items.Insert(0, (New ListItem("Selecione o Aluno -----", "0")))

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Médoto para carregar com brancos os campos da tela
    ''' </summary>
    Private Sub LimparCampos()
        txtTema.Text = String.Empty
        txtDataEntega.Text = String.Empty
        txtDataInicio.Text = String.Empty
        ddlAluno.SelectedIndex = 0
        ddlProfessores.SelectedIndex = 0
    End Sub

#End Region

End Class