using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataForAPIUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06fdfe3b-86b9-475e-a5ba-96528429bbc2", null, "Administrator", "ADMINISTRATOR" },
                    { "f55c973f-1c66-4439-a698-7c4cb5d5c816", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b9d866a5-b316-448c-a07f-969dce564b10", 0, "8381d802-8043-4d32-8240-cf08d255b2f3", "admin@pa.mail.com", false, "System", "Administrator", false, null, "ADMIN@PA.MAIL.COM", "ADMIN@PA.MAIL.COM", "AQAAAAIAAYagAAAAEEdZmIAJ7up5VYWVXRABSi8nU745/O/kGuEWLN3VFOKfRusO02uhY6vb3qR6CVgjJQ==", null, false, "37d55101-7f93-4f54-933d-d5a396e77193", false, "admin@pa.mail.com" },
                    { "c908badf-9b09-43dd-b814-a016623c75d8", 0, "4d291c6f-168d-412f-8265-fe495e079cd9", "user@pa.mail.com", false, "System", "User", false, null, "USER@PA.MAIL.COM", "USER@PA.MAIL.COM", "AQAAAAIAAYagAAAAEMdW2sJM7rsdEYkCwVaOF1p/LJTIOHjZI8f13yF4aMJxmEHAyQxFGSfqG3TfrSwvCQ==", null, false, "c7a58dfc-6a0b-4e45-9b5b-ad8ffd025c02", false, "user@pa.mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "06fdfe3b-86b9-475e-a5ba-96528429bbc2", "b9d866a5-b316-448c-a07f-969dce564b10" },
                    { "f55c973f-1c66-4439-a698-7c4cb5d5c816", "c908badf-9b09-43dd-b814-a016623c75d8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "06fdfe3b-86b9-475e-a5ba-96528429bbc2", "b9d866a5-b316-448c-a07f-969dce564b10" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f55c973f-1c66-4439-a698-7c4cb5d5c816", "c908badf-9b09-43dd-b814-a016623c75d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06fdfe3b-86b9-475e-a5ba-96528429bbc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f55c973f-1c66-4439-a698-7c4cb5d5c816");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9d866a5-b316-448c-a07f-969dce564b10");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c908badf-9b09-43dd-b814-a016623c75d8");
        }
    }
}
