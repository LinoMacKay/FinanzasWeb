using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33083faf-6f59-4084-b6f9-443023752b0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0ba2a4-708c-4904-a838-0265eb2218a8");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "QuoteDetails");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "QuoteDetails",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "565d1313-a006-44a7-b627-4236ed2745e4", "eb154040-9288-42bb-9760-8ce58e6c8381", "ADMIN", "ADMIN" },
                    { "aac6e899-ff94-4d9c-bec0-c71d5dd9e0f9", "47617651-6b02-4942-9c28-cbfb83ce11bd", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "565d1313-a006-44a7-b627-4236ed2745e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac6e899-ff94-4d9c-bec0-c71d5dd9e0f9");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "QuoteDetails");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "QuoteDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33083faf-6f59-4084-b6f9-443023752b0c", "e05d0b12-c4cd-4d96-8df6-5046655cafaa", "ADMIN", "ADMIN" },
                    { "cd0ba2a4-708c-4904-a838-0265eb2218a8", "467aa635-3887-46cc-916f-815257cdd548", "USER", "USER" }
                });
        }
    }
}
