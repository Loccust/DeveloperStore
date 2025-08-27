using Ambev.DeveloperEvaluation.Application.Models.Users;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects.Users;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Models.Mappings;

public class UserModelsToEntitiesProfile : Profile
{
    public UserModelsToEntitiesProfile()
    {
        CreateMap<NameModel, Name>();
        CreateMap<Name, NameModel>();

        CreateMap<AddressModel, Address>();
        CreateMap<Address, AddressModel>();

        CreateMap<GeolocationModel, Geolocation>();
        CreateMap<Geolocation, GeolocationModel>();

        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>();
    }
}
