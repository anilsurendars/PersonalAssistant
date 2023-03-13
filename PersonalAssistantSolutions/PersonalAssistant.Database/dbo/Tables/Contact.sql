CREATE TABLE [dbo].[Contact] (
    [Id]                    INT           IDENTITY (1, 1) NOT NULL,
    [ContactTypeId]         INT           NOT NULL,
    [MemberName]            VARCHAR (100) NOT NULL,
    [EmailAddress]          VARCHAR (100) NULL,
    [ContactNumber]         VARCHAR (50)  NOT NULL,
    [PersonalContactNumber] VARCHAR (50)  NULL,
    [IsActive]              BIT           NOT NULL,
    [CreatedBy]             INT           NOT NULL,
    [CreatedOn]             DATETIME2 (7) CONSTRAINT [DF_Contact_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]             INT           NULL,
    [UpdatedOn]             DATETIME2 (7) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contact_ContactType] FOREIGN KEY ([ContactTypeId]) REFERENCES [dbo].[ContactType] ([Id])
);

