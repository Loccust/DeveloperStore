using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.UseCases.Users.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// Handles the UpdateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated user details</returns>
    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await command.ValidateAsync();

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = _mapper.Map<User>(command);
        user.Password = _passwordHasher.HashPassword(command.Password);

        var createdUser = await _userRepository.UpdateAsync(user, cancellationToken);
        if(createdUser == null)
            throw new InvalidOperationException($"User not found");
        var result = _mapper.Map<UpdateUserResult>(createdUser);
        return result;
    }
}