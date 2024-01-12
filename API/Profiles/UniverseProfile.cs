using API.Data.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class UniverseProfile : Profile
{
    public UniverseProfile()
    {
       CreateMap<CreateUniverseDTO, Celestial>();//uses the automapper, that automatically converts a class universeDTO to celestial, 
       CreateMap<UpdateUniverseDTO, Celestial>();//same as above but different class
       CreateMap<Celestial, UpdateUniverseDTO>();
       CreateMap<Celestial, ReadUniverseDTO>()
             .ForMember(universeDto => universeDto.Address, opt => opt.MapFrom(universe => universe.Address))
             .ForMember(universeDto => universeDto.Telescope, opt => opt.MapFrom(universe => universe.Telescope))
             .ForMember(universeDto => universeDto.Session, opt => opt.MapFrom(universe => universe.Session));

    }

}
