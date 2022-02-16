Imports UTFPR.SGTCC.Negocio.ModuloCA
Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: GridGerenciarTcc                                                <BR/>
''' Objetivo.....: Code-behind do User Control de grid de TCC.                     <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class GridGerenciarTcc
    Inherits System.Web.UI.UserControl

#Region "Propriedades"

    ''' <summary>
    ''' Recebe a fonte de dados
    ''' </summary>
    ''' <value>Coleção de TCC</value>
    Public WriteOnly Property FontedeDados() As List(Of TCC)
        Set(ByVal value As List(Of TCC))
            gdvGerenciarTcc.DataSource = value
        End Set
    End Property

#End Region

#Region "Eventos"

    ''' <summary>
    ''' Evento do comando da grid view
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub gdvGerenciarTcc_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvGerenciarTcc.RowCommand

        Select Case e.CommandName
            Case "EditarTcc"
                Session("codigoTcc") = e.CommandArgument.ToString.Trim
                Response.Redirect(My.Resources.UrlMaps.EditarTCC)

            Case "DetalharBanca"
                Session("codigoTcc") = e.CommandArgument.ToString.Trim
                Response.Redirect(My.Resources.UrlMaps.GerenciarBanca)

        End Select

    End Sub

    ''' <summary>
    ''' Evento do click do link Próximo
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    ''' 
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
    ''' Método para carregar o GridView de TCC
    ''' </summary>
    Public Sub CarregarGridTCC(ByVal tema As String, ByVal status01 As Integer, ByVal status02 As Integer, _
                               ByVal status03 As Integer, ByVal status04 As Integer, ByVal status05 As Integer, _
                               ByVal matricula As Integer)

        ' Instancia um objeto Aviso
        Dim objTcc As New TCC

        Try
            hdnstatus01.Value = status01.ToString
            hdnstatus02.Value = status02.ToString
            hdnstatus03.Value = status03.ToString
            hdnstatus04.Value = status04.ToString
            hdnstatus05.Value = status05.ToString
            hdntema.Value = tema
            hdnmatricula.Value = matricula.ToString

            Me.FontedeDados = objTcc.SelecionarFiltradoTodosTCC(tema, status01, status02, status03, _
                                                                  status04, status05, matricula)

            ' Carrega o controle com os dados
            gdvGerenciarTcc.DataBind()
            ' Executa o método de paginação do GridView
            Me.ControlePaginacao()

        Catch ex As Exception
            Throw ex
        End Try
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
        If CBool(gdvGerenciarTcc.PageIndex + 1 And gdvGerenciarTcc.PageCount) Then
            lnkProxima.Visible = False
        End If
        If gdvGerenciarTcc.PageIndex = 0 Then
            lnkAnterior.Visible = False
        End If
        If gdvGerenciarTcc.PageCount = 0 Then
            pnlPaginacao.Visible = False
        Else
            pnlPaginacao.Visible = True
        End If

        ' Atribui na label a quantidade de páginas que o GridView possui
        lblTotalPag.Text = gdvGerenciarTcc.PageCount.ToString.Trim
        ' Atribui na label a página atual
        lblPagAtual.Text = CStr(gdvGerenciarTcc.PageIndex + 1)

    End Sub

    ''' <summary>
    ''' Método para ir para a página anterior
    ''' </summary>
    Private Sub VoltarPagina()
        ' Diminui uma página
        gdvGerenciarTcc.PageIndex -= 1
        ' Executa o método para controle de paginação
        Me.CarregarGridTCC(hdntema.Value, CInt(hdnstatus01.Value), CInt(hdnstatus02.Value), CInt(hdnstatus03.Value), _
                            CInt(hdnstatus04.Value), CInt(hdnstatus05.Value), CInt(hdnmatricula.Value))
    End Sub

    ''' <summary>
    ''' Método para ir para a próxima página
    ''' </summary>
    Private Sub AvancarPagina()
        ' Aumenta uma página
        gdvGerenciarTcc.PageIndex += 1
        ' Executa o método para controle de paginação
        Me.CarregarGridTCC(hdntema.Value, CInt(hdnstatus01.Value), CInt(hdnstatus02.Value), CInt(hdnstatus03.Value), _
                    CInt(hdnstatus04.Value), CInt(hdnstatus05.Value), CInt(hdnmatricula.Value))
    End Sub

#End Region

End Class