using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Data.Extensions
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc() {ID_DanhMuc= "DM1", TenDanhMuc= "NEW PRODUCTS", TrangThai="1" },
                new DanhMuc() {ID_DanhMuc= "DM2", TenDanhMuc= "LATEST PRODUCTS",TrangThai="1" },
                new DanhMuc() {ID_DanhMuc= "DM3", TenDanhMuc= "BEST SELLERS",TrangThai="1" });

            modelBuilder.Entity<NhaCungCap>().HasData(
                new NhaCungCap() { ID = 1,TenNCC = "Samsung Electronics Vietnam", DiaChi = "Yên Trung, Yên Phong, Bắc Ninh", TrangThai = "1" },
                new NhaCungCap() { ID = 2,TenNCC = "F.Studio (by FPT) - Apple Authorized Reseller", DiaChi = "121 Đ. Lê Lợi, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", TrangThai = "1" },
                new NhaCungCap() { ID = 3,TenNCC = "ASUS ROG Store", DiaChi = "264 Nguyễn Thị Minh Khai, Phường 6, Quận 3, Thành phố Hồ Chí Minh", TrangThai = "1" }
                );

            modelBuilder.Entity<LoaiSanPham>().HasData(
                new LoaiSanPham() { ID=1, TenLoai= "Smartphone Samsung",NhaCungCap=1,TrangThai="1" },
                new LoaiSanPham() { ID = 2, TenLoai = "iPhone", NhaCungCap=2,TrangThai="1" },
                new LoaiSanPham() { ID = 3, TenLoai = "Laptop Asus Gaming", NhaCungCap=3,TrangThai="1" },
                new LoaiSanPham() { ID = 4, TenLoai = "Macbook", NhaCungCap=2,TrangThai="1" }
                );
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham() {ID=1, TenSP= "iPhone 12 Pro Max",MaLoai= 3,DanhMuc= "DM1",Gia=33490000,GiaMoi= 33499000,Size= "128GB",SoLuong=7,NgayLap=DateTime.Now, TrangThai="1" },
                new SanPham() { ID = 2, TenSP = "iPhone 12", MaLoai= 2,DanhMuc= "DM1",Gia=33490000,GiaMoi= 33499000,Size= "128GB",SoLuong=7,NgayLap=DateTime.Now, TrangThai="1" },
                new SanPham() { ID = 3, TenSP = "iPhone 12 Pro", MaLoai= 2,DanhMuc= "DM1",Gia= 23990000, GiaMoi= 23490000,Image= "2.png",Image_List= "22nd.png", Size = "256GB", SoLuong=3,NgayLap=DateTime.Now, TrangThai="1" },
                new SanPham() { ID = 4, TenSP = "iPhone 12 Mini", MaLoai= 2,DanhMuc= "DM1",Gia=33490000,GiaMoi= 33499000, Image = "4.png", Image_List = "42nd.png",Size = "128GB",SoLuong=7,NgayLap=DateTime.Now, TrangThai="1" }

                );
        }
    }
}
