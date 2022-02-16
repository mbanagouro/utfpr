-- =================================================================
-- Nome.........: proc_AvisoInserir
-- Objetivo.....: Cadastra um novo aviso
-- =================================================================
DROP PROCEDURE [dbo].[proc_AvisoInserir]
GO

CREATE PROCEDURE [dbo].[proc_AvisoInserir]
(
    @FK_matriculaUsuario INT,
    @tituloAviso	     VARCHAR(50), 
	@conteudoAviso	     TEXT,
    @dataPublicacaoAviso DATETIME
)

AS

	BEGIN TRANSACTION

	-- Processo de inclusão
	INSERT INTO [dbo].[tbAviso]
			   	([FK_matriculaUsuario],
                 [tituloAviso],
                 [conteudoAviso],
                 [dataPublicacaoAviso])
		 VALUES
			   	(@FK_matriculaUsuario,
                 @tituloAviso,
                 @conteudoAviso,
                 @dataPublicacaoAviso);

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_AvisoInserir] 
GO
