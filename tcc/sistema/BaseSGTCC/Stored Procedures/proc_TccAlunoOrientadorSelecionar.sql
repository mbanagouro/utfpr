-- =================================================================
-- Nome.........: proc_TccAlunoOrientadorSelecionar
-- Objetivo.....: 
-- =================================================================
DROP PROCEDURE [dbo].[proc_TccAlunoOrientadorSelecionar]
GO

CREATE PROCEDURE [dbo].[proc_TccAlunoOrientadorSelecionar]
(
    @matriculaUsuario INT
)

AS

	SELECT [TAO].[FK_matriculaUsuario] as 'matriculaUsuario',
		   [USU].[nomeUsuario]         as 'nomeUsuario'
	  FROM [dbo].[tbTccAlunoOrientador] [TAO],
		   [dbo].[tbUsuario]            [USU], 
           [dbo].[tbTcc]                [TCC] 
	 WHERE [TAO].[FK_matriculaUsuario] <> @matriculaUsuario                                  AND
		   [USU].[matriculaUsuario]    =  [TAO].[FK_matriculaUsuario]                        AND
		   [TAO].[FK_codigoTcc]        IN (SELECT [FK_codigoTcc]
										   FROM   [dbo].[tbTccAlunoOrientador]
										   WHERE  [FK_matriculaUsuario] = @matriculaUsuario) AND
		   [TCC].[codigoTcc]           = [TAO].[FK_codigoTcc]                                AND
           [TCC].[statusTcc]           IN (1, 2, 3)

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_TccAlunoOrientadorSelecionar] 757250
GO