-- =================================================================
-- Nome.........: proc_BancaCountPorCodigoTcc
-- Objetivo.....: Retornar a quantidade de bancas ja cadastrada para um determinado TCC
-- =================================================================
DROP PROCEDURE [dbo].[proc_BancaCountPorCodigoTcc]
GO

CREATE PROCEDURE [dbo].[proc_BancaCountPorCodigoTcc]
(
    @codigoTcc			 INT
)

AS
	--- Buscar a quantidade de Bancas
	--- O valor retornado deve estar entre 0 e 2
	SELECT COUNT(*) as qtdeBanca
      FROM [dbo].[tbBanca]
	 WHERE [FK_codigoTcc] =  @codigoTcc 
GO
-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_BancaCountPorCodigoTcc] 1
GO
