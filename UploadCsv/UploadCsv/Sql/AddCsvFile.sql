USE [CsvDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[AddCsvFile];


GO
CREATE PROCEDURE [dbo].[AddCsvFile]
	@fileName nvarchar(128),
	@fileContent varbinary(MAX),
    @fileModified datetime2
AS
	INSERT INTO dbo.CsvFile
	([FileName], [FileContent], [LastModified])
	VALUES
	(@fileName, @fileContent, @fileModified)
RETURN 0
