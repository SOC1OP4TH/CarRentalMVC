using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalMVC.Migrations
{
    /// <inheritdoc />
    public partial class addedDLprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "drivingLicense",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "drivingLicense",
                table: "Customers");
        }
    }
}
