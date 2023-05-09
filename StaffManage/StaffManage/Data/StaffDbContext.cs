using Microsoft.EntityFrameworkCore;
using StaffManage.Models;

namespace StaffManage.Data
{
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options) {  
            
        }

        public DbSet<DonVi>? donvi { get; set; }
        public DbSet<CanBo>? canBo { get; set; }
        public DbSet<ChucDanh> chucDanh { get; set;}
        public DbSet<ChucVu> chucVu { get; set; }
        public DbSet<LinhVucNghienCuu> linhVuc { get; set; }
        public DbSet<GiaiThuong> giaiThuong { get; set; }
        public DbSet<VanBangCanBo> vanBang { get; set; }
        public DbSet<QuaTrinhDaoTao> quaTrinhDaoTao { get; set; }
        public DbSet<KinhNghiemKH_CN> kinhNghiemKH_CN { get; set; }
        public DbSet<TrinhDoNgoaiNgu> trinhDoNgoaiNgu { get; set; }
        public DbSet<KyLuat> kyLuat { get; set; }
        public DbSet<KhenThuong> khenThuong { get; set; }
        public DbSet<CongTrinhKH_CN> congTrinhKH_CN { get; set; }
        public DbSet<DeTaiDuAnKHCNThamGia> deTaiDuAn { get; set; }
        public DbSet<ChiTietGiaiThuong> chiTietGiaiThuong { get; set; }
        public DbSet<ChiTietLinhVucNghienCuu> chiTietLinhVucNghienCuu { get; set; }
        public DbSet<ChiTietChucVu> chiTietChucVu { get; set; }
        public DbSet<ChiTietChucDanh> chiTietChucDanh { get; set; }
        public DbSet<ChiTietQuaTrinhDaoTao> chiTietQuaTrinhDaoTao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình các quan hệ, khóa chính, khóa ngoại và các thiết lập khác ở đây
            modelBuilder.Entity<ChiTietGiaiThuong>(entity =>
            {
                entity.HasKey(c => new { c.Magiaithuong, c.Macanbo });

                entity.HasOne(e => e.GiaiThuong).WithMany(e => e.chiTietGiaiThuongs)
                .HasForeignKey(e => e.Magiaithuong);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietGiaiThuongs)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietLinhVucNghienCuu>(entity =>
            {
                entity.HasKey(c => new { c.Machuyennganh, c.Macanbo });

                entity.HasOne(e => e.LinhVucNghienCuu).WithMany(e => e.chiTietLinhVucNghienCuu)
                .HasForeignKey(e => e.Machuyennganh);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietLinhVucNghienCuu)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietChucVu>(entity =>
            {
                entity.HasKey(c => new { c.Machucvu, c.Macanbo });

                entity.HasOne(e => e.ChucVu).WithMany(e => e.chiTietChucVus)
                .HasForeignKey(e => e.Machucvu);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietChucVus)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietChucDanh>(entity =>
            {
                entity.HasKey(c => new { c.Machucdanh, c.Macanbo });

                entity.HasOne(e => e.ChucDanh).WithMany(e => e.chiTietChucDanhs)
                .HasForeignKey(e => e.Machucdanh);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietChucDanhs)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietQuaTrinhDaoTao>(entity =>
            {
                entity.HasKey(c => new { c.Mabacdaotao, c.Macanbo });

                entity.HasOne(e => e.QuaTrinhDaoTao).WithMany(e => e.chiTietQuaTrinhDaoTaos)
                .HasForeignKey(e => e.Mabacdaotao);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietQuaTrinhDaoTaos)
                .HasForeignKey(e => e.Macanbo);

            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
