
Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: DuplicateKeyException.                                          <BR/>
    ''' Objetivo.....: Classe de exceção para registro duplicado na base.              <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class DuplicateKeyException
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
