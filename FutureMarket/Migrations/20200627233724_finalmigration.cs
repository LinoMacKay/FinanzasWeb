using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class finalmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c508c5-90d3-455f-a16e-0ee58e290a7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8b4a123-527a-45e8-894d-6db8433048f7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83abce12-4f29-4e2e-9974-fdb407bce269", "8c448f5b-65e5-47d7-ac45-c5826ea5206d", "ADMIN", "ADMIN" },
                    { "3b4f7ade-b3e8-4a5c-bb4e-161c4e6d08d1", "54993085-36af-4cc9-bd2b-9f40f90d206c", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Customer_Categories",
                columns: new[] { "Customer_CategoryId", "Customer_CategoryDescription", "Customer_CategoryName" },
                values: new object[,]
                {
                    { 1, "ADMIN", "ADMIN" },
                    { 2, "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b4f7ade-b3e8-4a5c-bb4e-161c4e6d08d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83abce12-4f29-4e2e-9974-fdb407bce269");

            migrationBuilder.DeleteData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f8b4a123-527a-45e8-894d-6db8433048f7", "7033b61a-030e-49e0-8fba-3bc979f24962", "ADMIN", "ADMIN" },
                    { "16c508c5-90d3-455f-a16e-0ee58e290a7d", "2f5f9a1d-5150-4eb8-a8ff-3a0fdf796b67", "USER", "USER" }
                });
        }
    }
}
