using Microsoft.EntityFrameworkCore;
using Web_Common;

namespace Web_Data
{
    public class ImDbContext : DbContext
    {
        public ImDbContext (DbContextOptions<ImDbContext> options) : base(options)
        {
        }
        private static string ConnectionString= Util.GetConfig("ConnectionStrings:MyDb");
        public virtual DbSet<BinhLuan> im_Comment { get; set; }
        public virtual DbSet<ChiTietHoaDon> im_Invoice_Detail { get; set; }
        public virtual DbSet<DanhMuc> im_Category { get; set; }
        public virtual DbSet<HoaDon> im_Invoice { get; set; }
        public virtual DbSet<LoaiSanPham> im_Product_Type { get; set; }
        public virtual DbSet<NhaCungCap> im_Supplier { get; set; }
        public virtual DbSet<SanPham> im_Product { get; set; }
        public virtual DbSet<User> im_User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
