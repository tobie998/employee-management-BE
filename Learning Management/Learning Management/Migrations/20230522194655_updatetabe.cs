using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Management.Migrations
{
    /// <inheritdoc />
    public partial class updatetabe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quequan",
                table: "NhanSu");

            migrationBuilder.AddColumn<string>(
                name: "Diachi",
                table: "NhanSu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diachi",
                table: "NhanSu");

            migrationBuilder.AddColumn<string>(
                name: "Quequan",
                table: "NhanSu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
