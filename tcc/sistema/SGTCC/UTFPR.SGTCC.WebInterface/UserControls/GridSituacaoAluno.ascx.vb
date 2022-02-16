Imports UTFPR.SGTCC.Negocio.ModuloCA

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: GridSituacaoAluno.                                              <BR/>
''' Objetivo.....: Code-Behind do User Control da grid de situação de alunos.      <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class GridSituacaoAluno
    Inherits System.Web.UI.UserControl

#Region "Eventos"

    ''' <summary>
    ''' Evento do bound da grid
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub grdSituacaoAlunos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSituacaoAlunos.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lblStatus As Label = CType(e.Row.FindControl("lblStatus"), Label)
            Dim status As StatusTCC = CType(System.Enum.Parse(GetType(StatusTCC), lblStatus.Text), StatusTCC)

            Select Case status
                Case StatusTCC.Banca
                    lblStatus.Text = "Banca"
                Case StatusTCC.Aprovado
                    lblStatus.Text = "Aprovado"
                Case StatusTCC.Desistente
                    lblStatus.Text = "Desistente"
                Case StatusTCC.Matriculado
                    lblStatus.Text = "Matriculado"
                Case StatusTCC.Proposta
                    lblStatus.Text = "Proposta"
            End Select

        End If

    End Sub

    ''' <summary>
    ''' Evento do click do link Próximo
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub lnkProxima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProxima.Click
        Me.AvancarPagina()
    End Sub

    ''' <summary>
    ''' Evento do click do link Anterior
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub lnkAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAnterior.Click
        Me.VoltarPagina()
    End Sub

#End Region

#Region "Métodos Públicos"

    ''' <summary>
    ''' Método que carrega o grid com a situação dos alunos
    ''' </summary>
    ''' <param name="nomeUsuario">Nome do usuário</param>
    ''' <param name="statusTcc">Status do usuário</param>
    Public Sub CarregarGridAlunos(ByVal nomeUsuario As String, ByVal statusTcc As StatusTCC)

        ' Declara ao objeto
        Dim objTcc As TCC

        Try
            ' Instancia os objetos
            objTcc = New TCC

            ' Recupera os parâmetros
            hdnNome.Value = nomeUsuario
            hdnStatus.Value = statusTcc.ToString.Trim

            ' Executa o método que irá trazer os dados da situação dos alunos
            grdSituacaoAlunos.DataSource = objTcc.ConsultaSituacaoTcc(nomeUsuario, statusTcc)
            grdSituacaoAlunos.DataBind()

        Catch ex As Exception
            Me.ErroCarregarGrid()
        End Try

        ' Executa a paginação da grid
        Me.ControlePaginacao()

    End Sub

    ''' <summary>
    ''' Método para ir para a página anterior
    ''' </summary>
    Public Sub VoltarPagina()
        ' Diminui uma página
        grdSituacaoAlunos.PageIndex -= 1
        ' Recarrega o GridView
        Me.CarregarGridAlunos(hdnNome.Value, CType(hdnStatus.Value, StatusTCC))
    End Sub

    ''' <summary>
    ''' Método para ir para a próxima página
    ''' </summary>
    Public Sub AvancarPagina()
        ' Aumenta uma página
        grdSituacaoAlunos.PageIndex += 1
        ' Recarrega o GridView
        Me.CarregarGridAlunos(hdnNome.Value, CType(hdnStatus.Value, StatusTCC))
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que executa a paginação da GridView
    ''' </summary>
    Private Sub ControlePaginacao()

        ' Esconde os botões de próximo e anterior
        lnkAnterior.Visible = True
        lnkProxima.Visible = True

        ' Trata a exibição dos botões próximo e anterior na tela
        If CBool(grdSituacaoAlunos.PageIndex + 1 And grdSituacaoAlunos.PageCount) Then
            lnkProxima.Visible = False
        End If
        If grdSituacaoAlunos.PageIndex = 0 Then
            lnkAnterior.Visible = False
        End If
        If grdSituacaoAlunos.PageCount = 0 Then
            pnlPaginacao.Visible = False
        Else
            pnlPaginacao.Visible = True
        End If

        ' Atribui na label a quantidade de páginas que o GridView possui
        lblTotalPag.Text = grdSituacaoAlunos.PageCount.ToString.Trim
        ' Atribui na label a página atual
        lblPagAtual.Text = CStr(grdSituacaoAlunos.PageIndex + 1)

    End Sub

    ''' <summary>
    ''' Método executado quando ocorre um erro de carregamento do grid
    ''' </summary>
    Private Sub ErroCarregarGrid()
        divAviso.Visible = True
    End Sub

#End Region

End Class