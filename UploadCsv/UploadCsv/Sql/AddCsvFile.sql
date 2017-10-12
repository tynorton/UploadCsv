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
	@fileContent varbinary(MAX)
AS
	INSERT INTO dbo.CsvFile
	([FileName], [FileContent])
	VALUES
	(@fileName, @fileContent)
RETURN 0
