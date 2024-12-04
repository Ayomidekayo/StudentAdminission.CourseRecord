using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAdmission.Data.Migrations
{
    public partial class seededuserandRoledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d38524c-64e4-47c7-8a72-837446d80e0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b360267b-ab28-48d2-9ba4-ca1c69eb1b98");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e7655dc-09f2-4b90-99a6-23d30d73ed67", "ee2cc527-01d9-4aad-9375-9f24eb3de3e7", "User", "USER" },
                    { "e9d55997-49de-49dc-ac1d-572bc009aaad", "7b8545ad-640e-42c5-aebe-1fedb4f4b7a6", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "692ecad5-0d15-4bbe-9cbc-1aef283ff23e", 0, "229c0828-c3dc-4af6-ae15-4e92fd1bcf8c", null, "schooladmin@localhost.com", true, "School", "Admin", false, null, "SCHOOLADMIN@LOCALHOST.COM", "SCHOOLADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEBCBzfCFyJ+fvMHmjF4dX+KwJgekCSQVraxwIegbeDbAczuvpy0QfKA0h+l+fP4nSA==", null, false, "a4ce1751-57f9-4afa-912a-df2244445f87", false, "schooladmin@localhost.com" },
                    { "f5a5276d-9a51-433a-8102-de58b4c1b4ff", 0, "13abc46a-a594-4e65-ad78-7bfc5efaf29b", null, "schooluser@localhost.com", true, "School", "User", false, null, "SCHOOLUSER@LOCALHOST.COM", "SCHOOLUSER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEOvZDdWrKirb+b4hnZERGzKXpOZP3EJEBiDhVjzsgtubSuLgaNDiNqqpYqRxl2ccDw==", null, false, "3b72c8cb-5aba-4aba-996a-ff959dc544ce", false, "schooluser@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9d55997-49de-49dc-ac1d-572bc009aaad", "692ecad5-0d15-4bbe-9cbc-1aef283ff23e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2e7655dc-09f2-4b90-99a6-23d30d73ed67", "f5a5276d-9a51-433a-8102-de58b4c1b4ff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9d55997-49de-49dc-ac1d-572bc009aaad", "692ecad5-0d15-4bbe-9cbc-1aef283ff23e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e7655dc-09f2-4b90-99a6-23d30d73ed67", "f5a5276d-9a51-433a-8102-de58b4c1b4ff" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e7655dc-09f2-4b90-99a6-23d30d73ed67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d55997-49de-49dc-ac1d-572bc009aaad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "692ecad5-0d15-4bbe-9cbc-1aef283ff23e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5a5276d-9a51-433a-8102-de58b4c1b4ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d38524c-64e4-47c7-8a72-837446d80e0c", "3e8c9588-c51f-49cf-88c3-c55426e15ae3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b360267b-ab28-48d2-9ba4-ca1c69eb1b98", "adace01b-a074-4bc1-bd6a-af03bf427246", "User", "USER" });
        }
    }
}
