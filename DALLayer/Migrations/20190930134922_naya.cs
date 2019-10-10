using Microsoft.EntityFrameworkCore.Migrations;

namespace DALLayer.Migrations
{
    public partial class naya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "T_Orders",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "T_Orders",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
