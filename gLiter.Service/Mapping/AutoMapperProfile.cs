using AutoMapper;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using ServiceEntity = gLiter.Core.Models.Service;

namespace gLiter.Service.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ServiceEntity, ServiceDto>().ForMember(d => d.Title, opt => opt.Ignore()).ForMember(d => d.Description, opt => opt.Ignore()).ReverseMap();
        CreateMap<HeroSection, HeroSectionDto>().ForMember(d => d.Title, opt => opt.Ignore()).ForMember(d => d.Description, opt => opt.Ignore()).ReverseMap();
        CreateMap<SuccessPartner, SuccessPartnerDto>().ForMember(d => d.Name, opt => opt.Ignore()).ReverseMap();
        CreateMap<FleetVehicle, FleetDto>().ForMember(d => d.Name, opt => opt.Ignore()).ReverseMap();
        CreateMap<TransportRequest, TransportRequestDto>()
            .ForMember(d => d.ImageUrls, opt => opt.MapFrom(s => s.Images.Select(i => i.ImageUrl).ToList()));
        CreateMap<CreateTransportRequestDto, TransportRequest>()
            .ForMember(d => d.Images, opt => opt.Ignore());
        CreateMap<Station, StationDto>().ForMember(d => d.Title, opt => opt.Ignore()).ForMember(d => d.Description, opt => opt.Ignore()).ReverseMap();
        CreateMap<FuelPrice, FuelPriceDto>().ForMember(d => d.Title, opt => opt.Ignore()).ForMember(d => d.Description, opt => opt.Ignore()).ReverseMap();
        CreateMap<News, NewsDto>().ForMember(d => d.Title, opt => opt.Ignore()).ForMember(d => d.Description, opt => opt.Ignore()).ReverseMap();
        CreateMap<Job, JobDto>().ForMember(d => d.Title, opt => opt.Ignore()).ForMember(d => d.Description, opt => opt.Ignore()).ReverseMap();
        CreateMap<GalleryImage, GalleryDto>().ForMember(d => d.Title, opt => opt.Ignore()).ForMember(d => d.Description, opt => opt.Ignore()).ReverseMap();
        CreateMap<ContactMessage, ContactMessageDto>().ReverseMap();
        CreateMap<AdminUser, AdminResponseDto>();
        CreateMap<AdminRegisterDto, AdminUser>()
            .ForMember(d => d.PasswordHash, opt => opt.Ignore())
            .ForMember(d => d.PasswordSalt, opt => opt.Ignore())
            .ForMember(d => d.IsActive, opt => opt.Ignore())
            .ForMember(d => d.Role, opt => opt.Ignore());
    }
}
