using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCorina2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Aviso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPresencas_Alunos_AlunoId",
                table: "RegistroPresencas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistroPresencas",
                table: "RegistroPresencas");

            migrationBuilder.RenameTable(
                name: "RegistroPresencas",
                newName: "RegPresenca");

            migrationBuilder.RenameIndex(
                name: "IX_RegistroPresencas_AlunoId",
                table: "RegPresenca",
                newName: "IX_RegPresenca_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegPresenca",
                table: "RegPresenca",
                column: "RegPresencaId");

            migrationBuilder.CreateTable(
                name: "Avisos",
                columns: table => new
                {
                    AvisoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avisos", x => x.AvisoId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RegPresenca_Alunos_AlunoId",
                table: "RegPresenca",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegPresenca_Alunos_AlunoId",
                table: "RegPresenca");

            migrationBuilder.DropTable(
                name: "Avisos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegPresenca",
                table: "RegPresenca");

            migrationBuilder.RenameTable(
                name: "RegPresenca",
                newName: "RegistroPresencas");

            migrationBuilder.RenameIndex(
                name: "IX_RegPresenca_AlunoId",
                table: "RegistroPresencas",
                newName: "IX_RegistroPresencas_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistroPresencas",
                table: "RegistroPresencas",
                column: "RegPresencaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPresencas_Alunos_AlunoId",
                table: "RegistroPresencas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
