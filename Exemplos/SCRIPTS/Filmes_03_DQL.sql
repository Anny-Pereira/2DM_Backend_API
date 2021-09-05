USE CATALOGO;
GO

SELECT * FROM Genero
GO

SELECT * FROM Filme;
GO


/*
	ESTRUTURA DO JOIN
	SELECT nomeCampo1, nomeCampo2
	FROM tabela1
	TIPO_JOIN tabela2
	ON tabela1.campo1 = tabela2.campo2
	
	obs.: tabela1.campo1 é a PK da tabela1
	      tabela2.campo2 é a FK da tabela2 (ou vice-versa)
*/


-- SELECIONAR TODOS OS FILMES E OS GÊNEROS RELACIONADOS (sem Id)
-- LEFT JOIN
SELECT IdFilme, TituloFilme, nomeGenero FROM Filme
LEFT JOIN GENERO
ON FILME.IdGenero = GENERO.idGenero;


-- SELECIONAR SOMENTE OS FILMES QUE POSSUEM RELAÇÃO COM GÊNERO 
-- E OS TODOS OS OUTROS GÊNEROS 
-- RIGHT JOIN
SELECT IdFilme, TituloFilme, NomeGenero
FROM FILME
RIGHT JOIN GENERO
ON FILME.IdGenero = GENERO.IdGenero;



-- SELECIONAR SOMENTE OS FILMES QUE POSSUEM RELAÇÃO COM GÊNERO
-- INNER JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
INNER JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;



-- SELECIONAR TODOS OS FILMES E TODOS OS GÊNEROS
-- MESMO QUE NÃO HAJA CORRESPONDÊNCIA
-- FULL OUTER JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
FULL OUTER JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;

SELECT idFilme, tituloFilme, ISNULL (Genero.NomeGenero, 'Sem gênero') nomeGenero
FROM Filme LEFT JOIN Genero 
ON FILME.idGenero = GENERO.idGenero;
GO
