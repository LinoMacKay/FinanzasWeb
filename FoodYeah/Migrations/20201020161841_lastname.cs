using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class lastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10beda8d-ad86-4513-840d-a55316e91019");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3397b14e-fce2-4d4d-9ad8-155ebfdaf4f8");

            migrationBuilder.AddColumn<string>(
                name: "CustomerLastName",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e53556c6-210c-405f-80b7-c691f2613900", "0093cb1c-a4d2-4203-961a-fab9f195b9fb", "ADMIN", "ADMIN" },
                    { "d9b2eb71-b12b-4a0f-9593-89d79ae521e0", "9b9ce28f-8858-47e3-9e1c-26b53aea1c19", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9b2eb71-b12b-4a0f-9593-89d79ae521e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e53556c6-210c-405f-80b7-c691f2613900");

            migrationBuilder.DropColumn(
                name: "CustomerLastName",
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
    }
}
