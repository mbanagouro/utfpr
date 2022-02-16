Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: NovaBanca                                                       <BR/>
''' Objetivo.....: Cadastra banca para um determinado TCC                          <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class NovaBanca
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CarregarCamposTela()
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

        Try

            VerificarDuplicidadeBanca()
            CadastrarBanca()
            BloquearCamposBotao()

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para carregar todos os campos da tela
    ''' </summary>
    Private Sub CarregarCamposTela()

        DefinirTipoDaBanca()
        BuscarNomeAluno()
        BuscarNomeOrientador()
        BuscarTemaTcc()
        BuscarProfessores()
        CarregarHorarios()

    End Sub

    ''' <summary>
    ''' Método para montar nome do Aluno
    ''' </summary>
    Private Sub BuscarNomeAluno()

        Dim objTCC As New TCC()
        Dim objAluno As Aluno

        Try

            'Buscar o nome do Aluno vinculado ao TCC
            objAluno = objTCC.BuscarCodigoAlunoPorTcc(CType(Session("codigoTCC"), Integer))

            If Not objAluno Is Nothing Then
                'Atribui o nome retornado para o campo Aluno da tela
                lblAluno.Text = objAluno.Nome
            Else
                lblAluno.Text = "Erro ao buscar nome do aluno!"
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Médoto para buscar nome do Orientador
    ''' </summary>
    Private Sub BuscarNomeOrientador()

        Dim objTCC As New TCC()
        Dim objProfessor As Professor

        Try

            'Buscar o nome do Professor vinculado ao TCC
            objProfessor = objTCC.BuscarCodigoProfessorPorTcc(CType(Session("codigoTCC"), Integer))

            If Not objProfessor Is Nothing Then
                'Atribui o nome retornado para o campo Aluno da tela
                lblOrientador.Text = objProfessor.Nome
                hfOrientador.Value = objProfessor.Matricula.ToString.Trim
            Else
                lblOrientador.Text = "Erro ao buscar nome do Orientador!"
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para buscar a descrição do Tema
    ''' </summary>
    Private Sub BuscarTemaTcc()

        Dim objTCC As New TCC()

        Try
            'Seleciona o TCC solicitado pela tela de consulta, pegando o codigo pela variavel de sessão
            objTCC = objTCC.SelecionarTCCporCodigo(CType(Session("codigoTCC"), Integer))

            If Not objTCC Is Nothing Then

                'Carrega o campo Tema da tela
                lblTema.Text = objTCC.Tema
            Else
                lblTema.Text = "Erro ao buscar o Tema!"
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para definir o tipo da Banca
    ''' </summary>
    Private Sub DefinirTipoDaBanca()

        Dim objTCC As New TCC()
        Dim objBanca As New Banca()
        Dim qtdeBanca As Integer

        Try
            objTCC.Codigo = CType(Session("codigoTCC"), Integer)
            objBanca.TCC = objTCC

            qtdeBanca = objBanca.BuscarQtdeBancasCadastradas()

            If qtdeBanca = 0 Then
                lblTipoBanca.Text = "Proposta"
                Session("tipoBanca") = TipoBanca.Proposta
            Else
                If qtdeBanca = 1 Then
                    lblTipoBanca.Text = "Defesa"
                    Session("tipoBanca") = TipoBanca.Defesa
                Else
                    If qtdeBanca = 2 Then
                        lblMensagem.Text = "Não é possível cadastrar mais bancas para este TCC"
                        BloquearCamposBotao()
                    Else
                        lblMensagem.Text = "Erro fatal, há mais de 2 bancas para este TCC, contactar o responsável"
                        BloquearCamposBotao()
                    End If
                End If
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para Montagem dos Combos de professores
    ''' </summary>
    Private Sub BuscarProfessores()
        Try
            'Declaração de Objetos e Variaveis
            Dim objProfessor As New Professor()
            Dim lstProfessores As List(Of Professor) = objProfessor.SelecionarTodosProfessores()

            ''<<<<<  DROPLIST PROFESSOR CONVIDADO 01 >>>>>
            'Definir as colunas de Nome e Valor (Codigo matricula)
            ddlProfConvidado1.DataValueField = "Matricula"
            ddlProfConvidado1.DataTextField = "Nome"
            'Carregar a dropList
            ddlProfConvidado1.DataSource = lstProfessores
            ddlProfConvidado1.DataBind()
            ddlProfConvidado1.Items.Insert(0, (New ListItem("Selecione o Professor -----", "0")))
            ddlProfConvidado1.Items.Remove(New ListItem(lblOrientador.Text, hfOrientador.Value))

            ''<<<<<  DROPLIST PROFESSOR CONVIDADO 02 >>>>>
            ''Definir as colunas de Nome e Valor (Codigo matricula)
            ddlProfConvidado2.DataValueField = "Matricula"
            ddlProfConvidado2.DataTextField = "Nome"
            'Carregar a dropList
            ddlProfConvidado2.DataSource = lstProfessores
            ddlProfConvidado2.DataBind()
            ddlProfConvidado2.Items.Insert(0, (New ListItem("Selecione o Professor -----", "0")))
            ddlProfConvidado2.Items.Remove(New ListItem(lblOrientador.Text, hfOrientador.Value))

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para carregar o Combo de horários
    ''' </summary>
    Private Sub CarregarHorarios()

        Dim horario As DateTimeOffset
        Dim HorarioTxt As String
        Dim count As Integer

        Try

            horario = CType("13:00:00", DateTimeOffset)
            HorarioTxt = horario.DateTime.ToShortTimeString

            ddlHora.Items.Insert(0, (New ListItem("-----", "0")))

            While CType(HorarioTxt, DateTime) < CDate("23:00:00")
                count = count + 1
                ddlHora.Items.Insert(count, (New ListItem(HorarioTxt, count.ToString)))
                HorarioTxt = horario.AddMinutes(60).DateTime.ToShortTimeString
                horario = CType(HorarioTxt, DateTimeOffset)
            End While

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Procedimento para verificar na tbBanca se já existe uma banca cadastrada no horário que está sendo informado
    ''' </summary>
    Private Sub VerificarDuplicidadeBanca()

        Dim objBanca As New Banca

        Try
            Dim strData = txtData.Text & "  " & ddlHora.SelectedItem.Text
            objBanca.Data = CType(strData, Date)

            If objBanca.VerificarDuplicidadeBanca() > 0 Then
                Throw New BancaNoMesmoHorarioException("Já existe banca cadastrada nesta data!")
            End If

        Catch vdb As BancaNoMesmoHorarioException
            Throw vdb
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Método para cadastrar a Banca na base de dados
    ''' </summary>
    Private Sub CadastrarBanca()

        Dim objBanca As New Banca
        Dim objTCC As New TCC
        Dim objConvidado1 As New Professor
        Dim objConvidado2 As New Professor

        Try
            objTCC.Codigo = CType(Session("codigoTCC"), Integer)

            objConvidado1.Matricula = CInt(ddlProfConvidado1.SelectedValue)
            objConvidado2.Matricula = CInt(ddlProfConvidado2.SelectedValue)

            'Carga no Objeto de Banca
            objBanca.TCC = objTCC
            objBanca.TipoBanca = CType(Session("tipoBanca"), TipoBanca)

            objBanca.Convidado01 = objConvidado1
            objBanca.Convidado02 = objConvidado2

            Dim strData = txtData.Text & "  " & ddlHora.SelectedItem.Text
            objBanca.Data = CDate(strData)
            objBanca.Local = txtLocal.Text

            'Chamar procedimento de inserção de banca
            objBanca.Salvar()

            lblMensagem.Text = "Banca cadastrada com sucesso."

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para Bloquear todos os campos e botões da Tela
    ''' </summary>
    Private Sub BloquearCamposBotao()

        txtLocal.Enabled = False
        ddlProfConvidado1.Enabled = False
        ddlProfConvidado2.Enabled = False
        ddlHora.Enabled = False
        txtData.Enabled = False
        imbCalendar.Enabled = False
        btnSalvar.Visible = False

    End Sub

#End Region

End Class