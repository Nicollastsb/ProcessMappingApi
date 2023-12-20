using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessMappingApi.Migrations
{
    /// <inheritdoc />
    public partial class CorrectCompanyProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCompanyProcessId",
                table: "CompanyProcesses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentCompanyProcessId",
                table: "CompanyProcesses",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
