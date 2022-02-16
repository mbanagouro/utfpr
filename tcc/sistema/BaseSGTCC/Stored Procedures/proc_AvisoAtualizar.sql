-- =================================================================
-- Nome.........: proc_AvisoAtualizar
-- Objetivo.....: Atualiza um aviso
-- =================================================================
DROP PROCEDURE [dbo].[proc_AvisoAtualizar]
GO

CREATE PROCEDURE [dbo].[proc_AvisoAtualizar]
(
    @codigoAviso   INT,
    @tituloAviso   VARCHAR(50), 
	@conteudoAviso TEXT
)

AS

	BEGIN TRANSACTION

	-- Processo de atualização
	UPDATE [dbo].[tbAviso]
	   SET [tituloAviso]   = @tituloAviso,
           [conteudoAviso] = @conteudoAviso
     WHERE [codigoAviso]   = @codigoAviso;

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_AvisoAtualizar] 
GO
