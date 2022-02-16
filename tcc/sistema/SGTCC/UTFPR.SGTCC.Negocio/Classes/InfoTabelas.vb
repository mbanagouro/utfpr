
Namespace Comum

    ''' <summary>
    ''' ****************************************************************************** <BR/>
    ''' Nome.........: InfoTabelas.                                                    <BR/>
    ''' Objetivo.....: Classe com a constante dos nomes das tabelas.                   <BR/>
    ''' ****************************************************************************** <BR/>
    ''' </summary>
    Public Class InfoTabelas

#Region "Campos da Tabela tbBancasProfessores"

        Public Const BANPROF_CODIGOTCC As String = "FK_codigoTcc"
        Public Const BANPROF_TIPO As String = "FK_tipoBanca"
        Public Const BANPROF_MATRICULA As String = "FK_matriculaUsuario"

#End Region

#Region "Campos da Tabela Banca"

        Public Const BANCA_CODIGOTCC As String = "FK_codigoTcc"
        Public Const BANCA_TIPO As String = "tipoBanca"
        Public Const BANCA_SALA As String = "salaBanca"
        Public Const BANCA_DATA As String = "dataBanca"

#End Region

#Region "Campos da Tabela TCC"

        Public Const TCC_CODIGO As String = "codigoTcc"
        Public Const TCC_TEMA As String = "temaTcc"
        Public Const TCC_STATUS As String = "statusTcc"
        Public Const TCC_DTINI As String = "dataInicioTcc"
        Public Const TCC_DTFIM As String = "dataFinalTcc"
        Public Const TCC_NOTAPROP As String = "notaPropostaTcc"
        Public Const TCC_NOTAFINAL As String = "notaFinalTcc"

#End Region

#Region "Campos da Tabela Agenda"

        Public Const AGE_CODIGO As String = "codigoEvento"
        Public Const AGE_NOME As String = "nomeEvento"
        Public Const AGE_DESCRICAO As String = "descricaoEvento"
        Public Const AGE_DATA As String = "dataEvento"

#End Region

#Region "Campos da Tabela Cidade"

        Public Const EST_CODIGO As String = "codigoEstado"
        Public Const EST_NOME As String = "nomeEstado"

#End Region

#Region "Campos da Tabela Estado"

        Public Const CID_CODIGO As String = "codigoCidade"
        Public Const CID_NOME As String = "nomeCidade"

#End Region

#Region "Campos da Tabela Usuário"

        Public Const USU_MATRICULA As String = "matriculaUsuario"
        Public Const USU_NOME As String = "nomeUsuario"
        Public Const USU_SENHA As String = "senhaUsuario"
        Public Const USU_EMAIL As String = "emailUsuario"
        Public Const USU_TEL As String = "telefoneUsuario"
        Public Const USU_CEL As String = "celularUsuario"
        Public Const USU_STATUS As String = "statusUsuario"
        Public Const USU_TIPO As String = "tipoUsuario"

#End Region

#Region "Campos da Tabela Aviso"

        Public Const AVI_CODIGO As String = "codigoAviso"
        Public Const AVI_TITULO As String = "tituloAviso"
        Public Const AVI_CONTEUDO As String = "conteudoAviso"
        Public Const AVI_DTPUBLICACAO As String = "dataPublicacaoAviso"

#End Region

#Region "Campos da Tabela Mensagem"

        Public Const MEN_CODIGO As String = "codigoMensagem"
        Public Const MEN_ASSUNTO As String = "assuntoMensagem"
        Public Const MEN_CONTEUDO As String = "conteudoMensagem"
        Public Const MEN_PRIORIDADE As String = "prioridadeMensagem"
        Public Const MEN_DATA As String = "dataMensagem"
        Public Const MEN_LIDO As String = "lidoMensagem"

#End Region

    End Class

End Namespace