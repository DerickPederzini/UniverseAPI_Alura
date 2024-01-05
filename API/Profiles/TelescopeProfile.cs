using API.Data.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class TelescopeProfile : Profile
    {
        public TelescopeProfile()
        {
            CreateMap<CreateTelescopeDTO, Telescope>();//uses the automapper, that automatically converts a class universeDTO to celestial, 
            CreateMap<UpdateTelescopeDTO, Telescope>();//same as above but different class
            CreateMap<Telescope, ReadTelescopeDTO>();
        }
    }
}
