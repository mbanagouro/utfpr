-- =================================================================
-- Nome.........: proc_MensagemSelecionarEnviadas
-- Objetivo.....: Lista as mensagens enviadas pelo usuário
-- =================================================================
DROP PROCEDURE [dbo].[proc_MensagemSelecionarEnviadas]
GO

CREATE PROCEDURE [dbo].[proc_MensagemSelecionarEnviadas]
(
	@matriculaRemetente INT
)

AS

	SELECT   [MEN].[codigoMensagem]     as 'codigoMensagem',
             [MEN].[assuntoMensagem]    as 'assuntoMensagem',
		     [MEN].[prioridadeMensagem] as 'prioridadeMensagem',
		     [MEN].[dataMensagem]       as 'dataMensagem',
		     [MEN].[lidoMensagem]       as 'lidoMensagem'
	FROM     [dbo].[tbMensagem] [MEN]
	WHERE    [MEN].[remetenteMensagem] = @matriculaRemetente
	ORDER BY [MEN].[dataMensagem] DESC;

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_MensagemSelecionarEnviadas] 757250
GO