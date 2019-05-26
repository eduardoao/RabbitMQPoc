USE [DataAccessContextDb]
GO

/****** Object: Table [dbo].[AplicationDomain] Script Date: 26/05/2019 17:18:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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


