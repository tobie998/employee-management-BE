using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Researcher_Management.Migrations
{
    /// <inheritdoc />
    public partial class inittablecanbo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "canBoNghienCuu",
                columns: table => new
                {
                    Macanbonghiencuu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Chunhiemdetai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Chucdanhnghenghiep = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hocham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dienthoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Khoacongtac = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canBoNghienCuu", x => x.Macanbonghiencuu);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "canBoNghienCuu");
        }
    }
}
