-- =================================================================
-- Nome.........: [proc_CoordenadorAtualSelecionar]
-- Objetivo.....: 
-- =================================================================
DROP PROCEDURE [dbo].[proc_CoordenadorAtualSelecionar]
GO

CREATE PROCEDURE [dbo].[proc_CoordenadorAtualSelecionar]
AS

    -- Selecionar todos os usuários do tipo 4 (Professores)
	SELECT [matriculaUsuario] as 'matriculaUsuario',
		   [nomeUsuario]      as 'nomeUsuario',
           [emailUsuario]     as 'emailUsuario'
	  FROM [dbo].[tbUsuario]
	 WHERE [tipoUsuario] = 3

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_CoordenadorAtualSelecionar] 
GO
