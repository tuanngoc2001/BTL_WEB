using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Data
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tên loại")]
        [StringLength(maximumLength: 50, ErrorMessage = "Tên loại 50 kí tự")]
        public string TenLoai { get; set; }
        public int NhaCungCap { get; set; }
        [ForeignKey("NhaCungCap")]
        public virtual NhaCungCap MaNCC { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập trạng thái")]
        [RegularExpression(@"^[0-1]{1}", ErrorMessage = "Trạng thái 0 hoặc 1")]
        public string TrangThai { get; set; }
        public ICollection<SanPham> lstSanPham { set; get; }
    }
}
