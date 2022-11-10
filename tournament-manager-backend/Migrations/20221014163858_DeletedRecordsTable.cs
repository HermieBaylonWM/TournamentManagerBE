using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tournament_manager_backend.Migrations
{
    public partial class DeletedRecordsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    LosserScore = table.Column<int>(type: "int", nullable: false),
                    Opponent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinnerScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_PlayerId",
                table: "Records",
                column: "PlayerId");
        }
    }
}
