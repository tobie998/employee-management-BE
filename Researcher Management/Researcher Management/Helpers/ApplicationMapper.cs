using AutoMapper;
using Researcher_Management.Data;
using Researcher_Management.Models;

namespace Researcher_Management.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<CanBoNghienCuu, CanBoNghienCuuModel>().ReverseMap();

        }
    }
}
