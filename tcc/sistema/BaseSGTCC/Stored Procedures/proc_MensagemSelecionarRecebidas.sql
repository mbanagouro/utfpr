-- =================================================================
-- Nome.........: proc_MensagemSelecionarRecebidas
-- Objetivo.....: Seleciona as mensagens recebidas
-- =================================================================
DROP PROCEDURE [dbo].[proc_MensagemSelecionarRecebidas]
GO

CREATE PROCEDURE [dbo].[proc_MensagemSelecionarRecebidas]
(
	@matriculaDestinatario INT
)

AS

	SELECT   [USU].[matriculaUsuario]   as 'matriculaUsuario',
             [USU].[nomeUsuario]        as 'nomeUsuario',
             [MEN].[codigoMensagem]     as 'codigoMensagem',
             [MEN].[assuntoMensagem]    as 'assuntoMensagem',
		     [MEN].[prioridadeMensagem] as 'prioridadeMensagem',
		     [MEN].[dataMensagem]       as 'dataMensagem',
		     [MEN].[lidoMensagem]       as 'lidoMensagem'
	FROM     [dbo].[tbUsuario]           [USU],
		     [dbo].[tbMensagem]          [MEN],
             [dbo].[tbMensagensUsuarios] [MEU]
	WHERE    [MEU].[FK_matriculaUsuario] = @matriculaDestinatario      AND
             [MEN].[codigoMensagem]      = [MEU].[FK_codigoMensagem]   AND
             [USU].[matriculaUsuario]    = [MEN].[remetenteMensagem]
	ORDER BY [MEN].[dataMensagem] DESC;

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_MensagemSelecionarRecebidas] 111111
GO