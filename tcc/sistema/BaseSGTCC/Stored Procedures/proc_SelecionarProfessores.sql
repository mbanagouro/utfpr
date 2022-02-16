-- =================================================================
-- Nome.........: [proc_SelecionarProfessores]
-- Objetivo.....: Selecionar os professores ativos
-- =================================================================
DROP PROCEDURE [dbo].[proc_SelecionarProfessores]
GO

CREATE PROCEDURE [dbo].[proc_SelecionarProfessores]
AS
    -- Selecionar todos os usuários do tipo 4 (Professores) que estejam ativos.
	SELECT [matriculaUsuario],
		   [nomeUsuario]
	  FROM [dbo].[tbUsuario]
	 WHERE [tipoUsuario] = 4
	ORDER BY [nomeUsuario]
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_SelecionarProfessores] 
GO
