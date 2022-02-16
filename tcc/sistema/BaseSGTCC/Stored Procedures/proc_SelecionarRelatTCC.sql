-- =================================================================
-- Nome.........: [proc_SelecionarRelTCC]
-- Objetivo.....: Selecionar os dados necessários para Relatório
-- =================================================================
DROP PROCEDURE [dbo].[proc_SelecionarRelTCC]
GO


CREATE PROCEDURE [dbo].[proc_SelecionarRelTCC]
(
	@dataini		DATETIME,
	@datafim		DATETIME
)

AS
	SET DATEFORMAT dmy;

	SELECT	TCC.[codigoTcc],
			(SELECT dbo.fct_nomeAluno(TCC.[codigoTcc]))			as 'nomeAluno',
			TCC.[temaTcc],
			BCA.[tipoBanca],
			(SELECT dbo.fct_nomeOrientador(TCC.[codigoTcc]))	as 'nomeOrientador',
			(SELECT dbo.fct_convidado01Banca(TCC.[codigoTcc], BCA.[tipoBanca] )) as 'convidado01',
			(SELECT dbo.fct_convidado02Banca(TCC.[codigoTcc], BCA.[tipoBanca], (SELECT dbo.fct_convidado01Banca(TCC.[codigoTcc], BCA.[tipoBanca] )))) as 'convidado02',
			BCA.[dataBanca],
			BCA.[salaBanca]
	  FROM	[dbo].[tbBanca] BCA,
            [dbo].[tbTcc]	TCC
	 WHERE  TCC.[codigoTcc] = BCA.[FK_codigoTcc]
       AND  BCA.[databanca] >= @dataini
       AND  BCA.[databanca] <= @datafim
  ORDER BY	BCA.[tipoBanca], BCA.[databanca] ASC
  
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_SelecionarRelTCC] '01/10/2007 00:00:00', '19/12/2008 00:00:00'
GO

