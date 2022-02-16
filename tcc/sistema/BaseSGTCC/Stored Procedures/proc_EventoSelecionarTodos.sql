-- =================================================================
-- Nome.........: proc_EventoSelecionarTodos
-- Objetivo.....: Seleciona os eventos de um determinado usuário
-- =================================================================
DROP PROCEDURE [dbo].[proc_EventoSelecionarTodos]
GO

CREATE PROCEDURE [dbo].[proc_EventoSelecionarTodos]
(
	@matriculaUsuario INT
)

AS

	-- Processo de busca
	SELECT [AGE].[nomeEvento] as 'nomeEvento',
		   [AGE].[dataEvento] as 'dataEvento'
      FROM [dbo].[tbAgenda] [AGE]
     WHERE [AGE].[FK_matriculaUsuario] = @matriculaUsuario;

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_EventoSelecionarTodos] 757250
GO