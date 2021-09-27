CREATE DATABASE M_Rental;
GO

USE M_Rental;
GO

CREATE TABLE Empresas 
(	
    IdEmpresa   INT PRIMARY KEY IDENTITY
    ,NomeEmpresa       VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE Marcas
(
    IdMarca		INT PRIMARY KEY IDENTITY
    ,NomeMarca		VARCHAR(200) UNIQUE
);
GO

CREATE TABLE Modelos
(
    IdModelo	INT PRIMARY KEY IDENTITY
    ,Descricao  VARCHAR(200) UNIQUE
    ,IdMarca    INT FOREIGN KEY REFERENCES Marcas (IdMarca)
);
GO

CREATE TABLE Veiculos
(
    IdVeiculo   INT PRIMARY KEY IDENTITY
    ,IdModelo   INT FOREIGN KEY REFERENCES Modelos (IdModelo)
    ,Placa	    VARCHAR(200) UNIQUE
	,IdEmpresa	INT FOREIGN KEY REFERENCES Empresas (IdEmpresa)
);
GO

CREATE TABLE Clientes
(
    IdCliente   INT PRIMARY KEY IDENTITY
    ,Nome	    VARCHAR(200)
	,Sobrenome  VARCHAR(200)
	,CPF		VARCHAR(200) UNIQUE
);
GO

CREATE TABLE Alugueis
(
    IdAluguel   INT PRIMARY KEY IDENTITY
    ,IdCliente	INT FOREIGN KEY REFERENCES Clientes (IdCliente)
	,IdVeiculo	INT FOREIGN KEY REFERENCES Veiculos (IdVeiculo)
	,DataInicio DATE NOT NULL
	,DataFim	DATE NOT NULL
);
GO