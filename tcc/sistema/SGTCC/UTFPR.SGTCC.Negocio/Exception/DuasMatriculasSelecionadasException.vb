Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: DuasMatriculasSelecionadas.                                     <BR/>
    ''' Objetivo.....:                                                                 <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class DuasMatriculasSelecionadasException
        Inherits Exception

#Region "Construtor"

        ''' <summary>
        ''' Construtor padrão
        ''' </summary>
        ''' <param name="mensagem">Mensagem</param>
        Public Sub New(ByVal mensagem As String)
            MyBase.New(mensagem)
        End Sub

#End Region

    End Class

End Namespace



