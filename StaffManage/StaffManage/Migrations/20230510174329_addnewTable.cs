using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class addnewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "chiTietQuaTrinhDaoTao",
                columns: table => new
                {
                    Mabacdaotao = table.Column<int>(type: "int", nullable: false),
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
                name: "chiTietVeKinhNghiemKH_CN",
                columns: table => new
                {
                    Mahinhthuchoidong = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_chiTietChucDanh_Macanbo",
                table: "chiTietChucDanh",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietQuaTrinhDaoTao_Macanbo",
                table: "chiTietQuaTrinhDaoTao",
                column: "Macanbo");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietVeKinhNghiemKH_CN_Macanbo",
                table: "chiTietVeKinhNghiemKH_CN",
                column: "Macanbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietChucDanh");

            migrationBuilder.DropTable(
                name: "chiTietQuaTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "chiTietVeKinhNghiemKH_CN");
        }
    }
}
