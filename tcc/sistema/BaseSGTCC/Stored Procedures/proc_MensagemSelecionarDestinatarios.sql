-- =================================================================
-- Nome.........: proc_MensagemSelecionarDestinatarios
-- Objetivo.....: Lista as mensagens enviadas pelo usuário
-- =================================================================
DROP PROCEDURE [dbo].[proc_MensagemSelecionarDestinatarios]
GO

CREATE PROCEDURE [dbo].[proc_MensagemSelecionarDestinatarios]
(
	@codigoMensagem INT
)

AS

	SELECT   [USU].[nomeUsuario] as 'nomeUsuario'
	FROM     [dbo].[tbMensagensUsuarios] [MEU], 
             [dbo].[tbUsuario]           [USU]
	WHERE    [MEU].[FK_codigoMensagem] = @codigoMensagem AND
             [USU].[matriculaUsuario] = [MEU].[FK_matriculaUsuario]

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_MensagemSelecionarDestinatarios] 1
GO