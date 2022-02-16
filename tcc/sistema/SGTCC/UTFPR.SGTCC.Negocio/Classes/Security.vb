Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography

Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Security.                                                       <BR/>
    ''' Objetivo.....: Provê métodos para a segurança da aplicação.                    <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    ''' <remarks>Esta classe não pode ser instanciada</remarks>
    Public NotInheritable Class Security


#Region "Atributos"

        Private Shared _key As String = My.Resources.Chave

#End Region

#Region "Propriedades"

#End Region

#Region "Construtores"

        ''' <summary>
        ''' Essa classe possui um construtor privado pois ela não deve ser instanciada.
        ''' </summary>
        Private Sub New()
            MyBase.New()
        End Sub

#End Region

#Region "Métodos"

        ''' <summary>
        ''' Função Responsável por Cifrar a sua String
        ''' </summary>
        ''' <param name="vstrTextToBeEncrypted">String a ser cifrada</param>
        ''' <returns>String cifrada</returns>
        ''' <remarks>
        ''' Use da seguinte forma: Cifrar("Palavra")
        ''' </remarks>
        Public Shared Function Cifrar(ByVal vstrTextToBeEncrypted As String) As String

            Dim vstrEncryptionKey As String = _key
            Dim bytValue() As Byte
            Dim bytKey() As Byte
            Dim bytEncoded() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
            Dim intLength As Integer
            Dim intRemaining As Integer
            Dim objMemoryStream As New MemoryStream
            Dim objCryptoStream As CryptoStream
            Dim objRijndaelManaged As RijndaelManaged


            ' ***************************************************************
            ' ****** Descarta todos os caracteres nulos da palavra a ser cifrada              
            ' ***************************************************************

            vstrTextToBeEncrypted = TiraCaracteresNulos(vstrTextToBeEncrypted)

            ' ***************************************************************
            ' ****** O valor deve estar dentro da tabela ASCII (i.e., no DBCS chars)    
            ' ***************************************************************

            bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

            intLength = Len(vstrEncryptionKey)

            ' ****************************************************************
            ' ****** A chave cifrada será de 256 bits long (32 bytes)                             
            ' ****** Se for maior que 32 bytes então será truncado.                               
            ' ****** Se for menor que 32 bytes será alocado.                                        
            ' ****** Usando upper-case Xs.                                                                  
            ' ****************************************************************

            If intLength >= 32 Then
                vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
            Else
                intLength = Len(vstrEncryptionKey)
                intRemaining = 32 - intLength
                vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
            End If

            bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

            objRijndaelManaged = New RijndaelManaged

            ' **************************************************************
            ' ****** Cria o valor a ser crifrado e depois escreve                                  
            ' ****** Convertido em uma disposição do byte                                       
            ' **************************************************************

            Try

                objCryptoStream = New CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
                objCryptoStream.Write(bytValue, 0, bytValue.Length)

                objCryptoStream.FlushFinalBlock()

                bytEncoded = objMemoryStream.ToArray
                objMemoryStream.Close()
                objCryptoStream.Close()
            Catch

            End Try

            ' **************************************************************
            ' ****** Retorna o valor cifrado (convertido de byte para base64)           
            ' **************************************************************

            Return Convert.ToBase64String(bytEncoded)

        End Function

        ''' <summary>
        ''' Função Responsável por Decifrar a sua String Cifrada
        ''' </summary>
        ''' <param name="vstrStringToBeDecrypted">String a ser decifrada</param>
        ''' <returns>String decifrada</returns>
        ''' <remarks>
        ''' Use da seguinte forma: Decifrar("Palavra") 
        ''' </remarks>
        Public Shared Function Decifrar(ByVal vstrStringToBeDecrypted As String) As String

            Dim vstrDecryptionKey As String = _key

            Dim bytDataToBeDecrypted() As Byte
            Dim bytTemp() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
            Dim objRijndaelManaged As New RijndaelManaged
            Dim objMemoryStream As MemoryStream
            Dim objCryptoStream As CryptoStream
            Dim bytDecryptionKey() As Byte

            Dim intLength As Integer
            Dim intRemaining As Integer
            Dim intCtr As Integer
            Dim strReturnString As String = String.Empty
            Dim achrCharacterArray() As Char
            Dim intIndex As Integer

            ' ***************************************************************
            ' ****** Convert base64 cifrada para byte array                                
            ' ****** Convert base64 cifrada para byte array                                
            ' ***************************************************************

            bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

            ' ***************************************************************
            ' ****** A chave cifrada sera de 256 bits long (32 bytes)                           
            ' ****** Se for maior que 32 bytes então será truncado.                              
            ' ****** Se for menor que 32 bytes será alocado.                                       
            ' ****** Usando upper-case Xs.                                                              
            ' ***************************************************************

            intLength = Len(vstrDecryptionKey)

            If intLength >= 32 Then
                vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
            Else
                intLength = Len(vstrDecryptionKey)
                intRemaining = 32 - intLength
                vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
            End If

            bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

            ReDim bytTemp(bytDataToBeDecrypted.Length)

            objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

            ' ***************************************************************
            ' ****** Escrever o valor decifrado depois que é convertido                      
            ' ***************************************************************

            Try

                objCryptoStream = New CryptoStream(objMemoryStream, _
                objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
                CryptoStreamMode.Read)

                objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

                objCryptoStream.FlushFinalBlock()
                objMemoryStream.Close()
                objCryptoStream.Close()

            Catch

            End Try

            ' ***************************************************************
            ' ****** Retorna o valor decifrado                                    
            ' ***************************************************************

            Return TiraCaracteresNulos(Encoding.ASCII.GetString(bytTemp))

        End Function

        ''' <summary>
        ''' Função responsável por tirar os espaços em branco da variável a ser cifrada
        ''' </summary>
        ''' <param name="vstrStringWithNulls">String com os espaços a ser retirado</param>
        ''' <returns>String sem os espaços</returns>
        ''' <remarks>Esta função é chamada internamente </remarks>
        Private Shared Function TiraCaracteresNulos(ByVal vstrStringWithNulls As String) As String

            Dim intPosition As Integer
            Dim strStringWithOutNulls As String

            intPosition = 1
            strStringWithOutNulls = vstrStringWithNulls

            Do While intPosition > 0
                intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

                If intPosition > 0 Then
                    strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                    Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
                End If

                If intPosition > strStringWithOutNulls.Length Then
                    Exit Do
                End If
            Loop

            Return strStringWithOutNulls

        End Function

#End Region

    End Class

End Namespace


