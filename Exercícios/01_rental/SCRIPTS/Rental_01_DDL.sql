CREATE DATABASE M_Rental;
GO

USE M_Rental;
GO

CREATE TABLE Empresa(
IdEmpresa INT PRIMARY KEY IDENTITY(1,1),
NomeEmpresa VARCHAR(30)
);
GO

CREATE TABLE Marca(
IdMarca INT PRIMARY KEY IDENTITY(1,1),
NomeMarca VARCHAR(20) NOT NULL
);
GO

CREATE TABLE Modelo(
IdModelo INT PRIMARY KEY IDENTITY(1,1),
Idmarca INT Foreign KEY REFERENCES Marca(IdMarca),
NomeModelo VARCHAR(20),
AnoModelo INT 
);
GO

CREATE TABLE Veiculo(
IdVeiculo INT PRIMARY KEY IDENTITY(1,1),
IdEmpresa INT Foreign KEY REFERENCES Empresa(IdEmpresa),
IdModelo INT Foreign KEY REFERENCES Modelo(IdModelo),
Placa VARCHAR(10)
);
GO


CREATE TABLE Cliente(
IdCliente INT PRIMARY KEY IDENTITY(1,1),
NomeCliente VARCHAR(30) NOT NULL,
SobrenomeCliente VARCHAR(40) NOT NULL,
DataNascimento DATE
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
