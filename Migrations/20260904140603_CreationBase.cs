using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_REST_REVISION.Migrations
{
    /// <inheritdoc />
    public partial class CreationBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marque",
                columns: table => new
                {
                    idmarque = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nommarque = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_marque", x => x.idmarque);
                });

            migrationBuilder.CreateTable(
                name: "typdeproduit",
                columns: table => new
                {
                    idtypeproduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomtypeproduit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typeproduit", x => x.idtypeproduit);
                });

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    idproduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomproduit = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    nomphoto = table.Column<string>(type: "text", nullable: true),
                    uriphoto = table.Column<string>(type: "text", nullable: true),
                    idtypeproduit = table.Column<int>(type: "integer", nullable: false),
                    idmarque = table.Column<int>(type: "integer", nullable: false),
                    stockreel = table.Column<int>(type: "integer", nullable: false),
                    stockmin = table.Column<int>(type: "integer", nullable: false),
                    stockmax = table.Column<int>(type: "integer", nullable: false),
                    idmarque1 = table.Column<int>(type: "integer", nullable: false),
                    idtypeproduit1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produit", x => x.idproduit);
                    table.ForeignKey(
                        name: "fk_produit_marque",
                        column: x => x.idmarque,
                        principalTable: "marque",
                        principalColumn: "idmarque");
                    table.ForeignKey(
                        name: "fk_produit_typeproduit",
                        column: x => x.idtypeproduit,
                        principalTable: "typdeproduit",
                        principalColumn: "idtypeproduit");
                });

            migrationBuilder.CreateIndex(
                name: "IX_produit_idmarque",
                table: "produit",
                column: "idmarque");

            migrationBuilder.CreateIndex(
                name: "IX_produit_idtypeproduit",
                table: "produit",
                column: "idtypeproduit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "marque");

            migrationBuilder.DropTable(
                name: "typdeproduit");
        }
    }
}
