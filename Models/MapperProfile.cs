using AutoMapper;
using CarAds.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarAds.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BrandEntity, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.BrandName))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));


            CreateMap<ModelEntity, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            
            CreateMap<BodyEntity, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.BodyName))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            
            CreateMap<FuelEntity, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.FuelType))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));


            CreateMap<CarEntity, CarDTO>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.ModelName))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Model.Brand.BrandName))
                .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel.FuelType))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body.BodyName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Phone))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.FuelId, opt => opt.MapFrom(src => src.Fuel))
                .ForMember(dest => dest.BodyId, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Person, opt => opt.Ignore())
                .ForMember(dest => dest.Model, opt => opt.Ignore())
                .ForMember(dest => dest.Fuel, opt => opt.Ignore())
                .ForMember(dest => dest.Body, opt => opt.Ignore());


            CreateMap<PersonEntity, CarDTO>()
                .ReverseMap();
        }
    }
}
