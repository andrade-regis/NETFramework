CREATE DATABASE Agenda;
GO

USE Agenda;

-- Tabelas
CREATE TABLE Usuários (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Sobrenome NVARCHAR(255),
    Email NVARCHAR(255) NOT NULL,
    Senha NVARCHAR(32) NOT NULL,
    CONSTRAINT UQ_Usuários_Email UNIQUE (Email)
);

CREATE TABLE AgendasUsuários (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuárioId INT NOT NULL,
    Nome NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_AgendasUsuários_Usuários FOREIGN KEY (UsuárioId) REFERENCES Usuários(Id),
);

CREATE TABLE ContatosAgendas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AgendaUsuárioId INT NOT NULL,
    Nome NVARCHAR(100) NOT NULL,
    Sobrenome NVARCHAR(255),
    Email NVARCHAR(255),
    Endereço NVARCHAR(255),
    CONSTRAINT FK_ContatosAgendas_AgendasUsuários FOREIGN KEY (AgendaUsuárioId) REFERENCES AgendasUsuários(Id),
);

CREATE TABLE TelefonesContatos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ContatoAgendaId INT NOT NULL,
    Número NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_TelefonesContatos_ContatosAgendas FOREIGN KEY (ContatoAgendaId) REFERENCES ContatosAgendas(Id),
);
GO

-- Índices
CREATE INDEX IX_AgendasUsuários_UsuárioId ON AgendasUsuários(UsuárioId);
CREATE INDEX IX_ContatosAgendas_AgendaUsuárioId ON ContatosAgendas(AgendaUsuárioId);
CREATE INDEX IX_TelefonesContatos_ContatoAgendaId ON TelefonesContatos(ContatoAgendaId);
GO

-- Procedures

-- Usuários

CREATE PROCEDURE SP_Usuários_Adicionar
	@Id INT OUTPUT,
	@Nome NVARCHAR(100),
	@Sobrenome NVARCHAR(255),
	@Email NVARCHAR(255),
	@Senha NVARCHAR(32)
AS
BEGIN
	INSERT INTO Usuários
		(Nome, Sobrenome, Email, Senha)
	VALUES
		(@Nome, @Sobrenome, @Email, @Senha)
	
	SET @Id = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE SP_Usuários_Atualizar
	@Id INT,
	@Nome NVARCHAR(100),
	@Sobrenome NVARCHAR(255),
	@Email NVARCHAR(255),
	@Senha NVARCHAR(32)
AS
BEGIN
	UPDATE Usuários
	SET 
		Nome = @Nome,
		Sobrenome = @Sobrenome,
		Email = @Email,
		Senha = @Senha
	WHERE
		Id = @Id
END;
GO

CREATE PROCEDURE SP_Usuários_Remover
	@Id INT,
	@Nome NVARCHAR(100),
	@Email NVARCHAR(255)
AS
BEGIN
	DELETE FROM 
		Usuários
	WHERE
		Id = @Id AND
		Nome = @Nome AND
		Email = @Email
END;
GO

CREATE PROCEDURE SP_Usuários_Carregar_PorEmail_Senha
	@Email NVARCHAR(255),
	@Senha NVARCHAR(32)
AS
BEGIN
	SELECT
		*
	FROM Usuários
	WHERE
		Email = @Email AND
		Senha = @Senha
END;
GO

CREATE PROCEDURE SP_Usuários_Carregar_PorId
	@Id INT
AS
BEGIN
	SELECT
		*
	FROM Usuários
	WHERE
		Id = @Id
END;
GO

-- AgendasUsuários

CREATE PROCEDURE SP_AgendasUsuários_Adicionar
	@Id INT OUTPUT,
	@UsuárioId INT,
	@Nome NVARCHAR(100)
AS
BEGIN
	INSERT INTO AgendasUsuários
		(UsuárioId, Nome)
	VALUES
		(@UsuárioId, @Nome)
	
	SET @Id = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE SP_AgendasUsuários_Atualizar
	@Id INT,
	@UsuárioId INT,
	@Nome NVARCHAR(100)
AS
BEGIN
	UPDATE AgendasUsuários
	SET 
		UsuárioId = @UsuárioId,
		Nome = @Nome
	WHERE
		Id = @Id
END;
GO

CREATE PROCEDURE SP_AgendasUsuários_Remover
	@Id INT,
	@Nome NVARCHAR(100)
AS
BEGIN
	DELETE FROM 
		Usuários
	WHERE
		Id = @Id AND
		Nome = @Nome
END;
GO

CREATE PROCEDURE SP_AgendasUsuários_Carregar_PorUsuário
	@UsuárioId INT
AS
BEGIN
	SELECT 
		* 
	FROM AgendasUsuários
	WHERE
		UsuárioId = @UsuárioId
END;
GO

-- ContatosAgendas

CREATE PROCEDURE SP_ContatosAgendas_Adicionar
	@Id INT OUTPUT,
	@AgendaUsuárioId INT,
	@Nome NVARCHAR(100),
	@Sobrenome NVARCHAR(255),
	@Email NVARCHAR(255),
	@Endereço NVARCHAR(255)
AS
BEGIN
	INSERT INTO ContatosAgendas
		(AgendaUsuárioId, Nome, Sobrenome, Email, Endereço)
	VALUES
		(@AgendaUsuárioId, @Nome, @Sobrenome, @Email, @Endereço)
	
	SET @Id = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE SP_ContatosAgendas_Atualizar
	@Id INT,
	@AgendaUsuárioId INT,
	@Nome NVARCHAR(100),
	@Sobrenome NVARCHAR(255),
	@Email NVARCHAR(255),
	@Endereço NVARCHAR(255)
AS
BEGIN
	UPDATE ContatosAgendas
	SET 
		AgendaUsuárioId = @AgendaUsuárioId,
		Nome = @Nome,
		Sobrenome = @Sobrenome,
		Email = @Email,
		Endereço = @Endereço
	WHERE
		Id = @Id
END;
GO

CREATE PROCEDURE SP_ContatosAgendas_Remover
	@Id INT,
	@Nome NVARCHAR(100)
AS
BEGIN
	DELETE FROM ContatosAgendas
	WHERE
		Id = @Id AND
		Nome = @Nome
END;
GO

CREATE PROCEDURE SP_ContatosAgendas_Carregar_PorAgendaUsuário
	@AgendaUsuárioId NVARCHAR(255)
AS
BEGIN
	SELECT
		*
	FROM ContatosAgendas
	WHERE
		AgendaUsuárioId = @AgendaUsuárioId
END;
GO

CREATE PROCEDURE SP_ContatosAgendas_Carregar_PorId
	@Id INT
AS
BEGIN
	SELECT
		*
	FROM ContatosAgendas
	WHERE
		Id = @Id
END;
GO

-- TelefonesContatos

CREATE PROCEDURE SP_TelefonesContatos_Adicionar
	@Id INT OUTPUT,
	@ContatoAgendaId INT,
	@Número NVARCHAR(20)
AS
BEGIN
	INSERT INTO TelefonesContatos
		(ContatoAgendaId, Número)
	VALUES
		(@ContatoAgendaId, @Número)
	
	SET
		@Id	= SCOPE_IDENTITY()
END;
GO

CREATE PROCEDURE SP_TelefonesContatos_Atualizar
	@Id INT,
	@ContatoAgendaId INT,
	@Número NVARCHAR(20)
AS
BEGIN
	UPDATE TelefonesContatos
	SET
		ContatoAgendaId = @ContatoAgendaId,
		Número = @Número
	WHERE
		Id = @Id
END;
GO

CREATE PROCEDURE SP_TelefonesContatos_Remover
	@Id INT,
	@Número NVARCHAR(20)
AS
BEGIN
	DELETE FROM TelefonesContatos
	WHERE Id = @Id AND
		  Número = @Número
END;
GO

CREATE PROCEDURE SP_TelefonesContatos_Carregar_PorContatoAgenda
	@ContatoAgendaId INT
AS
BEGIN
	SELECT 
		* 
	FROM TelefonesContatos
	WHERE
		ContatoAgendaId = @ContatoAgendaId
END;
GO

CREATE PROCEDURE SP_TelefonesContatos_Carregar_PorId
	@Id INT
AS
BEGIN
	SELECT
		*
	FROM TelefonesContatos
	WHERE
		Id = @Id
END;
GO

-- Triggers
CREATE TRIGGER TR_Usuários_Insert
ON Usuários
AFTER INSERT
AS
BEGIN
    INSERT INTO AgendasUsuários (UsuárioId, Nome)
    SELECT Id, 'Pessoal'
    FROM inserted;
    INSERT INTO AgendasUsuários (UsuárioId, Nome)
    SELECT Id, 'Profissional'
    FROM inserted;
END;
GO