-- =================================================================
-- Nome.........: fct_nomeAluno
-- Objetivo.....: Busca o nome do Aluno de um determinado TCC
-- =================================================================
DROP FUNCTION [dbo].[fct_nomeAluno]
GO

CREATE FUNCTION [dbo].[fct_nomeAluno] (@codigoTcc INT)
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
						   AND  USU.tipoUsuario		 = 2)

	RETURN @resultado

END
GO

-- =============================================
-- Exemplo para executar a Function
-- =============================================
SELECT [dbo].[fct_nomeAluno](2)
GO