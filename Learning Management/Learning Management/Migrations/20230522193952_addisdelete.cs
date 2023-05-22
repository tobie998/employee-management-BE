using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Management.Migrations
{
    /// <inheritdoc />
    public partial class addisdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diachi",
                table: "NhanSu");

            migrationBuilder.AddColumn<int>(
                name: "isDelete",
                table: "NhanSu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "NhanSu");

            migrationBuilder.AddColumn<string>(
                name: "Diachi",
                table: "NhanSu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
