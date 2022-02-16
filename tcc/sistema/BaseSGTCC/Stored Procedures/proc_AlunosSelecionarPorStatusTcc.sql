-- =================================================================
-- Nome.........: [proc_AlunosSelecionarPorStatusTcc]
-- Objetivo.....: 
-- =================================================================
DROP PROCEDURE [dbo].[proc_AlunosSelecionarPorStatusTcc]
GO

CREATE PROCEDURE [dbo].[proc_AlunosSelecionarPorStatusTcc]
(
	@nomeUsuario VARCHAR(100), 
	@statusTcc   INT
)

AS

	IF @nomeUsuario = '%%' AND @statusTcc = 0

		SELECT   [USU].[matriculaUsuario] as 'matriculaUsuario', 
				 [USU].[nomeUsuario]      as 'nomeUsuario', 
				 [TCC].[temaTcc]          as 'temaTcc', 
				 [TCC].[statusTcc]        as 'statusTcc',
                 [TCC].[notaPropostaTcc]  as 'notaPropostaTcc',
                 [TCC].[notaFinalTcc]     as 'notaFinalTcc'
		  FROM   [dbo].[tbUsuario]            [USU], 
				 [dbo].[tbTccAlunoOrientador] [TAO], 
				 [dbo].[tbTcc]                [TCC]
		 WHERE   [USU].[tipoUsuario]      = 2                           AND
				 [USU].[matriculaUsuario] = [TAO].[FK_matriculaUsuario] AND
				 [TAO].[FK_codigoTcc]     = [TCC].[codigoTcc]           AND
				 [TCC].[statusTcc]        IN (1, 2, 3, 4, 5)
		ORDER BY [USU].[nomeUsuario]

	IF @nomeUsuario = '%%' AND @statusTcc <> 0
	
		SELECT   [USU].[matriculaUsuario] as 'matriculaUsuario', 
				 [USU].[nomeUsuario]      as 'nomeUsuario', 
				 [TCC].[temaTcc]          as 'temaTcc', 
				 [TCC].[statusTcc]        as 'statusTcc',
                 [TCC].[notaPropostaTcc]  as 'notaPropostaTcc',
                 [TCC].[notaFinalTcc]     as 'notaFinalTcc'
		  FROM   [dbo].[tbUsuario]            [USU], 
				 [dbo].[tbTccAlunoOrientador] [TAO], 
				 [dbo].[tbTcc]                [TCC]
		 WHERE   [USU].[tipoUsuario]      = 2                           AND
				 [USU].[matriculaUsuario] = [TAO].[FK_matriculaUsuario] AND
				 [TAO].[FK_codigoTcc]     = [TCC].[codigoTcc]           AND
				 [TCC].[statusTcc]        = @statusTcc
		ORDER BY [USU].[nomeUsuario]

	IF @nomeUsuario <> '%%' AND @statusTcc = 0

		SELECT   [USU].[matriculaUsuario] as 'matriculaUsuario', 
				 [USU].[nomeUsuario]      as 'nomeUsuario', 
				 [TCC].[temaTcc]          as 'temaTcc', 
				 [TCC].[statusTcc]        as 'statusTcc',
                 [TCC].[notaPropostaTcc]  as 'notaPropostaTcc',
                 [TCC].[notaFinalTcc]     as 'notaFinalTcc'
		  FROM   [dbo].[tbUsuario]            [USU], 
				 [dbo].[tbTccAlunoOrientador] [TAO], 
				 [dbo].[tbTcc]                [TCC]
		 WHERE   [USU].[tipoUsuario]      = 2                           AND
				 [USU].[matriculaUsuario] = [TAO].[FK_matriculaUsuario] AND
				 [TAO].[FK_codigoTcc]     = [TCC].[codigoTcc]           AND
				 [USU].[nomeUsuario]   LIKE @nomeUsuario                AND				 
				 [TCC].[statusTcc]        IN (1, 2, 3, 4, 5)
		ORDER BY [USU].[nomeUsuario]		

	IF @nomeUsuario <> '%%' AND @statusTcc <> 0

		SELECT   [USU].[matriculaUsuario] as 'matriculaUsuario', 
				 [USU].[nomeUsuario]      as 'nomeUsuario', 
				 [TCC].[temaTcc]          as 'temaTcc', 
				 [TCC].[statusTcc]        as 'statusTcc',
                 [TCC].[notaPropostaTcc]  as 'notaPropostaTcc',
                 [TCC].[notaFinalTcc]     as 'notaFinalTcc'
		  FROM   [dbo].[tbUsuario]            [USU], 
				 [dbo].[tbTccAlunoOrientador] [TAO], 
				 [dbo].[tbTcc]                [TCC]
		 WHERE   [USU].[tipoUsuario]      = 2                           AND
				 [USU].[matriculaUsuario] = [TAO].[FK_matriculaUsuario] AND
				 [TAO].[FK_codigoTcc]     = [TCC].[codigoTcc]           AND
				 [USU].[nomeUsuario]   LIKE @nomeUsuario                AND				 
				 [TCC].[statusTcc]        = @statusTcc
		ORDER BY [USU].[nomeUsuario]

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_AlunosSelecionarPorStatusTcc] '%%', 0
GO