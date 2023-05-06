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


    }
}
