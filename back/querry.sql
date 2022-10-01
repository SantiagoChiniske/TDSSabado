USE MASTER
GO

IF EXISTS(SELECT * FROM sys.databases WHERE NAME ='TDSabado')
	DROP DATABASE TDSabado
go 

CREATE DATABASE TDSabado
go

USE TDSabado
go

CREATE TABLE Usuario(
	ID INT IDENTITY PRIMARY KEY,
	Nome VARCHAR (60)not null,
	DataNascimento DATE not null,
	UserId VARCHAR (60) not null,
	Senha VARCHAR(MAX) not null
);
go

CREATE TABLE Token(
	ID INT Identity primary key,
	UserID INT REFERENCES Usuario (ID),
	Value VARCHAR (MAX) not null
	);
GO

CREATE TABLE Post(
	ID INT Identity PRIMARY KEY ,
	UserID INT REFERENCES Usuario (ID),
	Moment datetime not null,
	Content varchar (max) not null
);
go

CREATE TABLE PostImage(
	ID INT Identity PRIMARY KEY ,
	PostID Int REFERENCES Post(ID),
	Bytes image not null
);
GO

CREATE TABLE Likes(
	ID INT Identity PRIMARY KEY ,
	PostID Int REFERENCES Post(ID),
	UserID INT REFERENCES Usuario (ID)
);
GO

CREATE TABLE Follow(
	ID INT Identity PRIMARY KEY ,
	FollowedID Int REFERENCES Usuario(ID),
	FollowerID INT REFERENCES Usuario (ID)
);
GO

SELECT* FROM Usuario