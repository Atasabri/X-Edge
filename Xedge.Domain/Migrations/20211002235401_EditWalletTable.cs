using Microsoft.EntityFrameworkCore.Migrations;

namespace Xedge.Domain.Migrations
{
    public partial class EditWalletTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3505485e-87de-45ef-b9ad-5c49a0628ec5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a949109e-e7d1-402b-b9c7-27e0bce8aba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9947dbd-f50e-4471-83bd-285de4f65907");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "36dc0191-fd5e-43e4-9e20-2f16b7137ac9", "ad751b12-9955-446f-965b-a4ab240fd004" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad751b12-9955-446f-965b-a4ab240fd004");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36dc0191-fd5e-43e4-9e20-2f16b7137ac9");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "WalletTransactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "WalletTransactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bfdce41b-2900-4ecd-80b3-910bce7be38f", "6c97916e-fca5-4f5f-af1b-740213b75457", "Admin", "ADMIN" },
                    { "ff511223-1557-4424-9faf-02badb998e69", "60684e48-2d77-4cf3-a056-3ccf529216ce", "Editor", "EDITOR" },
                    { "d9e36e92-0b53-40f2-8711-f0818905701d", "456b25d9-7656-4248-afc4-3ead61d14c26", "User", "USER" },
                    { "a98d080c-d3e7-4e44-a143-c9d43a222b1a", "44cd5daa-632e-4b8d-bb39-6c2adebc537c", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d1099681-4f94-49cc-98e4-09d502182730", 0, 0.0, "66b166e1-6f87-4025-8d5c-6e37e7d34c47", 1, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBVnR1hTfzCLCR1gYaKNEP+OIMl4Vhl3WhuBJGQpKtSZrl/QuZ1rqh3KAKhQ9XG1yg==", null, false, "77d2d95d-55ed-4f10-a951-12c09ada90d8", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d1099681-4f94-49cc-98e4-09d502182730", "bfdce41b-2900-4ecd-80b3-910bce7be38f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a98d080c-d3e7-4e44-a143-c9d43a222b1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9e36e92-0b53-40f2-8711-f0818905701d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff511223-1557-4424-9faf-02badb998e69");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d1099681-4f94-49cc-98e4-09d502182730", "bfdce41b-2900-4ecd-80b3-910bce7be38f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfdce41b-2900-4ecd-80b3-910bce7be38f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1099681-4f94-49cc-98e4-09d502182730");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad751b12-9955-446f-965b-a4ab240fd004", "2db1be28-4417-474b-bfdd-3939b708bab7", "Admin", "ADMIN" },
                    { "3505485e-87de-45ef-b9ad-5c49a0628ec5", "153c18a6-9d3b-45ab-be2f-65f027c87109", "Editor", "EDITOR" },
                    { "f9947dbd-f50e-4471-83bd-285de4f65907", "d3e14757-a95d-458c-8273-41c6d7f775b9", "User", "USER" },
                    { "a949109e-e7d1-402b-b9c7-27e0bce8aba5", "4ed901b9-fec1-4aad-aafb-b603082be5b1", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "36dc0191-fd5e-43e4-9e20-2f16b7137ac9", 0, "bc4c93f2-e9e5-4d09-b653-15c28ab1d40b", 1, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGZzaXVFp8G/kGiOVkou6bpRiW6gIR7dUtU3Av/CKjWgeajn/Vv2zLRqVJwLes/DCQ==", null, false, "9f796897-a1ed-4104-a141-8ccd887ba7d6", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "36dc0191-fd5e-43e4-9e20-2f16b7137ac9", "ad751b12-9955-446f-965b-a4ab240fd004" });
        }
    }
}
