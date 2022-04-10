using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Data
{
    [Table("im_Invoice_Detail")]
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }
        public int HoaDon_ID { get; set; }
        [ForeignKey("HoaDon_ID")]

        public virtual HoaDon HoaDon { set; get; }

        public string TenSP { get; set; }
        public string SoLuong { get; set; }
        public string Gia { get; set; }
        public int KhuyenMai { get; set; }
        public int ThanhTien { get; set; }
        public int TrangThai { get; set; }
    }
}
