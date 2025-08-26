using AutoMapper;
using Ambev.DeveloperEvaluation.Application.UseCases.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Dtos.Users;
using Ambev.DeveloperEvaluation.Application.Models.User;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<NameDto, NameModel>();
        CreateMap<NameModel, NameDto>();

        CreateMap<AddressDto, AddressModel>();
        CreateMap<AddressModel, AddressDto>();

        CreateMap<GeolocationDto, GeolocationModel>();
        CreateMap<GeolocationModel, GeolocationDto>();

        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<CreateUserResult, CreateUserResponse>();
    }
}
