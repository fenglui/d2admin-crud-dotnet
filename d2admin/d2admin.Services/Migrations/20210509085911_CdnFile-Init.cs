using Microsoft.EntityFrameworkCore.Migrations;

namespace d2admin.Services.Migrations
{
    public partial class CdnFileInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CdnFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Avatar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Pictures = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Images = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Files = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdnFile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CdnFile");
        }
    }
}
