using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Data;


namespace Web_API_v1.Models
{
    public class HoaDonViewModel
    {
        public List<HoaDon> HoaDons { get; set; }
        public SelectList HD { get; set; }
        public string HoaDon { get; set; }
        public int SearchString { get; set; }
    }
}
