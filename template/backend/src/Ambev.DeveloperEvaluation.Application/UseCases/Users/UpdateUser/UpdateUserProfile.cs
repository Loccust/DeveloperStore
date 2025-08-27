using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.UpdateUser;

public class UpdateUserProfile : Profile
{
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserCommand, User>();
        CreateMap<User, UpdateUserResult>();
    }
}
