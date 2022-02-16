-- =================================================================
-- Nome.........: proc_MensagemSelecionarRecebidoPorCodigo
-- Objetivo.....: Lista a mensagem recebida em detalhes
-- =================================================================
DROP PROCEDURE [dbo].[proc_MensagemSelecionarRecebidoPorCodigo]
GO

CREATE PROCEDURE [dbo].[proc_MensagemSelecionarRecebidoPorCodigo]
(
	@codigoMensagem INT
)

AS

	BEGIN TRANSACTION;

	-- Atualiza a mensagem como lida
	UPDATE   [dbo].[tbMensagem]
       SET   [lidoMensagem] = 1
     WHERE   [codigoMensagem] = @codigoMensagem

	-- Seleciona a mensagem
	SELECT   [USU].[matriculaUsuario]   as 'matriculaUsuario',
             [USU].[nomeUsuario]        as 'nomeUsuario',
             [MEN].[codigoMensagem]     as 'codigoMensagem',
			 [MEN].[assuntoMensagem]    as 'assuntoMensagem',
			 [MEN].[prioridadeMensagem] as 'prioridadeMensagem',
             [MEN].[conteudoMensagem]   as 'conteudoMensagem',
			 [MEN].[dataMensagem]       as 'dataMensagem'
	FROM     [dbo].[tbUsuario]           [USU],
             [dbo].[tbMensagem]          [MEN],
			 [dbo].[tbMensagensUsuarios] [MEU]
	WHERE    [MEN].[codigoMensagem]      = @codigoMensagem        AND
             [MEU].[FK_codigoMensagem]   = [MEN].[codigoMensagem] AND
             [USU].[matriculaUsuario]    = [MEN].[remetenteMensagem]; 

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_MensagemSelecionarRecebidoPorCodigo] 1
GO