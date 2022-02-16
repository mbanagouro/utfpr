-- =====================================================================
-- Nome.........: [proc_TccAlunoProfesssorSelecionar]
-- Objetivo.....: Seleciona o aluno e o orientador de um determinado TCC
-- =====================================================================
DROP PROCEDURE [dbo].[proc_TccAlunoOrientadorSelecionar]
GO

CREATE PROCEDURE [dbo].[proc_TccAlunoOrientadorSelecionar]
(
    @codigoTCC      INT
)

AS
	SELECT	[FK_matriculaUsuario]
	FROM	[dbo].[tbTccAlunoOrientador]
	WHERE   [FK_codigoTcc] = @codigoTCC
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_TccAlunoOrientadorSelecionar] 3
GO
