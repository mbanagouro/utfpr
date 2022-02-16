Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: GridAvisos                                                      <BR/>
''' Objetivo.....: Grid que carrega os avisos do sistema para manutenção.          <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class GridAvisos
    Inherits System.Web.UI.UserControl

#Region "Eventos"

    ''' <summary>
    ''' Evento bound do controle GridView
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub gdvAvisos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvAvisos.RowCommand

        Select Case e.CommandName

            Case "Visualizar"
                ' Redireciona para página de visualização
                Me.RedirecionaVisualizarAviso(e.CommandArgument.ToString.Trim)

            Case "Editar"
                ' Redireciona para página de edição
                Me.RedirecionaEditarAviso(e.CommandArgument.ToString.Trim)

            Case "Apagar"
                ' Executa o método de exclusão
                Me.ExcluirAviso(CType(e.CommandArgument, Integer))
                ' Recarrega o GridView de Avisos
                Me.CarregarGridAvisos()

            Case Else
                ' Não faz nada

        End Select

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
    ''' Método para carregar o GridView de avisos
    ''' </summary>
    Public Sub CarregarGridAvisos()

        ' Declara os objetos
        Dim objAviso As Aviso

        Try

            ' Instancia os objetos
            objAviso = New Aviso

            ' Atribui a coleção de avisos ao DataSource do GridView
            gdvAvisos.DataSource = objAviso.SelecionarTodosAvisos()
            gdvAvisos.DataBind()

        Catch ex As Exception
            Me.ErroCarregarGrid()
        End Try

        ' Executa o método de paginação do GridView
        Me.ControlePaginacao()

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para exclusão do aviso na base de dados
    ''' </summary>
    ''' <param name="codigoAviso">Código identificador do aviso</param>
    Private Sub ExcluirAviso(ByVal codigoAviso As Integer)

        ' Declara os objetos
        Dim objAviso As Aviso

        Try
            ' Instancia os objetos
            objAviso = New Aviso

            ' Executa o método de exclusão
            objAviso.ExcluirAviso(codigoAviso)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Método que executa a paginação da GridView
    ''' </summary>
    Private Sub ControlePaginacao()

        ' Esconde os botões de próximo e anterior
        lnkAnterior.Visible = True
        lnkProxima.Visible = True

        ' Trata a exibição dos botões próximo e anterior na tela
        If CBool(gdvAvisos.PageIndex + 1 And gdvAvisos.PageCount) Then
            lnkProxima.Visible = False
        End If
        If gdvAvisos.PageIndex = 0 Then
            lnkAnterior.Visible = False
        End If
        If gdvAvisos.PageCount = 0 Then
            pnlPaginacao.Visible = False
        Else
            pnlPaginacao.Visible = True
        End If

        ' Atribui na label a quantidade de páginas que o GridView possui
        lblTotalPag.Text = gdvAvisos.PageCount.ToString.Trim
        ' Atribui na label a página atual
        lblPagAtual.Text = CStr(gdvAvisos.PageIndex + 1)

    End Sub

    ''' <summary>
    ''' Método para ir para a página anterior
    ''' </summary>
    Private Sub VoltarPagina()
        ' Diminui uma página
        gdvAvisos.PageIndex -= 1
        ' Executa o método para controle de paginação
        Me.CarregarGridAvisos()
    End Sub

    ''' <summary>
    ''' Método para ir para a próxima página
    ''' </summary>
    Private Sub AvancarPagina()
        ' Aumenta uma página
        gdvAvisos.PageIndex += 1
        ' Executa o método para controle de paginação
        Me.CarregarGridAvisos()
    End Sub

    ''' <summary>
    ''' Método que redireciona para a página de visualização do aviso
    ''' </summary>
    ''' <param name="codigoAviso">objAviso As Aviso</param>
    Private Sub RedirecionaVisualizarAviso(ByVal codigoAviso As String)
        Session("codigoAviso") = String.Empty
        Session("codigoAviso") = codigoAviso
        Response.Redirect(My.Resources.UrlMaps.VisualizarAviso)
    End Sub

    ''' <summary>
    ''' Método que redireciona para a página de edição do aviso
    ''' </summary>
    ''' <param name="codigoAviso">Código do aviso</param>
    Private Sub RedirecionaEditarAviso(ByVal codigoAviso As String)
        Session("codigoAviso") = String.Empty
        Session("codigoAviso") = codigoAviso
        Response.Redirect(My.Resources.UrlMaps.EditarAviso)
    End Sub

    ''' <summary>
    ''' Método executado quando ocorre um erro de carregamento do grid
    ''' </summary>
    Private Sub ErroCarregarGrid()
        divAviso.Visible = True
    End Sub

#End Region

End Class