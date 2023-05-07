using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class adddbinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chucDanh",
                columns: table => new
                {
                    Machucdanh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenchucdanh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucDanh", x => x.Machucdanh);
                });

            migrationBuilder.CreateTable(
                name: "chucVu",
                columns: table => new
                {
                    Machucvu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenchucvu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucVu", x => x.Machucvu);
                });

            migrationBuilder.CreateTable(
                name: "congTrinhKH_CN",
                columns: table => new
                {
                    MacongtrinhKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaicongtrinhKH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congTrinhKH_CN", x => x.MacongtrinhKH);
                });

            migrationBuilder.CreateTable(
                name: "deTaiDuAn",
                columns: table => new
                {
                    Madetai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tendetai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deTaiDuAn", x => x.Madetai);
                });

            migrationBuilder.CreateTable(
                name: "donvi",
                columns: table => new
                {
                    Madonvi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tendonvi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Nguoidungdau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dienthoai = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donvi", x => x.Madonvi);
                });

            migrationBuilder.CreateTable(
                name: "giaiThuong",
                columns: table => new
                {
                    Magiaithuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hinhthuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giaiThuong", x => x.Magiaithuong);
                });

            migrationBuilder.CreateTable(
                name: "khenThuong",
                columns: table => new
                {
                    Makhenthuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenkhenthuong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khenThuong", x => x.Makhenthuong);
                });

            migrationBuilder.CreateTable(
                name: "KinhNghiemKH&CN",
                columns: table => new
                {
                    Mahinhthuchoidong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hinhthuchoidong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KinhNghiemKH&CN", x => x.Mahinhthuchoidong);
                });

            migrationBuilder.CreateTable(
                name: "kyLuat",
                columns: table => new
                {
                    Makyluat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenkyluat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenkyluat2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kyLuat", x => x.Makyluat);
                });

            migrationBuilder.CreateTable(
                name: "linhVuc",
                columns: table => new
                {
                    Machuyennganh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenchuyennganh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_linhVuc", x => x.Machuyennganh);
                });

            migrationBuilder.CreateTable(
                name: "quaTrinhDaoTao",
                columns: table => new
                {
                    Mabacdaotao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bacdaotao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quaTrinhDaoTao", x => x.Mabacdaotao);
                });

            migrationBuilder.CreateTable(
                name: "trinhDoNgoaiNgu",
                columns: table => new
                {
                    Mangoaingu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenngoaingu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trinhDoNgoaiNgu", x => x.Mangoaingu);
                });

            migrationBuilder.CreateTable(
                name: "vanBang",
                columns: table => new
                {
                    Mavanbang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenvanbang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vanBang", x => x.Mavanbang);
                });

            migrationBuilder.CreateTable(
                name: "canBo",
                columns: table => new
                {
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namsinh = table.Column<int>(type: "int", nullable: false),
                    Gioitinh = table.Column<bool>(type: "bit", nullable: false),
                    Hocham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hocvi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namhocham = table.Column<int>(type: "int", nullable: false),
                    Namhocvi = table.Column<int>(type: "int", nullable: false),
                    Diachinharieng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dienthoainharieng = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Dienthoaicoquan = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bacluong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Luongcoban = table.Column<double>(type: "float", nullable: false),
                    Madonvi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canBo", x => x.Macanbo);
                    table.ForeignKey(
                        name: "FK_canBo_donvi_Madonvi",
                        column: x => x.Madonvi,
                        principalTable: "donvi",
                        principalColumn: "Madonvi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGiaiThuong",
                columns: table => new
                {
                    Magiaithuong = table.Column<int>(type: "int", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hinhthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Noidung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namtangthuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGiaiThuong", x => new { x.Magiaithuong, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_ChiTietGiaiThuong_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietGiaiThuong_giaiThuong_Magiaithuong",
                        column: x => x.Magiaithuong,
                        principalTable: "giaiThuong",
                        principalColumn: "Magiaithuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_canBo_Madonvi",
                table: "canBo",
                column: "Madonvi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGiaiThuong_Macanbo",
                table: "ChiTietGiaiThuong",
                column: "Macanbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietGiaiThuong");

            migrationBuilder.DropTable(
                name: "chucDanh");

            migrationBuilder.DropTable(
                name: "chucVu");

            migrationBuilder.DropTable(
                name: "congTrinhKH_CN");

            migrationBuilder.DropTable(
                name: "deTaiDuAn");

            migrationBuilder.DropTable(
                name: "khenThuong");

            migrationBuilder.DropTable(
                name: "KinhNghiemKH&CN");

            migrationBuilder.DropTable(
                name: "kyLuat");

            migrationBuilder.DropTable(
                name: "linhVuc");

            migrationBuilder.DropTable(
                name: "quaTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "trinhDoNgoaiNgu");

            migrationBuilder.DropTable(
                name: "vanBang");

            migrationBuilder.DropTable(
                name: "canBo");

            migrationBuilder.DropTable(
                name: "giaiThuong");

            migrationBuilder.DropTable(
                name: "donvi");
        }
    }
}
