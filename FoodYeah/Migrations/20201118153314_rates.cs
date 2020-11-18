using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class rates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cb9860b-1a1f-457c-8df6-73f4ff688062");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f923f385-48b4-478c-95b9-ed967a6572a6");

            migrationBuilder.DropColumn(
                name: "TEA",
                table: "LOCs");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "LOCs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TypeRate",
                table: "LOCs",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Rate",
                table: "LOCs");

            migrationBuilder.DropColumn(
                name: "TypeRate",
                table: "LOCs");

            migrationBuilder.AddColumn<decimal>(
                name: "TEA",
                table: "LOCs",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7cb9860b-1a1f-457c-8df6-73f4ff688062", "b68d269b-a279-4738-8c45-edab9cd0b02b", "ADMIN", "ADMIN" },
                    { "f923f385-48b4-478c-95b9-ed967a6572a6", "015c2b48-4ae9-4e17-8ed4-a5e858d3b4bb", "USER", "USER" }
                });
        }
    }
}
