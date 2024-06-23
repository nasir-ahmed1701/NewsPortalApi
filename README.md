# NewsPortal API

## Create a database with the name 'NewsPortalDb'

~~~~
CREATE DATABASE NewsPortalDb
~~~~

## Execute below table scripts

~~~~
USE [NewsPortalDb]

CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL CONSTRAINT PK_Categories PRIMARY KEY IDENTITY(1,1),
	[Title] NVARCHAR(50) NOT NULL CONSTRAINT UK_Categories_Title UNIQUE
)
GO

CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT NULL CONSTRAINT PK_Articles PRIMARY KEY IDENTITY(1,1),
	[Title] NVARCHAR(250) NOT NULL,
	[CategoryId] INT NOT NULL CONSTRAINT FK_Articles_CategoryId FOREIGN KEY REFERENCES [dbo].[Categories] ([Id]),
	[Description] NVARCHAR(MAX) NOT NULL,
	[CreatedDateTimeUtc] DATETIME NOT NULL
)
GO
~~~~

## Execute the below data scripts for `Categories` table

~~~~
SET IDENTITY_INSERT [dbo].[Categories] ON;

INSERT INTO [dbo].[Categories] (Id,Title) 
VALUES
	(1, 'Sports'),
	(2, 'Politics'),
	(3, 'Business'),
	(4, 'Entertainment')

SET IDENTITY_INSERT [dbo].[Categories] OFF;
~~~~

## Execute the below data scripts for `Articles` table

~~~~
SET IDENTITY_INSERT [dbo].[Articles] ON;

INSERT INTO [dbo].[Articles] (Id,Title,CategoryId,Description,CreatedDateTimeUtc) 
VALUES
	(1, N'Susie Wolff is upending F1’s ‘boys club’ with an all-female racing empire',1,N'Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview.',N'2024-06-23T14:30:00'),
	(2, N'Avi-Yonah: Is A Mark To Market Tax Constitutional After Moore?',2,N'TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax',N'2024-06-23T14:31:00'),
	(3, N'Elon Musk claims there are ‘far more’ smart, hardworking people in China than in the US',2,N'Should you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the USShould you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the US',N'2024-06-23T14:32:00'),
	(4, N'Test 1 is upending F1’s ‘boys club’ with an all-female racing empire',1,N'Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview.',N'2024-06-23T14:33:00'),
	(5, N'Test 2 Avi-Yonah: Is A Mark To Market Tax Constitutional After Moore?',2,N'TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax',N'2024-06-23T14:34:00'),
	(6, N'Test 3 Elon Musk claims there are ‘far more’ smart, hardworking people in China than in the US',2,N'Should you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the USShould you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the US',N'2024-06-23T14:36:00'),
	(7, N'Test 4 is upending F1’s ‘boys club’ with an all-female racing empire',1,N'Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview.',N'2024-06-23T14:37:00'),
	(8, N'Test 5 Avi-Yonah: Is A Mark To Market Tax Constitutional After Moore?',2,N'TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax',N'2024-06-23T14:38:00'),
	(9, N'Test 6 Elon Musk claims there are ‘far more’ smart, hardworking people in China than in the US',2,N'Should you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the USShould you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the US',N'2024-06-23T14:38:00'),
	(10, N'Test 7 is upending F1’s ‘boys club’ with an all-female racing empire',1,N'Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview. Formula 1 has a problem.The high-speed racing league has been described as a boys club, Susie Wolff, the former driver and current F1 Academy managing director told Fortune in a recent interview.',N'2024-06-23T14:39:00'),
	(11, N'Test 8 Avi-Yonah: Is A Mark To Market Tax Constitutional After Moore?',2,N'TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax TaxProf Blog Op-Ed: Is a Mark to Market Tax Constitutional After Moore?, by Reuven S. Avi-Yonah (Michigan; Google Scholar): The main reason the Supreme Court granted certiorari in Moore was not to debate the constitutionality of the Mandatory Repatriation Tax',N'2024-06-23T14:40:00'),
	(12, N'Test 9 Elon Musk claims there are ‘far more’ smart, hardworking people in China than in the US',2,N'Should you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the USShould you turn your attention to the worlds second largest economy? Elon Musk claims there are far more smart, hardworking people in China than in the US Elon Musk claims there are far more smart, hardworking people in China than in the US',N'2024-06-23T14:45:00')
	

SET IDENTITY_INSERT [dbo].[Articles] OFF;
~~~~

