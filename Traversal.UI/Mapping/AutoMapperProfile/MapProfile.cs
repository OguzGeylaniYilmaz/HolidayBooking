using AutoMapper;
using DtoLayer.DTOs.AnnouncementDtos;
using DtoLayer.DTOs.AppUserDtos;
using DtoLayer.DTOs.ContactUsDtos;
using EntityLayer.Concrete;

namespace Traversal.UI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
            CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();
            CreateMap<AddAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementListDto, Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();

           
        }
    }
}
