using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class AddNewTable : Migration
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
                    Tenkyluat = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chucDanh");

            migrationBuilder.DropTable(
                name: "chucVu");

            migrationBuilder.DropTable(
                name: "congTrinhKH_CN");

            migrationBuilder.DropTable(
                name: "deTaiDuAn");

            migrationBuilder.DropTable(
                name: "giaiThuong");

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
        }
    }
}
