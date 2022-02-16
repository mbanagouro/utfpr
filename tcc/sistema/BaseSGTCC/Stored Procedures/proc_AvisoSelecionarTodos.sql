-- =================================================================
-- Nome.........: proc_AvisoSelecionarTodos
-- Objetivo.....: Seleciona todos os avisos
-- =================================================================
DROP PROCEDURE [dbo].[proc_AvisoSelecionarTodos]
GO

CREATE PROCEDURE [dbo].[proc_AvisoSelecionarTodos]

AS

	SELECT [USU].[nomeUsuario]         as 'nomeUsuario',
           [AVI].[codigoAviso]         as 'codigoAviso',
		   [AVI].[tituloAviso]         as 'tituloAviso',
		   [AVI].[conteudoAviso]       as 'conteudoAviso',
		   [AVI].[dataPublicacaoAviso] as 'dataPublicacaoAviso'
	  FROM [dbo].[tbAviso]   [AVI],
           [dbo].[tbUsuario] [USU]
     WHERE [USU].[matriculaUsuario] = [AVI].[FK_matriculaUsuario]
  ORDER BY [AVI].[dataPublicacaoAviso];

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_AvisoSelecionarTodos] 
GO