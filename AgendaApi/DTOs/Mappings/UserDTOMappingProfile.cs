using AgendaApi.Models;
using AutoMapper;

namespace AgendaApi.DTOs.Mappings
{
    public class UserDTOMappingProfile : Profile
    {
        public UserDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
