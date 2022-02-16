-- ============================================================================
-- Nome.........: [proc_BancaExcluir]
-- Objetivo.....: Excluir uma banca cadastrada pra um TCC informando seu tipo
-- ============================================================================
DROP PROCEDURE [dbo].[proc_BancaExcluir]
GO

CREATE PROCEDURE [dbo].[proc_BancaExcluir]
(
	@codigoTcc			INT,
	@tipoBanca			INT
)

AS

	DELETE [dbo].[tbBancasProfessores]
	 WHERE [FK_tipoBanca] = @tipoBanca
       AND [FK_codigoTcc] = @codigoTcc

	DELETE [dbo].[tbBanca]
	 WHERE [tipoBanca]    = @tipoBanca
       AND [FK_codigoTcc] = @codigoTcc
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
--EXECUTE [dbo].[proc_BancaExcluir] 1, 2
--GO
