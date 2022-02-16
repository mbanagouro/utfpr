Imports UTFPR.SGTCC.Negocio.ModuloAP

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: Menu.                                                           <BR/>
''' Objetivo.....: Code-Behind do UserControl menu do sistema.                     <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class Menu
    Inherits System.Web.UI.UserControl

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.ExibeMenu()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHome.Click
        Response.Redirect(My.Resources.UrlMaps.Home)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkMateria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMateria.Click
        Response.Redirect(My.Resources.UrlMaps.Materia)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkAgenda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAgenda.Click
        Response.Redirect(My.Resources.UrlMaps.Agenda)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkCorreio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCorreio.Click
        Response.Redirect(My.Resources.UrlMaps.Correio)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkArquivos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkArquivos.Click
        Response.Redirect(My.Resources.UrlMaps.GerenciarArquivos)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkAvisos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAvisos.Click
        Response.Redirect(My.Resources.UrlMaps.GerenciarAvisos)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkConfig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkConfig.Click
        Response.Redirect(My.Resources.UrlMaps.Configuracoes)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkDownloads_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDownloads.Click
        Response.Redirect(My.Resources.UrlMaps.Downloads)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkTcc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTcc.Click
        Response.Redirect(My.Resources.UrlMaps.mainTCC)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Private Sub lnkUsuarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkUsuarios.Click
        Response.Redirect(My.Resources.UrlMaps.GerenciarUsuarios)
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método que exibe o menu conforme regra do usuário
    ''' </summary>
    Private Sub ExibeMenu()

        ' Declara os objetos
        Dim objLogin As Login

        Try
            ' Instancia os objetos
            objLogin = New Login

            If objLogin.IsPermissao("Aluno") OrElse _
            objLogin.IsPermissao("Professor") OrElse _
            objLogin.IsPermissao("Coordenador") Then
                menuAgenda.Visible = True
                menuCorreio.Visible = True
            End If

            If objLogin.IsPermissao("Coordenador") OrElse _
            objLogin.IsPermissao("Administrador") Then
                menuTcc.Visible = True
                menuAvisos.Visible = True
                menuUsuarios.Visible = True
                menuArquivos.Visible = True
            End If

            If objLogin.IsPermissao("Administrador") Then
                menuConfig.Visible = True
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class