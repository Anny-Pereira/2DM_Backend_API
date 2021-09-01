USE M_Rental;
GO

INSERT INTO Empresa (NomeEmpresa)
VALUES ('Rental');
GO

INSERT INTO Cliente(NomeCliente, SobrenomeCliente)
VALUES ('Paulo', 'Brandão'), ('Bianca', 'Santos'), ('José', 'Rocha');
GO

INSERT INTO Veiculo(IdEmpresa, Placa)
VALUES (1, 'ABC 5588'), (1, 'CDD 1123'), (1, 'WDY 4576'), (1, 'TLU 2557'), (1, 'FFY 4662');
GO

INSERT INTO Modelo(IdVeiculo, NomeModelo, AnoModelo)
VALUES (4, 'Versa', 2019), (3, 'EcoSport', 2017), (5, 'Corsa', 2015), (1, 'Palio', 2015), (2, 'X1', 2020);
GO


UPDATE Modelo
SET AnoModelo = 2016
WHERE IdModelo = 4;
GO


INSERT INTO Marca(IdModelo, NomeMarca)
VALUES (2, 'Ford'), (4, 'Fiat'), (1, 'Nissan'), (3, 'GM'), (5, 'BMW');
GO


INSERT INTO Aluguel(IdVeiculo, IdCliente, DataAluguel, DataDevolucao)
VALUES (3, 2,  '2021-02-15','2021-03-19' ), (5, 3, '2021-05-30','2021-06-30' ), (1, 1,  '2021-07-23', '2021-08-25'), (2, 2, '2021-08-02', '2021-10-27');
GO
