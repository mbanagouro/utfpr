Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Agenda.                                                         <BR/>
''' Objetivo.....: Code-Behind da página da agenda pessoal.                        <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Agenda
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Executa o método para carregar os eventos
        If Not Page.IsPostBack Then
            ' Executa o método que irá carregar os eventos
            Me.CarregarEventos()
        End If

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que irá carregar os eventos no calendário
    ''' </summary>
    Private Sub CarregarEventos()

        ' Declara os objetos
        Dim objEvento As Evento
        Dim objLogin As Login

        Try

            ' Instancia os objetos
            objLogin = New Login
            objEvento = New Evento

            Me.calAgenda.Eventos = objEvento.SelecionarEventos(objLogin.Matricula)

        Catch ex As Exception
            lblMensagem.Text = "Falha ao carregar os eventos da agenda"
        End Try

    End Sub

#End Region

End Class