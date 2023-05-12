using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class addfulldatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chiTietDeTaiDuAnKHCNThamGia",
                columns: table => new
                {
                    Madetai = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tendetai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigianbatdau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigianketthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tinhtrang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietDeTaiDuAnKHCNThamGia", x => new { x.Madetai, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietDeTaiDuAnKHCNThamGia_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietDeTaiDuAnKHCNThamGia_deTaiDuAn_Madetai",
                        column: x => x.Madetai,
                        principalTable: "deTaiDuAn",
                        principalColumn: "Madetai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietVanBang",
                columns: table => new
                {
                    Mavanbang = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenvanbang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Noidungvanbang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namcap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietVanBang", x => new { x.Mavanbang, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietVanBang_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietVanBang_vanBang_Mavanbang",
                        column: x => x.Mavanbang,
                        principalTable: "vanBang",
                        principalColumn: "Mavanbang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "congTrinhVaKetQuaNghienCuuDuocApDung",
                columns: table => new
                {
                    Macongtrinhnghiencuu = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tencongtrinhnghiencuu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hinhthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quymo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachiapdung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigian = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congTrinhVaKetQuaNghienCuuDuocApDung", x => new { x.Macongtrinhnghiencuu, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_congTrinhVaKetQuaNghienCuuDuocApDung_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deTaiDuAnKHCNChuTri",
                columns: table => new
                {
                    Madetai = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tendetai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigianbatdau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigianketthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tinhtrang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deTaiDuAnKHCNChuTri", x => new { x.Madetai, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_deTaiDuAnKHCNChuTri_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deTaiDuAnKHCNChuTri_deTaiDuAn_Madetai",
                        column: x => x.Madetai,
                        principalTable: "deTaiDuAn",
                        principalColumn: "Madetai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDeTaiDuAnKHCNThamGia_Macanbo",
                table: "chiTietDeTaiDuAnKHCNThamGia",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietVanBang_Macanbo",
                table: "chiTietVanBang",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_congTrinhVaKetQuaNghienCuuDuocApDung_Macanbo",
                table: "congTrinhVaKetQuaNghienCuuDuocApDung",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_deTaiDuAnKHCNChuTri_Macanbo",
                table: "deTaiDuAnKHCNChuTri",
                column: "Macanbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietDeTaiDuAnKHCNThamGia");

            migrationBuilder.DropTable(
                name: "chiTietVanBang");

            migrationBuilder.DropTable(
                name: "congTrinhVaKetQuaNghienCuuDuocApDung");

            migrationBuilder.DropTable(
                name: "deTaiDuAnKHCNChuTri");
        }
    }
}
