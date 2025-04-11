using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCorina2.Data.Migrations
{
    /// <inheritdoc />
    public partial class TipoUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    TipoUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.TipoUsuarioId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}
