-- =================================================================================
-- Nome.........: proc_UsuarioAlunoSelecionarPorTcc
-- Objetivo.....: Selecionar o codigo do Aluno vinculado ao codigo de TCC informado
-- =================================================================================
DROP PROCEDURE [dbo].[proc_UsuarioProfessorSelecionarPorTcc]
GO

CREATE PROCEDURE [dbo].[proc_UsuarioProfessorSelecionarPorTcc]
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
	  AND   U.tipoUsuario   in (3, 4)
GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_UsuarioProfessorSelecionarPorTcc] 1
GO
