-- =================================================================
-- Nome.........: proc_UsuarioSelecionarTodos
-- Objetivo.....: Recupera todos os usuários da base
-- =================================================================
DROP PROCEDURE [dbo].[proc_UsuarioSelecionarTodos]
GO

CREATE PROCEDURE [dbo].[proc_UsuarioSelecionarTodos]

AS

	-- Processo de busca
	SELECT [USU].[matriculaUsuario]  as 'matriculaUsuario',
		   [USU].[nomeUsuario]       as 'nomeUsuario',
		   [USU].[senhaUsuario]      as 'senhaUsuario',
		   [USU].[emailUsuario]      as 'emailUsuario',
	       [USU].[telefoneUsuario]   as 'telefoneUsuario',
	       [USU].[celularUsuario]    as 'celularUsuario',
           [USU].[tipoUsuario]       as 'tipoUsuario',
		   [USU].[FK_codigoCidade]   as 'codigoCidade',
           [CID].[FK_codigoEstado]   as 'codigoEstado',
           [CID].[nomeCidade]        as 'nomeCidade',
           [EST].[nomeEstado]        as 'nomeEstado'
      FROM [dbo].[tbUsuario] [USU],
           [dbo].[tbCidade]  [CID],
           [dbo].[tbEstado]  [EST]
     WHERE [USU].[FK_codigoCidade]  = [CID].[codigoCidade]  AND
           [CID].[FK_codigoEstado]  = [EST].[codigoEstado];

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_UsuarioSelecionarTodos]
GO
