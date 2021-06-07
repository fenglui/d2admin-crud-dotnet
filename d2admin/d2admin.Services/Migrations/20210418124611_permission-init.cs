using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace d2admin.Services.Migrations
{
    public partial class permissioninit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code",
                table: "Role",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "Role",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "del_flag",
                table: "Role",
                newName: "DelFlag");

            migrationBuilder.CreateTable(
                name: "pm_resource",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Permission = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Component = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pm_resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pm_role_resource",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ResourceId = table.Column<long>(type: "bigint", nullable: false),
                    DelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pm_role_resource", x => x.id);
                    table.ForeignKey(
                        name: "FK_pm_role_resource_pm_resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "pm_resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pm_role_resource_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pm_role_resource_ResourceId",
                table: "pm_role_resource",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_pm_role_resource_RoleId",
                table: "pm_role_resource",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pm_role_resource");

            migrationBuilder.DropTable(
                name: "pm_resource");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Role",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Role",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "DelFlag",
                table: "Role",
                newName: "del_flag");
        }
    }
}
