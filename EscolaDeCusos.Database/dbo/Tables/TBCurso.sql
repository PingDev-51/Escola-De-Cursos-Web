CREATE TABLE [dbo].[TBCurso] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         NVARCHAR (100)   NOT NULL,
    [Nivel]        INT              NOT NULL,
    [CargaHoraria] INT              NOT NULL,
    [ModuloId]     UNIQUEIDENTIFIER NULL,
    [CategoriaId]  UNIQUEIDENTIFIER NULL
);
GO

CREATE NONCLUSTERED INDEX [IX_TBCurso_CategoriaId]
    ON [dbo].[TBCurso]([CategoriaId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TBCurso_ModuloId]
    ON [dbo].[TBCurso]([ModuloId] ASC);
GO

ALTER TABLE [dbo].[TBCurso]
    ADD CONSTRAINT [FK_TBCurso_TBModulo] FOREIGN KEY ([ModuloId]) REFERENCES [dbo].[TBModulos] ([Id]);
GO

ALTER TABLE [dbo].[TBCurso]
    ADD CONSTRAINT [FK_TBCurso_TBCategoria] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[TBCategoria] ([Id]);
GO

ALTER TABLE [dbo].[TBCurso]
    ADD CONSTRAINT [PK_TBCurso] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

