using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_AgenceVoyage.Migrations
{
    /// <inheritdoc />
    public partial class AddAgenceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agences",
                columns: table => new
                {
                    IdAgence = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomAgence = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    AdresseAgence = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Ninea = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Rccm = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agences", x => x.IdAgence);
                    table.ForeignKey(
                        name: "FK_Agences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Prenom = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Age = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chauffeurs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voyage",
                columns: table => new
                {
                    IdUVoyage = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Destination = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    DateDepart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateArrivee = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    chauffeurid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyage", x => x.IdUVoyage);
                    table.ForeignKey(
                        name: "FK_Voyage_Chauffeurs_chauffeurid",
                        column: x => x.chauffeurid,
                        principalTable: "Chauffeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voyage_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomOfrre = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    DescriptionOffre = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    PrisOffre = table.Column<float>(type: "real", maxLength: 80, nullable: false),
                    Voyageid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offres_Voyage_Voyageid",
                        column: x => x.Voyageid,
                        principalTable: "Voyage",
                        principalColumn: "IdUVoyage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agences_UserId",
                table: "Agences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_UserId",
                table: "Chauffeurs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offres_Voyageid",
                table: "Offres",
                column: "Voyageid");

            migrationBuilder.CreateIndex(
                name: "IX_Voyage_chauffeurid",
                table: "Voyage",
                column: "chauffeurid");

            migrationBuilder.CreateIndex(
                name: "IX_Voyage_UserId",
                table: "Voyage",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agences");

            migrationBuilder.DropTable(
                name: "Offres");

            migrationBuilder.DropTable(
                name: "Voyage");

            migrationBuilder.DropTable(
                name: "Chauffeurs");
        }
    }
}
