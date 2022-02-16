-- =================================================================
-- Nome.........: [fct_convidado02Banca]
-- Objetivo.....: Busca o SEGUNDO professor convidado de uma Banca
-- =================================================================
DROP FUNCTION [dbo].[fct_convidado02Banca]
GO

CREATE FUNCTION [dbo].[fct_convidado02Banca] (@codigoTcc INT, @tipoBanca INT, @professor VARCHAR(100))
RETURNS VARCHAR(100)
AS
BEGIN
	
	DECLARE @conv01 VARCHAR(100)

	SET @conv01 =	(
						SELECT  USU.nomeUsuario
						  FROM  [dbo].[tbUsuario]			USU,
								[dbo].[tbBancasProfessores] BPR
						 WHERE  USU.matriculaUsuario		= BPR.FK_matriculaUsuario
						   AND  BPR.FK_codigoTcc			= @codigoTcc
						   AND  BPR.FK_tipoBanca			= @tipoBanca
						   AND  USU.nomeUsuario				<> @professor
					)
	
	RETURN @conv01

END
GO

-- =============================================
-- Exemplo para executar a Function
-- =============================================
SELECT [dbo].[fct_convidado02Banca](1, 1, 'Professor Teste')
GO