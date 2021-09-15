USE CATALOGO;
GO

INSERT INTO Genero(NomeGenero)
VALUES ('Ação'),('Comédia')
GO

DELETE FROM Genero
WHERE IdGenero in (3,4);
GO

INSERT INTO Genero(NomeGenero)
VALUES ('Drama');
GO

INSERT INTO Filme (IdGenero, TituloFilme)
VALUES (5, 'Como eu era antes de você'), (5, 'Sempre ao seu lado'), (1, 'Jonh Wick');
GO

INSERT INTO Filme (IdGenero, TituloFilme)
VALUES(2, 'Até que a sorte nos separe');
GO

INSERT INTO Filme ( TituloFilme)
VALUES( 'HER');
GO

INSERT INTO Genero(NomeGenero)
VALUES ('Aventura');
GO

INSERT INTO Usuario(email, senha, permissao)
VALUES ('saulo@email.com', '123', 'Administrador'),('lucas@email.com','123','Comum');
GO