CREATE TABLE [dbo].[TBAluno] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Nome]     NVARCHAR (100)   NOT NULL,
    [Telefone] NVARCHAR (20)    NOT NULL,
    [Email]    NVARCHAR (255)   NOT NULL
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_TBAluno_Telefone]
    ON [dbo].[TBAluno]([Telefone] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_TBAluno_Email]
    ON [dbo].[TBAluno]([Email] ASC);
GO

ALTER TABLE [dbo].[TBAluno]
    ADD CONSTRAINT [PK_TBAluno] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

