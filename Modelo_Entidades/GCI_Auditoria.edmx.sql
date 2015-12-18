
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/23/2013 15:55:01
-- Generated from EDMX file: C:\Users\Pablo\Desktop\GCI\Modelo_Entidades\GCI_Auditoria.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GCI_Auditoria];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Auditorias_Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auditorias_Log];
GO
IF OBJECT_ID(N'[dbo].[Auditorias_Cuotas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auditorias_Cuotas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Auditorias_Log'
CREATE TABLE [dbo].[Auditorias_Log] (
    [id] int IDENTITY(1,1) NOT NULL,
    [usuario] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [accion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Auditorias_Cuotas'
CREATE TABLE [dbo].[Auditorias_Cuotas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [estado] bit  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [Profesional_dni] int  NOT NULL,
    [usuario] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [accion] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Auditorias_Log'
ALTER TABLE [dbo].[Auditorias_Log]
ADD CONSTRAINT [PK_Auditorias_Log]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Auditorias_Cuotas'
ALTER TABLE [dbo].[Auditorias_Cuotas]
ADD CONSTRAINT [PK_Auditorias_Cuotas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------