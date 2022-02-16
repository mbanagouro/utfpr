-- =================================================================
-- Nome.........: proc_CoordenadorAtualizar
-- Objetivo.....: 
-- =================================================================
DROP PROCEDURE [dbo].[proc_CoordenadorAtualizar]
GO

CREATE PROCEDURE [dbo].[proc_CoordenadorAtualizar]
(
    @matriculaUsuario INT
)

AS

	-- Atribuir o Coordenador atual como professor
	UPDATE [tbUsuario]
       SET [tipoUsuario] = 4
     WHERE [tipoUsuario] = 3

	-- Atribuir como Coordenador o professor selecionado
	UPDATE [tbUsuario]
       SET [tipoUsuario] = 3
     WHERE [matriculaUsuario] = @matriculaUsuario
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_CoordenadorAtualizar] 757285
GO
