-- =================================================================
-- Nome.........: tbEstado
-- Objetivo.....: Armazenar os estados do territ�rio brasileiro
-- Campos.......:
--   codigoEstado(PK) = C�digo identificador do Estado.
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
-- Objetivo.....: Armazenar as cidades do territ�rio brasileiro
-- Campos.......:
--    codigoCidade(PK)    = C�digo identificador da Cidade.
--    FK_codigoEstado(FK) = C�digo Identificador do Estado.
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

-- �ndice tbEstado
-- CREATE UNIQUE CLUSTERED 
-- INDEX  PK_CodigoEstado
-- ON     [dbo].[tbEstado](codigoEstado)
-- WITH   DROP_EXISTING,
--        FILLFACTOR = 65

--##############################################################################################--

-- =================================================================
-- Nome.........: tbTcc
-- Objetivo.....: Armazenar as informa��es do TCC
-- Campos.......:
--   codigoTcc(PK) = C�digo identificador do TCC.
--   temaTcc       = Tema do TCC.
--   statusTcc     = Status em que se encontra o TCC.
--   dataInicioTcc = Data de in�cio do TCC.
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

-- �ndice tbTcc
-- CREATE UNIQUE CLUSTERED 
-- INDEX  PK_CodigoTcc
-- ON     [dbo].[tbTcc](codigoTcc)
-- WITH   DROP_EXISTING,
--        FILLFACTOR = 65

--##############################################################################################--

-- =================================================================
-- Nome.........: tbBanca
-- Objetivo.....: Armazenar informa��es sobre a banca de TCC
-- Campos.......:
--   tipoBanca(PK)        = C�digo identificador do tipo da banca.
--   FK_codigoTcc(PK, FK) = C�digo identificador do TCC.
--   dataBanca            = Data da banca.
--   salaBanca            = Sala reservada para apresenta��o.
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

-- �ndice tbBanca
-- CREATE UNIQUE CLUSTERED 
-- INDEX  PK_Banca
-- ON     [dbo].[tbBanca](tipoBanca, FK_codigoTcc)
-- WITH   DROP_EXISTING,
--        FILLFACTOR = 65

--##############################################################################################--

-- =================================================================
-- Nome.........: tbUsuario
-- Objetivo.....: Armazenar as informa��es referentes aos Usu�rios
-- Campos.......:
--   matriculaUsuario(PK)  = N�mero da matr�cula.
--   nomeUsuario           = Nome do usu�rio.
--   senhaUsuario          = Senha de acesso.
--   emailUsuario          = Endere�o de email.
--   telefoneUsuario       = N�mero do telefone.
--   celularUsuario        = N�mero do celular.
--   numAcessosUsuario     = N�mero de acessos do sistema.
--   statusUsuario         = C�digo identificador de status.
--   tipoUsuario           = C�digo identificador do tipo do usu�rio.
--   FK_codigoCidade(FK)   = C�digo identificador da Cidade.
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
--   codigoEvento(PK)        = C�digo identificador do evento.
--   FK_matriculaUsuario(FK) = C�digo identificador do n� da matr�cula.
--   nomeEvento              = T�tulo do evento.
--   descricaoEvento         = Descri��o do evento.
--   dataEvento              = Data que ocorrer� o evento.
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
--   codigoAviso(PK)         = C�digo identificador do aviso.
--	 FK_matriculaUsuario(FK) = C�digo identificador da matr�cula.
--	 tituloAviso             = T�tulo do aviso.
--	 conteudoAviso           = Conte�do do aviso.
--	 dataPublicacaoAviso     = Data que ser� publicado o aviso.
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
--   FK_matriculaUsuario(PK, FK) = C�digo identificador do n� da matr�cula.
--   FK_codigoTcc(PK, FK)        = C�digo identificador do TCC.
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
-- Objetivo.....: Armazenar os Professor que far�o parte das bancas de TCC
-- Campos.......:
--   FK_codigoTcc(PK, FK)        = C�digo identificador do TCC.
--   FK_matriculaUsuario(PK, FK) = C�digo identificador do n� da matr�cula.
--   FK_tipoBanca(PK, FK)        = C�digo identificador do tipo de banca.
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
--   codigoMensagem(PK)      = C�digo identificador da mensagem.
--   FK_matriculaUsuario(FK) = C�digo identificador do n� da matr�cula.
--   destinatarioMensagem    = C�digo do destinat�rio da mensagem.
--	 assuntoMensagem         = Assunto da mensagem.
--	 prioridadeMensagem      = Prioridade da mensagem.
--	 conteudoMensagem        = Conte�do da mensagem.
--	 dataMensagem            = Data de envio.
--	 lidoMensagem            = C�digo identificador de lido e n�o lido.
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
-- Objetivo.....: Armazenar as mensagens de cada usu�rio.
-- Campos.......:
--	 FK_matriculaUsuario(PK, FK) = C�digo identificador do n� da matr�cula.
--	 FK_codigoMensagem(PK, FK)   = C�digo identificador da mensagem.
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