using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Data
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public string ID_DanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string TrangThai { get; set; }
        public ICollection<SanPham> dmucSanPham { get; set; }
    }
}
