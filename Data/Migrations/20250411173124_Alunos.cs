using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCorina2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Alunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassificacoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HorarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Alunos_Classificacoes_ClassificacoeId",
                        column: x => x.ClassificacoeId,
                        principalTable: "Classificacoes",
                        principalColumn: "ClassificacoeId");
                    table.ForeignKey(
                        name: "FK_Alunos_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ClassificacoeId",
                table: "Alunos",
                column: "ClassificacoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_HorarioId",
                table: "Alunos",
                column: "HorarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
