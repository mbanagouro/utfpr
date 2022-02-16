Imports UTFPR.SGTCC.Negocio.ModuloAP

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: ListarUltimosAvisos.                                            <BR/>
''' Objetivo.....: Code-Behind do UserControl para listar os últimos avisos.       <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class ListarUltimosAvisos
    Inherits System.Web.UI.UserControl

#Region "Eventos"

    ''' <summary>
    ''' Evento do comando enviado a grid
    ''' </summary>
    ''' <param name="source">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub rptAvisos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAvisos.ItemCommand

        Try

            If e.CommandName = "Visualizar" Then
                Me.VisualizaAviso(e.CommandArgument.ToString.Trim)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega a grid com os avisos
    ''' </summary>
    Protected Sub CarregarAvisos()

        ' Declara os objetos
        Dim objAviso As Aviso
        Dim lstAvisos As List(Of Aviso)

        Try
            ' Instancia os objetos
            objAviso = New Aviso
            ' Busca os avisos
            lstAvisos = objAviso.SelecionarUltimosAvisos()

            If lstAvisos.Count > 0 Then
                ' Popula o controle Repeater com os últimos avisos
                rptAvisos.DataSource = lstAvisos
                ' Carrega o controle com o método DataBind
                rptAvisos.DataBind()
            Else
                divAviso.Visible = True
            End If

        Catch ex As Exception
            lblMsgGrid.Text = "Falha ao carregar os avisos"
            divAviso.Visible = True
        End Try

    End Sub

    ''' <summary>
    ''' Método que redireciona para a página de Aviso
    ''' </summary>
    ''' <param name="codigoAviso">Código do aviso</param>
    Private Sub VisualizaAviso(ByVal codigoAviso As String)
        Session("codigoAviso") = String.Empty
        Session("codigoAviso") = codigoAviso
        Response.Redirect(My.Resources.UrlMaps.VisualizarAviso)
    End Sub

#End Region

End Class