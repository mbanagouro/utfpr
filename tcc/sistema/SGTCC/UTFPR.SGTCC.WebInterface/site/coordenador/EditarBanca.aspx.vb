Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: EditarBanca                                                     <BR/>
''' Objetivo.....: Alteração dos dados da Banca                                    <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class EditarBanca
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
            AtualizarBanca()
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CarregarCamposTela()

        Try
            DefinirTipoDaBanca()
            BuscarNomeAluno()
            BuscarNomeOrientador()
            BuscarTemaTcc()
            BuscarProfessores()
            CarregarHorarios()
            MontaBanca()
        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' 
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
                ' TODO: TRATAR MENSAGEM DE ERRO
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' 
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
                ' TODO: TRATAR MENSAGEM DE ERRO
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' 
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
                ' TODO: tratar caso nao ache o TCC
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub DefinirTipoDaBanca()

        Try
            If (CType(Session("tipoBanca"), Integer)) = TipoBanca.Proposta Then
                lblTipoBanca.Text = "Proposta"
            Else
                lblTipoBanca.Text = "Defesa"
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' 
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
    ''' 
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
                ddlHora.Items.Insert(count, (New ListItem(HorarioTxt, count.ToString.Trim)))
                HorarioTxt = horario.AddMinutes(50).DateTime.ToShortTimeString
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
                Throw New BancaNoMesmoHorarioException("Ja existe banca cadastrada nesta Data")
            End If

        Catch vdb As BancaNoMesmoHorarioException
            Throw vdb
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 
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

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub MontaBanca()

        Dim objBanca As New Banca
        Dim objTcc As New TCC
        Dim objProfessor As New Professor
        Dim Data As String
        Dim Horario As String
        Dim listItem As ListItem

        Try
            objBanca = objBanca.BuscaBancaPorTipo(CType(Session("tipoBanca"), Integer), CType(Session("codigoTCC"), Integer))

            Data = objBanca.Data.Date.ToShortDateString
            Horario = objBanca.Data.ToShortTimeString

            txtLocal.Text = objBanca.Local
            txtData.Text = Data

            'Busca Convidado 01
            objProfessor = objProfessor.SelecionarProfessorPorMatricula(objBanca.Convidado01.Matricula)

            'Seleciona no dropList o Convidado 01
            listItem = ddlProfConvidado1.Items.FindByText(objProfessor.Nome)
            ddlProfConvidado1.SelectedValue = listItem.Value

            'Busca Convidado 02
            objProfessor = objProfessor.SelecionarProfessorPorMatricula(objBanca.Convidado02.Matricula)

            'Seleciona no dropList o Convidado 01
            listItem = ddlProfConvidado2.Items.FindByText(objProfessor.Nome)
            ddlProfConvidado2.SelectedValue = listItem.Value

            'Seleciona o Horário
            listItem = ddlHora.Items.FindByText(Horario)
            ddlHora.SelectedValue = listItem.Value

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub AtualizarBanca()

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
            objBanca.TipoBanca = CType(Session("tipoBanca"), Integer)

            objBanca.Convidado01 = objConvidado1
            objBanca.Convidado02 = objConvidado2

            Dim strData = txtData.Text & "  " & ddlHora.SelectedItem.Text
            objBanca.Data = CType(strData, Date)
            objBanca.Local = txtLocal.Text

            'Chamar procedimento de inserção de banca
            objBanca.Atualizar()

            lblMensagem.Text = "Banca atualizada com sucesso!"

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Sub

#End Region

End Class