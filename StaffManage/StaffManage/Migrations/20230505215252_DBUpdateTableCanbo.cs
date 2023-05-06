using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class DBUpdateTableCanbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_canBo_Madonvi",
                table: "canBo",
                column: "Madonvi");

            migrationBuilder.AddForeignKey(
                name: "FK_canBo_donvi_Madonvi",
                table: "canBo",
                column: "Madonvi",
                principalTable: "donvi",
                principalColumn: "Madonvi",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_canBo_donvi_Madonvi",
                table: "canBo");

            migrationBuilder.DropIndex(
                name: "IX_canBo_Madonvi",
                table: "canBo");
        }
    }
}
