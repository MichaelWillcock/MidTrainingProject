using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterBuilderData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HitDice = table.Column<int>(type: "int", nullable: false),
                    WeaponProficiencies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmourProficiencies = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassesId);
                    table.ForeignKey(
                        name: "FK_Class_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ProficiencyBonus = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelsId);
                    table.ForeignKey(
                        name: "FK_Level_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RacesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubRaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryIncrease = table.Column<int>(type: "int", nullable: false),
                    SecondayASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryIncrease = table.Column<int>(type: "int", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RacesId);
                    table.ForeignKey(
                        name: "FK_Race_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    StatLineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.StatLineId);
                    table.ForeignKey(
                        name: "FK_Stats_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CharacterId",
                table: "Class",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Level_CharacterId",
                table: "Level",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_CharacterId",
                table: "Race",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_CharacterId",
                table: "Stats",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
