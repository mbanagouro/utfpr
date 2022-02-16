
Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: ValidaException.                                                <BR/>
    ''' Objetivo.....: Classe de exceção para validação.                               <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class ValidaException
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
