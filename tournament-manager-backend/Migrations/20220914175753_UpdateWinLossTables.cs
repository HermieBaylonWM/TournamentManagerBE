using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tournament_manager_backend.Migrations
{
    public partial class UpdateWinLossTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "WinRecords",
                newName: "Opponent");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LossRecords",
                newName: "Opponent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opponent",
                table: "WinRecords",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Opponent",
                table: "LossRecords",
                newName: "Name");
        }
    }
}
