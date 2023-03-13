CREATE TABLE [dbo].[Website] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [WebsiteName] VARCHAR (100)  NOT NULL,
    [Url]         VARCHAR (1000) NOT NULL,
    [UserName]    VARCHAR (150)  NOT NULL,
    [Password]    VARCHAR (150)  NOT NULL,
    [IsActive]    BIT            NOT NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedOn]   DATETIME2 (7)  CONSTRAINT [DF_Website_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedOn]   DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Website] PRIMARY KEY CLUSTERED ([Id] ASC)
);

