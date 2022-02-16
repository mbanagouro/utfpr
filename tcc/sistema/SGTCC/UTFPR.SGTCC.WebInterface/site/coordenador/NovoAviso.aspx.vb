Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: NovoAviso                                                       <BR/>
''' Objetivo.....: Code-Behind da página de cadastro de novo aviso.                <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class NovoAviso
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Evento do click do botão cadastrar
    ''' </summary>
    ''' <param name="sender">Objeto que contém informações sobre o disparador do evento</param>
    ''' <param name="e">Objeto que contém as informações sobre o evento</param>
    Protected Sub btnCadastrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCadastrar.Click
        Me.CadastrarNovoAviso()
    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' Método para cadastrar um novo aviso
    ''' </summary>
    Private Sub CadastrarNovoAviso()

        ' Declara os objetos
        Dim objAviso As Aviso
        Dim objLogin As Login

        Try
            ' Instancia os objetos
            objAviso = New Aviso
            objLogin = New Login

            ' Executa o método para cadastrar um novo aviso
            objAviso.CadastrarAviso(objLogin.Matricula, _
                                    Me.txtTitulo.Text.Trim, _
                                    Me.editor.Content.ToString.Trim)

            ' Envia mensagem de sucesso para a tela
            Me.lblMensagem.Text = "Aviso cadastrado com sucesso!"
            ' Executa o método para limpar os campos na tela
            Me.LimpaCampos()

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' Método que limpa os campos da tela
    ''' </summary>
    Private Sub LimpaCampos()
        ' Inicializa os campos de entrada
        'Me.txtConteudo.Value = String.Empty
        Me.txtTitulo.Text = String.Empty
    End Sub

#End Region

End Class