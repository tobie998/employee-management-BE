using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class updatedbcanbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietChucDanh");

            migrationBuilder.DropTable(
                name: "chiTietChucVu");

            migrationBuilder.RenameColumn(
                name: "Tennkhenthuong",
                table: "chiTietKhenThuong",
                newName: "Tenkhenthuong");

            migrationBuilder.AddColumn<int>(
                name: "Machucdanh",
                table: "canBo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Machucvu",
                table: "canBo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_canBo_Machucdanh",
                table: "canBo",
                column: "Machucdanh");

            migrationBuilder.AddForeignKey(
                name: "FK_canBo_chucDanh_Machucdanh",
                table: "canBo",
                column: "Machucdanh",
                principalTable: "chucDanh",
                principalColumn: "Machucdanh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_canBo_chucVu_Madonvi",
                table: "canBo",
                column: "Madonvi",
                principalTable: "chucVu",
                principalColumn: "Machucvu",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_canBo_chucDanh_Machucdanh",
                table: "canBo");

            migrationBuilder.DropForeignKey(
                name: "FK_canBo_chucVu_Madonvi",
                table: "canBo");

            migrationBuilder.DropIndex(
                name: "IX_canBo_Machucdanh",
                table: "canBo");

            migrationBuilder.DropColumn(
                name: "Machucdanh",
                table: "canBo");

            migrationBuilder.DropColumn(
                name: "Machucvu",
                table: "canBo");

            migrationBuilder.RenameColumn(
                name: "Tenkhenthuong",
                table: "chiTietKhenThuong",
                newName: "Tennkhenthuong");

            migrationBuilder.CreateTable(
                name: "chiTietChucDanh",
                columns: table => new
                {
                    Machucdanh = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenchucdanh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietChucDanh", x => new { x.Machucdanh, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietChucDanh_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietChucDanh_chucDanh_Machucdanh",
                        column: x => x.Machucdanh,
                        principalTable: "chucDanh",
                        principalColumn: "Machucdanh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietChucVu",
                columns: table => new
                {
                    Machucvu = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenchucvu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietChucVu", x => new { x.Machucvu, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietChucVu_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietChucVu_chucVu_Machucvu",
                        column: x => x.Machucvu,
                        principalTable: "chucVu",
                        principalColumn: "Machucvu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietChucDanh_Macanbo",
                table: "chiTietChucDanh",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietChucVu_Macanbo",
                table: "chiTietChucVu",
                column: "Macanbo");
        }
    }
}
