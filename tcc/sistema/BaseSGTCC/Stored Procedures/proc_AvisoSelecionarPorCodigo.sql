-- =================================================================
-- Nome.........: proc_AvisoSelecionarPorCodigo
-- Objetivo.....: Seleciona um aviso pelo código
-- =================================================================
DROP PROCEDURE [dbo].[proc_AvisoSelecionarPorCodigo]
GO

CREATE PROCEDURE [dbo].[proc_AvisoSelecionarPorCodigo]
(
    @codigoAviso INT
)

AS

	SELECT [USU].[nomeUsuario]         as 'nomeUsuario',
           [AVI].[FK_matriculaUsuario] as 'matriculaUsuario',
           [AVI].[codigoAviso]         as 'codigoAviso',
           [AVI].[tituloAviso]         as 'tituloAviso',
           [AVI].[conteudoAviso]       as 'conteudoAviso', 
           [AVI].[dataPublicacaoAviso] as 'dataPublicacaoAviso'
      FROM [dbo].[tbAviso]   [AVI], 
           [dbo].[tbUsuario] [USU]
     WHERE [codigoAviso]            = @codigoAviso AND
           [USU].[matriculaUsuario] = [AVI].[FK_matriculaUsuario];

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_AvisoSelecionarPorCodigo] 
GO