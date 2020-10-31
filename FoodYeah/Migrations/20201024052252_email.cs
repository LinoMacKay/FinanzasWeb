using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9b2eb71-b12b-4a0f-9593-89d79ae521e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e53556c6-210c-405f-80b7-c691f2613900");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f6fcba6-45e8-4e1e-8a76-3a61bebdb5e5", "d4b2cbb0-ab68-4070-9ffc-990d741e0a45", "ADMIN", "ADMIN" },
                    { "d30e53a8-817a-4662-8058-aac1f1229f59", "ff00a932-cf0d-45bf-bf3c-0da76f531bf7", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f6fcba6-45e8-4e1e-8a76-3a61bebdb5e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30e53a8-817a-4662-8058-aac1f1229f59");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e53556c6-210c-405f-80b7-c691f2613900", "0093cb1c-a4d2-4203-961a-fab9f195b9fb", "ADMIN", "ADMIN" },
                    { "d9b2eb71-b12b-4a0f-9593-89d79ae521e0", "9b9ce28f-8858-47e3-9e1c-26b53aea1c19", "USER", "USER" }
                });
        }
    }
}
