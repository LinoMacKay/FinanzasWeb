using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodYeah.Migrations
{
    public partial class loc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b4f7ade-b3e8-4a5c-bb4e-161c4e6d08d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83abce12-4f29-4e2e-9974-fdb407bce269");

            migrationBuilder.CreateTable(
                name: "LOCs",
                columns: table => new
                {
                    LOCId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    TCEA = table.Column<float>(nullable: false),
                    Fee = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    LineOfCredit = table.Column<int>(nullable: false),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCs", x => x.LOCId);
                    table.ForeignKey(
                        name: "FK_LOCs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "152c95f4-7eb6-413d-aa02-97e45b61c71f", "cdb2ac9d-6a21-470d-9380-cd721e5be25c", "ADMIN", "ADMIN" },
                    { "63fe7afe-9478-4cd3-a96a-3e11366ca608", "6bc0ff33-2bf8-45de-8be9-ebef02062e3e", "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOCs_CustomerId",
                table: "LOCs",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOCs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "152c95f4-7eb6-413d-aa02-97e45b61c71f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63fe7afe-9478-4cd3-a96a-3e11366ca608");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83abce12-4f29-4e2e-9974-fdb407bce269", "8c448f5b-65e5-47d7-ac45-c5826ea5206d", "ADMIN", "ADMIN" },
                    { "3b4f7ade-b3e8-4a5c-bb4e-161c4e6d08d1", "54993085-36af-4cc9-bd2b-9f40f90d206c", "USER", "USER" }
                });
        }
    }
}
