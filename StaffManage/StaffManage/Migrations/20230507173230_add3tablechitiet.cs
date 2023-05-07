using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class add3tablechitiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "chiTietLinhVucNghienCuu",
                columns: table => new
                {
                    Machuyennganh = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenchuyennganh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietLinhVucNghienCuu", x => new { x.Machuyennganh, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietLinhVucNghienCuu_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietLinhVucNghienCuu_linhVuc_Machuyennganh",
                        column: x => x.Machuyennganh,
                        principalTable: "linhVuc",
                        principalColumn: "Machuyennganh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietChucVu_Macanbo",
                table: "chiTietChucVu",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLinhVucNghienCuu_Macanbo",
                table: "chiTietLinhVucNghienCuu",
                column: "Macanbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietChucVu");

            migrationBuilder.DropTable(
                name: "chiTietLinhVucNghienCuu");
        }
    }
}
