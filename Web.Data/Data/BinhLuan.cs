using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Data
{
    [Table("BinhLuan")]
    public class BinhLuan
    {
        [Key]
        public int id { set; get; }
        public int User_ID { set; get; }
        [ForeignKey("User_ID")]
        public virtual User User { set; get; }
        [ForeignKey("SanPham_ID")]
        public int SanPham_ID { set; get; }
        public virtual SanPham SanPham { set; get; }
        public string NoiDung { set; get; }
        public DateTime NgayDang { set; get; }
        public int TrangThai { set; get; }
    }
}
