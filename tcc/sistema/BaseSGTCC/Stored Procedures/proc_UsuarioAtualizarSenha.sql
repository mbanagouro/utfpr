-- =================================================================
-- Nome.........: proc_UsuarioAtualizarSenha
-- Objetivo.....: Altera a senha de acesso ao sistema do Usuário
-- =================================================================
DROP PROCEDURE [dbo].[proc_UsuarioAtualizarSenha]
GO

CREATE PROCEDURE [dbo].[proc_UsuarioAtualizarSenha]
(
	@matriculaUsuario  INT,
	@senhaUsuario      VARCHAR(24)
)

AS

	BEGIN TRANSACTION

	-- Processo de alteração
	UPDATE [dbo].[tbUsuario]
	   SET [senhaUsuario]      = @senhaUsuario
     WHERE [matriculaUsuario]  = @matriculaUsuario;

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_UsuarioAtualizarSenha] 757250, 'Senha Nova'
GO
