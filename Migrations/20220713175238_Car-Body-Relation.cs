using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAds.Migrations
{
    public partial class CarBodyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "BodyId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyId",
                table: "Cars",
                column: "BodyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Bodies_BodyId",
                table: "Cars",
                column: "BodyId",
                principalTable: "Bodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Bodies_BodyId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BodyId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BodyId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
