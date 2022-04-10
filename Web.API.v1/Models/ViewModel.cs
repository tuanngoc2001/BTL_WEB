using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Data;
namespace Web_API_v1.Models
{
    public class ViewModel
    {
        public List<LoaiSanPham> LoaiSP { get; set; }
        public SelectList DSLoaisp { get; set; }
        public string LoaiSanPham { get; set; }
        public string SearchString { get; set; }
        public SelectList HD { get; internal set; }
        public List<HoaDon> HoaDons { get; internal set; }
    }
}
