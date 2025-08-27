using Ambev.DeveloperEvaluation.Application.UseCases.Users.ListUsers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Models.Mappings;
public class PaginatedProfile : Profile
{
    public PaginatedProfile()
    {
        CreateMap<PaginatedList<User>, ListUsersResult>();
    }
}
