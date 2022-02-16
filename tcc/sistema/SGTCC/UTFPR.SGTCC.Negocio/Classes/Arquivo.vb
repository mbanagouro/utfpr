Imports System.IO
Imports System.Collections.Generic

Namespace ModuloAP

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: Arquivo.                                                        <BR/>
    ''' Objetivo.....: Classe responsável pela manipulação dos arquivos.               <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class Arquivo

#Region "Atributos"

#End Region

#Region "Propriedades"

        ''' <summary>
        ''' Nome do arquivo
        ''' </summary>
        Private _nome As String
        Public Property Nome() As String
            Get
                Return _nome
            End Get
            Set(ByVal value As String)
                _nome = value
            End Set
        End Property

        ''' <summary>
        ''' Caminho físico do arquivo
        ''' </summary>
        Private _caminhoFisico As String
        Public Property CaminhoFisico() As String
            Get
                Return _caminhoFisico
            End Get
            Set(ByVal value As String)
                _caminhoFisico = value
            End Set
        End Property

        ''' <summary>
        ''' Tipo do Arquivo
        ''' </summary>
        Private _tipoItem As TipoArquivo
        Public Property TipoItem() As TipoArquivo
            Get
                Return _tipoItem
            End Get
            Set(ByVal value As TipoArquivo)
                _tipoItem = value
            End Set
        End Property

        ''' <summary>
        ''' Extensão do arquivo
        ''' </summary>
        Private _extensao As String
        Public Property Extensao() As String
            Get
                Return _extensao
            End Get
            Set(ByVal value As String)
                _extensao = value
            End Set
        End Property

        ''' <summary>
        ''' Tamanho do arquivo
        ''' </summary>
        Private _tamanhoKB As Integer
        Public Property TamanhoKB() As Integer
            Get
                Return _tamanhoKB
            End Get
            Set(ByVal value As Integer)
                _tamanhoKB = value
            End Set
        End Property

        ''' <summary>
        ''' Data de Criação do arquivo
        ''' </summary>
        Private _dataCriacao As DateTime
        Public Property DataCriacao() As DateTime
            Get
                Return _dataCriacao
            End Get
            Set(ByVal value As DateTime)
                _dataCriacao = value
            End Set
        End Property

        ''' <summary>
        ''' Somente leitura
        ''' </summary>
        Private _somenteLeitura As Boolean
        Public Property SomenteLeitura() As Boolean
            Get
                Return _somenteLeitura
            End Get
            Set(ByVal value As Boolean)
                _somenteLeitura = value
            End Set
        End Property

        ''' <summary>
        ''' Ícone do arquivo
        ''' </summary>
        Private _icone As String
        Public Property Icone() As String
            Get
                Return _icone
            End Get
            Set(ByVal value As String)
                _icone = value
            End Set
        End Property

#End Region

#Region "Construtor"

        ''' <summary>
        ''' Construtor Padrão
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub

#End Region

#Region "Métodos"

        ''' <summary>
        ''' Método que recupera os arquivos de um determinado diretório
        ''' </summary>
        ''' <param name="diretorio">Diretório que deseja-se obter os arquivos</param>
        ''' <returns>Lista de Arquivos</returns>
        Public Overloads Shared Function ObterArquivos(ByVal diretorio As String) As List(Of FileInfo)

            ' Instancia uma coleção de objetos FileInfo
            Dim lstArquivos As New List(Of FileInfo)

            ' Obtém um array com todos os arquivos do diretório informado
            Dim arquivos() As String = Directory.GetFiles(diretorio)

            ' Percorre o array de arquivos
            For Each arquivo As String In arquivos
                ' Adiciona um novo objeto FileInfo a coleção
                lstArquivos.Add(New FileInfo(arquivo))
            Next

            ' Retorna a coleção de arquivos
            Return lstArquivos

        End Function

        ''' <summary>
        ''' Método que recupera os arquivos de um determinado diretório
        ''' </summary>
        ''' <param name="diretorio">Diretório que deseja-se obter os arquivos</param>
        ''' <param name="padraoBusca"></param>
        ''' <param name="opcaoBusca">Enumerador da opção de pesquisa</param>
        ''' <returns>Lista de Arquivos</returns>
        Public Overloads Shared Function ObterArquivos(ByVal diretorio As String, _
                                                       ByVal padraoBusca As String, _
                                                       ByVal opcaoBusca As SearchOption) As List(Of FileInfo)

            ' Instancia uma coleção de objetos FileInfo
            Dim lstArquivos As New List(Of FileInfo)

            ' Obtém um array com todos os arquivos do diretório informado
            Dim arquivos() As String = Directory.GetFiles(diretorio, padraoBusca, opcaoBusca)

            ' Percorre o array de arquivos
            For Each arquivo As String In arquivos
                ' Adiciona um novo objeto FileInfo a coleção
                lstArquivos.Add(New FileInfo(arquivo))
            Next

            ' Retorna a coleção de arquivos
            Return lstArquivos

        End Function

        ''' <summary>
        ''' Método que recupera os diretórios de um determinado diretório
        ''' </summary>
        ''' <param name="diretorio">Diretório que deseja-se obter os arquivos</param>
        ''' <returns>Lista de diretórios</returns>
        Public Shared Function ObterDiretorios(ByVal diretorio As String) As List(Of DirectoryInfo)

            ' Instancia uma coleção de objetos FileInfo
            Dim lstDiretorios As New List(Of DirectoryInfo)

            ' Obtém um array com todos os diretórios do diretório informado
            Dim pastas() As String = Directory.GetDirectories(diretorio)

            ' Percorre o array de diretórios
            For Each pasta As String In pastas
                ' Adiciona um novo objeto DirectoryInfo a coleção
                lstDiretorios.Add(New DirectoryInfo(pasta))
            Next

            ' Retorna a coleção de diretórios
            Return lstDiretorios

        End Function

#End Region

    End Class

End Namespace


