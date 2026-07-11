using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migration
{
    /// <inheritdoc />
    public partial class ConfigModulos : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBInstrutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Graduacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBInstruto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBModulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duracao = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBModulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCurso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    ModuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCurso_TBModulo",
                        column: x => x.ModuloId,
                        principalTable: "TBModulos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBTurma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstrutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumeroMaxDeAlunos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTurma", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TBTurma_TBCurso",
                        column: x => x.CursoId,
                        principalTable: "TBCurso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__TBTurma_TBInstrutor",
                        column: x => x.InstrutorId,
                        principalTable: "TBInstrutor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCurso_ModuloId",
                table: "TBCurso",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutores_Email",
                table: "TBInstrutor",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutores_Telefone",
                table: "TBInstrutor",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBTurma_CursoId",
                table: "TBTurma",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTurma_InstrutorId",
                table: "TBTurma",
                column: "InstrutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTurma");

            migrationBuilder.DropTable(
                name: "TBCurso");

            migrationBuilder.DropTable(
                name: "TBInstrutor");

            migrationBuilder.DropTable(
                name: "TBModulos");
        }
    }
}
