using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Data;


namespace Web_API_v1.Models
{
    public class NhaCungCapViewModel
    {
        public List<NhaCungCap> NhaCungCaps { get; set; }
        public SelectList DSNhaCungCap { get; set; }
        public string NhaCungCap { get; set; }
        public string SearchString { get; set; }
    }
}
