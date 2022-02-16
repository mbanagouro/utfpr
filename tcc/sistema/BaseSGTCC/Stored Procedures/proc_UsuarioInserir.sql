-- =================================================================
-- Nome.........: proc_UsuarioInserir
-- Objetivo.....: Cadastra um Usuario na tabela Usuarios
-- =================================================================
DROP PROCEDURE [dbo].[proc_UsuarioInserir]
GO

CREATE PROCEDURE [dbo].[proc_UsuarioInserir]
(
	@matriculaUsuario  INT,
    @nomeUsuario	   VARCHAR(100), 
	@senhaUsuario	   VARCHAR(24),
	@emailUsuario	   VARCHAR(100),
	@telefoneUsuario   CHAR(10) = NULL,
	@celularUsuario	   CHAR(10) = NULL,
	@tipoUsuario       INT, -- Administrador = 1, Aluno = 2, Coordenador = 3, Professor = 4
	@codigoCidade      INT
)

AS

	BEGIN TRANSACTION

	-- Processo de inclusão
	INSERT INTO [dbo].[tbUsuario]
			   	([matriculaUsuario],
                 [nomeUsuario],
			   	 [senhaUsuario],
                 [emailUsuario],
                 [telefoneUsuario],
                 [celularUsuario],
				 [tipoUsuario],
                 [FK_codigoCidade])
		 VALUES
			   	(@matriculaUsuario,
                 @nomeUsuario,
			   	 @senhaUsuario,
                 @emailUsuario,
                 @telefoneUsuario,
                 @celularUsuario,
				 @tipoUsuario,
                 @codigoCidade);

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_UsuarioInserir] 757250, 'Michel Cesar Leme Banagouro', 'R932FYKtfk3llyL3mzqYHw==', 'mick_bana@hotmail.com', '123456789', '123456789', 2, 1;
EXECUTE [dbo].[proc_UsuarioInserir] 222222, 'Bruno Gustavo Carvalho Capel', 'R932FYKtfk3llyL3mzqYHw==', 'bcapel@hotmail.com', '123456789', '123456789', 2, 1;
EXECUTE [dbo].[proc_UsuarioInserir] 111111, 'Eidy Tanaka Guandeline', 'R932FYKtfk3llyL3mzqYHw==', 'eidy@utfpr.edu.br', '123456789', '123456789', 3, 1;
GO