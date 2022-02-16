-- =================================================================
-- Nome.........: proc_BancaSelecionar
-- Objetivo.....: Retornar todos os campos referentes à Banca
-- =================================================================
DROP PROCEDURE [dbo].[proc_BancaSelecionar]
GO

CREATE PROCEDURE [dbo].[proc_BancaSelecionar]
(
	@tipoBanca			INT,
    @codigoTcc			INT
)

AS  
	SELECT	A.dataBanca,
			A.salaBanca,
			B.FK_matriculaUsuario
      FROM	[dbo].[tbBanca] A, [dbo].[tbBancasProfessores] B
	 WHERE	A.[tipoBanca]    =  B.[FK_tipoBanca]
	   AND  A.[FK_codigoTcc] =  B.[FK_codigoTcc]
	   AND	A.[tipoBanca]    =  @tipoBanca
       AND	A.[FK_codigoTcc] =  @codigoTcc
     ORDER  BY B.FK_matriculaUsuario
GO
-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_BancaSelecionar] 1, 1
GO
