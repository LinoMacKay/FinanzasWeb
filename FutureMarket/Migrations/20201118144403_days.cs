using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class days : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9435dff-1ce4-475a-bc87-68250d87d8e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0db63c-e384-44d4-93f4-de359f8bebaa");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstPaidDay",
                table: "QuoteDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaidDay",
                table: "QuoteDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7cb9860b-1a1f-457c-8df6-73f4ff688062", "b68d269b-a279-4738-8c45-edab9cd0b02b", "ADMIN", "ADMIN" },
                    { "f923f385-48b4-478c-95b9-ed967a6572a6", "015c2b48-4ae9-4e17-8ed4-a5e858d3b4bb", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FirstPaidDay",
                table: "QuoteDetails");

            migrationBuilder.DropColumn(
                name: "LastPaidDay",
                table: "QuoteDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad0db63c-e384-44d4-93f4-de359f8bebaa", "fc1977b8-4906-4e6c-93fb-0faed97d0589", "ADMIN", "ADMIN" },
                    { "a9435dff-1ce4-475a-bc87-68250d87d8e6", "54363a51-0bf9-448a-8dce-a34a865afcab", "USER", "USER" }
                });
        }
    }
}
