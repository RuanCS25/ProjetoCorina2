using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCorina2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Classificacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classificacoes",
                columns: table => new
                {
                    ClassificacoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacoes", x => x.ClassificacoeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classificacoes");
        }
    }
}
