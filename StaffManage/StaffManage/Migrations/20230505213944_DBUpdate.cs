using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class DBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Luongcoban = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canBo", x => x.Macanbo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "canBo");
        }
    }
}
