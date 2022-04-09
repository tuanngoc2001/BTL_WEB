using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class HoaDonViewModel
    {
        public List<HoaDonModel> HoaDons { get; set; }
        public SelectList HD { get; set; }
        public string HoaDon { get; set; }
        public int SearchString { get; set; }
    }
}
