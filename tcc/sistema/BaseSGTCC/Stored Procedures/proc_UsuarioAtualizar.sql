-- =================================================================
-- Nome.........: proc_UsuarioAtualizar
-- Objetivo.....: Atualiza os dados cadastrais do Usuario
-- =================================================================
DROP PROCEDURE [dbo].[proc_UsuarioAtualizar]
GO

CREATE PROCEDURE [dbo].[proc_UsuarioAtualizar]
(
	@matriculaUsuario  INT,
    @nomeUsuario	   VARCHAR(100), 
	@emailUsuario	   VARCHAR(100),
	@telefoneUsuario   CHAR(10) = NULL,
	@celularUsuario	   CHAR(10) = NULL,
	@FK_codigoCidade   INT
)

AS
	BEGIN TRANSACTION

	-- Processo de alteração
	UPDATE [dbo].[tbUsuario]
	   SET [nomeUsuario]       = @nomeUsuario,
           [emailUsuario]      = @emailUsuario,
           [telefoneUsuario]   = @telefoneUsuario,
           [celularUsuario]    = @celularUsuario,
           [FK_codigoCidade]   = @FK_codigoCidade
	 WHERE [matriculaUsuario]  = @matriculaUsuario;

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_UsuarioAtualizar] 757250, 'Nome', 'Email', '123456789', '123456789', 1
GO
