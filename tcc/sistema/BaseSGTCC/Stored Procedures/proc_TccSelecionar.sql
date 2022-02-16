-- =================================================================
-- Nome.........: proc_TccSelecionar
-- Objetivo.....: Seleciona um TCC a partir de um codigo informado
-- =================================================================
DROP PROCEDURE [dbo].[proc_TccSelecionar]
GO

CREATE PROCEDURE [dbo].[proc_TccSelecionar]
(
    @codigoTCC      INT
)

AS
	SELECT	[temaTCC],
			[statusTCC],
			[dataInicioTcc],
			[dataFinalTcc],
			[notaPropostaTcc],
			[notaFinalTcc]
	FROM	[dbo].[tbTCC]
	WHERE   [codigoTCC] = @codigoTCC
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_TccSelecionar] 1
GO
