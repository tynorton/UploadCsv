﻿USE [CsvDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[CsvFile];


GO
CREATE TABLE [dbo].[CsvFile] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FileName]     NVARCHAR (128)  NOT NULL,
    [LastModified] DATETIME        NOT NULL,
    [FileContent]  VARBINARY (MAX) NOT NULL
);


