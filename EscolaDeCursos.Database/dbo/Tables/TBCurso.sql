CREATE TABLE [dbo].[TBCurso] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         NVARCHAR (100)   NOT NULL,
    [Nivel]        INT              NOT NULL,
    [CargaHoraria] INT              NOT NULL,
    [ModuloId]     UNIQUEIDENTIFIER NULL
);
GO

ALTER TABLE [dbo].[TBCurso]
    ADD CONSTRAINT [PK_TBCurso] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[TBCurso]
    ADD CONSTRAINT [FK_TBCurso_TBModulo] FOREIGN KEY ([ModuloId]) REFERENCES [dbo].[TBModulos] ([Id]);
GO

CREATE NONCLUSTERED INDEX [IX_TBCurso_ModuloId]
    ON [dbo].[TBCurso]([ModuloId] ASC);
GO

