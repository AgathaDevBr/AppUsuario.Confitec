-- Inserir valores na tabela Escolaridade
INSERT INTO [dbo].[Escolaridade] ([Escolaridade]) VALUES ('Infantil');
INSERT INTO [dbo].[Escolaridade] ([Escolaridade]) VALUES ('Fundamental');
INSERT INTO [dbo].[Escolaridade] ([Escolaridade]) VALUES ('Médio');
INSERT INTO [dbo].[Escolaridade] ([Escolaridade]) VALUES ('Superior');

DDL
CREATE TABLE Escolaridade (
    IdEscolaridade INT PRIMARY KEY,
    Escolaridade VARCHAR(40) NOT NULL
);

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY,
    Nome VARCHAR(10) NOT NULL,
    SobreNome VARCHAR(100) NOT NULL,
    Email VARCHAR(50) UNIQUE NOT NULL,
    DataNascimento DATE NOT NULL,
    IdEscolaridade INT,
    FOREIGN KEY (IdEscolaridade) REFERENCES Escolaridade(IdEscolaridade)
);


//Consulta dos 5 primeiros 
SELECT TOP 5
    U.IdUsuario,
    U.Nome,
    U.SobreNome,
    U.Email,
    U.DataNascimento
FROM Usuario U
INNER JOIN Escolaridade E ON U.IdEscolaridade = E.IdEscolaridade
WHERE E.Escolaridade = 'Superior';