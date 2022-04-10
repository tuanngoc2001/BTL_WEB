using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Data;


namespace Web_API_v1.Models
{
    public class SanPhamViewModel
    {
        public List<SanPham> SanPhams { get; set; }
        public SelectList SPs { get; set; }
        public string SanPham { get; set; }
        public string SearchString { get; set; }
    }
}
