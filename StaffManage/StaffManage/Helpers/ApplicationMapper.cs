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
        }
    }
}
