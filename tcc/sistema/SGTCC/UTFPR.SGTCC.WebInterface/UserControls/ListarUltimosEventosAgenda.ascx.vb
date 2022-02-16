Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: ListarUltimosEventosAgenda.                                     <BR/>
''' Objetivo.....: Code-Behind do UserControl que Lista                            <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class ListarUltimosEventosAgenda
    Inherits System.Web.UI.UserControl

#Region "Eventos"

    ''' <summary>
    ''' Evento do comando enviado a grid
    ''' </summary>
    ''' <param name="source">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub rptEventos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptEventos.ItemCommand

        If e.CommandName = "Visualizar" Then
            Me.RedirecionaEventoAgenda(e.CommandArgument.ToString.Trim)
        End If

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega a grid com os eventos
    ''' </summary>
    Public Sub CarregarEventos()

        ' Declara os objetos
        Dim objLogin As Login
        Dim objEvento As Evento
        Dim lstEvento As List(Of Evento)

        Try

            ' Instancia os objetos
            objLogin = New Login
            objEvento = New Evento

            ' Obtém a lista de eventos
            lstEvento = objEvento.SelecionarProximosEventos(objLogin.Matricula)

            If lstEvento.Count > 0 Then
                rptEventos.DataSource = lstEvento
                rptEventos.DataBind()
            Else
                divAviso.Visible = True
            End If

        Catch ex As Exception
            lblMsgGrid.Text = "Falha ao carregar os eventos recentes"
            divAviso.Visible = True
        End Try

    End Sub

    ''' <summary>
    ''' Redireciona para a página de Evento
    ''' </summary>
    Public Sub RedirecionaEventoAgenda(ByVal dataEvento As String)
        ' Limpa a sessão
        Session("dataEvento") = String.Empty
        ' Atribui o valor selecionado
        Session("dataEvento") = dataEvento
        ' Redireciona para a página de eventos
        Response.Redirect(My.Resources.UrlMaps.EventoAgenda)
    End Sub

#End Region

End Class