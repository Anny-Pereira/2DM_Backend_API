USE M_Rental;
GO

INSERT INTO Empresa (NomeEmpresa)
VALUES ('Rental');
GO

INSERT INTO Cliente(NomeCliente, SobrenomeCliente, DataNascimento)
VALUES ('Paulo', 'Brandão', '1985-05-12'), ('Bianca', 'Santos', '1990-10-20'), ('José', 'Rocha', '1989-01-30');
GO


INSERT INTO Marca(NomeMarca)
VALUES ( 'Ford'), ('Fiat'), ( 'Nissan'), ('GM'), ('BMW');
GO


INSERT INTO Modelo(IdMarca, NomeModelo, AnoModelo)
VALUES (3, 'Versa', 2019), (1, 'EcoSport', 2017), (4, 'Corsa', 2015), (2, 'Palio', 2015), (5, 'X1', 2020);
GO


UPDATE Modelo
SET AnoModelo = 2016
WHERE IdModelo = 4;
GO


INSERT INTO Veiculo(IdEmpresa, IdModelo, Placa)
VALUES (1, 4, 'ABC 5588'), (1, 5, 'CDD 1123'), (1, 2, 'WDY 4576'), (1, 1, 'TLU 2557'), (1, 3, 'FFY 4662');
GO



INSERT INTO Aluguel(IdVeiculo, IdCliente, DataAluguel, DataDevolucao)
VALUES (4, 2,  '2021-02-15','2021-03-19' ), (6, 3, '2021-05-30','2021-06-30' ), (2, 1,  '2021-07-23', '2021-08-25'), (3, 2, '2021-08-02', '2021-10-27');
GO
