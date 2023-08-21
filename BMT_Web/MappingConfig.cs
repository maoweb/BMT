using AutoMapper;
using BMT_Web.Models.Dto;

namespace BMT_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ContactDTO, ContactCreateDTO>().ReverseMap();
            CreateMap<ContactDTO, ContactUpdateDTO>().ReverseMap();
        }
    }
}
