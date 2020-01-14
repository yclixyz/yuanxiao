using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gugubao.Award.Infrastructure.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwardLevel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AwardItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LevelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardItem_AwardLevel_LevelId",
                        column: x => x.LevelId,
                        principalTable: "AwardLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    CellPhone = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true),
                    HeadImageUrl = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    HasPrized = table.Column<bool>(nullable: false),
                    GroupId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AwardRecord",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    AwardItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardRecord_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwardRecord_AwardItem_AwardItemId",
                        column: x => x.AwardItemId,
                        principalTable: "AwardItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_GroupId",
                table: "Account",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardItem_LevelId",
                table: "AwardItem",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecord_AccountId",
                table: "AwardRecord",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecord_AwardItemId",
                table: "AwardRecord",
                column: "AwardItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardRecord");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AwardItem");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "AwardLevel");
        }
    }
}
