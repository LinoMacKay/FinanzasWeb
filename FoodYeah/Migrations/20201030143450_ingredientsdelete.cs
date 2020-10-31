using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodYeah.Migrations
{
    public partial class ingredientsdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOCs_Customers_CustomerId",
                table: "LOCs");

            migrationBuilder.DropIndex(
                name: "IX_LOCs_CustomerId",
                table: "LOCs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91c7d691-c96c-4c5b-923a-ef737e65cbae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6dc6d1f-10c3-4e36-ae59-b38456779f57");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "LOCId",
                table: "LOCs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6725e2b5-3399-4ee0-967f-d8483bfa02dd", "c52215db-c11b-4a9d-99b5-261b3bcae7b5", "ADMIN", "ADMIN" },
                    { "25f99ecd-b66b-4773-82b9-6b9453b6561a", "0826148b-cb6a-4918-9791-634ce3264194", "USER", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LOCs_Customers_LOCId",
                table: "LOCs",
                column: "LOCId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LOCs_Customers_LOCId",
                table: "LOCs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f99ecd-b66b-4773-82b9-6b9453b6561a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6725e2b5-3399-4ee0-967f-d8483bfa02dd");

            migrationBuilder.AddColumn<string[]>(
                name: "Ingredients",
                table: "Products",
                type: "text[]",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "LOCId",
                table: "LOCs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e6dc6d1f-10c3-4e36-ae59-b38456779f57", "62e27c9d-8341-4f74-930d-b68a15bdd1f2", "ADMIN", "ADMIN" },
                    { "91c7d691-c96c-4c5b-923a-ef737e65cbae", "736a985c-1f33-4af8-8c4f-83c58e988d8d", "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOCs_CustomerId",
                table: "LOCs",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LOCs_Customers_CustomerId",
                table: "LOCs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
