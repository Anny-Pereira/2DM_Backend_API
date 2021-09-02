USE M_Rental;
GO

SELECT * FROM Empresa;
GO

SELECT * FROM Cliente;
GO

SELECT * FROM Veiculo;
GO

SELECT * FROM MODELO;
GO

SELECT * FROM Marca;
GO

SELECT * FROM Aluguel;
GO

--- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
SELECT IdAluguel, NomeCliente, NomeModelo, DataAluguel, DataDevolucao
FROM Aluguel
LEFT JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
LEFT JOIN Modelo
ON Aluguel.IdVeiculo = Modelo.IdVeiculo;
GO



--- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
SELECT IdAluguel,Cliente.NomeCliente, NomeModelo, DataAluguel, DataDevolucao
FROM Aluguel
LEFT JOIN Modelo
ON Aluguel.IdVeiculo = Modelo.IdVeiculo
FULL OUTER JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
WHERE Aluguel.IdCliente = 2
GO


SELECT idVeiculo, placa, nomeModelo FROM Veiculo LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo

SELECT idVeiculo, idEmpresa , placa, nomeModelo FROM Veiculo LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo   WHERE idVeiculo = 4

SELECT idVeiculo, placa, nomeModelo, veiculo.idModelo FROM Veiculo LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo