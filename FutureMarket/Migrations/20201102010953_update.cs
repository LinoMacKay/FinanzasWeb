using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DateOfIssue",
                table: "LOCs");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "LOCs");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "LOCs");

            migrationBuilder.DropColumn(
                name: "LineOfCredit",
                table: "LOCs");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "LOCs");

            migrationBuilder.AddColumn<int>(
                name: "TotalLineOfCredit",
                table: "LOCs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "883089d5-41e9-41b3-861d-cf3ec783775b", "e6e2a836-a454-476e-a79a-a2015e41880a", "ADMIN", "ADMIN" },
                    { "d2a42a83-1701-4b46-9871-d094eea24d7f", "7856d49d-7229-45f1-a7ea-3a89fa7a39ad", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "883089d5-41e9-41b3-861d-cf3ec783775b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2a42a83-1701-4b46-9871-d094eea24d7f");

            migrationBuilder.DropColumn(
                name: "TotalLineOfCredit",
                table: "LOCs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfIssue",
                table: "LOCs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "LOCs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Fee",
                table: "LOCs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LineOfCredit",
                table: "LOCs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LOCs",
                type: "integer",
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
    }
}
