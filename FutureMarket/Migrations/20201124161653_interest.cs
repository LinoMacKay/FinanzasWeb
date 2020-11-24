using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class interest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c1427be-09da-4477-8df5-21d114a28f06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4578a4-677e-46e5-8ee1-cbae08160a8f");

            migrationBuilder.AddColumn<decimal>(
                name: "Interest",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78e36cd8-a5dc-47aa-96d8-d10ede5dec94", "3d91c43a-b580-4441-98c9-97392dc594ec", "ADMIN", "ADMIN" },
                    { "d734795f-d50c-41c8-81f3-c408b16dedb4", "68845d77-0bcd-4abf-80bd-d22789de30dd", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78e36cd8-a5dc-47aa-96d8-d10ede5dec94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d734795f-d50c-41c8-81f3-c408b16dedb4");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "Quote");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "df4578a4-677e-46e5-8ee1-cbae08160a8f", "ea6c366a-0a18-4459-ba9c-9b303df5e1dc", "ADMIN", "ADMIN" },
                    { "2c1427be-09da-4477-8df5-21d114a28f06", "b18bd37e-1b15-4a2c-8d14-f6882e1c43bb", "USER", "USER" }
                });
        }
    }
}
