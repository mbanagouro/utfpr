Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: EditarTCC                                                       <BR/>
''' Objetivo.....: Editar um TCC já cadastrado                                     <BR/>
''' ****************************************************************************** <BR/>
''' </summary>

Partial Public Class EditarTCC
    Inherits System.Web.UI.Page

#Region "Atributos"

    ''' <summary>
    ''' Objeto TCC
    ''' </summary>
    Private objTCC As New TCC()

#End Region

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Me.CarregarCamposTela()

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
    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Me.AtualizarTcc()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para carregar todos os campos da tela
    ''' </summary>
    Private Sub CarregarCamposTela()
        Try
            Dim listItemStatus As ListItem
            Dim DataAux As New DateTime

            'Seleciona o TCC solicitado pela tela de consulta, pegando o codigo pela variavel de sessão
            objTCC = objTCC.SelecionarTCCporCodigo(CType(Session("codigoTCC"), Integer))

            If Not objTCC Is Nothing Then

                CaregarComboAlunos()
                CarregarComboProfessores()
                CarregarComboStatus()

                txtTema.Text = objTCC.Tema
                txtDataInicio.Text = objTCC.DataInicio.ToString("dd/MM/yyyy")
                txtDataEntrega.Text = objTCC.DataFim.ToString("dd/MM/yyyy")

                'Seleciona no dropList o Status atual do TCC
                listItemStatus = ddlStatus.Items.FindByValue(CInt(objTCC.Status).ToString)
                ddlStatus.SelectedValue = listItemStatus.Value

                'Carregar os campos de Nota
                txtNotaProposta.Text = objTCC.NotaProposta.ToString.Trim
                txtNotaFinal.Text = objTCC.NotaFinal.ToString.Trim
            Else
                Throw New Exception("TCC nao encontrado")
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' Método para carrerar o combo de professores
    ''' </summary>
    Private Sub CarregarComboProfessores()
        Try
            'Declaração de Objetos e Variaveis
            Dim objProfessor As New Professor()
            Dim listItemStatus As ListItem

            'Carregar a dropList
            ddlProfessores.DataSource = objProfessor.SelecionarTodosProfessores()

            'Definir as colunas de Nome e Valor (Codigo matricula)
            ddlProfessores.DataValueField = "Matricula"
            ddlProfessores.DataTextField = "Nome"
            ddlProfessores.DataBind()

            ddlProfessores.Items.Insert(0, (New ListItem("Selecione o Professor -----", "0")))

            'Seleciona no dropList o Professor atual do TCC
            listItemStatus = ddlProfessores.Items.FindByValue(CInt(objTCC.Orientador.Matricula).ToString)
            ddlProfessores.SelectedValue = listItemStatus.Value

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para carrerar o combo de Alunos
    ''' </summary>
    Private Sub CaregarComboAlunos()
        Try
            'Declaração de Objetos e Variaveis
            Dim objAluno As New Aluno()
            Dim listItemStatus As ListItem

            'Carregar a dropList
            ddlAluno.DataSource = objAluno.SelecionarTodosAlunos()
            ddlAluno.DataValueField = "Matricula"
            ddlAluno.DataTextField = "Nome"
            ddlAluno.DataBind()

            'Adicionar a opção 0
            ddlAluno.Items.Insert(0, (New ListItem("Selecione o Aluno -----", "0")))

            'Seleciona no dropList o Aluno atual do TCC
            listItemStatus = ddlAluno.Items.FindByValue(objTCC.Aluno.Matricula.ToString)
            ddlAluno.SelectedValue = listItemStatus.Value

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para carrerar o combo de Status
    ''' </summary>
    Private Sub CarregarComboStatus()

        ddlStatus.Items.Add(New ListItem("Proposta", CInt(StatusTCC.Proposta).ToString))
        ddlStatus.Items.Add(New ListItem("Matriculado", CInt(StatusTCC.Matriculado).ToString))
        ddlStatus.Items.Add(New ListItem("Banca Agendada", CInt(StatusTCC.Banca).ToString))
        ddlStatus.Items.Add(New ListItem("Aprovado/Terminou", CInt(StatusTCC.Aprovado).ToString))
        ddlStatus.Items.Add(New ListItem("Desistente", CInt(StatusTCC.Desistente).ToString))

    End Sub

    ''' <summary>
    ''' Método de atualização do TCC
    ''' </summary>
    Private Sub AtualizarTcc()

        Try
            Dim objTCC As New TCC()
            Dim objAluno As New Aluno
            Dim objProfessor As New Professor

            'Carregar o objeto TCC
            'Codigo TCC
            objTCC.Codigo = CInt(Session("codigoTCC"))
            'TEMA
            objTCC.Tema = txtTema.Text
            'STATUS
            objTCC.Status = CType(ddlStatus.SelectedValue, StatusTCC)
            'NOTA PROPOSTA
            objTCC.NotaProposta = CInt(txtNotaProposta.Text)
            'NOTA FINAL
            objTCC.NotaFinal = CInt(txtNotaFinal.Text)

            'ALUNO E ORIENTADOR
            objAluno.Matricula = CInt(ddlAluno.SelectedValue)
            objProfessor.Matricula = CInt(ddlProfessores.SelectedValue)

            objTCC.Aluno = objAluno
            objTCC.Orientador = objProfessor

            'Data Inicio TCC
            If txtDataInicio.Text = String.Empty Then
                objTCC.DataInicio = System.DateTime.MinValue
            Else
                objTCC.DataInicio = CDate(txtDataInicio.Text)
            End If
            'Data final (entrega) do TCC
            If txtDataEntrega.Text = String.Empty Then
                objTCC.DataFim = System.DateTime.MinValue
            Else
                objTCC.DataFim = CType(txtDataEntrega.Text, System.DateTime)
            End If

            'Atualizar o TCC
            objTCC.AtualizarTCC()

            'Definir a mensagem de sucesso
            lblMensagem.Text = "Trabalho de Conclusão de Curso atualizado com sucesso!"
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

#End Region

End Class