
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/27/2014 16:10:32
-- Generated from EDMX file: C:\_\src\Neumont\CSC160-SC\DataPersistenceEF\DataPersistenceEF\ContactModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlakeIsCool];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ContactEFs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactEFs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ContactEFs'
CREATE TABLE [dbo].[ContactEFs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Group] int  NOT NULL,
    [EmailAddressHome] nvarchar(max)  NULL,
    [EmailAddressWork] nvarchar(max)  NULL,
    [PhoneNumberHome] nvarchar(max)  NULL,
    [PhoneNumberWork] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ContactEFs'
ALTER TABLE [dbo].[ContactEFs]
ADD CONSTRAINT [PK_ContactEFs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------