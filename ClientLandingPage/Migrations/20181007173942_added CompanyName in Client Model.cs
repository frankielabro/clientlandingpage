using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientLandingPage.Migrations
{
    public partial class addedCompanyNameinClientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Client");
        }
    }
}
