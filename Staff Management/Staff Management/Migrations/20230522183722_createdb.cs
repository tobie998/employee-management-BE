using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staff_Management.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chucDanh",
                columns: table => new
                {
                    Machucdanh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenchucdanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucDanh", x => x.Machucdanh);
                });

            migrationBuilder.CreateTable(
                name: "chucVu",
                columns: table => new
                {
                    Machucvu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenchucvu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucVu", x => x.Machucvu);
                });

            migrationBuilder.CreateTable(
                name: "congTrinhKH_CN",
                columns: table => new
                {
                    MacongtrinhKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaicongtrinhKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congTrinhKH_CN", x => x.MacongtrinhKH);
                });

            migrationBuilder.CreateTable(
                name: "deTaiDuAn",
                columns: table => new
                {
                    Madetai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tendetai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deTaiDuAn", x => x.Madetai);
                });

            migrationBuilder.CreateTable(
                name: "donVi",
                columns: table => new
                {
                    Madonvi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tendonvi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Nguoidungdau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dienthoai = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donVi", x => x.Madonvi);
                });

            migrationBuilder.CreateTable(
                name: "giaiThuong",
                columns: table => new
                {
                    Magiaithuong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hinhthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giaiThuong", x => x.Magiaithuong);
                });

            migrationBuilder.CreateTable(
                name: "khenThuong",
                columns: table => new
                {
                    Makhenthuong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenkhenthuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khenThuong", x => x.Makhenthuong);
                });

            migrationBuilder.CreateTable(
                name: "KinhNghiemKH&CN",
                columns: table => new
                {
                    Mahinhthuchoidong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hinhthuchoidong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KinhNghiemKH&CN", x => x.Mahinhthuchoidong);
                });

            migrationBuilder.CreateTable(
                name: "kyLuat",
                columns: table => new
                {
                    Makyluat = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenkyluat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kyLuat", x => x.Makyluat);
                });

            migrationBuilder.CreateTable(
                name: "linhVuc",
                columns: table => new
                {
                    Malinhvuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenlinhvuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_linhVuc", x => x.Malinhvuc);
                });

            migrationBuilder.CreateTable(
                name: "quaTrinhDaoTao",
                columns: table => new
                {
                    Mabacdaotao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bacdaotao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quaTrinhDaoTao", x => x.Mabacdaotao);
                });

            migrationBuilder.CreateTable(
                name: "trinhDoNgoaiNgu",
                columns: table => new
                {
                    Mangoaingu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenngoaingu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trinhDoNgoaiNgu", x => x.Mangoaingu);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "vanBang",
                columns: table => new
                {
                    Mavanbang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenvanbang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
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
                    Namsinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Machucdanh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Machucvu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Madonvi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canBo", x => x.Macanbo);
                    table.ForeignKey(
                        name: "FK_canBo_chucDanh_Machucdanh",
                        column: x => x.Machucdanh,
                        principalTable: "chucDanh",
                        principalColumn: "Machucdanh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_canBo_chucVu_Madonvi",
                        column: x => x.Madonvi,
                        principalTable: "chucVu",
                        principalColumn: "Machucvu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_canBo_donVi_Madonvi",
                        column: x => x.Madonvi,
                        principalTable: "donVi",
                        principalColumn: "Madonvi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chuyenNganhKH_CN",
                columns: table => new
                {
                    Machuyennganh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenchuyennganh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Malinhvuc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuyenNganhKH_CN", x => x.Machuyennganh);
                    table.ForeignKey(
                        name: "FK_chuyenNganhKH_CN_linhVuc_Malinhvuc",
                        column: x => x.Malinhvuc,
                        principalTable: "linhVuc",
                        principalColumn: "Malinhvuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietCongTrinhKH_CN",
                columns: table => new
                {
                    MacongtrinhKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "chiTietDeTaiDuAnKH_CN",
                columns: table => new
                {
                    Madetai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tendetai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigianbatdau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigianketthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tinhtrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietDeTaiDuAnKH_CN", x => new { x.Madetai, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietDeTaiDuAnKH_CN_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietDeTaiDuAnKH_CN_deTaiDuAn_Madetai",
                        column: x => x.Madetai,
                        principalTable: "deTaiDuAn",
                        principalColumn: "Madetai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietDeTaiDuAnKHCNThamGia",
                columns: table => new
                {
                    Madetai = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "ChiTietGiaiThuong",
                columns: table => new
                {
                    Magiaithuong = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "chiTietKhenThuong",
                columns: table => new
                {
                    Makhenthuong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenkhenthuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Makyluat = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Maquatrinhcongtac = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "chiTietQuaTrinhDaoTao",
                columns: table => new
                {
                    Mabacdaotao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bacdaotao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chuyennganh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namtotnghiep = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietQuaTrinhDaoTao", x => new { x.Mabacdaotao, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietQuaTrinhDaoTao_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietQuaTrinhDaoTao_quaTrinhDaoTao_Mabacdaotao",
                        column: x => x.Mabacdaotao,
                        principalTable: "quaTrinhDaoTao",
                        principalColumn: "Mabacdaotao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietTrinhDoNgoaiNgu",
                columns: table => new
                {
                    Mangoaingu = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "chiTietVanBang",
                columns: table => new
                {
                    Mavanbang = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "chiTietVeKinhNghiemKH_CN",
                columns: table => new
                {
                    Mahinhthuchoidong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hinhthuchoidong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietVeKinhNghiemKH_CN", x => new { x.Mahinhthuchoidong, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietVeKinhNghiemKH_CN_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietVeKinhNghiemKH_CN_KinhNghiemKH&CN_Mahinhthuchoidong",
                        column: x => x.Mahinhthuchoidong,
                        principalTable: "KinhNghiemKH&CN",
                        principalColumn: "Mahinhthuchoidong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "congTrinhVaKetQuaNghienCuuDuocApDung",
                columns: table => new
                {
                    Macongtrinhnghiencuu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tencongtrinhnghiencuu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hinhthuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quymo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachiapdung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thoigian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false)
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
                name: "nghienCuuSinhDaHuongDan",
                columns: table => new
                {
                    MaNCS = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "chiTietChuyenNganhKH_CN",
                columns: table => new
                {
                    Machuyennganh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Macanbo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tenchuyennganh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietChuyenNganhKH_CN", x => new { x.Machuyennganh, x.Macanbo });
                    table.ForeignKey(
                        name: "FK_chiTietChuyenNganhKH_CN_canBo_Macanbo",
                        column: x => x.Macanbo,
                        principalTable: "canBo",
                        principalColumn: "Macanbo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietChuyenNganhKH_CN_chuyenNganhKH_CN_Machuyennganh",
                        column: x => x.Machuyennganh,
                        principalTable: "chuyenNganhKH_CN",
                        principalColumn: "Machuyennganh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_canBo_Machucdanh",
                table: "canBo",
                column: "Machucdanh");

            migrationBuilder.CreateIndex(
                name: "IX_canBo_Madonvi",
                table: "canBo",
                column: "Madonvi");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietChuyenNganhKH_CN_Macanbo",
                table: "chiTietChuyenNganhKH_CN",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietCongTrinhKH_CN_Macanbo",
                table: "chiTietCongTrinhKH_CN",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDeTaiDuAnKH_CN_Macanbo",
                table: "chiTietDeTaiDuAnKH_CN",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietDeTaiDuAnKHCNThamGia_Macanbo",
                table: "chiTietDeTaiDuAnKHCNThamGia",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGiaiThuong_Macanbo",
                table: "ChiTietGiaiThuong",
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
                name: "IX_chiTietQuaTrinhDaoTao_Macanbo",
                table: "chiTietQuaTrinhDaoTao",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietTrinhDoNgoaiNgu_Macanbo",
                table: "chiTietTrinhDoNgoaiNgu",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietVanBang_Macanbo",
                table: "chiTietVanBang",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietVeKinhNghiemKH_CN_Macanbo",
                table: "chiTietVeKinhNghiemKH_CN",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chuyenNganhKH_CN_Malinhvuc",
                table: "chuyenNganhKH_CN",
                column: "Malinhvuc");

            migrationBuilder.CreateIndex(
                name: "IX_congTrinhVaKetQuaNghienCuuDuocApDung_Macanbo",
                table: "congTrinhVaKetQuaNghienCuuDuocApDung",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_nghienCuuSinhDaHuongDan_Macanbo",
                table: "nghienCuuSinhDaHuongDan",
                column: "Macanbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietChuyenNganhKH_CN");

            migrationBuilder.DropTable(
                name: "chiTietCongTrinhKH_CN");

            migrationBuilder.DropTable(
                name: "chiTietDeTaiDuAnKH_CN");

            migrationBuilder.DropTable(
                name: "chiTietDeTaiDuAnKHCNThamGia");

            migrationBuilder.DropTable(
                name: "ChiTietGiaiThuong");

            migrationBuilder.DropTable(
                name: "chiTietKhenThuong");

            migrationBuilder.DropTable(
                name: "chiTietKyLuat");

            migrationBuilder.DropTable(
                name: "chiTietQuaTrinhCongTac");

            migrationBuilder.DropTable(
                name: "chiTietQuaTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "chiTietTrinhDoNgoaiNgu");

            migrationBuilder.DropTable(
                name: "chiTietVanBang");

            migrationBuilder.DropTable(
                name: "chiTietVeKinhNghiemKH_CN");

            migrationBuilder.DropTable(
                name: "congTrinhVaKetQuaNghienCuuDuocApDung");

            migrationBuilder.DropTable(
                name: "nghienCuuSinhDaHuongDan");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "chuyenNganhKH_CN");

            migrationBuilder.DropTable(
                name: "congTrinhKH_CN");

            migrationBuilder.DropTable(
                name: "deTaiDuAn");

            migrationBuilder.DropTable(
                name: "giaiThuong");

            migrationBuilder.DropTable(
                name: "khenThuong");

            migrationBuilder.DropTable(
                name: "kyLuat");

            migrationBuilder.DropTable(
                name: "quaTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "trinhDoNgoaiNgu");

            migrationBuilder.DropTable(
                name: "vanBang");

            migrationBuilder.DropTable(
                name: "KinhNghiemKH&CN");

            migrationBuilder.DropTable(
                name: "canBo");

            migrationBuilder.DropTable(
                name: "linhVuc");

            migrationBuilder.DropTable(
                name: "chucDanh");

            migrationBuilder.DropTable(
                name: "chucVu");

            migrationBuilder.DropTable(
                name: "donVi");
        }
    }
}
