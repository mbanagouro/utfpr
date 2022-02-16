-- =================================================================
-- Nome.........: proc_TccAlunoOrientadorSelecionar
-- Objetivo.....: 
-- =================================================================
DROP PROCEDURE [dbo].[proc_SelecionarTodosProfessores]
GO

CREATE PROCEDURE [dbo].[proc_SelecionarTodosProfessores]
AS
    -- Selecionar todos os usuários do tipo 4 e 3 (Professores e Coordenador).
	SELECT [matriculaUsuario],
		   [nomeUsuario]
	  FROM [dbo].[tbUsuario]
	 WHERE [tipoUsuario] IN (3, 4)
	ORDER BY [nomeUsuario]

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_SelecionarTodosProfessores] 
GO
