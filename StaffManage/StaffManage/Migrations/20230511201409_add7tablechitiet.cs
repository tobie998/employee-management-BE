using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class add7tablechitiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chiTietCongTrinhKH_CN",
                columns: table => new
                {
                    MacongtrinhKH = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaicongtrinhKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TencongtrinhKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vaitro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Noicongbo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namcongbo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietCongTrinhKH_CN", x => new { x.MacongtrinhKH, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietCongTrinhKH_CN_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietCongTrinhKH_CN_congTrinhKH_CN_MacongtrinhKH",
                        column: x => x.MacongtrinhKH,
                        principalTable: "congTrinhKH_CN",
                        principalColumn: "MacongtrinhKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietKhenThuong",
                columns: table => new
                {
                    Makhenthuong = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tennkhenthuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngayapdung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietKhenThuong", x => new { x.Makhenthuong, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietKhenThuong_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietKhenThuong_khenThuong_Makhenthuong",
                        column: x => x.Makhenthuong,
                        principalTable: "khenThuong",
                        principalColumn: "Makhenthuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietKyLuat",
                columns: table => new
                {
                    Makyluat = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenkyluat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngayapdung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietKyLuat", x => new { x.Makyluat, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietKyLuat_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietKyLuat_kyLuat_Makyluat",
                        column: x => x.Makyluat,
                        principalTable: "kyLuat",
                        principalColumn: "Makyluat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietQuaTrinhCongTac",
                columns: table => new
                {
                    Maquatrinhcongtac = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Thoigian = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Vitricongtac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linhvucchuyenmon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coquancongtac = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietQuaTrinhCongTac", x => new { x.Maquatrinhcongtac, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietQuaTrinhCongTac_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietTrinhDoNgoaiNgu",
                columns: table => new
                {
                    Mangoaingu = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nghe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Noi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Viet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenngoaingu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietTrinhDoNgoaiNgu", x => new { x.Mangoaingu, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietTrinhDoNgoaiNgu_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietTrinhDoNgoaiNgu_trinhDoNgoaiNgu_Mangoaingu",
                        column: x => x.Mangoaingu,
                        principalTable: "trinhDoNgoaiNgu",
                        principalColumn: "Mangoaingu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nghienCuuSinhDaHuongDan",
                columns: table => new
                {
                    MaNCS = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HotenNCS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vaitro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Donvicongtac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NambaovecuaNCS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nghienCuuSinhDaHuongDan", x => new { x.MaNCS, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_nghienCuuSinhDaHuongDan_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietCongTrinhKH_CN_Macanbo",
                table: "chiTietCongTrinhKH_CN",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietKhenThuong_Macanbo",
                table: "chiTietKhenThuong",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietKyLuat_Macanbo",
                table: "chiTietKyLuat",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietQuaTrinhCongTac_Macanbo",
                table: "chiTietQuaTrinhCongTac",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietTrinhDoNgoaiNgu_Macanbo",
                table: "chiTietTrinhDoNgoaiNgu",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_nghienCuuSinhDaHuongDan_Macanbo",
                table: "nghienCuuSinhDaHuongDan",
                column: "Macanbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietCongTrinhKH_CN");

            migrationBuilder.DropTable(
                name: "chiTietKhenThuong");

            migrationBuilder.DropTable(
                name: "chiTietKyLuat");

            migrationBuilder.DropTable(
                name: "chiTietQuaTrinhCongTac");

            migrationBuilder.DropTable(
                name: "chiTietTrinhDoNgoaiNgu");

            migrationBuilder.DropTable(
                name: "nghienCuuSinhDaHuongDan");
        }
    }
}
