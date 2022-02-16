-- =================================================================
-- Nome.........: proc_UsuarioSelecionar
-- Objetivo.....: Recupera os dados de um determinado Usuario
-- =================================================================
DROP PROCEDURE [dbo].[proc_UsuarioSelecionar]
GO

CREATE PROCEDURE [dbo].[proc_UsuarioSelecionar]
(
	@matriculaUsuario INT, 
    @senhaUsuario     VARCHAR(100) = NULL,
    @emailUsuario     VARCHAR(100) = NULL
)

AS

	IF @senhaUsuario IS NULL AND @emailUsuario IS NULL
		
		BEGIN

			-- Processo de busca por matrícula
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
			 WHERE [USU].[matriculaUsuario] = @matriculaUsuario    AND
				   [USU].[FK_codigoCidade]  = [CID].[codigoCidade] AND
				   [CID].[FK_codigoEstado]  = [EST].[codigoEstado];		
		END

	ELSE IF NOT @senhaUsuario IS NULL

		BEGIN

			-- Processo de busca por login
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
			 WHERE [USU].[matriculaUsuario] = @matriculaUsuario    AND
				   [USU].[senhaUsuario]     = @senhaUsuario        AND
				   [USU].[FK_codigoCidade]  = [CID].[codigoCidade] AND
				   [CID].[FK_codigoEstado]  = [EST].[codigoEstado];

		END

	ELSE IF NOT @emailUsuario IS NULL
	
		BEGIN

			-- Processo de busca por email
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
			 WHERE [USU].[matriculaUsuario] = @matriculaUsuario    AND
				   [USU].[emailUsuario]     = @emailUsuario        AND
				   [USU].[FK_codigoCidade]  = [CID].[codigoCidade] AND
				   [CID].[FK_codigoEstado]  = [EST].[codigoEstado];

		END

GO

-- =============================================
-- Exemplo para executar a Procedure
-- =============================================
EXECUTE [dbo].[proc_UsuarioSelecionar] 111111
GO
