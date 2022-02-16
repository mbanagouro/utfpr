Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Gerenciar Banca                                                 <BR/>
''' Objetivo.....: Tela de controle da(s) banca(s) de um TCC                       <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class GerenciarBanca
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Try
                TrataMontagemTela()
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
    Private Sub btnNovaBanca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaBanca.Click
        Response.Redirect(My.Resources.UrlMaps.NovaBanca)
    End Sub

    ''' <summary>
    ''' Trtamento do botão excluir Banca de Proposta
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDeletarProposta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeletarProposta.Click
        Dim objBanca As New Banca
        Dim objTCC As New TCC

        Try
            'Carrega os objetos
            objTCC.Codigo = CType(Session("codigoTCC"), Integer)
            objBanca.TCC = objTCC
            objBanca.TipoBanca = TipoBanca.Proposta

            'Executa procedimento de exclusão
            objBanca.Excluir()

            TrataMontagemTela()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Tratamento do botão excluir Banca de Defesa (Final)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDeletarDefesa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeletarDefesa.Click
        Dim objBanca As New Banca
        Dim objTCC As New TCC

        Try
            'Carrega os objetos
            objTCC.Codigo = CType(Session("codigoTCC"), Integer)
            objBanca.TCC = objTCC
            objBanca.TipoBanca = TipoBanca.Defesa

            'Executa procedimento de exclusão
            objBanca.Excluir()

            TrataMontagemTela()

            lblMensagem.Text = "Banca excluida com sucesso!"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAlterarDefesa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterarDefesa.Click

        'Redirecionar para página de alteração de Banca
        Session("tipoBanca") = TipoBanca.Defesa
        Response.Redirect(My.Resources.UrlMaps.EditarBanca)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAlterarProposta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterarProposta.Click

        'Redirecionar para página de alteração de Banca
        Session("tipoBanca") = TipoBanca.Proposta
        Response.Redirect(My.Resources.UrlMaps.EditarBanca)

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método de processamento principal da montagem da tela
    ''' </summary>
    Private Sub TrataMontagemTela()

        Try
            Dim qtdebanca = DefinirTipoDaBanca()

            'Montagem dos três campos fixos no inicio da página
            MontaDadosCabec()

            'Verifica e trata a montagem dos painéis da tela
            If qtdebanca = 0 Then
                pnlProposta.Enabled = False
                pnlProposta.Visible = False
                pnlDefesa.Visible = False
                pnlDefesa.Enabled = False
                btnNovaBanca.Enabled = True
                btnNovaBanca.Visible = True
                lblMensagem.Text = "Não há bancas cadastradas para este TCC. Clique no botão 'Nova Banca' para o cadastramento."
            Else
                If qtdebanca = 1 Then
                    pnlDefesa.Visible = False
                    pnlDefesa.Enabled = False
                    btnDeletarProposta.Enabled = True
                    btnDeletarProposta.Visible = True
                    btnNovaBanca.Enabled = True
                    btnNovaBanca.Visible = True
                    MontaProposta()
                Else
                    If qtdebanca = 2 Then
                        btnNovaBanca.Enabled = False
                        btnNovaBanca.Visible = False
                        btnDeletarProposta.Enabled = False
                        btnDeletarProposta.Visible = False
                        MontaProposta()
                        MontaDefesa()
                    Else
                        btnNovaBanca.Enabled = False
                        btnNovaBanca.Visible = False
                        lblMensagem.Text = "Erro fatal, há mais de 2 bancas para este TCC, contactar o responsável"
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Função para definir a quantidade de bancas já cadastradas para poder tratar a tela
    ''' </summary>
    ''' <returns></returns>
    Private Function DefinirTipoDaBanca() As Integer

        ' Declaração de onjetos e variáveis
        Dim objTCC As New TCC()
        Dim objBanca As New Banca()
        Dim qtdeBanca As Integer

        Try
            objTCC.Codigo = CType(Session("codigoTCC"), Integer)
            objBanca.TCC = objTCC

            'Obtem a quantidade de bancas
            qtdeBanca = objBanca.BuscarQtdeBancasCadastradas()

            Return qtdeBanca

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Function

    ''' <summary>
    ''' Método de tratamento da montagem dos campos com informação do TCC no inicio da tela
    ''' </summary>
    Private Sub MontaDadosCabec()

        BuscarNomeAluno()
        BuscarNomeOrientador()
        BuscarTemaTcc()

    End Sub

    ''' <summary>
    ''' Método para montagem dos dados da Banca de PROPOSTA
    ''' </summary>
    Private Sub MontaProposta()

        Dim objBanca As New Banca
        Dim objTcc As New TCC
        Dim objProfessor As New Professor

        Try
            pnlProposta.Visible = True
            pnlProposta.Enabled = True

            objBanca = objBanca.BuscaBancaPorTipo(1, CType(Session("codigoTCC"), Integer))

            lblDataProposta.Text = objBanca.Data.ToString
            lblLocalProposta.Text = objBanca.Local

            objProfessor = objProfessor.SelecionarProfessorPorMatricula(objBanca.Convidado01.Matricula)
            lblConvidado01Proposta.Text = objProfessor.Nome

            objProfessor = objProfessor.SelecionarProfessorPorMatricula(objBanca.Convidado02.Matricula)
            lblConvidado02Proposta.Text = objProfessor.Nome

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Método para montagem dos dados da Banca de DEFESA
    ''' </summary>
    Private Sub MontaDefesa()

        Dim objBanca As New Banca
        Dim objTcc As New TCC
        Dim objProfessor As New Professor

        Try
            pnlDefesa.Visible = True
            pnlDefesa.Enabled = True

            objBanca = objBanca.BuscaBancaPorTipo(2, CType(Session("codigoTCC"), Integer))

            lblDataDefesa.Text = objBanca.Data.ToString
            lblLocalDefesa.Text = objBanca.Local

            objProfessor = objProfessor.SelecionarProfessorPorMatricula(objBanca.Convidado01.Matricula)
            lblConvidado01Defesa.Text = objProfessor.Nome

            objProfessor = objProfessor.SelecionarProfessorPorMatricula(objBanca.Convidado02.Matricula)
            lblConvidado02Defesa.Text = objProfessor.Nome

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método para montar o nome do Aluno
    ''' </summary>
    Private Sub BuscarNomeAluno()

        'Declaração dos objetos
        Dim objTCC As New TCC()
        Dim objAluno As Aluno

        Try
            'Buscar o nome do Aluno vinculado ao TCC
            objAluno = objTCC.BuscarCodigoAlunoPorTcc(CType(Session("codigoTCC"), Integer))
            'atribui o valor ao campo da tela
            lblAluno.Text = objAluno.Nome

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para montar o nome do Orientador
    ''' </summary>
    Private Sub BuscarNomeOrientador()
        'Declaração dos objetos
        Dim objTCC As New TCC()
        Dim objProfessor As Professor

        Try

            'Buscar o nome do Professor vinculado ao TCC
            objProfessor = objTCC.BuscarCodigoProfessorPorTcc(CType(Session("codigoTCC"), Integer))

            If Not objProfessor Is Nothing Then
                'Atribui o nome retornado para o campo Aluno da tela
                lblOrientador.Text = objProfessor.Nome
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Método para montar a descrição do Tema do TCC 
    ''' </summary>
    Private Sub BuscarTemaTcc()
        Dim objTCC As New TCC()

        Try
            'Seleciona o TCC solicitado pela tela de consulta, pegando o codigo pela variavel de sessão
            objTCC = objTCC.SelecionarTCCporCodigo(CType(Session("codigoTCC"), Integer))

            If Not objTCC Is Nothing Then
                'Carrega o campo Tema da tela
                lblTema.Text = objTCC.Tema
            End If

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try
    End Sub

#End Region

End Class