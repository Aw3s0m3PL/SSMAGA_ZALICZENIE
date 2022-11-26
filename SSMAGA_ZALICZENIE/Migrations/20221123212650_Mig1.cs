using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSMAGAZALICZENIE.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "varchar(50)", nullable: false),
                    IlOs = table.Column<int>(name: "Il_Os", type: "int", nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Zdjecie = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uname = table.Column<string>(type: "varchar(50)", nullable: false),
                    pass = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    IDREZ = table.Column<int>(name: "ID_REZ", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATAPOCZ = table.Column<DateTime>(name: "DATA_POCZ", type: "date", nullable: false),
                    DATAKON = table.Column<DateTime>(name: "DATA_KON", type: "date", nullable: false),
                    OfertaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.IDREZ);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Oferta_OfertaID",
                        column: x => x.OfertaID,
                        principalTable: "Oferta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_OfertaID",
                table: "Rezerwacje",
                column: "OfertaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Oferta");
        }
    }
}
