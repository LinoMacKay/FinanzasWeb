using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45c6c794-997d-4179-b874-360833500607");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bedc8a03-7c90-463b-9da2-082cbfc298a6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6321e376-3d80-4bdf-8bdf-7fee6f80be0b", "dbf3a4dc-a57a-49f6-af16-153bde3a0ca2", "ADMIN", "ADMIN" },
                    { "fc030306-5163-425d-9596-4bae2f5c7e1a", "bc9fd249-2683-4e82-96bf-04f5769a8fbf", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 1,
                columns: new[] { "Customer_CategoryDescription", "Customer_CategoryName" },
                values: new object[] { "Owner", "Owner" });

            migrationBuilder.UpdateData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 2,
                columns: new[] { "Customer_CategoryDescription", "Customer_CategoryName" },
                values: new object[] { "Client", "Client" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6321e376-3d80-4bdf-8bdf-7fee6f80be0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc030306-5163-425d-9596-4bae2f5c7e1a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bedc8a03-7c90-463b-9da2-082cbfc298a6", "9fbfa6c1-2e45-4f03-a3e4-5213782f3863", "ADMIN", "ADMIN" },
                    { "45c6c794-997d-4179-b874-360833500607", "64174c00-11dd-4dea-a64c-e42c9f65269c", "USER", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 1,
                columns: new[] { "Customer_CategoryDescription", "Customer_CategoryName" },
                values: new object[] { "ADMIN", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 2,
                columns: new[] { "Customer_CategoryDescription", "Customer_CategoryName" },
                values: new object[] { "USER", "USER" });
        }
    }
}
