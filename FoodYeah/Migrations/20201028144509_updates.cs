using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodYeah.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f6fcba6-45e8-4e1e-8a76-3a61bebdb5e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30e53a8-817a-4662-8058-aac1f1229f59");

            migrationBuilder.AlterColumn<int>(
                name: "LOCId",
                table: "LOCs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e6dc6d1f-10c3-4e36-ae59-b38456779f57", "62e27c9d-8341-4f74-930d-b68a15bdd1f2", "ADMIN", "ADMIN" },
                    { "91c7d691-c96c-4c5b-923a-ef737e65cbae", "736a985c-1f33-4af8-8c4f-83c58e988d8d", "USER", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91c7d691-c96c-4c5b-923a-ef737e65cbae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6dc6d1f-10c3-4e36-ae59-b38456779f57");

            migrationBuilder.AlterColumn<int>(
                name: "LOCId",
                table: "LOCs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f6fcba6-45e8-4e1e-8a76-3a61bebdb5e5", "d4b2cbb0-ab68-4070-9ffc-990d741e0a45", "ADMIN", "ADMIN" },
                    { "d30e53a8-817a-4662-8058-aac1f1229f59", "ff00a932-cf0d-45bf-bf3c-0da76f531bf7", "USER", "USER" }
                });
        }
    }
}
