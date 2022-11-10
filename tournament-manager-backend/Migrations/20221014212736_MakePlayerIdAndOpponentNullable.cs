using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tournament_manager_backend.Migrations
{
    public partial class MakePlayerIdAndOpponentNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WinRecords_Players_PlayerId",
                table: "WinRecords");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "WinRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Opponent",
                table: "WinRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_WinRecords_Players_PlayerId",
                table: "WinRecords",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WinRecords_Players_PlayerId",
                table: "WinRecords");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "WinRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Opponent",
                table: "WinRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WinRecords_Players_PlayerId",
                table: "WinRecords",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
