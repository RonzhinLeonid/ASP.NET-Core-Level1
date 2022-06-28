using AutoMapper;
using DataLayer;
using ViewModel;

namespace WebStore.Services.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ForMember("Brand", opt => opt.MapFrom(src => src.Brand!.Name))
                .ForMember("Section", opt => opt.MapFrom(src => src.Section.Name))
                .ReverseMap();
        }
    }
}