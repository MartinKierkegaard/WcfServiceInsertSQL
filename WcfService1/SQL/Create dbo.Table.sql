USE [HotelDB]
GO

/****** Object: Table [dbo].[Table] Script Date: 04-04-2018 13:55:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[volumen1] (
    [Id]   INT           IDENTITY (10, 100) NOT NULL,
    [request] NVARCHAR (50) NULL,
    [volume] NVARCHAR (50) NULL,
    [length] NVARCHAR (50) NULL,
    [width] NVARCHAR (50) NULL,
    [height] NVARCHAR (50) NULL,
);


