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
            CreateMap<LinhVucNghienCuu, LinhVucNghienCuuModel>().ReverseMap();
            CreateMap<ChucDanh, ChucDanhModel>().ReverseMap();
            CreateMap<QuaTrinhDaoTao, QuaTrinhDaoTaoModel>().ReverseMap();
            CreateMap<KinhNghiemKH_CN, KinhNghiemKH_CnModel>().ReverseMap();
            CreateMap<ChiTietVeKinhNghiemKH_CN, ChiTietVeKinhNghiemKH_CnModel>().ReverseMap();



        }
    }
}
