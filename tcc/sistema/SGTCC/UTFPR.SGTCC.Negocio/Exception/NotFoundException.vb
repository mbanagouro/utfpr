
Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: NotFoundException.                                              <BR/>
    ''' Objetivo.....: Classe de exceção para registro não encontrado na base.         <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class NotFoundException
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


