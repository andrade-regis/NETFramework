CREATE DATABASE Agenda;
GO

USE Agenda;

-- Tabelas
CREATE TABLE Usu�rios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Sobrenome NVARCHAR(255),
    Email NVARCHAR(255) NOT NULL,
    Senha NVARCHAR(32) NOT NULL,
    CONSTRAINT UQ_Usu�rios_Email UNIQUE (Email)
);

CREATE TABLE AgendasUsu�rios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usu�rioId INT NOT NULL,
    Nome NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_AgendasUsu�rios_Usu�rios FOREIGN KEY (Usu�rioId) REFERENCES Usu�rios(Id),
);

CREATE TABLE ContatosAgendas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AgendaUsu�rioId INT NOT NULL,
    Nome NVARCHAR(100) NOT NULL,
    Sobrenome NVARCHAR(255),
    Email NVARCHAR(255),
    Endere�o NVARCHAR(255),
    CONSTRAINT FK_ContatosAgendas_AgendasUsu�rios FOREIGN KEY (AgendaUsu�rioId) REFERENCES AgendasUsu�rios(Id),
);

CREATE TABLE TelefonesContatos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ContatoAgendaId INT NOT NULL,
    N�mero NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_TelefonesContatos_ContatosAgendas FOREIGN KEY (ContatoAgendaId) REFERENCES ContatosAgendas(Id),
);
GO

-- �ndices
CREATE INDEX IX_AgendasUsu�rios_Usu�rioId ON AgendasUsu�rios(Usu�rioId);
CREATE INDEX IX_ContatosAgendas_AgendaUsu�rioId ON ContatosAgendas(AgendaUsu�rioId);
CREATE INDEX IX_TelefonesContatos_ContatoAgendaId ON TelefonesContatos(ContatoAgendaId);
GO

-- Triggers
CREATE TRIGGER TR_Usu�rios_Insert
ON Usu�rios
AFTER INSERT
AS
BEGIN
    INSERT INTO AgendasUsu�rios (Usu�rioId, Nome)
    SELECT Id, 'Pessoal'
    FROM inserted;
    INSERT INTO AgendasUsu�rios (Usu�rioId, Nome)
    SELECT Id, 'Profissional'
    FROM inserted;
END;
