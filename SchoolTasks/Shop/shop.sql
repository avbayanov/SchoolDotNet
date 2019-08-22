CREATE DATABASE Shop;

GO
USE Shop;

CREATE TABLE [dbo].[Categories]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL 
);

CREATE TABLE [dbo].[Products]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Price] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	FOREIGN KEY (CategoryId) REFERENCES [dbo].[Categories] (Id)
);

INSERT INTO [dbo].[Categories] (Name) 
VALUES  (N'Category1'), (N'Category2'), (N'Category3');

INSERT INTO [dbo].[Products] (Name, Price, CategoryId)
VALUES 
	(N'Product1', 100, 1),
	(N'Product2', 200, 2),
	(N'Product3', 300, 3),
	(N'Product4', 400, 1);