using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDPDay9LabCF.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PDPLoai_San_Pham",
                columns: table => new
                {
                    pdpId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pdpMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    pdpTenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pdpTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDPLoai_San_Pham", x => x.pdpId);
                });

            migrationBuilder.CreateTable(
                name: "PDPSan_Pham",
                columns: table => new
                {
                    pdpId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pdpMaSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    pdpTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pdpHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pdpSoLuong = table.Column<int>(type: "int", nullable: false),
                    pdpDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pdpLoaiSanPhamId = table.Column<long>(type: "bigint", nullable: false),
                    pdpLoai_San_PhampdpId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDPSan_Pham", x => x.pdpId);
                    table.ForeignKey(
                        name: "FK_PDPSan_Pham_PDPLoai_San_Pham_pdpLoai_San_PhampdpId",
                        column: x => x.pdpLoai_San_PhampdpId,
                        principalTable: "PDPLoai_San_Pham",
                        principalColumn: "pdpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PDPLoai_San_Pham_pdpMaLoai",
                table: "PDPLoai_San_Pham",
                column: "pdpMaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PDPSan_Pham_pdpLoai_San_PhampdpId",
                table: "PDPSan_Pham",
                column: "pdpLoai_San_PhampdpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PDPSan_Pham");

            migrationBuilder.DropTable(
                name: "PDPLoai_San_Pham");
        }
    }
}
