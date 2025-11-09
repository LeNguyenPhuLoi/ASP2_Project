using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLinhKienDienTu.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHOHANG",
                columns: table => new
                {
                    STT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKHO = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    TENKHO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DIACHIKHO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MANV = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    SOLUONGLOAIHANG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHOHANG__CA1EB690DBCC293B", x => x.STT);
                });

            migrationBuilder.CreateTable(
                name: "LOAISANPHAM",
                columns: table => new
                {
                    MALOAI = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    TENLOAI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MOTA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSP", x => x.MALOAI);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASS = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    QUYEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TK", x => x.EMAIL);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    MASP = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    TENSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DONGIA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DVT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MOTA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HINHANH = table.Column<string>(type: "char(200)", unicode: false, fixedLength: true, maxLength: 200, nullable: true),
                    SOLUONGTON = table.Column<int>(type: "int", nullable: true),
                    MALOAI = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP", x => x.MASP);
                    table.ForeignKey(
                        name: "FK_SP_LSP",
                        column: x => x.MALOAI,
                        principalTable: "LOAISANPHAM",
                        principalColumn: "MALOAI");
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    MAKH = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    TENKH = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    SDT = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DIACHI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NGAYTAO = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KH", x => x.MAKH);
                    table.ForeignKey(
                        name: "FK_KH_TK",
                        column: x => x.EMAIL,
                        principalTable: "TAIKHOAN",
                        principalColumn: "EMAIL");
                });

            migrationBuilder.CreateTable(
                name: "LICHSUHOATDONG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    THOIGIAN = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    HOATDONG = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DOITUONG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CHITIET = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LICHSUHO__3214EC2713995A09", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LICHSUHOATDONG_TAIKHOAN",
                        column: x => x.EMAIL,
                        principalTable: "TAIKHOAN",
                        principalColumn: "EMAIL");
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MANV = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    TENNV = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GIOITINH = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NGAYSINH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHUC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LUONG = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    DIACHI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<int>(type: "int", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NV", x => x.MANV);
                    table.ForeignKey(
                        name: "FK_NV_TK",
                        column: x => x.EMAIL,
                        principalTable: "TAIKHOAN",
                        principalColumn: "EMAIL");
                });

            migrationBuilder.CreateTable(
                name: "KHO_SANPHAM",
                columns: table => new
                {
                    STT = table.Column<int>(type: "int", nullable: false),
                    MASP = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    NGAYNHAP = table.Column<DateTime>(type: "datetime", nullable: false),
                    SOLUONGNHAP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_K_SP", x => new { x.STT, x.MASP, x.NGAYNHAP });
                    table.ForeignKey(
                        name: "FK_KSP_KHO",
                        column: x => x.STT,
                        principalTable: "KHOHANG",
                        principalColumn: "STT");
                    table.ForeignKey(
                        name: "FK_KSP_SANPHAM",
                        column: x => x.MASP,
                        principalTable: "SANPHAM",
                        principalColumn: "MASP");
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    MAHD = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    NGAYLAP = table.Column<DateTime>(type: "datetime", nullable: true),
                    TONGTIEN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MAKH = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    MANV = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HD", x => x.MAHD);
                    table.ForeignKey(
                        name: "FK_H_NV",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                    table.ForeignKey(
                        name: "FK_HD_KH",
                        column: x => x.MAKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MAKH");
                });

            migrationBuilder.CreateTable(
                name: "CHITIETHOADON",
                columns: table => new
                {
                    MAHD = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    MASP = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    STT = table.Column<int>(type: "int", nullable: true),
                    SOLUONG = table.Column<int>(type: "int", nullable: true),
                    DONGIA = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    THANHTIEN = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHD", x => new { x.MAHD, x.MASP });
                    table.ForeignKey(
                        name: "FK_CTHD_HD",
                        column: x => x.MAHD,
                        principalTable: "HOADON",
                        principalColumn: "MAHD");
                    table.ForeignKey(
                        name: "FK_CTHD_K",
                        column: x => x.STT,
                        principalTable: "KHOHANG",
                        principalColumn: "STT");
                    table.ForeignKey(
                        name: "FK_CTHD_SP",
                        column: x => x.MASP,
                        principalTable: "SANPHAM",
                        principalColumn: "MASP");
                });

            migrationBuilder.CreateTable(
                name: "GIOHANG",
                columns: table => new
                {
                    MAGH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKH = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    MASP = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: true),
                    MAHD = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GIOHANG__603F38A3C0DE190B", x => x.MAGH);
                    table.ForeignKey(
                        name: "FK_GH_HD",
                        column: x => x.MAHD,
                        principalTable: "HOADON",
                        principalColumn: "MAHD");
                    table.ForeignKey(
                        name: "FK_GH_KH",
                        column: x => x.MAKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MAKH");
                    table.ForeignKey(
                        name: "FK_GH_SP",
                        column: x => x.MASP,
                        principalTable: "SANPHAM",
                        principalColumn: "MASP");
                });

            migrationBuilder.CreateTable(
                name: "LICHSUMUAHANG",
                columns: table => new
                {
                    MALSMH = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    MAKH = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    MAHD = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    NGAYMUA = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    TONGTIEN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValue: "Hoàn tất")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSMH", x => x.MALSMH);
                    table.ForeignKey(
                        name: "FK_LSMH_HD",
                        column: x => x.MAHD,
                        principalTable: "HOADON",
                        principalColumn: "MAHD");
                    table.ForeignKey(
                        name: "FK_LSMH_KH",
                        column: x => x.MAKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MAKH");
                });

            migrationBuilder.CreateTable(
                name: "THANHTOAN",
                columns: table => new
                {
                    MATT = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    MAHD = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    PHUONGTHUC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NGAYTT = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    TONGTIEN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValue: "Đã thanh toán")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TT", x => x.MATT);
                    table.ForeignKey(
                        name: "FK_TT_HD",
                        column: x => x.MAHD,
                        principalTable: "HOADON",
                        principalColumn: "MAHD");
                });

            migrationBuilder.CreateTable(
                name: "CHITIETGIOHANG",
                columns: table => new
                {
                    MAGH = table.Column<int>(type: "int", nullable: false),
                    MASP = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: true),
                    DONGIA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    THANHTIEN = table.Column<decimal>(type: "decimal(29,2)", nullable: true, computedColumnSql: "([SOLUONG]*[DONGIA])", stored: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTGH", x => new { x.MAGH, x.MASP });
                    table.ForeignKey(
                        name: "FK_CTGH_GH",
                        column: x => x.MAGH,
                        principalTable: "GIOHANG",
                        principalColumn: "MAGH");
                    table.ForeignKey(
                        name: "FK_CTGH_SP",
                        column: x => x.MASP,
                        principalTable: "SANPHAM",
                        principalColumn: "MASP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETGIOHANG_MASP",
                table: "CHITIETGIOHANG",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETHOADON_MASP",
                table: "CHITIETHOADON",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETHOADON_STT",
                table: "CHITIETHOADON",
                column: "STT");

            migrationBuilder.CreateIndex(
                name: "IX_GIOHANG_MAHD",
                table: "GIOHANG",
                column: "MAHD");

            migrationBuilder.CreateIndex(
                name: "IX_GIOHANG_MAKH",
                table: "GIOHANG",
                column: "MAKH");

            migrationBuilder.CreateIndex(
                name: "IX_GIOHANG_MASP",
                table: "GIOHANG",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MAKH",
                table: "HOADON",
                column: "MAKH");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MANV",
                table: "HOADON",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_KHACHHANG_EMAIL",
                table: "KHACHHANG",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_KHO_SANPHAM_MASP",
                table: "KHO_SANPHAM",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_LICHSUHOATDONG_EMAIL",
                table: "LICHSUHOATDONG",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_LICHSUMUAHANG_MAHD",
                table: "LICHSUMUAHANG",
                column: "MAHD");

            migrationBuilder.CreateIndex(
                name: "IX_LICHSUMUAHANG_MAKH",
                table: "LICHSUMUAHANG",
                column: "MAKH");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_EMAIL",
                table: "NHANVIEN",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MALOAI",
                table: "SANPHAM",
                column: "MALOAI");

            migrationBuilder.CreateIndex(
                name: "IX_THANHTOAN_MAHD",
                table: "THANHTOAN",
                column: "MAHD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETGIOHANG");

            migrationBuilder.DropTable(
                name: "CHITIETHOADON");

            migrationBuilder.DropTable(
                name: "KHO_SANPHAM");

            migrationBuilder.DropTable(
                name: "LICHSUHOATDONG");

            migrationBuilder.DropTable(
                name: "LICHSUMUAHANG");

            migrationBuilder.DropTable(
                name: "THANHTOAN");

            migrationBuilder.DropTable(
                name: "GIOHANG");

            migrationBuilder.DropTable(
                name: "KHOHANG");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "LOAISANPHAM");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");
        }
    }
}
