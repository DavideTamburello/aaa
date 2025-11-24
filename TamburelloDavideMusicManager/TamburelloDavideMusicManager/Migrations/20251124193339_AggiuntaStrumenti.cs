using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TamburelloDavideMusicManager.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaStrumenti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abilita",
                columns: table => new
                {
                    CantanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    StrumentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Livello = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilita", x => new { x.CantanteId, x.StrumentoId });
                    table.ForeignKey(
                        name: "FK_Abilita_Cantanti_CantanteId",
                        column: x => x.CantanteId,
                        principalTable: "Cantanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abilita_Strumento_StrumentoId",
                        column: x => x.StrumentoId,
                        principalTable: "Strumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilita_StrumentoId",
                table: "Abilita",
                column: "StrumentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilita");

            migrationBuilder.DropTable(
                name: "Strumento");
        }
    }
}
