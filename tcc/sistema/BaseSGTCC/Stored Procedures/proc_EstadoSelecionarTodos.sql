-- =================================================================
-- Nome.........: proc_EstadoSelecionarTodos
-- Objetivo.....: Seleciona os estados cadastrados
-- =================================================================
DROP PROCEDURE [dbo].[proc_EstadoSelecionarTodos]
GO

CREATE PROCEDURE [dbo].[proc_EstadoSelecionarTodos]
AS

	-- Processo de busca
	SELECT [EST].[codigoEstado] as 'codigoEstado',
		   [EST].[nomeEstado]   as 'nomeEstado',
           [EST].[siglaEstado]  as 'siglaEstado'
      FROM [dbo].[tbEstado] [EST]
  ORDER BY [nomeEstado] ASC

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_EstadoSelecionarTodos]
GO
