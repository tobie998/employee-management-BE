using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Management.Migrations
{
    /// <inheritdoc />
    public partial class initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanSu",
                columns: table => new
                {
                    Manhansu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tennhansu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quequan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chucvu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanSu", x => x.Manhansu);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanSu");
        }
    }
}
