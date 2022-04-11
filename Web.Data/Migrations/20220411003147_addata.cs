using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Data.Migrations
{
    public partial class addata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "im_Category",
                columns: new[] { "ID_DanhMuc", "TenDanhMuc", "TrangThai" },
                values: new object[,]
                {
                    { "DM1", "NEW PRODUCTS", "1" },
                    { "DM2", "LATEST PRODUCTS", "1" },
                    { "DM3", "BEST SELLERS", "1" }
                });

            migrationBuilder.InsertData(
                table: "im_Supplier",
                columns: new[] { "ID", "DiaChi", "TenNCC", "TrangThai" },
                values: new object[,]
                {
                    { 1, "Yên Trung, Yên Phong, Bắc Ninh", "Samsung Electronics Vietnam", "1" },
                    { 2, "121 Đ. Lê Lợi, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", "F.Studio (by FPT) - Apple Authorized Reseller", "1" },
                    { 3, "264 Nguyễn Thị Minh Khai, Phường 6, Quận 3, Thành phố Hồ Chí Minh", "ASUS ROG Store", "1" }
                });

            migrationBuilder.InsertData(
                table: "im_Product_Type",
                columns: new[] { "ID", "NhaCungCap", "TenLoai", "TrangThai" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone Samsung", "1" },
                    { 2, 2, "iPhone", "1" },
                    { 4, 2, "Macbook", "1" },
                    { 3, 3, "Laptop Asus Gaming", "1" }
                });

            migrationBuilder.InsertData(
                table: "im_Product",
                columns: new[] { "ID", "DanhMuc", "Gia", "GiaMoi", "Image", "Image_List", "MaLoai", "MoTa", "MoTaNgan", "NgayLap", "Size", "SoLuong", "TenSP", "TrangThai" },
                values: new object[,]
                {
                    { 2, "DM1", 33490000, 33499000, null, null, 2, null, null, new DateTime(2022, 4, 11, 7, 31, 47, 265, DateTimeKind.Local).AddTicks(970), "128GB", 7, "iPhone 12", "1" },
                    { 3, "DM1", 23990000, 23490000, "2.png", "22nd.png", 2, null, null, new DateTime(2022, 4, 11, 7, 31, 47, 265, DateTimeKind.Local).AddTicks(1389), "256GB", 3, "iPhone 12 Pro", "1" },
                    { 4, "DM1", 33490000, 33499000, "4.png", "42nd.png", 2, null, null, new DateTime(2022, 4, 11, 7, 31, 47, 265, DateTimeKind.Local).AddTicks(1396), "128GB", 7, "iPhone 12 Mini", "1" },
                    { 1, "DM1", 33490000, 33499000, null, null, 3, null, null, new DateTime(2022, 4, 11, 7, 31, 47, 264, DateTimeKind.Local).AddTicks(658), "128GB", 7, "iPhone 12 Pro Max", "1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "im_Category",
                keyColumn: "ID_DanhMuc",
                keyValue: "DM2");

            migrationBuilder.DeleteData(
                table: "im_Category",
                keyColumn: "ID_DanhMuc",
                keyValue: "DM3");

            migrationBuilder.DeleteData(
                table: "im_Product",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "im_Product",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "im_Product",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "im_Product",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "im_Product_Type",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "im_Product_Type",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "im_Category",
                keyColumn: "ID_DanhMuc",
                keyValue: "DM1");

            migrationBuilder.DeleteData(
                table: "im_Product_Type",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "im_Product_Type",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "im_Supplier",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "im_Supplier",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "im_Supplier",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
