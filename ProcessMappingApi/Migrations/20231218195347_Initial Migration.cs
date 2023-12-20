using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessMappingApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCompanyProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubCompanyProcessOrder = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProcesses_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyProcesses_CompanyProcesses_CompanyProcessId",
                        column: x => x.CompanyProcessId,
                        principalTable: "CompanyProcesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProcesses_AreaId",
                table: "CompanyProcesses",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProcesses_CompanyProcessId",
                table: "CompanyProcesses",
                column: "CompanyProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProcesses");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
