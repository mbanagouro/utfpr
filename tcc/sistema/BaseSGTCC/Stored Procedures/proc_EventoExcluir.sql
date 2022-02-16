-- =================================================================
-- Nome.........: proc_EventoExcluir
-- Objetivo.....: Exclui um evento
-- =================================================================
DROP PROCEDURE [dbo].[proc_EventoExcluir]
GO

CREATE PROCEDURE [dbo].[proc_EventoExcluir]
(
	@matriculaUsuario  INT,
	@dataEvento	       DATETIME
)

AS

	BEGIN TRANSACTION

	-- Processo de exclusão
	DELETE FROM [dbo].[tbAgenda]
		  WHERE	[FK_matriculaUsuario] = @matriculaUsuario AND
                [dataEvento]          = @dataEvento;

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_EventoExcluir] 
GO