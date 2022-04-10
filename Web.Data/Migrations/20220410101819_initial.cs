using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "im_Category",
                columns: table => new
                {
                    ID_DanhMuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Category", x => x.ID_DanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "im_Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "im_User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "im_Product_Type",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NhaCungCap = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Product_Type", x => x.ID);
                    table.ForeignKey(
                        name: "FK_im_Product_Type_im_Supplier_NhaCungCap",
                        column: x => x.NhaCungCap,
                        principalTable: "im_Supplier",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "im_Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_im_Invoice_im_User_User_ID",
                        column: x => x.User_ID,
                        principalTable: "im_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "im_Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    DanhMuc = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Gia = table.Column<int>(type: "int", nullable: false),
                    GiaMoi = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_List = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MoTaNgan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_im_Product_im_Category_DanhMuc",
                        column: x => x.DanhMuc,
                        principalTable: "im_Category",
                        principalColumn: "ID_DanhMuc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_im_Product_im_Product_Type_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "im_Product_Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "im_Invoice_Detail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDon_ID = table.Column<int>(type: "int", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhuyenMai = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Invoice_Detail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_im_Invoice_Detail_im_Invoice_HoaDon_ID",
                        column: x => x.HoaDon_ID,
                        principalTable: "im_Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "im_Comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    SanPham_ID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_im_Comment_im_Product_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "im_Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_im_Comment_im_User_User_ID",
                        column: x => x.User_ID,
                        principalTable: "im_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_im_Comment_SanPhamID",
                table: "im_Comment",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_im_Comment_User_ID",
                table: "im_Comment",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_im_Invoice_User_ID",
                table: "im_Invoice",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_im_Invoice_Detail_HoaDon_ID",
                table: "im_Invoice_Detail",
                column: "HoaDon_ID");

            migrationBuilder.CreateIndex(
                name: "IX_im_Product_DanhMuc",
                table: "im_Product",
                column: "DanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_im_Product_MaLoai",
                table: "im_Product",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_im_Product_Type_NhaCungCap",
                table: "im_Product_Type",
                column: "NhaCungCap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "im_Comment");

            migrationBuilder.DropTable(
                name: "im_Invoice_Detail");

            migrationBuilder.DropTable(
                name: "im_Product");

            migrationBuilder.DropTable(
                name: "im_Invoice");

            migrationBuilder.DropTable(
                name: "im_Category");

            migrationBuilder.DropTable(
                name: "im_Product_Type");

            migrationBuilder.DropTable(
                name: "im_User");

            migrationBuilder.DropTable(
                name: "im_Supplier");
        }
    }
}
