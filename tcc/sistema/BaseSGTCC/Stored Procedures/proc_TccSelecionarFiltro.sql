-- =================================================================
-- Nome.........: proc_TccSelecionarFiltro
-- Objetivo.....: Seleciona Todos os TCC(s) que atendam as condições do filtro
-- =================================================================
DROP PROCEDURE [dbo].[proc_TccSelecionarFiltro]
GO

CREATE PROCEDURE [dbo].[proc_TccSelecionarFiltro]
(
	@tema			VARCHAR(150) = '%%',
	@status1		INT = 1,
	@status2		INT = 2,
	@status3		INT = 3, 
	@status4		INT = 4, 
	@status5		INT = 5,
	@matricula      INT = 0
)
AS
    DECLARE @sql VARCHAR(MAX)

    SET @sql = 
	'SELECT	T.[codigoTCC],
			T.[temaTCC],
			T.[statusTCC],
			T.[dataInicioTcc],
			T.[dataFinalTcc],
			T.[notaPropostaTcc],
			T.[notaFinalTcc]
	FROM	[dbo].[tbTCC] T, [dbo].[tbTccAlunoOrientador] TAO
    WHERE   T.[codigoTCC] = TAO.[FK_codigoTcc] 
      AND   T.[temaTCC] LIKE ''' + @tema + '''' + 
    ' AND   T.[statusTCC] IN ( ' + CONVERT(VARCHAR(1),@status1) + ','
								 + CONVERT(VARCHAR(1),@status2) + ','
								 + CONVERT(VARCHAR(1),@status3) + ','
								 + CONVERT(VARCHAR(1),@status4) + ','
								 + CONVERT(VARCHAR(1),@status5) + ')'

	
	IF  @matricula > 0 BEGIN
	    SET @sql = @sql
        + ' AND   TAO.[FK_matriculaUsuario] = ' + CONVERT(VARCHAR(10),@matricula) 
    END       

    SET @sql = @sql  
	+ ' GROUP BY T.[codigoTCC],
				T.[temaTCC],
				T.[statusTCC],
				T.[dataInicioTcc],
				T.[dataFinalTcc],
				T.[notaPropostaTcc],
				T.[notaFinalTcc] ORDER BY T.[codigoTCC] DESC'                     
	

	EXEC(@sql)

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_TccSelecionarFiltro] '%%', 1, 2, 3, 4, 5
GO



