using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "152c95f4-7eb6-413d-aa02-97e45b61c71f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63fe7afe-9478-4cd3-a96a-3e11366ca608");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bedc8a03-7c90-463b-9da2-082cbfc298a6", "9fbfa6c1-2e45-4f03-a3e4-5213782f3863", "ADMIN", "ADMIN" },
                    { "45c6c794-997d-4179-b874-360833500607", "64174c00-11dd-4dea-a64c-e42c9f65269c", "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId1",
                table: "Customers",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_CustomerId1",
                table: "Customers",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_CustomerId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerId1",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45c6c794-997d-4179-b874-360833500607");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bedc8a03-7c90-463b-9da2-082cbfc298a6");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "152c95f4-7eb6-413d-aa02-97e45b61c71f", "cdb2ac9d-6a21-470d-9380-cd721e5be25c", "ADMIN", "ADMIN" },
                    { "63fe7afe-9478-4cd3-a96a-3e11366ca608", "6bc0ff33-2bf8-45de-8be9-ebef02062e3e", "USER", "USER" }
                });
        }
    }
}
