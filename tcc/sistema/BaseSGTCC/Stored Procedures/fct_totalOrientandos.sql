-- =================================================================
-- Nome.........: fct_totalOrientandos
-- Objetivo.....: Busca a quantidade de alunos orientandos.
-- =================================================================
DROP FUNCTION [dbo].[fct_totalOrientandos]
GO

CREATE FUNCTION [dbo].[fct_totalOrientandos] (@matriculaUsuario INT)
RETURNS INT
AS
BEGIN

	DECLARE @resultado INT

	SET @resultado = (SELECT COUNT(*)
                        FROM tbTccAlunoOrientador
                       WHERE FK_matriculaUsuario = @matriculaUsuario)

	RETURN @resultado

END
GO

-- =============================================
-- Exemplo para executar a Function
-- =============================================
SELECT [dbo].[fct_totalOrientandos](111111)
GO