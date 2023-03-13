CREATE TABLE [dbo].[ContactType] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [ContactType] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

