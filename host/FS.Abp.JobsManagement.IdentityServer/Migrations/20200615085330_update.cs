using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.Abp.JobsManagement.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "CodingManagementCodes",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "CodingManagementVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProviderName = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodingManagementVersions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodingManagementVersions");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "CodingManagementCodes");
        }
    }
}
