-- =================================================================
-- Nome.........: [fct_convidado01Banca]
-- Objetivo.....: Busca os professores convidados de uma Banca
-- =================================================================
DROP FUNCTION [dbo].[fct_convidado01Banca]
GO

CREATE FUNCTION [dbo].[fct_convidado01Banca] (@codigoTcc INT, @tipoBanca INT)
RETURNS VARCHAR(100)
AS
BEGIN
	
	DECLARE @conv01 VARCHAR(100)

	SET @conv01 =	(
						SELECT  TOP 1 USU.nomeUsuario
						  FROM  [dbo].[tbUsuario]			USU,
								[dbo].[tbBancasProfessores] BPR
						 WHERE  USU.matriculaUsuario		= BPR.FK_matriculaUsuario
						   AND  BPR.FK_codigoTcc			= @codigoTcc
						   AND  BPR.FK_tipoBanca			= @tipoBanca
					)
	
	RETURN @conv01

END
GO

-- =============================================
-- Exemplo para executar a Function
-- =============================================
SELECT [dbo].[fct_convidado01Banca](1, 1)
GO