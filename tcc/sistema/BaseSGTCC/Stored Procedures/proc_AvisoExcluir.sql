-- =================================================================
-- Nome.........: proc_AvisoExcluir
-- Objetivo.....: Exclui um aviso
-- =================================================================
DROP PROCEDURE [dbo].[proc_AvisoExcluir]
GO

CREATE PROCEDURE [dbo].[proc_AvisoExcluir]
(
    @codigoAviso INT
)

AS

	BEGIN TRANSACTION

	-- Processo de exclusão
	DELETE FROM [dbo].[tbAviso]
		  WHERE	[codigoAviso] = @codigoAviso;

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_AvisoExcluir] 
GO
