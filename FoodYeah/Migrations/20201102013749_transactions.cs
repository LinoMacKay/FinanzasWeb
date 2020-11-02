using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodYeah.Migrations
{
    public partial class transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2259292a-043b-4f29-b940-5abc314d192c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c1ee389-5cc2-49ce-830f-99fbcd1df486");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "544626b1-d21f-41bc-b107-f7cc1519d7c0", "571dcd77-0d83-4c8f-9cca-0a1d2d3ed65b", "ADMIN", "ADMIN" },
                    { "a65aacca-2dd6-4a29-995a-0ba62e4f8687", "d6de3143-c7ec-442f-8d1d-fde5af77199e", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "544626b1-d21f-41bc-b107-f7cc1519d7c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a65aacca-2dd6-4a29-995a-0ba62e4f8687");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2259292a-043b-4f29-b940-5abc314d192c", "2bc71c68-8a8e-454d-b1b4-be2caa062837", "ADMIN", "ADMIN" },
                    { "7c1ee389-5cc2-49ce-830f-99fbcd1df486", "d480bf7f-1191-4275-91a5-b8bb3739ae0c", "USER", "USER" }
                });
        }
    }
}
