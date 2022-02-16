-- =================================================================
-- Nome.........: proc_CidadeSelecionarPorEstado
-- Objetivo.....: Seleciona as cidades de um determinado estado
-- =================================================================
DROP PROCEDURE [dbo].[proc_CidadeSelecionarPorEstado]
GO

CREATE PROCEDURE [dbo].[proc_CidadeSelecionarPorEstado]
(
	@FK_codigoEstado SMALLINT
)

AS

	-- Processo de busca
	SELECT [CID].[codigoCidade] as 'codigoCidade',
		   [CID].[nomeCidade]   as 'nomeCidade'
      FROM [dbo].[tbCidade] [CID]
	 WHERE [FK_codigoEstado] = @FK_codigoEstado
  ORDER BY [nomeCidade] ASC

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_CidadeSelecionarPorEstado] 1
GO