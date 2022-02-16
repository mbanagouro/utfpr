Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Calendario.                                                     <BR/>
''' Objetivo.....: Code-Behind do User Control de calendrário.                     <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Calendario
    Inherits System.Web.UI.UserControl

#Region "Propriedades"

    ''' <summary>
    ''' Coleção de Evento
    ''' </summary>
    Private _lstEventos As List(Of Evento)
    Public Property Eventos() As List(Of Evento)
        Get
            Return Me._lstEventos
        End Get
        Set(ByVal value As List(Of Evento))
            Me._lstEventos = value
        End Set
    End Property

#End Region

#Region "Eventos"

    ''' <summary>
    ''' Tratamento da renderização do calendário
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub calEventos_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles calEventos.DayRender

        Try

            e.Cell.ToolTip = "Não há evento cadastrado!"
            e.Cell.Attributes("onClick") = e.SelectUrl

            If Not Me.Eventos Is Nothing AndAlso Not Me.Eventos.Count = 0 Then

                For Each evento As Evento In Me.Eventos
                    If e.Day.Date = evento.Data Then
                        e.Cell.CssClass = "cssMarcaEvento"
                        e.Cell.ToolTip = evento.NomeEvento
                    End If
                Next

            End If

        Catch ex As Exception
            Log.GravarLog("User Control Calendario", "calEventos_DayRender", ex.Message, TipoErro.Critico)
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Tratamento da seleção do evento no calendário
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub calEventos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calEventos.SelectionChanged
        Me.RedirecionaEventoAgenda()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Redireciona para a página de Evento
    ''' </summary>
    Public Sub RedirecionaEventoAgenda()
        ' Limpa a sessão
        Session("dataEvento") = String.Empty
        ' Atribui o valor selecionado
        Session("dataEvento") = calEventos.SelectedDate.Date
        ' Redireciona para a página de eventos
        Response.Redirect(My.Resources.UrlMaps.EventoAgenda)
    End Sub

#End Region

End Class