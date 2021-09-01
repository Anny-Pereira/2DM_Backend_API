CREATE DATABASE M_Rental;
GO

USE M_Rental;
GO

CREATE TABLE Empresa(
IdEmpresa INT PRIMARY KEY IDENTITY(1,1),
NomeEmpresa VARCHAR(30)
);
GO

CREATE TABLE Veiculo(
IdVeiculo INT PRIMARY KEY IDENTITY(1,1),
IdEmpresa INT Foreign KEY REFERENCES Empresa(IdEmpresa),
Placa VARCHAR(10)
);
GO

CREATE TABLE Modelo(
IdModelo INT PRIMARY KEY IDENTITY(1,1),
IdVeiculo INT Foreign KEY REFERENCES Veiculo(IdVeiculo),
NomeModelo VARCHAR(20),
AnoModelo INT 
);
GO


CREATE TABLE Marca(
IdMarca INT PRIMARY KEY IDENTITY(1,1),
IdModelo INT Foreign KEY REFERENCES Modelo(IdModelo),
NomeMarca VARCHAR(20) NOT NULL
);
GO

CREATE TABLE Cliente(
IdCliente INT PRIMARY KEY IDENTITY(1,1),
NomeCliente VARCHAR(30) NOT NULL,
SobrenomeCliente VARCHAR(40) NOT NULL
);
GO

CREATE TABLE Aluguel(
IdAluguel INT PRIMARY KEY IDENTITY(1,1),
IdVeiculo INT Foreign KEY REFERENCES Veiculo(IdVeiculo),
IdCliente INT Foreign KEY REFERENCES Cliente(IdCliente),
DataAluguel DATE,
DataDevolucao DATE
);
GO
