using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "6321e376-3d80-4bdf-8bdf-7fee6f80be0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc030306-5163-425d-9596-4bae2f5c7e1a");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10beda8d-ad86-4513-840d-a55316e91019", "55dc447c-013b-4a22-86ef-cf9b5f4cbb6c", "ADMIN", "ADMIN" },
                    { "3397b14e-fce2-4d4d-9ad8-155ebfdaf4f8", "0217813d-e717-4958-89bd-104b496a1780", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10beda8d-ad86-4513-840d-a55316e91019");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3397b14e-fce2-4d4d-9ad8-155ebfdaf4f8");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Customers",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6321e376-3d80-4bdf-8bdf-7fee6f80be0b", "dbf3a4dc-a57a-49f6-af16-153bde3a0ca2", "ADMIN", "ADMIN" },
                    { "fc030306-5163-425d-9596-4bae2f5c7e1a", "bc9fd249-2683-4e82-96bf-04f5769a8fbf", "USER", "USER" }
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
    }
}
