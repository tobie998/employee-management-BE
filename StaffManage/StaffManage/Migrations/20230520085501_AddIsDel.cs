using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManage.Migrations
{
    public partial class AddIsDel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "vanBang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "trinhDoNgoaiNgu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "quaTrinhDaoTao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "linhVuc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "kyLuat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "KinhNghiemKH&CN",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "khenThuong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "giaiThuong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "donvi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "deTaiDuAnKHCNChuTri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "deTaiDuAn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "congTrinhVaKetQuaNghienCuuDuocApDung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "congTrinhKH_CN",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "chucVu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "chucDanh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "canBo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "vanBang");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "trinhDoNgoaiNgu");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "quaTrinhDaoTao");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "linhVuc");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "kyLuat");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "KinhNghiemKH&CN");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "khenThuong");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "giaiThuong");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "donvi");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "deTaiDuAnKHCNChuTri");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "deTaiDuAn");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "congTrinhVaKetQuaNghienCuuDuocApDung");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "congTrinhKH_CN");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "chucVu");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "chucDanh");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "canBo");
        }
    }
}
