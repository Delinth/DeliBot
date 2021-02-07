using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliBot.Console.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LastName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuessOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuessOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuessOptions_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuessHints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GuessOptionId = table.Column<int>(type: "int", nullable: true),
                    Hint = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuessHints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuessHints_GuessOptions_GuessOptionId",
                        column: x => x.GuessOptionId,
                        principalTable: "GuessOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuessPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GuessOptionId = table.Column<int>(type: "int", nullable: true),
                    CropPicUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FullPicUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuessPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuessPictures_GuessOptions_GuessOptionId",
                        column: x => x.GuessOptionId,
                        principalTable: "GuessOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuessHints_GuessOptionId",
                table: "GuessHints",
                column: "GuessOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_GuessOptions_PersonId",
                table: "GuessOptions",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GuessPictures_GuessOptionId",
                table: "GuessPictures",
                column: "GuessOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuessHints");

            migrationBuilder.DropTable(
                name: "GuessPictures");

            migrationBuilder.DropTable(
                name: "GuessOptions");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
