using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterBuilderData.Migrations
{
    public partial class AddRaceString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Characters_CharacterId",
                table: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Race_CharacterId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Race");

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Race",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Race",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Race_CharacterId",
                table: "Race",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Characters_CharacterId",
                table: "Race",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
