using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodYeah.Migrations
{
    public partial class quotedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "883089d5-41e9-41b3-861d-cf3ec783775b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2a42a83-1701-4b46-9871-d094eea24d7f");

            migrationBuilder.CreateTable(
                name: "QuoteDetails",
                columns: table => new
                {
                    QuoteDetailsId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocId = table.Column<int>(nullable: false),
                    NumberQuotes = table.Column<int>(nullable: false),
                    Quotes = table.Column<List<decimal>>(nullable: true),
                    Frecuency = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    LastTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteDetails", x => x.QuoteDetailsId);
                    table.ForeignKey(
                        name: "FK_QuoteDetails_LOCs_LocId",
                        column: x => x.LocId,
                        principalTable: "LOCs",
                        principalColumn: "LOCId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2259292a-043b-4f29-b940-5abc314d192c", "2bc71c68-8a8e-454d-b1b4-be2caa062837", "ADMIN", "ADMIN" },
                    { "7c1ee389-5cc2-49ce-830f-99fbcd1df486", "d480bf7f-1191-4275-91a5-b8bb3739ae0c", "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteDetails_LocId",
                table: "QuoteDetails",
                column: "LocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2259292a-043b-4f29-b940-5abc314d192c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c1ee389-5cc2-49ce-830f-99fbcd1df486");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "883089d5-41e9-41b3-861d-cf3ec783775b", "e6e2a836-a454-476e-a79a-a2015e41880a", "ADMIN", "ADMIN" },
                    { "d2a42a83-1701-4b46-9871-d094eea24d7f", "7856d49d-7229-45f1-a7ea-3a89fa7a39ad", "USER", "USER" }
                });
        }
    }
}
