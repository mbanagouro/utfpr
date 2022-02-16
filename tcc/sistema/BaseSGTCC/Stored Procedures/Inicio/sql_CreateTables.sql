-- =================================================================
-- Nome.........: tbEstado
-- Objetivo.....: Armazenar os estados do território brasileiro
-- Campos.......:
--   codigoEstado(PK) = Código identificador do Estado.
--   nomeEstado       = Nome do Estado.
--   siglaEstado      = Sigla UF do Estado.
-- =================================================================
CREATE TABLE [dbo].[tbEstado] (
	[codigoEstado] SMALLINT    NOT NULL,
	[nomeEstado]   VARCHAR(50) NOT NULL,
	[siglaEstado]  CHAR(2)     NOT NULL,

	PRIMARY KEY(codigoEstado)
);

--##############################################################################################--

-- =================================================================
-- Nome.........: tbCidade
-- Objetivo.....: Armazenar as cidades do território brasileiro
-- Campos.......:
--    codigoCidade(PK)    = Código identificador da Cidade.
--    FK_codigoEstado(FK) = Código Identificador do Estado.
--    nomeCidade          = Nome da Cidade.
-- =================================================================
CREATE TABLE [dbo].[tbCidade] (
	[codigoCidade]    INT         NOT NULL,
	[FK_codigoEstado] SMALLINT    NOT NULL,
	[nomeCidade]      VARCHAR(50) NOT NULL,

	PRIMARY KEY(codigoCidade),

	FOREIGN KEY(FK_codigoEstado)
		REFERENCES tbEstado(codigoEstado)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION
);

-- Índice tbEstado
-- CREATE UNIQUE CLUSTERED 
-- INDEX  PK_CodigoEstado
-- ON     [dbo].[tbEstado](codigoEstado)
-- WITH   DROP_EXISTING,
--        FILLFACTOR = 65

--##############################################################################################--

-- =================================================================
-- Nome.........: tbTcc
-- Objetivo.....: Armazenar as informações do TCC
-- Campos.......:
--   codigoTcc(PK) = Código identificador do TCC.
--   temaTcc       = Tema do TCC.
--   statusTcc     = Status em que se encontra o TCC.
--   dataInicioTcc = Data de início do TCC.
--   dataFinalTcc  = Data limite para entrega do TCC.
-- =================================================================
CREATE TABLE [dbo].[tbTcc] (
	codigoTcc       INT IDENTITY(1,1) NOT NULL,
	temaTcc         VARCHAR(150)      NOT NULL,
	statusTcc       INT               NOT NULL, --  
	notaPropostaTcc INT                   NULL,
    notaFinalTcc    INT                   NULL,
    dataInicioTcc   DATETIME              NULL,
	dataFinalTcc    DATETIME              NULL,

	PRIMARY KEY(codigoTcc)
);

-- Índice tbTcc
-- CREATE UNIQUE CLUSTERED 
-- INDEX  PK_CodigoTcc
-- ON     [dbo].[tbTcc](codigoTcc)
-- WITH   DROP_EXISTING,
--        FILLFACTOR = 65

--##############################################################################################--

-- =================================================================
-- Nome.........: tbBanca
-- Objetivo.....: Armazenar informações sobre a banca de TCC
-- Campos.......:
--   tipoBanca(PK)        = Código identificador do tipo da banca.
--   FK_codigoTcc(PK, FK) = Código identificador do TCC.
--   dataBanca            = Data da banca.
--   salaBanca            = Sala reservada para apresentação.
-- =================================================================
CREATE TABLE [dbo].[tbBanca] (
	tipoBanca    INT         NOT NULL, -- Defesa = 1, Proposta = 2
	FK_codigoTcc INT         NOT NULL,
	dataBanca	 DATETIME    NOT NULL,
	salaBanca    VARCHAR(15)     NULL,

	PRIMARY KEY(tipoBanca, FK_codigoTcc),

	FOREIGN KEY(FK_codigoTcc)
		REFERENCES tbTcc(codigoTcc)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION
);

-- Índice tbBanca
-- CREATE UNIQUE CLUSTERED 
-- INDEX  PK_Banca
-- ON     [dbo].[tbBanca](tipoBanca, FK_codigoTcc)
-- WITH   DROP_EXISTING,
--        FILLFACTOR = 65

--##############################################################################################--

-- =================================================================
-- Nome.........: tbUsuario
-- Objetivo.....: Armazenar as informações referentes aos Usuários
-- Campos.......:
--   matriculaUsuario(PK)  = Número da matrícula.
--   nomeUsuario           = Nome do usuário.
--   senhaUsuario          = Senha de acesso.
--   emailUsuario          = Endereço de email.
--   telefoneUsuario       = Número do telefone.
--   celularUsuario        = Número do celular.
--   numAcessosUsuario     = Número de acessos do sistema.
--   statusUsuario         = Código identificador de status.
--   tipoUsuario           = Código identificador do tipo do usuário.
--   FK_codigoCidade(FK)   = Código identificador da Cidade.
-- =================================================================
CREATE TABLE [dbo].[tbUsuario] (
	matriculaUsuario  INT          NOT NULL,
	nomeUsuario       VARCHAR(100) NOT NULL,
	senhaUsuario      VARCHAR(24)  NOT NULL,
	emailUsuario      VARCHAR(100) NOT NULL,
	telefoneUsuario   CHAR(10)         NULL,
	celularUsuario    CHAR(10)         NULL,
	tipoUsuario       INT          NOT NULL, -- Administrador = 1, Aluno = 2, Coordenador = 3, Professor = 4
	FK_codigoCidade   INT          NOT NULL,

	PRIMARY KEY(matriculaUsuario),

	FOREIGN KEY(FK_codigoCidade)
		REFERENCES tbCidade(codigoCidade)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION
);

--##############################################################################################--

-- =================================================================
-- Nome.........: tbAgenda
-- Objetivo.....: Armazenar os eventos da agenda
-- Campos.......:
--   codigoEvento(PK)        = Código identificador do evento.
--   FK_matriculaUsuario(FK) = Código identificador do nº da matrícula.
--   nomeEvento              = Título do evento.
--   descricaoEvento         = Descrição do evento.
--   dataEvento              = Data que ocorrerá o evento.
-- =================================================================
CREATE TABLE [dbo].[tbAgenda] (
	codigoEvento        INT IDENTITY(1,1) NOT NULL,
	FK_matriculaUsuario INT               NOT NULL,
	nomeEvento          VARCHAR(50)       NOT NULL,
	descricaoEvento     TEXT                  NULL,
	dataEvento          DATETIME          NOT NULL,

	PRIMARY KEY(codigoEvento),

	FOREIGN KEY(FK_matriculaUsuario)
		REFERENCES tbUsuario(matriculaUsuario)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION,
);

--##############################################################################################--

-- =================================================================
-- Nome.........: tbAviso
-- Objetivo.....: Armazenar os avisos publicados pelo Professor / Coordenador
-- Campos.......:
--   codigoAviso(PK)         = Código identificador do aviso.
--	 FK_matriculaUsuario(FK) = Código identificador da matrícula.
--	 tituloAviso             = Título do aviso.
--	 conteudoAviso           = Conteúdo do aviso.
--	 dataPublicacaoAviso     = Data que será publicado o aviso.
-- =================================================================
CREATE TABLE [dbo].[tbAviso] (
	codigoAviso         INT IDENTITY(1,1) NOT NULL,
	FK_matriculaUsuario INT               NOT NULL,
	tituloAviso         VARCHAR(50)       NOT NULL,
	conteudoAviso       TEXT              NOT NULL,
	dataPublicacaoAviso DATETIME          NULL,

	PRIMARY KEY(codigoAviso),

	FOREIGN KEY(FK_matriculaUsuario)
		REFERENCES tbUsuario(matriculaUsuario)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION
);

--##############################################################################################--

-- =================================================================
-- Nome.........: tbTccAlunoOrientador
-- Objetivo.....: Armazena o aluno e o orientador de determinado TCC
-- Campos.......:
--   FK_matriculaUsuario(PK, FK) = Código identificador do nº da matrícula.
--   FK_codigoTcc(PK, FK)        = Código identificador do TCC.
-- =================================================================
CREATE TABLE [dbo].[tbTccAlunoOrientador] (
  FK_matriculaUsuario INT NOT NULL,
  FK_codigoTcc        INT NOT NULL,

  PRIMARY KEY(FK_matriculaUsuario, FK_codigoTcc),

  FOREIGN KEY(FK_matriculaUsuario)
    REFERENCES tbUsuario(matriculaUsuario)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,

  FOREIGN KEY(FK_codigoTcc)
    REFERENCES tbTcc(codigoTcc)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

--##############################################################################################--

-- =================================================================
-- Nome.........: tbBancasProfessores
-- Objetivo.....: Armazenar os Professor que farão parte das bancas de TCC
-- Campos.......:
--   FK_codigoTcc(PK, FK)        = Código identificador do TCC.
--   FK_matriculaUsuario(PK, FK) = Código identificador do nº da matrícula.
--   FK_tipoBanca(PK, FK)        = Código identificador do tipo de banca.
-- =================================================================
CREATE TABLE [dbo].[tbBancasProfessores] (
	FK_codigoTcc        INT     NOT NULL,
	FK_matriculaUsuario INT     NOT NULL,
	FK_tipoBanca        INT     NOT NULL,

	PRIMARY KEY(FK_codigoTcc, FK_matriculaUsuario, FK_tipoBanca),

	FOREIGN KEY(FK_tipoBanca, FK_codigoTcc)
		REFERENCES tbBanca(tipoBanca, FK_codigoTcc)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION,
	FOREIGN KEY(FK_matriculaUsuario)
		REFERENCES tbUsuario(matriculaUsuario)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION
);

--##############################################################################################--

-- =================================================================
-- Nome.........: tbMensagem
-- Objetivo.....: Armazenar as mensagens enviadas e recebidas
-- Campos.......:
--   codigoMensagem(PK)      = Código identificador da mensagem.
--   FK_matriculaUsuario(FK) = Código identificador do nº da matrícula.
--   destinatarioMensagem    = Código do destinatário da mensagem.
--	 assuntoMensagem         = Assunto da mensagem.
--	 prioridadeMensagem      = Prioridade da mensagem.
--	 conteudoMensagem        = Conteúdo da mensagem.
--	 dataMensagem            = Data de envio.
--	 lidoMensagem            = Código identificador de lido e não lido.
--	 anexoMensagem           = Anexos da mensagem.
-- =================================================================
CREATE TABLE [dbo].[tbMensagem] (
    codigoMensagem      INT IDENTITY(1,1) NOT NULL,
    remetenteMensagem   INT               NOT NULL,
	assuntoMensagem     VARCHAR(100)      NOT NULL,
	prioridadeMensagem  INT               NOT NULL, -- Importante = 1, Normal = 2, Urgente = 3
	conteudoMensagem    TEXT              NOT NULL,
	dataMensagem        DATETIME          NOT NULL,
	lidoMensagem        INT               NOT NULL  -- Lido = 1, NaoLido = 2

	PRIMARY KEY(codigoMensagem)
);

--##############################################################################################--

-- =================================================================
-- Nome.........: [tbMensagensUsuarios]
-- Objetivo.....: Armazenar as mensagens de cada usuário.
-- Campos.......:
--	 FK_matriculaUsuario(PK, FK) = Código identificador do nº da matrícula.
--	 FK_codigoMensagem(PK, FK)   = Código identificador da mensagem.
-- =================================================================
CREATE TABLE [dbo].[tbMensagensUsuarios] (
	FK_matriculaUsuario INT NOT NULL,
	FK_codigoMensagem   INT NOT NULL,

	PRIMARY KEY(FK_matriculaUsuario, FK_codigoMensagem),

	FOREIGN KEY(FK_codigoMensagem)
		REFERENCES tbMensagem(codigoMensagem)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION,
	FOREIGN KEY(FK_matriculaUsuario)
		REFERENCES tbUsuario(matriculaUsuario)
			ON DELETE NO ACTION
			ON UPDATE NO ACTION
);

--##############################################################################################--