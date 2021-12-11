using Microsoft.EntityFrameworkCore.Migrations;

namespace d2admin.Services.Migrations
{
    public partial class c2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallingCode",
                table: "User");

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6fadf7cf-baa8-401d-84f5-ae54c584ad4d", "23a1557f-604d-4728-b011-a851da4a307b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6fadf7cf-baa8-401d-84f5-ae54c584ad4d", "23a1557f-604d-4728-b011-a851da4a307b" });

            migrationBuilder.AddColumn<string>(
                name: "CallingCode",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
