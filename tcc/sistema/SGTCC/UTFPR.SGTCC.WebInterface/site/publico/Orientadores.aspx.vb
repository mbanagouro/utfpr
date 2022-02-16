Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum
Imports UTFPR.SGTCC.Negocio.ModuloCA

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Orientadores.                                                   <BR/>
''' Objetivo.....: Code-Behind da página de pesquisa de orientadores.              <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Orientadores
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.CarregaGridOrientadores()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que carrega a grid de orientadores
    ''' </summary>
    Public Sub CarregaGridOrientadores()
        Me.grdSOrientadores.CarregarGridOrientadores()
    End Sub

#End Region

End Class