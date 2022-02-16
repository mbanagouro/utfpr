-- =================================================================
-- Nome.........: proc_AvisoSelecionarUltimos
-- Objetivo.....: Seleciona os últimos avisos cadastrados
-- =================================================================
DROP PROCEDURE [dbo].[proc_AvisoSelecionarUltimos]
GO

CREATE PROCEDURE [dbo].[proc_AvisoSelecionarUltimos]

AS

	-- Processo de Busca
	SELECT TOP 5
           [USU].[nomeUsuario]         as 'nomeUsuario',
           [AVI].[codigoAviso]         as 'codigoAviso',
		   [AVI].[tituloAviso]         as 'tituloAviso',
		   [AVI].[conteudoAviso]       as 'conteudoAviso',
		   [AVI].[dataPublicacaoAviso] as 'dataPublicacaoAviso'
	  FROM [dbo].[tbAviso]   [AVI],
		   [dbo].[tbUsuario] [USU]
  WHERE [USU].[matriculaUsuario] = [AVI].[FK_matriculaUsuario]
  ORDER BY [AVI].[dataPublicacaoAviso] DESC;

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_AvisoSelecionarUltimos] 
GO