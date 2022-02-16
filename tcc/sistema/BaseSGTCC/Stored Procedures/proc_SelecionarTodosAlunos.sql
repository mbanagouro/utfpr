-- =================================================================
-- Nome.........: [proc_SelecionarTodosAlunos]
-- Objetivo.....: 
-- =================================================================
DROP PROCEDURE [dbo].[proc_SelecionarTodosAlunos]
GO

CREATE PROCEDURE [dbo].[proc_SelecionarTodosAlunos]
AS
    -- Selecionar todos os usuários do tipo 2 (Alunos) que estejam ativos.
	SELECT [matriculaUsuario],
		   [nomeUsuario]
	  FROM [dbo].[tbUsuario]
	 WHERE [tipoUsuario] = 2
	ORDER BY [nomeUsuario]

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_SelecionarTodosAlunos] 
GO
