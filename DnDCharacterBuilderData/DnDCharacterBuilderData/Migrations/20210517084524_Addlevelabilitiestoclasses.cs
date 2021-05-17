using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterBuilderData.Migrations
{
    public partial class Addlevelabilitiestoclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level1Abilities",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level2Abilities",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level1Abilities",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Level2Abilities",
                table: "Class");
        }
    }
}
