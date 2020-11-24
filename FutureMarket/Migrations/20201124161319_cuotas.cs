using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodYeah.Migrations
{
    public partial class cuotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FirstPaidDay",
                table: "QuoteDetails");

            migrationBuilder.DropColumn(
                name: "LastPaidDay",
                table: "QuoteDetails");

            migrationBuilder.DropColumn(
                name: "Quotes",
                table: "QuoteDetails");

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<decimal>(nullable: false),
                    FirstPaidDay = table.Column<DateTime>(nullable: false),
                    LastPaidDay = table.Column<DateTime>(nullable: false),
                    QuoteDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quote_QuoteDetails_QuoteDetailsId",
                        column: x => x.QuoteDetailsId,
                        principalTable: "QuoteDetails",
                        principalColumn: "QuoteDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "df4578a4-677e-46e5-8ee1-cbae08160a8f", "ea6c366a-0a18-4459-ba9c-9b303df5e1dc", "ADMIN", "ADMIN" },
                    { "2c1427be-09da-4477-8df5-21d114a28f06", "b18bd37e-1b15-4a2c-8d14-f6882e1c43bb", "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quote_QuoteDetailsId",
                table: "Quote",
                column: "QuoteDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c1427be-09da-4477-8df5-21d114a28f06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4578a4-677e-46e5-8ee1-cbae08160a8f");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstPaidDay",
                table: "QuoteDetails",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaidDay",
                table: "QuoteDetails",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal[]>(
                name: "Quotes",
                table: "QuoteDetails",
                type: "numeric[]",
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
    }
}
