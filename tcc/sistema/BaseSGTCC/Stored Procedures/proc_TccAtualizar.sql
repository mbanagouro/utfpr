-- =================================================================
-- Nome.........: proc_TccAtualizar
-- Objetivo.....: Atualiza um determinado TCC
-- =================================================================
DROP PROCEDURE [dbo].[proc_TccAtualizar]
GO

CREATE PROCEDURE [dbo].[proc_TccAtualizar]
(
    @codigoTcc			 INT,
    @matriculaAluno      INT,
    @matriculaOrientador INT,
	@temaTcc             VARCHAR(150),
    @statusTcc           INT, 
	@dataInicioTcc       DATETIME,
	@dataFinalTcc        DATETIME,
	@notaProposta		 INT,
	@notaFinalTcc		 INT
)

AS
	SET DATEFORMAT dmy;

    -- Atualiza o TCC
	UPDATE [dbo].[tbTcc]
	   SET 
		   [temaTcc] = @temaTcc,
           [statusTcc] = @statusTcc,
		   [dataInicioTcc] = @dataInicioTcc,
           [dataFinalTcc] = @dataFinalTcc,
           [notaPropostaTcc] = @notaProposta,
           [notaFinalTcc] = @notaFinalTcc	
	 WHERE [codigoTcc] = @codigoTcc 

	-- Apaga o aluno e professor vinculado ao TCC

	DELETE FROM [dbo].[tbTccAlunoOrientador]
	 WHERE [FK_codigoTcc] = @codigoTcc 
       AND [FK_codigoTcc] <> 0 

	-- Vincula o TCC a um Aluno
	INSERT INTO [dbo].[tbTccAlunoOrientador]
                ([FK_matriculaUsuario], 
                 [FK_codigoTcc])
         VALUES 
                (@matriculaAluno,
                 @codigoTcc);

	-- Vincula o TCC a um Orientador
	INSERT INTO [dbo].[tbTccAlunoOrientador]
                ([FK_matriculaUsuario], 
                 [FK_codigoTcc])
         VALUES 
                (@matriculaOrientador,
                 @codigoTcc);

	/*IF @@ERROR <> 0
		ROLLBACK
	ELSE
		COMMIT*/
GO
-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
--EXECUTE [dbo].[proc_TccInserir] 222222, 111111, 'SGTCC', 1, '11-08-2008', '11-08-2009'
--GO
