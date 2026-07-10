CREATE TABLE [dbo].[TBModulos] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [Nome]    NVARCHAR (100)   NOT NULL,
    [Duracao] INT              NOT NULL
);
GO

ALTER TABLE [dbo].[TBModulos]
    ADD CONSTRAINT [PK_TBModulos] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

