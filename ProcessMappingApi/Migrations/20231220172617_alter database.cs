using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessMappingApi.Migrations
{
    /// <inheritdoc />
    public partial class alterdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCompanyProcessOrder",
                table: "CompanyProcesses",
                newName: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "CompanyProcesses",
                newName: "SubCompanyProcessOrder");
        }
    }
}
