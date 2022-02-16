-- =================================================================
-- Nome.........: proc_BancaInserir
-- Objetivo.....: Cadastra um TCC e vincula a um aluno.
-- =================================================================
DROP PROCEDURE [dbo].[proc_BancaInserir]
GO

CREATE PROCEDURE [dbo].[proc_BancaInserir]
(

	@tipoBanca			INT,
    @codigoTcc			INT,
    @dataBanca			DATETIME,
	@salaBanca			VARCHAR(10),
	@matriculaConv1		INT,
	@matriculaConv2		INT
)

AS

	-- Declaração de variáveis
	DECLARE @ultimoIdentificador INT

	BEGIN TRANSACTION;

    -- Inclui uma nova Banca
	INSERT INTO [dbo].[tbBanca]
			   	([tipoBanca],
                 [FK_codigoTcc],
			   	 [dataBanca],
                 [salaBanca])
		 VALUES
			   	(@tipoBanca,
                 @codigoTcc,
			   	 @dataBanca,
                 @salaBanca);

	SET @ultimoIdentificador = (SELECT TOP 1 @@IDENTITY AS 'Identificador'
                                FROM   tbTcc);

	-- Vincula a Banca a um professor convidado (1º)
	INSERT INTO [dbo].[tbBancasProfessores]
                ([FK_codigoTcc], 
				 [FK_matriculaUsuario],
                 [FK_tipoBanca])
         VALUES 
                (@codigoTcc,
                 @matriculaConv1,
				 @tipoBanca);

-- Vincula a Banca a um professor convidado (2º)
	INSERT INTO [dbo].[tbBancasProfessores]
                ([FK_codigoTcc], 
				 [FK_matriculaUsuario],
                 [FK_tipoBanca])
         VALUES 
                (@codigoTcc,
                 @matriculaConv2,
				 @tipoBanca);

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
--EXECUTE [dbo].[proc_BancaInserir] 222222, 111111, 'SGTCC', 1, '11-08-2008', '11-08-2009'
--GO
