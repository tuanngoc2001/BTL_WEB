using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class SanPhamViewModel
    {
        public List<SanPhamModel> SanPhams { get; set; }
        public SelectList SPs { get; set; }
        public string SanPham { get; set; }
        public string SearchString { get; set; }
    }
}
