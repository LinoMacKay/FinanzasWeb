using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class lastnameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5538038-27f8-4b33-af9f-7227a37eef53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d366cefa-a3ff-4720-8f12-78d2dc838c66");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f858f41-e5e2-4ddb-86a9-39ee04f5f62d", "7ed6ab38-9e9f-46c9-826c-1025e0720d38", "Admin", "ADMIN" },
                    { "fb029378-8fe8-474a-92c4-13446510ff7d", "6c1c5f42-061c-4c11-954e-e7497f592b8d", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f858f41-e5e2-4ddb-86a9-39ee04f5f62d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb029378-8fe8-474a-92c4-13446510ff7d");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d366cefa-a3ff-4720-8f12-78d2dc838c66", "15fde1f5-9a53-437d-8dab-d676b8713c52", "Admin", "ADMIN" },
                    { "a5538038-27f8-4b33-af9f-7227a37eef53", "ccb0551e-fe9d-4947-847a-3f814f690aaf", "User", "USER" }
                });
        }
    }
}
