USE [DataAccessContextDb]
GO

/****** Object: Table [dbo].[AplicationDomain] Script Date: 24/05/2019 16:04:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[AplicationDomain];


GO
CREATE TABLE [dbo].[AplicationDomain] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ServiceName]        NVARCHAR (MAX) NULL,
    [ServiceDisplayName] NVARCHAR (MAX) NULL,
    [ServiceType]        INT            NOT NULL,
    [Status]             INT            NOT NULL,
    [MachiName]          NVARCHAR (MAX) NULL,
    [DateTimeUtc]        DATETIME       NOT NULL
);


