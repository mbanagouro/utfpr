-- =================================================================
-- Nome.........: proc_MensagemSelecionarEnviadoPorCodigo
-- Objetivo.....: Seleciona a mensagem detalhada
-- =================================================================
DROP PROCEDURE [dbo].[proc_MensagemSelecionarEnviadoPorCodigo]
GO

CREATE PROCEDURE [dbo].[proc_MensagemSelecionarEnviadoPorCodigo]
(
	@codigoMensagem INT
)

AS

	-- Seleciona a mensagem
	SELECT   [MEN].[codigoMensagem]     as 'codigoMensagem',
             [MEN].[assuntoMensagem]    as 'assuntoMensagem',
			 [MEN].[prioridadeMensagem] as 'prioridadeMensagem',
             [MEN].[conteudoMensagem]   as 'conteudoMensagem',
			 [MEN].[dataMensagem]       as 'dataMensagem'
	FROM	 [dbo].[tbMensagem] [MEN]
	WHERE    [MEN].[codigoMensagem]   = @codigoMensagem;
            
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_MensagemSelecionarEnviadoPorCodigo] 1
GO 