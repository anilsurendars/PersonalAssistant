CREATE TABLE [dbo].[Investment] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [InvestementTypeId] INT             NOT NULL,
    [Name]              VARCHAR (100)   NOT NULL,
    [Amount]            DECIMAL (18, 2) NOT NULL,
    [IntervalTypeId]    INT             NOT NULL,
    [StartDate]         DATETIME2 (7)   NOT NULL,
    [EndDate]           DATETIME2 (7)   NOT NULL,
    [DueDate]           DATETIME2 (7)   NOT NULL,
    [PaymentMode]       VARCHAR (20)    NOT NULL,
    [WebsiteId]         INT             NULL,
    [IsActive]          BIT             NOT NULL,
    [CreatedBy]         INT             NOT NULL,
    [CreatedOn]         DATETIME2 (7)   CONSTRAINT [DF_Investment_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]         INT             NULL,
    [UpdatedOn]         DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Investment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Investment_IntervalType] FOREIGN KEY ([IntervalTypeId]) REFERENCES [dbo].[IntervalType] ([Id]),
    CONSTRAINT [FK_Investment_InvestmentType] FOREIGN KEY ([InvestementTypeId]) REFERENCES [dbo].[InvestmentType] ([Id]),
    CONSTRAINT [FK_Investment_Website] FOREIGN KEY ([WebsiteId]) REFERENCES [dbo].[Website] ([Id])
);

