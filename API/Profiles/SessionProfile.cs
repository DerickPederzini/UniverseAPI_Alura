using API.Data.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDTO, Session>();
            CreateMap<Session, ReadSessionDTO>();
        }
    }
}
