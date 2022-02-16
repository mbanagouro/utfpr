Imports System.Web.Configuration

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Home                                                            <BR/>
''' Objetivo.....: Code-Behind da página principal.                                <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Home
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CarregarProfessorResp()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CarregarProfessorResp()

        If Not Config.NomeCoordenadorAtual = String.Empty Then
            lblNomeCoordenador.Text = Config.NomeCoordenadorAtual
        Else
            lblNomeCoordenador.Text = "Sem coordenador atual"
        End If

        If Not Config.EmailCoordenadorAtual = String.Empty Then
            Me.hlkMailCoordenador.HRef = "mailto: " & Config.EmailCoordenadorAtual
        Else
            Me.hlkMailCoordenador.HRef = String.Empty
        End If

    End Sub

#End Region

End Class