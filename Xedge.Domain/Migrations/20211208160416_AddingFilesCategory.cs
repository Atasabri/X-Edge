using Microsoft.EntityFrameworkCore.Migrations;

namespace Xedge.Domain.Migrations
{
    public partial class AddingFilesCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a28f779-184c-4d0c-aaa6-9f6d83f47c29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60930647-1cfa-4765-aa9b-62960467c4e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72fae469-bc34-4389-9883-60035f488057");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8f513147-db34-4d34-894c-054f53403e09", "200ae2bc-ac61-4d0a-b0f6-acceb44f1898" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "200ae2bc-ac61-4d0a-b0f6-acceb44f1898");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f513147-db34-4d34-894c-054f53403e09");

            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "Files",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Name_AR = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ce42a40d-1925-45ee-a041-c686607c51b0", "1603df10-8df9-43ce-aba7-8299dbdd687c", "Admin", "ADMIN" },
                    { "756fff00-2fd5-4588-ac7b-142073da7d90", "59730286-59a1-40a8-9678-3b57dbc8ef9d", "Editor", "EDITOR" },
                    { "94a6bb7c-7f75-4bb9-9b67-df76ef3103ce", "a3662faa-8fb2-48d2-b65a-22b6135a75fc", "User", "USER" },
                    { "e9ba2d3e-9320-40a4-8cb4-e943fbf72724", "cf07b878-8c14-4041-bcc3-2bc5e545b688", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d6f8b166-2f37-4f7a-83da-2bc4c0e9781f", 0, 0.0, "1696632b-ada6-49a6-ae9a-a80ffff08ca7", 1, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMk6j/Js+LvfxaCMj6tC4sa9z6MJWuuyHlaXC39GhbVK6UK2EbKFeyTJtAcN+HXDJA==", null, false, "ce5521db-ae57-4731-ae3c-cf36640c0370", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d6f8b166-2f37-4f7a-83da-2bc4c0e9781f", "ce42a40d-1925-45ee-a041-c686607c51b0" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_Category_Id",
                table: "Files",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileCategory_Category_Id",
                table: "Files",
                column: "Category_Id",
                principalTable: "FileCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileCategory_Category_Id",
                table: "Files");

            migrationBuilder.DropTable(
                name: "FileCategory");

            migrationBuilder.DropIndex(
                name: "IX_Files_Category_Id",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "756fff00-2fd5-4588-ac7b-142073da7d90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a6bb7c-7f75-4bb9-9b67-df76ef3103ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9ba2d3e-9320-40a4-8cb4-e943fbf72724");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d6f8b166-2f37-4f7a-83da-2bc4c0e9781f", "ce42a40d-1925-45ee-a041-c686607c51b0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce42a40d-1925-45ee-a041-c686607c51b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6f8b166-2f37-4f7a-83da-2bc4c0e9781f");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Files");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "200ae2bc-ac61-4d0a-b0f6-acceb44f1898", "5859391f-5236-4218-a3d6-b8f5362dfdc4", "Admin", "ADMIN" },
                    { "60930647-1cfa-4765-aa9b-62960467c4e0", "8e2c0b0f-30c2-43aa-abb1-a5bf92475b74", "Editor", "EDITOR" },
                    { "72fae469-bc34-4389-9883-60035f488057", "7465a4cb-d0ca-4925-87bb-c2e7f960263d", "User", "USER" },
                    { "1a28f779-184c-4d0c-aaa6-9f6d83f47c29", "f1126d9d-c58f-41eb-9b15-55f8e4d44e46", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f513147-db34-4d34-894c-054f53403e09", 0, 0.0, "983fe328-80f1-41bf-8c50-deaf10a04510", 1, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEEDAsG6hhrhRkD+THKaCdVo32rrQGsiTbbezHHxh1QAQmNDEy+GiB2X5kBer4OUPAg==", null, false, "8b0d0d9b-893a-4ef7-bd14-fadb9867f41f", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8f513147-db34-4d34-894c-054f53403e09", "200ae2bc-ac61-4d0a-b0f6-acceb44f1898" });
        }
    }
}
