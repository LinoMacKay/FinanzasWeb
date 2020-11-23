using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class linktocustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "544626b1-d21f-41bc-b107-f7cc1519d7c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a65aacca-2dd6-4a29-995a-0ba62e4f8687");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a0e57f0-b07b-40d2-a884-3d9a40a1c10f", "db96f2d7-e8bd-4a02-acb2-8e0d61634a05", "ADMIN", "ADMIN" },
                    { "8469d882-ddd8-4edf-8bee-3e59acc7d666", "34e0307b-07f8-4cb4-97a7-b8bfb7680a64", "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a0e57f0-b07b-40d2-a884-3d9a40a1c10f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8469d882-ddd8-4edf-8bee-3e59acc7d666");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "544626b1-d21f-41bc-b107-f7cc1519d7c0", "571dcd77-0d83-4c8f-9cca-0a1d2d3ed65b", "ADMIN", "ADMIN" },
                    { "a65aacca-2dd6-4a29-995a-0ba62e4f8687", "d6de3143-c7ec-442f-8d1d-fde5af77199e", "USER", "USER" }
                });
        }
    }
}
