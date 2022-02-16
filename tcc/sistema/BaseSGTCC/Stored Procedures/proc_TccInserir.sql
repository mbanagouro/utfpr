-- =================================================================
-- Nome.........: proc_TccInserir
-- Objetivo.....: Cadastra um TCC e vincula a um aluno.
-- =================================================================
DROP PROCEDURE [dbo].[proc_TccInserir]
GO

CREATE PROCEDURE [dbo].[proc_TccInserir]
(
    @matriculaAluno      INT,
    @matriculaOrientador INT,
	@temaTcc             VARCHAR(150),
    @statusTcc           INT, 
	@dataInicioTcc       DATETIME = NULL,
	@dataFinalTcc        DATETIME = NULL,
	@notaProposta		 INT = 0,
	@notaFinalTcc		 INT = 0
)

AS

	-- Declaração de variáveis
	DECLARE @ultimoIdentificador INT

	BEGIN TRANSACTION;

    -- Inclui um novo TCC
	INSERT INTO [dbo].[tbTcc]
			   	([temaTcc],
                 [statusTcc],
			   	 [dataInicioTcc],
                 [dataFinalTcc],
                 [notaPropostaTcc],
                 [notaFinalTcc])
		 VALUES
			   	(@temaTcc,
                 @statusTcc,
			   	 @dataInicioTcc,
                 @dataFinalTcc,
				 @notaProposta,
				 @notaFinalTcc);

	SET @ultimoIdentificador = (SELECT TOP 1 @@IDENTITY AS 'Identificador'
                                FROM   tbTcc);

	-- Vincula o TCC a um Aluno
	INSERT INTO [dbo].[tbTccAlunoOrientador]
                ([FK_matriculaUsuario], 
                 [FK_codigoTcc])
         VALUES 
                (@matriculaAluno,
                 @ultimoIdentificador);

	-- Vincula o TCC a um Orientador
	INSERT INTO [dbo].[tbTccAlunoOrientador]
                ([FK_matriculaUsuario], 
                 [FK_codigoTcc])
         VALUES 
                (@matriculaOrientador,
                 @ultimoIdentificador);

	IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
--EXECUTE [dbo].[proc_TccInserir] 222222, 111111, 'SGTCC', 1, '11-08-2008', '11-08-2009'
--GO
