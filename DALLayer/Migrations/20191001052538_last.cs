using Microsoft.EntityFrameworkCore.Migrations;

namespace DALLayer.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "T_Orders",
                nullable: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "T_Orders");
        }
    }
}
