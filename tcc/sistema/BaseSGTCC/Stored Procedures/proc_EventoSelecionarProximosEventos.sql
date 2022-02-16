-- =================================================================
-- Nome.........: proc_EventoSelecionarProximosEventos
-- Objetivo.....: Seleciona os próximos eventos após a data atual
-- =================================================================
DROP PROCEDURE [dbo].[proc_EventoSelecionarProximosEventos]
GO

CREATE PROCEDURE [dbo].[proc_EventoSelecionarProximosEventos]
(
	@matriculaUsuario INT
)

AS

	-- Processo de busca
	SELECT [AGE].[nomeEvento]   as 'nomeEvento',
		   [AGE].[dataEvento]   as 'dataEvento'
      FROM [dbo].[tbAgenda] [AGE]
     WHERE [AGE].[FK_matriculaUsuario] = @matriculaUsuario AND
           [AGE].[dataEvento] >= GetDate()
  ORDER BY [AGE].[dataEvento] ASC;

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_EventoSelecionarProximosEventos] 757250
GO
