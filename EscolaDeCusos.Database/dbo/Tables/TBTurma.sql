CREATE TABLE [dbo].[TBTurma] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Nome]              NVARCHAR (100)   NOT NULL,
    [InstrutorId]       UNIQUEIDENTIFIER NULL,
    [NumeroMaxDeAlunos] NVARCHAR (100)   NOT NULL,
    [CursoId]           UNIQUEIDENTIFIER NULL,
    [DataInicio]        DATE             NOT NULL,
    [DataTermino]       DATE             NOT NULL
);
GO

CREATE NONCLUSTERED INDEX [IX_TBTurma_CursoId]
    ON [dbo].[TBTurma]([CursoId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TBTurma_InstrutorId]
    ON [dbo].[TBTurma]([InstrutorId] ASC);
GO

ALTER TABLE [dbo].[TBTurma]
    ADD CONSTRAINT [FK__TBTurma_TBCurso] FOREIGN KEY ([CursoId]) REFERENCES [dbo].[TBCurso] ([Id]);
GO

ALTER TABLE [dbo].[TBTurma]
    ADD CONSTRAINT [FK__TBTurma_TBInstrutor] FOREIGN KEY ([InstrutorId]) REFERENCES [dbo].[TBInstrutor] ([Id]);
GO

ALTER TABLE [dbo].[TBTurma]
    ADD CONSTRAINT [PK_TBTurma] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

