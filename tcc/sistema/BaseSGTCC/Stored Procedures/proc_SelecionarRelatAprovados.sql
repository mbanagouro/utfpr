-- =======================================================================
-- Nome.........: [proc_SelecionarRelAprovados]
-- Objetivo.....: Selecionar os dados necessários para Pauta de Aprovados
-- =======================================================================
DROP PROCEDURE [dbo].[proc_SelecionarRelAprovados]
GO

CREATE PROCEDURE [dbo].[proc_SelecionarRelAprovados]
(
	@dataini		DATETIME,
	@datafim		DATETIME
)

AS
	SET DATEFORMAT dmy;

	SELECT	TCC.[codigoTcc],
			(SELECT dbo.fct_nomeAluno(TCC.[codigoTcc]))								as 'nomeAluno',
			TCC.[temaTcc],
			BCA.[tipoBanca],
			(SELECT dbo.fct_nomeOrientador(TCC.[codigoTcc]))						as 'nomeOrientador',
			(SELECT dbo.fct_convidado01Banca(TCC.[codigoTcc], BCA.[tipoBanca] ))	as 'convidado01',
			(SELECT dbo.fct_convidado02Banca(TCC.[codigoTcc], BCA.[tipoBanca], (SELECT dbo.fct_convidado01Banca(TCC.[codigoTcc], BCA.[tipoBanca] )))) as 'convidado02',
			CONVERT(varchar(10), BCA.[dataBanca], 103) as 'Data',
			CONVERT(varchar(08), BCA.[dataBanca], 108) as 'Hora',
			BCA.[salaBanca]
	  FROM	[dbo].[tbBanca] BCA,
            [dbo].[tbTcc]	TCC
	 WHERE  TCC.[codigoTcc] =	BCA.[FK_codigoTcc]
       AND  BCA.[databanca] >=	@dataini
       AND  BCA.[databanca] <=	@datafim
	   AND  BCA.[tipoBanca]	 =  2
	   AND  TCC.[statusTcc]	 =  4	
  GROUP BY	TCC.[codigoTcc],
			BCA.[tipoBanca],
			BCA.[dataBanca],
			BCA.[salaBanca],
			TCC.[temaTcc]	
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_SelecionarRelAprovados] '01/11/2007 00:00:00', '19/12/2008 00:00:00'
GO
