-- =================================================================
-- Nome.........: proc_EventoSelecionarPorData
-- Objetivo.....: Seleciona um evento pela data
-- =================================================================
DROP PROCEDURE [dbo].[proc_EventoSelecionarPorData]
GO

CREATE PROCEDURE [dbo].[proc_EventoSelecionarPorData]
(
	@matriculaUsuario INT,
    @dataEvento       DATETIME
)

AS

	-- Processo de busca
	SELECT [AGE].[FK_matriculaUsuario]   as 'matriculaUsuario',
		   [AGE].[nomeEvento]            as 'nomeEvento',
		   [AGE].[descricaoEvento]       as 'descricaoEvento',
		   [AGE].[dataEvento]            as 'dataEvento'
      FROM [dbo].[tbAgenda] [AGE]
     WHERE [AGE].[FK_matriculaUsuario] = @matriculaUsuario    AND
           [AGE].[dataEvento]          = @dataEvento;

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_EventoSelecionarPorData]
GO