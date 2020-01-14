using Microsoft.EntityFrameworkCore.Migrations;

namespace Gugubao.Award.Infrastructure.Migrations
{
    public partial class AddLocalUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadImageLocalUrl",
                table: "Account",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadImageLocalUrl",
                table: "Account");
        }
    }
}
