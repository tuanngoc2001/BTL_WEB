using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class ViewModel
    {
        public List<LoaiSanPhamModel> LoaiSP { get; set; }
        public SelectList DSLoaisp { get; set; }
        public string LoaiSanPham { get; set; }
        public string SearchString { get; set; }
        public SelectList HD { get; internal set; }
        public List<HoaDonModel> HoaDons { get; internal set; }
    }
}
