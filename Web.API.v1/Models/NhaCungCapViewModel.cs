using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class NhaCungCapViewModel
    {
        public List<NhaCungCapModel> NhaCungCaps { get; set; }
        public SelectList DSNhaCungCap { get; set; }
        public string NhaCungCap { get; set; }
        public string SearchString { get; set; }
    }
}
