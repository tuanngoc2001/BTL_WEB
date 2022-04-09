using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class ChiTietHoaDonViewModel
    {
        public List<ChiTietHoaDonModel> ChiTietHoaDons { get; set; }
        public SelectList DSCTHD { get; set; }
        public string ChiTietHoaDon { get; set; }
        public string searchString { get; set; }
    }
}
