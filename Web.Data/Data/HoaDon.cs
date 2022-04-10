using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Data
{
    [Table("HoaDon")]
    public class HoaDon
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual User User { set; get; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public int ThanhTien { get; set; }
        public int TrangThai { get; set; }
        public ICollection<ChiTietHoaDon> lstCTHD { set; get; }
    }

}
