using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class tea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a0e57f0-b07b-40d2-a884-3d9a40a1c10f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8469d882-ddd8-4edf-8bee-3e59acc7d666");

            migrationBuilder.DropColumn(
                name: "TCEA",
                table: "LOCs");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Debt",
                table: "QuoteDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalLineOfCredit",
                table: "LOCs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "AvalibleLineOfCredit",
                table: "LOCs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "TEA",
                table: "LOCs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbac8025-fe1c-4736-80dd-d8b5d02e2156", "b08f3302-5768-4154-9526-df5e7564cc80", "ADMIN", "ADMIN" },
                    { "7117fcca-0bea-4cd8-940e-6094ccec4a03", "f541b4d5-739d-4934-b3ad-fe5b775ab836", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7117fcca-0bea-4cd8-940e-6094ccec4a03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbac8025-fe1c-4736-80dd-d8b5d02e2156");

            migrationBuilder.DropColumn(
                name: "Debt",
                table: "QuoteDetails");

            migrationBuilder.DropColumn(
                name: "TEA",
                table: "LOCs");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transactions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "TotalLineOfCredit",
                table: "LOCs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "AvalibleLineOfCredit",
                table: "LOCs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<float>(
                name: "TCEA",
                table: "LOCs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a0e57f0-b07b-40d2-a884-3d9a40a1c10f", "db96f2d7-e8bd-4a02-acb2-8e0d61634a05", "ADMIN", "ADMIN" },
                    { "8469d882-ddd8-4edf-8bee-3e59acc7d666", "34e0307b-07f8-4cb4-97a7-b8bfb7680a64", "USER", "USER" }
                });
        }
    }
}
