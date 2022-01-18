using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddedNewBalancefieldstotransactionstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromNewBalance",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToNewBalance",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromNewBalance",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ToNewBalance",
                table: "Transactions");
        }
    }
}
