-- =================================================================
-- Nome.........: proc_ProfessorSelecionarOrientadores
-- Objetivo.....: 
-- =================================================================
DROP PROCEDURE [dbo].[proc_ProfessorSelecionarOrientadores]
GO

CREATE PROCEDURE [dbo].[proc_ProfessorSelecionarOrientadores]

AS

	SELECT [USU].[matriculaUsuario]                                    as 'matriculaUsuario',
		   [USU].[nomeUsuario]                                         as 'nomeUsuario',
           (SELECT dbo.fct_totalOrientandos([USU].[matriculaUsuario])) as 'totalOrientandos'
	  FROM [dbo].[tbUsuario]            [USU]
	 WHERE [USU].[tipoUsuario]         IN (3, 4)
  ORDER BY 'totalOrientandos' DESC

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_ProfessorSelecionarOrientadores] 
GO