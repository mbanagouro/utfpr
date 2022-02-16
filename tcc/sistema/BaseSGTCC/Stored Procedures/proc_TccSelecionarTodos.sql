-- =================================================================
-- Nome.........: proc_TccSelecionarTodos
-- Objetivo.....: Seleciona Todos os TCC(s)
-- =================================================================
DROP PROCEDURE [dbo].[proc_TccSelecionarTodos]
GO

CREATE PROCEDURE [dbo].[proc_TccSelecionarTodos]
AS
	SELECT	[codigoTCC],
			[temaTCC],
			[statusTCC],
			[dataInicioTcc],
			[dataFinalTcc],
			[notaPropostaTcc],
			[notaFinalTcc]
	FROM	[dbo].[tbTCC]
ORDER BY	[codigoTCC] DESC
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_TccSelecionarTodos] 
GO
