# NewsPortal API

## Create a database with the name 'NewsPortalDb'

## Execute below table scripts

CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL CONSTRAINT PK_Categories PRIMARY KEY IDENTITY(1,1),
	[Title] NVARCHAR(50) NOT NULL CONSTRAINT UK_Categories_Title UNIQUE
)

CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT NULL CONSTRAINT PK_Articles PRIMARY KEY IDENTITY(1,1),
	[Title] NVARCHAR(250) NOT NULL,
	[CategoryId] INT NOT NULL CONSTRAINT FK_Articles_CategoryId FOREIGN KEY REFERENCES [dbo].[Categories] ([Id]),
	[Description] NVARCHAR(MAX) NOT NULL,
	[CreatedDateTimeUtc] DATETIME NOT NULL
)

