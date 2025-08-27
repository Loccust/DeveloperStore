using MediatR;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.ListUsers;

public class ListUsersCommand : IRequest<ListUsersResult>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string OrderBy { get; set; }
}