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
        public DbSet<DeTaiDuAnKHCN> deTaiDuAn { get; set; }
        public DbSet<ChiTietGiaiThuong> chiTietGiaiThuong { get; set; }
        public DbSet<ChiTietLinhVucNghienCuu> chiTietLinhVucNghienCuu { get; set; }
        public DbSet<ChiTietChucVu> chiTietChucVu { get; set; }
        public DbSet<ChiTietChucDanh> chiTietChucDanh { get; set; }
        public DbSet<ChiTietQuaTrinhDaoTao> chiTietQuaTrinhDaoTao { get; set; }
        public DbSet<ChiTietVeKinhNghiemKH_CN> chiTietVeKinhNghiemKH_CN { get; set; }
        public DbSet<ChiTietTrinhDoNgoaiNgu> chiTietTrinhDoNgoaiNgu { get; set; }
        public DbSet<NghienCuuSinhDaHuongDan> nghienCuuSinhDaHuongDan { get; set; }
        public DbSet<ChiTietKyLuat> chiTietKyLuat { get; set; }
        public DbSet<ChiTietKhenThuong> chiTietKhenThuong { get; set; }
        public DbSet<ChiTietQuaTrinhCongTac> chiTietQuaTrinhCongTac { get; set; }
        public DbSet<ChiTietCongTrinhKH_CN> chiTietCongTrinhKH_CN { get; set; }
        public DbSet<ChiTietDeTaiDuAnKHCNThamGia> chiTietDeTaiDuAnKHCNThamGia { get; set; }
        public DbSet<DeTaiDuAnKHCNChuTri> deTaiDuAnKHCNChuTri { get; set; }
        public DbSet<CongTrinhVaKetQuaNghienCuuDuocApDung> congTrinhVaKetQuaNghienCuuDuocApDung { get; set; }
        public DbSet<ChiTietVanBang> chiTietVanBang { get; set; }


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

            modelBuilder.Entity<ChiTietVeKinhNghiemKH_CN>(entity =>
            {
                entity.HasKey(c => new { c.Mahinhthuchoidong, c.Macanbo });

                entity.HasOne(e => e.KinhNghiemKH_CN).WithMany(e => e.chiTietVeKinhNghiemKH_CNs)
                .HasForeignKey(e => e.Mahinhthuchoidong);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietVeKinhNghiemKH_CNs)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietTrinhDoNgoaiNgu>(entity =>
            {
                entity.HasKey(c => new { c.Mangoaingu, c.Macanbo });

                entity.HasOne(e => e.TrinhDoNgoaiNgu).WithMany(e => e.chiTietTrinhDoNgoaiNgu)
                .HasForeignKey(e => e.Mangoaingu);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietTrinhDoNgoaiNgu)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<NghienCuuSinhDaHuongDan>(entity =>
            {
                entity.HasKey(c => new { c.MaNCS, c.Macanbo });

                entity.HasOne(e => e.CanBo).WithMany(e => e.nghienCuuSinhDaHuongDan)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietKyLuat>(entity =>
            {
                entity.HasKey(c => new { c.Makyluat, c.Macanbo });

                entity.HasOne(e => e.KyLuat).WithMany(e => e.chiTietKyLuat)
                .HasForeignKey(e => e.Makyluat);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietKyLuat)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietKhenThuong>(entity =>
            {
                entity.HasKey(c => new { c.Makhenthuong, c.Macanbo });

                entity.HasOne(e => e.KhenThuong).WithMany(e => e.chiTietKhenThuong)
                .HasForeignKey(e => e.Makhenthuong);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietKhenThuong)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietQuaTrinhCongTac>(entity =>
            {
                entity.HasKey(c => new { c.Maquatrinhcongtac, c.Macanbo });

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietQuaTrinhCongTac)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietCongTrinhKH_CN>(entity =>
            {
                entity.HasKey(c => new { c.MacongtrinhKH, c.Macanbo });

                entity.HasOne(e => e.CongTrinhKH_CN).WithMany(e => e.chiTietCongTrinhKH_CN)
                .HasForeignKey(e => e.MacongtrinhKH);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietCongTrinhKH_CN)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietDeTaiDuAnKHCNThamGia>(entity =>
            {
                entity.HasKey(c => new { c.Madetai, c.Macanbo });

                entity.HasOne(e => e.deTaiDuAnKHCN).WithMany(e => e.chiTietDeTaiDuAnKHCNThamGia)
                .HasForeignKey(e => e.Madetai);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietDeTaiDuAnKHCNThamGia)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<DeTaiDuAnKHCNChuTri>(entity =>
            {
                entity.HasKey(c => new { c.Madetai, c.Macanbo });

                entity.HasOne(e => e.deTaiDuAnKHCN).WithMany(e => e.deTaiDuAnKHCNChuTri)
                .HasForeignKey(e => e.Madetai);

                entity.HasOne(e => e.CanBo).WithMany(e => e.deTaiDuAnKHCNChuTri)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<CongTrinhVaKetQuaNghienCuuDuocApDung>(entity =>
            {
                entity.HasKey(c => new { c.Macongtrinhnghiencuu, c.Macanbo });

                entity.HasOne(e => e.CanBo).WithMany(e => e.congTrinhVaKetQuaNghienCuuDuocApDung)
                .HasForeignKey(e => e.Macanbo);

            });

            modelBuilder.Entity<ChiTietVanBang>(entity =>
            {
                entity.HasKey(c => new { c.Mavanbang, c.Macanbo });

                entity.HasOne(e => e.vanBangCanBo).WithMany(e => e.chiTietVanBang)
                .HasForeignKey(e => e.Mavanbang);

                entity.HasOne(e => e.CanBo).WithMany(e => e.chiTietVanBang)
                .HasForeignKey(e => e.Macanbo);

            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
