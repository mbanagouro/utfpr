-- =================================================================
-- Nome.........: proc_EventoInserir
-- Objetivo.....: Cadastra um evento
-- =================================================================
DROP PROCEDURE [dbo].[proc_EventoInserir]
GO

CREATE PROCEDURE [dbo].[proc_EventoInserir]
(
	@matriculaUsuario  INT,
    @nomeEvento	       VARCHAR(50), 
	@descricaoEvento   TEXT,
	@dataEvento	       DATETIME
)

AS

	BEGIN TRANSACTION

	-- Processo de inclusão
	INSERT INTO [dbo].[tbAgenda]
			   	([FK_matriculaUsuario],
                 [nomeEvento],
			   	 [descricaoEvento],
                 [dataEvento])
		 VALUES
			   	(@matriculaUsuario,
                 @nomeEvento,
			   	 @descricaoEvento,
                 @dataEvento);

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_EventoInserir] 
GO