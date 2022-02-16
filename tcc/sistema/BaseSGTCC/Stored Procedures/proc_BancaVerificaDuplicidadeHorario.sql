-- =================================================================================
-- Nome.........: proc_BancaVerificaDuplicidadeHorario
-- Objetivo.....: Selecionar o codigo e nome do Aluno vinculado ao codigo de TCC informado
-- =================================================================================
DROP PROCEDURE [dbo].[proc_BancaVerificaDuplicidadeHorario]
GO

CREATE PROCEDURE [dbo].[proc_BancaVerificaDuplicidadeHorario]
(
    @dataBanca   DATETIME
)
AS

	SET DATEFORMAT dmy;

	SELECT	count(*) as totalBancas
	FROM	[dbo].[tbBanca]
	WHERE   [databanca] = @dataBanca

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
--EXECUTE [dbo].[proc_BancaVerificaDuplicidadeHorario]
GO
