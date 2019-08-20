CREATE DATABASE Shop;

USE Shop;

CREATE TABLE [dbo].[Categories]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR(100) NOT NULL 
);

CREATE TABLE [dbo].[Products]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	[Price] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	FOREIGN KEY (CategoryId) REFERENCES [dbo].[Categories] (Id)
);

INSERT INTO [dbo].[Categories] (Name) 
VALUES  ('Category1'), ('Category2'), ('Category3');

INSERT INTO [dbo].[Products] (Name, Price, CategoryId)
VALUES 
	('Product1', 100, 1),
	('Product2', 200, 2),
	('Product3', 300, 3),
	('Product4', 400, 1);