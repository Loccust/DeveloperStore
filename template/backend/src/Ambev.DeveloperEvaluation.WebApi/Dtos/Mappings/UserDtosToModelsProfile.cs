using Ambev.DeveloperEvaluation.Application.Models.Users;
using Ambev.DeveloperEvaluation.WebApi.Dtos.Users;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Dtos.Mappings;

public class UserDtosToModelsProfile : Profile
{
    public UserDtosToModelsProfile()
    {
        CreateMap<NameDto, NameModel>();
        CreateMap<NameModel, NameDto>();

        CreateMap<AddressDto, AddressModel>();
        CreateMap<AddressModel, AddressDto>();

        CreateMap<GeolocationDto, GeolocationModel>();
        CreateMap<GeolocationModel, GeolocationDto>();
        
        CreateMap<UserModel, UserDto>();
        CreateMap<UserDto, UserModel>();
    }
}
