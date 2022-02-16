-- =================================================================
-- Nome.........: proc_BancaAtualizar
-- Objetivo.....: Cadastra um TCC e vincula a um aluno.
-- =================================================================
DROP PROCEDURE [dbo].[proc_BancaAtualizar]
GO

CREATE PROCEDURE [dbo].[proc_BancaAtualizar]
(

	@tipoBanca			INT,
    @codigoTcc			INT,
    @dataBanca			DATETIME,
	@salaBanca			VARCHAR(10),
	@matriculaConv1		INT,
	@matriculaConv2		INT
)

AS

	UPDATE [dbo].[tbBanca]
	   SET 
		   [dataBanca]		= @dataBanca,
           [salaBanca]		= @salaBanca
	 WHERE
		   [tipoBanca]		= @tipoBanca
       AND [FK_codigoTcc]	= @codigoTcc

	
	DELETE [dbo].[tbBancasProfessores]
	 WHERE
		   [FK_tipoBanca]	= @tipoBanca
       AND [FK_codigoTcc]	= @codigoTcc
		 
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

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
--EXECUTE [dbo].[proc_BancaAtualizar] 222222, 111111, 'SGTCC', 1, '11-08-2008', '11-08-2009'
--GO
