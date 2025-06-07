using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            

            migrationBuilder.CreateTable(
                name: "LoaiDichVus",
                columns: table => new
                {
                    LoaiDichVuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDichVus", x => x.LoaiDichVuID);
                });


            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    DichVuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThoiGian = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiDichVuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.DichVuID);
                    table.ForeignKey(
                        name: "FK_DichVus_LoaiDichVus_LoaiDichVuID",
                        column: x => x.LoaiDichVuID,
                        principalTable: "LoaiDichVus",
                        principalColumn: "LoaiDichVuID",
                        onDelete: ReferentialAction.Cascade);
                });


      




            migrationBuilder.CreateIndex(
                name: "IX_DichVus_LoaiDichVuID",
                table: "DichVus",
                column: "LoaiDichVuID");

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "DichVus");

          

            migrationBuilder.DropTable(
                name: "LoaiDichVus");

        }
    }
}
