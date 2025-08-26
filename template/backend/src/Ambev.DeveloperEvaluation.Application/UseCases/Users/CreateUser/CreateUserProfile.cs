using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Models.User;
using Ambev.DeveloperEvaluation.Domain.ValueObjects.User;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.CreateUser;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<NameModel, Name>();
        CreateMap<Name, NameModel>();

        CreateMap<AddressModel, Address>();
        CreateMap<Address, AddressModel>();

        CreateMap<GeolocationModel, Geolocation>();
        CreateMap<Geolocation, GeolocationModel>();

        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserResult>();
    }
}
