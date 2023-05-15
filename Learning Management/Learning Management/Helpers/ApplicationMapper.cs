using AutoMapper;
using Learning_Management.Data;
using Learning_Management.Models;

namespace Learning_Management.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<NhanSu, NhanSuModel>().ReverseMap();

        }
    }
}
