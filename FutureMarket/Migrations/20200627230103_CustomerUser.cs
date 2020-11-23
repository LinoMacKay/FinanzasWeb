using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class CustomerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f858f41-e5e2-4ddb-86a9-39ee04f5f62d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb029378-8fe8-474a-92c4-13446510ff7d");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f8b4a123-527a-45e8-894d-6db8433048f7", "7033b61a-030e-49e0-8fba-3bc979f24962", "ADMIN", "ADMIN" },
                    { "16c508c5-90d3-455f-a16e-0ee58e290a7d", "2f5f9a1d-5150-4eb8-a8ff-3a0fdf796b67", "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_Email",
                table: "Customers",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_Email",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c508c5-90d3-455f-a16e-0ee58e290a7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8b4a123-527a-45e8-894d-6db8433048f7");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f858f41-e5e2-4ddb-86a9-39ee04f5f62d", "7ed6ab38-9e9f-46c9-826c-1025e0720d38", "Admin", "ADMIN" },
                    { "fb029378-8fe8-474a-92c4-13446510ff7d", "6c1c5f42-061c-4c11-954e-e7497f592b8d", "User", "USER" }
                });
        }
    }
}
