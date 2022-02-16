Imports UTFPR.SGTCC.Negocio.ModuloAP

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: GridMensagensRecebidas                                          <BR/>
''' Objetivo.....: Code-behind do User Control da grid de mensagens recebidas.     <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class GridMensagensRecebidas
    Inherits System.Web.UI.UserControl

#Region "Atributos"

    ''' <summary>
    ''' Constante com o caminho da imagem de alta prioridade
    ''' </summary>
    Private IMG_ALTA_PRI As String = "~/imagens/icones/img_alta_pri.png"
    ''' <summary>
    ''' Constante com o caminho da imagem de baixa prioridade
    ''' </summary>
    Private IMG_BAIXA_PRI As String = "~/imagens/icones/img_baixa_pri.png"
    ''' <summary>
    ''' Constante com o caminho da imagem de email lido
    ''' </summary>
    Private IMG_MAIL_OPEN As String = "~/imagens/icones/img_mail_open.png"
    ''' <summary>
    ''' Constante com o caminho da imagem de email não lido
    ''' </summary>
    Private IMG_MAIL_CLOSE As String = "~/imagens/icones/img_mail_close.png"

#End Region

#Region "Eventos"

    ''' <summary>
    ''' Evento do comando executado na GridView
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub gdvMensagens_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvMensagensRecebidas.RowCommand

        ' Verificando os casos
        Select Case e.CommandName

            Case "VerMensagem"
                ' Recupera o código da mensagem pelo argumento da linha selecionada no GridView
                Dim codMensagem As String = e.CommandArgument.ToString
                Dim tpMensagem As String = CInt(TipoMensagem.Recebida).ToString

                ' Redireciona para a página de visualizar a mensagem
                Me.RedirecionaVisualizaMensagem(codMensagem, tpMensagem)

            Case Else
                ' Não fazer nada

        End Select

    End Sub

    ''' <summary>
    ''' Evento disparado quando o controle é carregado
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub gdvMensagens_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvMensagensRecebidas.RowDataBound

        ' Se a linha que está sendo carregada for de dados
        If e.Row.RowType = DataControlRowType.DataRow Then

            ' Recupera o campo hidden e imagem prioridade da mensagem
            Dim hdnPrioridade As HiddenField = CType(e.Row.FindControl("hdnPrioridade"), HiddenField)
            Dim imgPrioridade As Image = CType(e.Row.FindControl("imgPrioridade"), Image)
            ' Converte o valor do hidden para um enumerador
            Dim prioridade As PrioridadeMensagem = CType(System.Enum.Parse(GetType(PrioridadeMensagem), hdnPrioridade.Value), PrioridadeMensagem)

            ' Pelo valor do hidden verifica qual imagem será exibida
            If prioridade = PrioridadeMensagem.Urgente Then
                imgPrioridade.ImageUrl = Me.IMG_ALTA_PRI
            ElseIf prioridade = PrioridadeMensagem.Importante Then
                imgPrioridade.ImageUrl = Me.IMG_BAIXA_PRI
            Else
                imgPrioridade.Visible = False
            End If

            ' Recupera o campo hidden e imagem de mensagem lida ou não lida
            Dim hdnLido As HiddenField = CType(e.Row.FindControl("hdnLido"), HiddenField)
            Dim imgLido As Image = CType(e.Row.FindControl("imgLido"), Image)
            ' Converte o valoda do hidden para um enumerador
            Dim lido As StatusMensagem = CType(System.Enum.Parse(GetType(StatusMensagem), hdnLido.Value), StatusMensagem)

            ' Pelo valor do hidden verifica qual imagem será exibida
            If lido = StatusMensagem.Lido Then
                e.Row.Font.Bold = False
                imgLido.ImageUrl = Me.IMG_MAIL_OPEN
            ElseIf lido = StatusMensagem.NaoLido Then
                e.Row.Font.Bold = True
                imgLido.ImageUrl = Me.IMG_MAIL_CLOSE
            End If

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
    ''' Função que formata a exibição dos nomes usuários de remetente ou destinatário no GridView
    ''' </summary>
    ''' <param name="lstUsuarios">Coleção de Usuario</param>
    ''' <returns>Retorna uma string formatada com a exibição do nome do(s) usuário(s)</returns>
    Public Function Formatar(ByVal lstUsuarios As List(Of Usuario)) As String

        Dim nomesFormatados As StringBuilder

        ' Instancia um objeto StringBuilder para formatação da string
        nomesFormatados = New StringBuilder

        ' Para cada usuário da coleção, é feita a concatenação do primeiro nome
        For Each user As Usuario In lstUsuarios
            Dim nomes() As String = user.Nome.Split(CChar(" "))

            If lstUsuarios.Count > 1 Then
                ' Atribui somente o nome e sobrenome
                nomesFormatados.Append(nomes(0))
                nomesFormatados.Append(" ")
                nomesFormatados.Append(nomes(nomes.GetUpperBound(0)))
                nomesFormatados.Append("; ")
            Else
                ' Atribui o nome completo
                nomesFormatados.Append(user.Nome)
            End If
        Next

        ' Se o tamanho da string passar de 30 posições
        ' acrescenta-se os 3 pontinhos no final
        If nomesFormatados.Length > 30 Then
            nomesFormatados.Remove(29, nomesFormatados.Length - 29)
            nomesFormatados.Append("...")
        End If

        ' Retorna a string formatada
        Return nomesFormatados.ToString()

    End Function

    ''' <summary>
    ''' Método que carrega o GridView com as mensagens
    ''' </summary>
    Public Sub CarregarGridMensagens()

        ' Declara os objetos
        Dim objMensagem As Mensagem
        Dim objLogin As Login

        Try
            ' Instancia os objetos
            objMensagem = New Mensagem
            objLogin = New Login

            ' Atribui a fonte de dados para o DataSource do GridView
            gdvMensagensRecebidas.DataSource = objMensagem.SelecionarRecebidas(objLogin.Matricula)
            ' Executa o método DataBind para carregar o controle com os dados
            gdvMensagensRecebidas.DataBind()

        Catch ex As Exception
            Me.ErroCarregarGrid()
        End Try

        ' Executa o método de paginação do GridView
        Me.ControlePaginacao()

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
        If CBool(gdvMensagensRecebidas.PageIndex + 1 And gdvMensagensRecebidas.PageCount) Then
            lnkProxima.Visible = False
        End If
        If gdvMensagensRecebidas.PageIndex = 0 Then
            lnkAnterior.Visible = False
        End If
        If gdvMensagensRecebidas.PageCount = 0 Then
            pnlPaginacao.Visible = False
        Else
            pnlPaginacao.Visible = True
        End If

        ' Atribui na label a quantidade de páginas que o GridView possui
        lblTotalPag.Text = gdvMensagensRecebidas.PageCount.ToString.Trim
        ' Atribui na label a página atual
        lblPagAtual.Text = CStr(gdvMensagensRecebidas.PageIndex + 1)

    End Sub

    ''' <summary>
    ''' Método para ir para a página anterior
    ''' </summary>
    Private Sub VoltarPagina()
        ' Diminui uma página
        gdvMensagensRecebidas.PageIndex -= 1
        ' Recarrega o GridView
        Me.CarregarGridMensagens()
    End Sub

    ''' <summary>
    ''' Método para ir para a próxima página
    ''' </summary>
    Private Sub AvancarPagina()
        ' Aumenta uma página
        gdvMensagensRecebidas.PageIndex += 1
        ' Recarrega o GridView
        Me.CarregarGridMensagens()
    End Sub

    ''' <summary>
    ''' Método executado quando ocorre um erro de carregamento do grid
    ''' </summary>
    Private Sub ErroCarregarGrid()
        divAviso.Visible = True
    End Sub

    ''' <summary>
    ''' Redireciona para a página de visualizar mensagem
    ''' </summary>
    ''' <param name="codigo">Código da mensagem</param>
    ''' <param name="tipo">Tipo da mensagem</param>
    Private Sub RedirecionaVisualizaMensagem(ByVal codigo As String, ByVal tipo As String)

        ' Limpa a sessão
        Session("codigoMensagem") = String.Empty
        Session("tipoMensagem") = String.Empty

        ' Atribui o valor para a sessão
        Session("codigoMensagem") = codigo
        Session("tipoMensagem") = tipo

        ' Redireciona para a página de visualizar a mensagem
        Response.Redirect(My.Resources.UrlMaps.VisualizarMensagem)

    End Sub

#End Region

End Class