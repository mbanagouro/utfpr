Imports UTFPR.SGTCC.Negocio.ModuloAP
Imports UTFPR.SGTCC.Negocio.Comum
Imports System.Web.Configuration
Imports System.Configuration

''' <summary>
''' ****************************************************************************** <BR/>
''' Nome.........: NovoDescricaoNota                                               <BR/>
''' Objetivo.....: Cadastra uma nova descrição para uma nota                       <BR/>
''' ****************************************************************************** <BR/>
''' </summary>
Partial Public Class DefinirCoordenador
    Inherits System.Web.UI.Page

#Region "Eventos"

    ''' <summary>
    ''' Tratamento inicial da página
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Try

                CarregarNomeCoordenadoratual()
                CarregarListaProfessores()

            Catch ex As Exception
                lblMensagem.Text = ex.Message
            End Try

        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnCadastrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCadastrar.Click

        Try

            Me.AtualizarCoordenador()
            Me.CarregarNomeCoordenadoratual()
            Me.CarregarListaProfessores()

        Catch ex As Exception
            lblMensagem.Text = ex.Message
        End Try

    End Sub

#End Region

#Region "Métodos Privados"

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CarregarNomeCoordenadoratual()

        Dim objProfessor As Professor

        Try

            objProfessor = New Professor

            objProfessor = objProfessor.SelecionarCoordenadorAtual()

            If Not objProfessor Is Nothing Then
                lblCoordenadorAtual.Text = objProfessor.Nome
            Else
                lblCoordenadorAtual.Text = "Não há nenhum coordenador cadastrado."
            End If

        Catch ex As Exception
            Throw New Exception("Falha ao carregar o nome do coordenador atual!")
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CarregarListaProfessores()

        Try
            Dim objProfessor As New Professor
            Dim objDataset As DataSet

            objDataset = objProfessor.SelecionarProfessores()

            droplistProfessores.DataValueField = "matriculaUsuario"
            droplistProfessores.DataTextField = "nomeUsuario"
            droplistProfessores.DataSource = objDataset.Tables(0)
            droplistProfessores.DataBind()

            droplistProfessores.Items.Insert(0, (New ListItem("Selecione o Professor -----", "0")))

        Catch ex As Exception
            Throw New Exception("Falha ao carregar o combo de professores!")
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub AtualizarCoordenador()

        Try
            Dim objProfessor As New Professor

            objProfessor.AtualizarCoordenador(CInt(droplistProfessores.SelectedValue))

            objProfessor = objProfessor.SelecionarCoordenadorAtual()

            Me.AtualizaArqConfiguracao(objProfessor)

            lblMensagem.Text = "Coordenador atualizado com sucesso."

        Catch ex As Exception
            Throw New Exception("Falha ao atualizar o coordenador atual!")
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objProfessor"></param>
    Private Sub AtualizaArqConfiguracao(ByVal objProfessor As Professor)

        Try
            Config.GravaCoordenadorAtual(objProfessor.Nome, objProfessor.Email)
        Catch ex As Exception
            Log.GravarLog("DefinirCoordenador", "AtualizaArqConfiguracao", ex.Message, TipoErro.Inesperado)
            Throw ex
        End Try

    End Sub

#End Region

End Class