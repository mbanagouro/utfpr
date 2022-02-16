-- =================================================================
-- Nome.........: [fct_nomeOrientador]
-- Objetivo.....: Busca o nome do Aluno de um determinado TCC
-- =================================================================
DROP FUNCTION [dbo].[fct_nomeOrientador]
GO

CREATE FUNCTION [dbo].[fct_nomeOrientador] (@codigoTcc INT)
RETURNS VARCHAR(100)
AS
BEGIN

	DECLARE @resultado VARCHAR(100)

	SET @resultado = (
						SELECT  USU.nomeUsuario
						  FROM  [dbo].[tbUsuario] USU,
								[dbo].[tbTccAlunoOrientador] TAO
						 WHERE  USU.matriculaUsuario = TAO.FK_matriculaUsuario
						   AND  TAO.FK_codigoTcc	 = @codigoTcc
						   AND  USU.tipoUsuario IN (3,4))

	RETURN @resultado

END
GO

-- =============================================
-- Exemplo para executar a Function
-- =============================================
SELECT [dbo].[fct_nomeOrientador](2)
GO