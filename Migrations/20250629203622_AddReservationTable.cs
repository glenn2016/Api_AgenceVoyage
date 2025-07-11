using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_AgenceVoyage.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offres_Voyage_Voyageid",
                table: "Offres");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Chauffeurs_chauffeurid",
                table: "Voyage");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Users_UserId",
                table: "Voyage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voyage",
                table: "Voyage");

            migrationBuilder.RenameTable(
                name: "Voyage",
                newName: "Voyages");

            migrationBuilder.RenameIndex(
                name: "IX_Voyage_UserId",
                table: "Voyages",
                newName: "IX_Voyages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyage_chauffeurid",
                table: "Voyages",
                newName: "IX_Voyages_chauffeurid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voyages",
                table: "Voyages",
                column: "IdUVoyage");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OffreId = table.Column<int>(type: "integer", nullable: false),
                    statut = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Offres_OffreId",
                        column: x => x.OffreId,
                        principalTable: "Offres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OffreId",
                table: "Reservations",
                column: "OffreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offres_Voyages_Voyageid",
                table: "Offres",
                column: "Voyageid",
                principalTable: "Voyages",
                principalColumn: "IdUVoyage",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyages_Chauffeurs_chauffeurid",
                table: "Voyages",
                column: "chauffeurid",
                principalTable: "Chauffeurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyages_Users_UserId",
                table: "Voyages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offres_Voyages_Voyageid",
                table: "Offres");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyages_Chauffeurs_chauffeurid",
                table: "Voyages");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyages_Users_UserId",
                table: "Voyages");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voyages",
                table: "Voyages");

            migrationBuilder.RenameTable(
                name: "Voyages",
                newName: "Voyage");

            migrationBuilder.RenameIndex(
                name: "IX_Voyages_UserId",
                table: "Voyage",
                newName: "IX_Voyage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyages_chauffeurid",
                table: "Voyage",
                newName: "IX_Voyage_chauffeurid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voyage",
                table: "Voyage",
                column: "IdUVoyage");

            migrationBuilder.AddForeignKey(
                name: "FK_Offres_Voyage_Voyageid",
                table: "Offres",
                column: "Voyageid",
                principalTable: "Voyage",
                principalColumn: "IdUVoyage",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Chauffeurs_chauffeurid",
                table: "Voyage",
                column: "chauffeurid",
                principalTable: "Chauffeurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Users_UserId",
                table: "Voyage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
