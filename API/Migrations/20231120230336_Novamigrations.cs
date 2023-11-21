using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Novamigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Concluida = table.Column<bool>(type: "INTEGER", nullable: false),
                    TextoAlternado = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "CriadoEm", "Nome" },
                values: new object[] { 1, new DateTime(2023, 11, 21, 20, 3, 36, 510, DateTimeKind.Local).AddTicks(2451), "Trabalho" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "CriadoEm", "Nome" },
                values: new object[] { 2, new DateTime(2023, 11, 22, 20, 3, 36, 510, DateTimeKind.Local).AddTicks(2455), "Estudos" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "CriadoEm", "Nome" },
                values: new object[] { 3, new DateTime(2023, 11, 23, 20, 3, 36, 510, DateTimeKind.Local).AddTicks(2456), "Lazer" });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "TarefaId", "CategoriaId", "Concluida", "CriadoEm", "Descricao", "TextoAlternado", "Titulo" },
                values: new object[] { 1, 1, false, new DateTime(2023, 11, 27, 20, 3, 36, 510, DateTimeKind.Local).AddTicks(2533), "Terminar relatório para reunião", "Em Andamento", "Concluir relatório" });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "TarefaId", "CategoriaId", "Concluida", "CriadoEm", "Descricao", "TextoAlternado", "Titulo" },
                values: new object[] { 2, 2, false, new DateTime(2023, 11, 23, 20, 3, 36, 510, DateTimeKind.Local).AddTicks(2535), "Preparar-se para a aula de Angular", "Em Andamento", "Estudar Angular" });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "TarefaId", "CategoriaId", "Concluida", "CriadoEm", "Descricao", "TextoAlternado", "Titulo" },
                values: new object[] { 3, 3, false, new DateTime(2023, 12, 4, 20, 3, 36, 510, DateTimeKind.Local).AddTicks(2537), "Dar um passeio relaxante no parque", "Em Andamento", "Passeio no parque" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
