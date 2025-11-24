using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nycthemeron.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserGroupRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Aspiration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Attribute = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    TalentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirement_Talent_TalentId",
                        column: x => x.TalentId,
                        principalTable: "Talent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TalentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TalentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentType_Talent_TalentId",
                        column: x => x.TalentId,
                        principalTable: "Talent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MainClass = table.Column<string>(type: "TEXT", nullable: true),
                    SubClass = table.Column<string>(type: "TEXT", nullable: true),
                    Tier = table.Column<string>(type: "TEXT", nullable: true),
                    Charges = table.Column<int>(type: "INTEGER", nullable: false),
                    SunTitle = table.Column<string>(type: "TEXT", nullable: true),
                    SunActionTypes = table.Column<string>(type: "TEXT", nullable: false),
                    SunAbilityType = table.Column<string>(type: "TEXT", nullable: true),
                    SunSpiritCost = table.Column<int>(type: "INTEGER", nullable: false),
                    SunRuleText = table.Column<string>(type: "TEXT", nullable: true),
                    SunRequirements = table.Column<string>(type: "TEXT", nullable: true),
                    MoonTitle = table.Column<string>(type: "TEXT", nullable: true),
                    MoonActionTypes = table.Column<string>(type: "TEXT", nullable: false),
                    MoonAbilityType = table.Column<string>(type: "TEXT", nullable: true),
                    MoonSpiritCost = table.Column<int>(type: "INTEGER", nullable: false),
                    MoonRuleText = table.Column<string>(type: "TEXT", nullable: true),
                    MoonRequirements = table.Column<string>(type: "TEXT", nullable: true),
                    CharacterSheetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AgilityId = table.Column<int>(type: "INTEGER", nullable: false),
                    BodyId = table.Column<int>(type: "INTEGER", nullable: false),
                    MindId = table.Column<int>(type: "INTEGER", nullable: false),
                    MysticId = table.Column<int>(type: "INTEGER", nullable: false),
                    PresenceId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxHitpoints = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentHitpoints = table.Column<int>(type: "INTEGER", nullable: false),
                    TempHitpoints = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseArmor = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentArmor = table.Column<int>(type: "INTEGER", nullable: false),
                    MagicalArmor = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseSpirit = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentSpirit = table.Column<int>(type: "INTEGER", nullable: false),
                    Movement = table.Column<int>(type: "INTEGER", nullable: false),
                    Initiative = table.Column<int>(type: "INTEGER", nullable: false),
                    TalentPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Race = table.Column<string>(type: "TEXT", nullable: true),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_CharacterAttribute_AgilityId",
                        column: x => x.AgilityId,
                        principalTable: "CharacterAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_CharacterAttribute_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CharacterAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_CharacterAttribute_MindId",
                        column: x => x.MindId,
                        principalTable: "CharacterAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_CharacterAttribute_MysticId",
                        column: x => x.MysticId,
                        principalTable: "CharacterAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_CharacterAttribute_PresenceId",
                        column: x => x.PresenceId,
                        principalTable: "CharacterAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheetTalent",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    TalentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheetTalent", x => new { x.CharactersId, x.TalentsId });
                    table.ForeignKey(
                        name: "FK_CharacterSheetTalent_CharacterSheet_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "CharacterSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheetTalent_Talent_TalentsId",
                        column: x => x.TalentsId,
                        principalTable: "Talent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    GameMasterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Admin = table.Column<bool>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterSheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    MainHandId = table.Column<int>(type: "INTEGER", nullable: true),
                    OffHandId = table.Column<int>(type: "INTEGER", nullable: true),
                    EquippedArmorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_CharacterSheet_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    ContainerId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsEquipped = table.Column<bool>(type: "INTEGER", nullable: false),
                    EquippedSlot = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemType = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    Accessory_Effects = table.Column<string>(type: "TEXT", nullable: true),
                    ArmorValue = table.Column<int>(type: "INTEGER", nullable: true),
                    Initative = table.Column<int>(type: "INTEGER", nullable: true),
                    Resistances = table.Column<string>(type: "TEXT", nullable: true),
                    Penalties = table.Column<string>(type: "TEXT", nullable: true),
                    Effects = table.Column<string>(type: "TEXT", nullable: true),
                    Equipped = table.Column<bool>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: true),
                    Range = table.Column<int>(type: "INTEGER", nullable: true),
                    InitativeMod = table.Column<int>(type: "INTEGER", nullable: true),
                    MovementMod = table.Column<int>(type: "INTEGER", nullable: true),
                    Grip = table.Column<string>(type: "TEXT", nullable: true),
                    WeightClass = table.Column<string>(type: "TEXT", nullable: true),
                    ReloadPenalty = table.Column<string>(type: "TEXT", nullable: true),
                    DamageTypes = table.Column<string>(type: "TEXT", nullable: true),
                    Weapon_Penalties = table.Column<string>(type: "TEXT", nullable: true),
                    Weapon_Effects = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Items_Items_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_CharacterSheetId",
                table: "Card",
                column: "CharacterSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_AgilityId",
                table: "CharacterSheet",
                column: "AgilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_BodyId",
                table: "CharacterSheet",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_GroupId",
                table: "CharacterSheet",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_MindId",
                table: "CharacterSheet",
                column: "MindId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_MysticId",
                table: "CharacterSheet",
                column: "MysticId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_PresenceId",
                table: "CharacterSheet",
                column: "PresenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_UserId",
                table: "CharacterSheet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheetTalent_TalentsId",
                table: "CharacterSheetTalent",
                column: "TalentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GameMasterId",
                table: "Groups",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CharacterSheetId",
                table: "Inventories",
                column: "CharacterSheetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EquippedArmorId",
                table: "Inventories",
                column: "EquippedArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_MainHandId",
                table: "Inventories",
                column: "MainHandId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_OffHandId",
                table: "Inventories",
                column: "OffHandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ContainerId",
                table: "Items",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_InventoryId",
                table: "Items",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_TalentId",
                table: "Requirement",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentType_TalentId",
                table: "TalentType",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId",
                table: "User",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_CharacterSheet_CharacterSheetId",
                table: "Card",
                column: "CharacterSheetId",
                principalTable: "CharacterSheet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSheet_Groups_GroupId",
                table: "CharacterSheet",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSheet_User_UserId",
                table: "CharacterSheet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_User_GameMasterId",
                table: "Groups",
                column: "GameMasterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_EquippedArmorId",
                table: "Inventories",
                column: "EquippedArmorId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_MainHandId",
                table: "Inventories",
                column: "MainHandId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_OffHandId",
                table: "Inventories",
                column: "OffHandId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_CharacterSheet_CharacterSheetId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Groups_GroupId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_EquippedArmorId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_MainHandId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_OffHandId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "CharacterSheetTalent");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "TalentType");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Talent");

            migrationBuilder.DropTable(
                name: "CharacterSheet");

            migrationBuilder.DropTable(
                name: "CharacterAttribute");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
