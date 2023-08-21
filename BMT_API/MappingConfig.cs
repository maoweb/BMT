using AutoMapper;
using BMT_API.Models;
using BMT_API.Models.Dto;

namespace BMT_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Contact, ContactCreateDTO>().ReverseMap();
            CreateMap<Contact, ContactUpdateDTO>().ReverseMap();
        }
    }
}
