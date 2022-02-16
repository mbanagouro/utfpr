-- =================================================================
-- Nome.........: proc_EventoAtualizar
-- Objetivo.....: Atualiza um evento
-- =================================================================
DROP PROCEDURE [dbo].[proc_EventoAtualizar]
GO

CREATE PROCEDURE [dbo].[proc_EventoAtualizar]
(
	@matriculaUsuario  INT,
    @nomeNomeEvento	   VARCHAR(50), 
	@descricaoEvento   TEXT,
	@dataEvento	       DATETIME
)

AS

	BEGIN TRANSACTION

	-- Processo de atualização
	UPDATE [dbo].[tbAgenda]
	   SET [nomeEvento]          = @nomeNomeEvento,
		   [descricaoEvento]     = @descricaoEvento
     WHERE [FK_matriculaUsuario] = @matriculaUsuario AND
           [dataEvento]          = @dataEvento;

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_EventoAtualizar] 
GO