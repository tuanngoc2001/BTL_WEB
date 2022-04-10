using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Data;
namespace Web_API_v1.Models
{
    public class ItemModel
    {
        public SanPham SanPham { get; set; }
        public int Quantity { get; set; }
    }
}