Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' 
''' </summary>
Partial Public Class GridOrientadores
    Inherits System.Web.UI.UserControl

#Region "Eventos"

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

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega os orientadores
    ''' </summary>
    Public Sub CarregarGridOrientadores()

        Dim objProfessor As Professor

        Try
            objProfessor = New Professor

            grdOrientadores.DataSource = objProfessor.SelecionarOrientadores
            grdOrientadores.DataBind()

            Me.ControlePaginacao()

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
        If CBool(grdOrientadores.PageIndex + 1 And grdOrientadores.PageCount) Then
            lnkProxima.Visible = False
        End If
        If grdOrientadores.PageIndex = 0 Then
            lnkAnterior.Visible = False
        End If
        If grdOrientadores.PageCount = 0 Then
            pnlPaginacao.Visible = False
        Else
            pnlPaginacao.Visible = True
        End If

        ' Atribui na label a quantidade de páginas que o GridView possui
        lblTotalPag.Text = grdOrientadores.PageCount.ToString.Trim
        ' Atribui na label a página atual
        lblPagAtual.Text = CStr(grdOrientadores.PageIndex + 1)

    End Sub

    ''' <summary>
    ''' Método para ir para a página anterior
    ''' </summary>
    Public Sub VoltarPagina()
        ' Diminui uma página
        grdOrientadores.PageIndex -= 1
        ' Recarrega o GridView
        Me.CarregarGridOrientadores()
    End Sub

    ''' <summary>
    ''' Método para ir para a próxima página
    ''' </summary>
    Public Sub AvancarPagina()
        ' Aumenta uma página
        grdOrientadores.PageIndex += 1
        ' Recarrega o GridView
        Me.CarregarGridOrientadores()
    End Sub

#End Region

End Class