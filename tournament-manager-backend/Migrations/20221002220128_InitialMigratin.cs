using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tournament_manager_backend.Migrations
{
    public partial class InitialMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LossRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opponent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerScore = table.Column<int>(type: "int", nullable: false),
                    LosserScore = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LossRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LossRecords_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WinRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opponent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinnerScore = table.Column<int>(type: "int", nullable: false),
                    LosserScore = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WinRecords_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LossRecords_PlayerId",
                table: "LossRecords",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_WinRecords_PlayerId",
                table: "WinRecords",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LossRecords");

            migrationBuilder.DropTable(
                name: "WinRecords");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
