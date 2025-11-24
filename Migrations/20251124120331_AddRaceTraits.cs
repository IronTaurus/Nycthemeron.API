using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nycthemeron.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRaceTraits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_User_GameMasterId",
                table: "Groups");

            migrationBuilder.AddColumn<bool>(
                name: "IsGameMaster",
                table: "UserGroups",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "GameMasterId",
                table: "Groups",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "RacialTraitId",
                table: "CharacterSheet",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "CharacterAttribute",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RacialFamily = table.Column<string>(type: "TEXT", nullable: true),
                    AgeExpectancy = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: true),
                    EncumbermentLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    Background = table.Column<string>(type: "TEXT", nullable: true),
                    Appearence = table.Column<string>(type: "TEXT", nullable: true),
                    Behaviour = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RacialTraits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacialTraits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceTalent",
                columns: table => new
                {
                    ChooseableTalentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RacesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTalent", x => new { x.ChooseableTalentsId, x.RacesId });
                    table.ForeignKey(
                        name: "FK_RaceTalent_Races_RacesId",
                        column: x => x.RacesId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceTalent_Talent_ChooseableTalentsId",
                        column: x => x.ChooseableTalentsId,
                        principalTable: "Talent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniqueTraits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueTraits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniqueTraits_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceNegativeTraits",
                columns: table => new
                {
                    NegativeRacialTraitsId = table.Column<int>(type: "INTEGER", nullable: false),
                    Race1Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceNegativeTraits", x => new { x.NegativeRacialTraitsId, x.Race1Id });
                    table.ForeignKey(
                        name: "FK_RaceNegativeTraits_Races_Race1Id",
                        column: x => x.Race1Id,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceNegativeTraits_RacialTraits_NegativeRacialTraitsId",
                        column: x => x.NegativeRacialTraitsId,
                        principalTable: "RacialTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacePositiveTraits",
                columns: table => new
                {
                    PositiveRacialTraitsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacePositiveTraits", x => new { x.PositiveRacialTraitsId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_RacePositiveTraits_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacePositiveTraits_RacialTraits_PositiveRacialTraitsId",
                        column: x => x.PositiveRacialTraitsId,
                        principalTable: "RacialTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_RacialTraitId",
                table: "CharacterSheet",
                column: "RacialTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAttribute_RaceId",
                table: "CharacterAttribute",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceNegativeTraits_Race1Id",
                table: "RaceNegativeTraits",
                column: "Race1Id");

            migrationBuilder.CreateIndex(
                name: "IX_RacePositiveTraits_RaceId",
                table: "RacePositiveTraits",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTalent_RacesId",
                table: "RaceTalent",
                column: "RacesId");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueTraits_RaceId",
                table: "UniqueTraits",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAttribute_Races_RaceId",
                table: "CharacterAttribute",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSheet_RacialTraits_RacialTraitId",
                table: "CharacterSheet",
                column: "RacialTraitId",
                principalTable: "RacialTraits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_User_GameMasterId",
                table: "Groups",
                column: "GameMasterId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAttribute_Races_RaceId",
                table: "CharacterAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSheet_RacialTraits_RacialTraitId",
                table: "CharacterSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_User_GameMasterId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "RaceNegativeTraits");

            migrationBuilder.DropTable(
                name: "RacePositiveTraits");

            migrationBuilder.DropTable(
                name: "RaceTalent");

            migrationBuilder.DropTable(
                name: "UniqueTraits");

            migrationBuilder.DropTable(
                name: "RacialTraits");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSheet_RacialTraitId",
                table: "CharacterSheet");

            migrationBuilder.DropIndex(
                name: "IX_CharacterAttribute_RaceId",
                table: "CharacterAttribute");

            migrationBuilder.DropColumn(
                name: "IsGameMaster",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "RacialTraitId",
                table: "CharacterSheet");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "CharacterAttribute");

            migrationBuilder.AlterColumn<int>(
                name: "GameMasterId",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_User_GameMasterId",
                table: "Groups",
                column: "GameMasterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
