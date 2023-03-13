CREATE TABLE [dbo].[InvestmentType] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [InvestmentType] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_InvestmentType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

