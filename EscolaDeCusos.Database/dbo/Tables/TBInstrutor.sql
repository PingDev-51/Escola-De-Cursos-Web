CREATE TABLE [dbo].[TBInstrutor] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Nome]      NVARCHAR (100)   NOT NULL,
    [Telefone]  NVARCHAR (20)    NOT NULL,
    [Email]     NVARCHAR (255)   NOT NULL,
    [Graduacao] NVARCHAR (100)   NOT NULL
);
GO

ALTER TABLE [dbo].[TBInstrutor]
    ADD CONSTRAINT [PK_TBInstruto] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_TBInstrutores_Telefone]
    ON [dbo].[TBInstrutor]([Telefone] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_TBInstrutores_Email]
    ON [dbo].[TBInstrutor]([Email] ASC);
GO

