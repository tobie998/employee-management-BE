using AutoMapper;
using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() { 

            CreateMap<DonVi, DonViModel>().ReverseMap();
            CreateMap<CanBo, CanBoModel>().ReverseMap();
            CreateMap<ChiTietGiaiThuong, ChiTietGiaiThuongModel>().ReverseMap();
            CreateMap<ChiTietLinhVucNghienCuu, ChiTietLinhVucNghienCuuModel>().ReverseMap();
            CreateMap<ChiTietChucVu, ChiTietChucVuModel>().ReverseMap();
            CreateMap<ChiTietChucDanh, ChiTietChucDanhModel>().ReverseMap();
            CreateMap<ChiTietQuaTrinhDaoTao, ChiTietQuaTrinhDaoTaoModel>().ReverseMap();
            CreateMap<ChucVu, ChucVuModel>().ReverseMap();
            CreateMap<GiaiThuong, GiaiThuongModel>().ReverseMap();
            CreateMap<DeTaiDuAnKHCN, DeTaiDuAnKHCNModel>().ReverseMap(); 
            CreateMap<LinhVucNghienCuu, LinhVucNghienCuuModel>().ReverseMap();
            CreateMap<ChucDanh, ChucDanhModel>().ReverseMap();
            CreateMap<QuaTrinhDaoTao, QuaTrinhDaoTaoModel>().ReverseMap();
            CreateMap<KinhNghiemKH_CN, KinhNghiemKH_CnModel>().ReverseMap();
            CreateMap<ChiTietVeKinhNghiemKH_CN, ChiTietVeKinhNghiemKH_CnModel>().ReverseMap();
            CreateMap<ChiTietTrinhDoNgoaiNgu, ChiTietTrinhDoNgoaiNguModel>().ReverseMap();
            CreateMap<TrinhDoNgoaiNgu, TrinhDoNgoaiNguModel>().ReverseMap();
            CreateMap<NghienCuuSinhDaHuongDan, NghienCuuSinhDaHuongDanModel>().ReverseMap();
            CreateMap<KyLuat, KyLuatModel>().ReverseMap();
            CreateMap<ChiTietKyLuat, ChiTietKyLuatModel>().ReverseMap();
            CreateMap<KhenThuong, KhenThuongModel>().ReverseMap();
            CreateMap<ChiTietKhenThuong, ChiTietKhenThuongModel>().ReverseMap();
            CreateMap<ChiTietQuaTrinhCongTac, ChiTietQuaTrinhCongTacModel>().ReverseMap();
            CreateMap<CongTrinhKH_CN, CongTrinhKH_CNModel>().ReverseMap();
            CreateMap<ChiTietCongTrinhKH_CN, ChiTietCongTrinhKH_CNModel>().ReverseMap();
            CreateMap<ChiTietDeTaiDuAnKHCNThamGia, ChiTietDeTaiDuAnKHCNThamGiaModel>().ReverseMap();
            CreateMap<CongTrinhVaKetQuaNghienCuuDuocApDung, CongTrinhVaKetQuaNghienCuuDuocApDungModel>().ReverseMap();
            CreateMap<VanBangCanBo, VanBangCanBoModel>().ReverseMap();
            CreateMap<ChiTietVanBang, ChiTietVanBangModel>().ReverseMap();


        }
    }
}
