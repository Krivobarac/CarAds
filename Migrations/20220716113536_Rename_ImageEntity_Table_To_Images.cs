using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAds.Migrations
{
    public partial class Rename_ImageEntity_Table_To_Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageEntity_Cars_CarId",
                table: "ImageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity");

            migrationBuilder.RenameTable(
                name: "ImageEntity",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_ImageEntity_CarId",
                table: "Images",
                newName: "IX_Images_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Cars_CarId",
                table: "Images",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Cars_CarId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ImageEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Images_CarId",
                table: "ImageEntity",
                newName: "IX_ImageEntity_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageEntity_Cars_CarId",
                table: "ImageEntity",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
