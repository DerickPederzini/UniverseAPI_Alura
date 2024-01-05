using API.Data.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class AddressProfile : Profile
{
   public AddressProfile()
    {
        CreateMap<CreateAddressDTO, Address>();//uses the automapper, that automatically converts a class universeDTO to celestial, 
        CreateMap<Address, ReadAddressDTO>();
        CreateMap<UpdateAddressDTO, Address>();//same as above but different class
    }
}
