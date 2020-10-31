using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class avaliblelineofcredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f99ecd-b66b-4773-82b9-6b9453b6561a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6725e2b5-3399-4ee0-967f-d8483bfa02dd");

            migrationBuilder.AddColumn<int>(
                name: "AvalibleLineOfCredit",
                table: "LOCs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dbfdd75-03a4-423c-a9eb-db4786a80541", "20559c54-f0f2-47b5-a6e1-e6fb7b7f6e68", "ADMIN", "ADMIN" },
                    { "84973117-c54f-435a-bb91-d1ff0aad83a8", "84fa5ba2-7e67-4212-a852-852a35e84746", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dbfdd75-03a4-423c-a9eb-db4786a80541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84973117-c54f-435a-bb91-d1ff0aad83a8");

            migrationBuilder.DropColumn(
                name: "AvalibleLineOfCredit",
                table: "LOCs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6725e2b5-3399-4ee0-967f-d8483bfa02dd", "c52215db-c11b-4a9d-99b5-261b3bcae7b5", "ADMIN", "ADMIN" },
                    { "25f99ecd-b66b-4773-82b9-6b9453b6561a", "0826148b-cb6a-4918-9791-634ce3264194", "USER", "USER" }
                });
        }
    }
}
