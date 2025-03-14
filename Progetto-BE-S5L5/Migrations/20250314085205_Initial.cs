using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progetto_BE_S5L5.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafica",
                columns: table => new
                {
                    idanagrafica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Indirizzo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Citta = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Cap = table.Column<int>(type: "int", nullable: false),
                    Codice_Fiscale = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Anagrafi__7AB1023C929CB4F0", x => x.idanagrafica);
                });

            migrationBuilder.CreateTable(
                name: "Violazione",
                columns: table => new
                {
                    idviolazione = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descrizione = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Violazio__AF77BD923F484CD4", x => x.idviolazione);
                });

            migrationBuilder.CreateTable(
                name: "Verbale",
                columns: table => new
                {
                    idVerbale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataViolazione = table.Column<DateOnly>(type: "date", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NominativoAgente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataTrascrizioneVerbale = table.Column<DateOnly>(type: "date", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false),
                    idanagrafica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idviolazione = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Verbale__A0FAF4534A6E58E3", x => x.idVerbale);
                    table.ForeignKey(
                        name: "Fk_Anagrafica_Verbale",
                        column: x => x.idanagrafica,
                        principalTable: "Anagrafica",
                        principalColumn: "idanagrafica");
                    table.ForeignKey(
                        name: "Fk_Violazione_Verbale",
                        column: x => x.idviolazione,
                        principalTable: "Violazione",
                        principalColumn: "idviolazione");
                });

            migrationBuilder.CreateIndex(
                name: "Unique_CF",
                table: "Anagrafica",
                column: "Codice_Fiscale",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_idanagrafica",
                table: "Verbale",
                column: "idanagrafica");

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_idviolazione",
                table: "Verbale",
                column: "idviolazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbale");

            migrationBuilder.DropTable(
                name: "Anagrafica");

            migrationBuilder.DropTable(
                name: "Violazione");
        }
    }
}
