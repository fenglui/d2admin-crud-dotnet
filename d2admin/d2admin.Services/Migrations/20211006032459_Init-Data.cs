using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace d2admin.Services.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "ConcurrencyStamp", "DelFlag", "Name", "NormalizedName", "ParentId" },
                values: new object[,]
                {
                    { "6fadf7cf-baa8-401d-84f5-ae54c584ad4d", "sa", "dd26e84d-13be-4060-96dc-92384bca27ed", false, "sa", "SA", null },
                    { "2a74609c-66c2-410c-b1bb-139ce71056f5", "admin", "354610ba-ab2a-4a34-a8e8-f9ab1c6866e3", false, "admin", "ADMIN", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "CallingCode", "ConcurrencyStamp", "DelFlag", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Mobile", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23a1557f-604d-4728-b011-a851da4a307b", 0, null, null, "3ea81291-7aa5-41f0-b8e1-d35009e39821", false, "fenglui@tuotuoniu.com", false, 0, false, null, null, "superadmin", null, null, "AQAAAAEAACcQAAAAEK39qZGWC5IE9b6nSSOjKiwLJ3RrRO/LGet0KIHuoUeZ5bjaQcZn1o9d67H6ciLGfA==", null, false, "AR5AJQGFXQSIHLMWMPM4MCYKEVDFYVPM", false, "sa" });

            migrationBuilder.InsertData(
                table: "pm_resource",
                columns: new[] { "Id", "Component", "CreateTime", "DelFlag", "Icon", "Name", "ParentId", "Path", "Permission", "Sort", "Title", "Type", "UpdateTime" },
                values: new object[,]
                {
                    { 16L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "editUser", 14L, null, "usersphere:user:edit", 110, "编辑用户", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "addUser", 14L, null, "usersphere:user:add", 110, "添加用户", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, "/usersphere/views/user", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user", "user", 1L, "/usersphere/user", "usersphere:user:view", 110, "用户管理", 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "authzRole", 7L, null, "permission:role:authz", 100, "分配权限", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "delRole", 7L, null, "permission:role:del", 100, "删除角色", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "editResource", 3L, null, "permission:resource:edit", 100, "修改角色", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "editRole", 7L, null, "permission:role:edit", 100, "修改角色", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "addRole", 7L, null, "permission:role:add", 100, "添加角色", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "eye", "viewRole", 7L, null, "permission:role:view", 90, "查看角色", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, "/permission/views/role", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "role", 2L, "/permission/role", "permission:role:view", 100, "角色管理", 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "delResource", 3L, null, "permission:resource:del", 100, "添加资源", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "addResource", 3L, null, "permission:resource:add", 100, "添加资源", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "eye", "viewResource", 3L, null, "permission:resource:view", 90, "查看资源", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "/permission/views/resource", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "address-book", "resource", 2L, "/permission/resource", "permission:resource:view", 90, "资源管理", 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "permission", 1L, null, null, 1, "权限管理", 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1L, "layoutHeaderAside", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "system", 0L, "/system", null, -10001, "系统管理", 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "delUser", 14L, null, "usersphere:user:del", 110, "删除用户", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "authzUser", 14L, null, "usersphere:user:authz", 110, "分配角色", 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "2a74609c-66c2-410c-b1bb-139ce71056f5");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "6fadf7cf-baa8-401d-84f5-ae54c584ad4d");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "23a1557f-604d-4728-b011-a851da4a307b");

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "pm_resource",
                keyColumn: "Id",
                keyValue: 18L);
        }
    }
}
