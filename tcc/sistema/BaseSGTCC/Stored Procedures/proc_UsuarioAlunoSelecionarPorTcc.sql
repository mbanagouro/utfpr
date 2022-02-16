-- =================================================================================
-- Nome.........: proc_UsuarioAlunoSelecionarPorTcc
-- Objetivo.....: Selecionar o codigo e nome do Aluno vinculado ao codigo de TCC informado
-- =================================================================================
DROP PROCEDURE [dbo].[proc_UsuarioAlunoSelecionarPorTcc]
GO

CREATE PROCEDURE [dbo].[proc_UsuarioAlunoSelecionarPorTcc]
(
    @codigoTCC      INT
)

AS
	SELECT	[matriculaUsuario]
		   ,[nomeUsuario]
	FROM	[dbo].[tbUsuario] U
           ,[dbo].[tbTccAlunoOrientador] T
	WHERE   U.[matriculaUsuario] = T.[FK_matriculaUsuario]
      AND   T.[FK_codigoTcc] = @codigoTCC
	  AND   U.tipoUsuario  = 2
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_UsuarioAlunoSelecionarPorTcc] 1
GO
