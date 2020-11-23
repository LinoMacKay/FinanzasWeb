using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class debtchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7117fcca-0bea-4cd8-940e-6094ccec4a03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbac8025-fe1c-4736-80dd-d8b5d02e2156");

            migrationBuilder.AlterColumn<decimal>(
                name: "Debt",
                table: "QuoteDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad0db63c-e384-44d4-93f4-de359f8bebaa", "fc1977b8-4906-4e6c-93fb-0faed97d0589", "ADMIN", "ADMIN" },
                    { "a9435dff-1ce4-475a-bc87-68250d87d8e6", "54363a51-0bf9-448a-8dce-a34a865afcab", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9435dff-1ce4-475a-bc87-68250d87d8e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0db63c-e384-44d4-93f4-de359f8bebaa");

            migrationBuilder.AlterColumn<int>(
                name: "Debt",
                table: "QuoteDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbac8025-fe1c-4736-80dd-d8b5d02e2156", "b08f3302-5768-4154-9526-df5e7564cc80", "ADMIN", "ADMIN" },
                    { "7117fcca-0bea-4cd8-940e-6094ccec4a03", "f541b4d5-739d-4934-b3ad-fe5b775ab836", "USER", "USER" }
                });
        }
    }
}
