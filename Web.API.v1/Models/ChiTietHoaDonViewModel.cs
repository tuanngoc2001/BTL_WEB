using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Data;


namespace Web_API_v1.Models
{
    public class ChiTietHoaDonViewModel
    {
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public SelectList DSCTHD { get; set; }
        public string ChiTietHoaDon { get; set; }
        public string searchString { get; set; }
    }
}
