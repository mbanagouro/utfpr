-- =================================================================
-- Nome.........: [proc_SelecionarProfessorPorMatricula]
-- Objetivo.....: Selecionar os professores ativos
-- =================================================================
DROP PROCEDURE [dbo].[proc_SelecionarProfessorPorMatricula]
GO

CREATE PROCEDURE [dbo].[proc_SelecionarProfessorPorMatricula]
(
	@matriculaUsuario		INT
)
AS
    -- Selecionar todos os usuários do tipo 4 (Professores) que estejam ativos.
	SELECT [matriculaUsuario],
		   [nomeUsuario]
	  FROM [dbo].[tbUsuario]
	 WHERE [matriculaUsuario] = @matriculaUsuario
	ORDER BY [nomeUsuario]
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_SelecionarProfessorPorMatricula] 753030
GO
