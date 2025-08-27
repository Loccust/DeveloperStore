using Ambev.DeveloperEvaluation.Application.UseCases.Users.ListUsers;
using Ambev.DeveloperEvaluation.WebApi.Dtos.Users;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

public class ListUsersProfile : Profile
{
    public ListUsersProfile()
    {
        CreateMap<ListUsersRequest, ListUsersCommand>();
        CreateMap<ListUsersResult, PaginatedResponse<UserDto>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true));
    }
}
