-- =================================================================
-- Nome.........: proc_MensagemSalvar
-- Objetivo.....: Cadastra uma mensagem do usuário
-- =================================================================
DROP PROCEDURE [dbo].[proc_MensagemSalvar]
GO

CREATE PROCEDURE [dbo].[proc_MensagemSalvar]
(
	@matriculaRemetente    INT,
	@assuntoMensagem       VARCHAR(100),
	@prioridadeMensagem    INT,
	@conteudoMensagem      TEXT,
    @ultimoCodigoMensagem  INT OUTPUT
)

AS

	BEGIN TRANSACTION

	-- Processo de inclusão
	INSERT INTO [dbo].[tbMensagem]
			   	([remetenteMensagem],
			   	 [assuntoMensagem],
                 [prioridadeMensagem],
                 [conteudoMensagem],
                 [dataMensagem],
                 [lidoMensagem])
		 VALUES
			   	(@matriculaRemetente,
			   	 @assuntoMensagem,
                 @prioridadeMensagem,
                 @conteudoMensagem,
                 CURRENT_TIMESTAMP,
                 2); -- Mensagem não lida

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		BEGIN
			COMMIT

			-- Obtém o código da última mensagem inserida
			SET @ultimoCodigoMensagem = (SELECT TOP 1 @@IDENTITY as 'codigoMensagem' 
										 FROM   [dbo].[tbMensagem])

			-- Retorna o código
			RETURN @ultimoCodigoMensagem
		END

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_MensagemSalvar] 111111, 'Assunto', 1, 'Texto teste', null, 0
GO