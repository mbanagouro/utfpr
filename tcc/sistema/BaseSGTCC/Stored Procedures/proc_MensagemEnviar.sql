-- =================================================================
-- Nome.........: proc_MensagemEnviar
-- Objetivo.....: Envia uma mensagem para um usuário
-- =================================================================
DROP PROCEDURE [dbo].[proc_MensagemEnviar]
GO

CREATE PROCEDURE [dbo].[proc_MensagemEnviar]
(
	@codigoMensagem        INT,
    @matriculaDestinatario INT
)

AS

	BEGIN TRANSACTION

	-- Processo de inclusão
	INSERT INTO [dbo].[tbMensagensUsuarios]
			   	([FK_codigoMensagem],
                 [FK_matriculaUsuario])
		 VALUES
			   	(@codigoMensagem,
                 @matriculaDestinatario);

	IF @@ERROR <> 0
		BEGIN
			ROLLBACK

			DELETE FROM tbMensagem
                  WHERE codigoMensagem = @codigoMensagem
		END
	ELSE
		COMMIT
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_MensagemEnviar] 
GO