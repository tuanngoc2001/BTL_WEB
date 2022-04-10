using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Data
{
    [Table("im_Supplier")]
    public class NhaCungCap
    {
        [Key]
        public int ID { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }
        public ICollection<LoaiSanPham> lstLoaiSanPham { set; get; }
    }
}
