using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class quotesnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_QuoteDetails_QuoteDetailsId",
                table: "Quote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quote",
                table: "Quote");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78e36cd8-a5dc-47aa-96d8-d10ede5dec94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d734795f-d50c-41c8-81f3-c408b16dedb4");

            migrationBuilder.RenameTable(
                name: "Quote",
                newName: "Quotes");

            migrationBuilder.RenameIndex(
                name: "IX_Quote_QuoteDetailsId",
                table: "Quotes",
                newName: "IX_Quotes_QuoteDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes",
                column: "QuoteId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17d55e8a-3904-45f2-b5aa-6bcb42a5dd17", "4fe61d2a-fc6c-4465-b561-3712a2c2ba24", "ADMIN", "ADMIN" },
                    { "c7891fa9-9797-4b2c-8994-713034ad7a7a", "c79d4b04-61a0-4aea-98a8-93673ce30d16", "USER", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteDetails_QuoteDetailsId",
                table: "Quotes",
                column: "QuoteDetailsId",
                principalTable: "QuoteDetails",
                principalColumn: "QuoteDetailsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteDetails_QuoteDetailsId",
                table: "Quotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d55e8a-3904-45f2-b5aa-6bcb42a5dd17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7891fa9-9797-4b2c-8994-713034ad7a7a");

            migrationBuilder.RenameTable(
                name: "Quotes",
                newName: "Quote");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_QuoteDetailsId",
                table: "Quote",
                newName: "IX_Quote_QuoteDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quote",
                table: "Quote",
                column: "QuoteId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78e36cd8-a5dc-47aa-96d8-d10ede5dec94", "3d91c43a-b580-4441-98c9-97392dc594ec", "ADMIN", "ADMIN" },
                    { "d734795f-d50c-41c8-81f3-c408b16dedb4", "68845d77-0bcd-4abf-80bd-d22789de30dd", "USER", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_QuoteDetails_QuoteDetailsId",
                table: "Quote",
                column: "QuoteDetailsId",
                principalTable: "QuoteDetails",
                principalColumn: "QuoteDetailsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
