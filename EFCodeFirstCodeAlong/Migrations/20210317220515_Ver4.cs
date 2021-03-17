using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCodeFirstCodeAlong.Migrations
{
    public partial class Ver4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId",
                unique: true);
        }
    }
}
