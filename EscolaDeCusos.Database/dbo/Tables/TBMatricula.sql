CREATE TABLE [dbo].[TBMatricula] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [AlunoId]     UNIQUEIDENTIFIER NULL,
    [TurmaId]     UNIQUEIDENTIFIER NULL,
    [MatriculaId] UNIQUEIDENTIFIER NOT NULL
);
GO

ALTER TABLE [dbo].[TBMatricula]
    ADD CONSTRAINT [PK_TBMatricula] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[TBMatricula]
    ADD CONSTRAINT [FK_TBMatricula_TBAluno] FOREIGN KEY ([AlunoId]) REFERENCES [dbo].[TBAluno] ([Id]);
GO

ALTER TABLE [dbo].[TBMatricula]
    ADD CONSTRAINT [FK_TBMatricula_TBTurma] FOREIGN KEY ([TurmaId]) REFERENCES [dbo].[TBTurma] ([Id]);
GO

CREATE NONCLUSTERED INDEX [IX_TBMatricula_AlunoId]
    ON [dbo].[TBMatricula]([AlunoId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TBMatricula_TurmaId]
    ON [dbo].[TBMatricula]([TurmaId] ASC);
GO

