using AutoMapper;
using DataLayer;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ForMember("Brand", opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember("Section", opt => opt.MapFrom(src => src.Section.Name))
                .ReverseMap();
        }
    }
}