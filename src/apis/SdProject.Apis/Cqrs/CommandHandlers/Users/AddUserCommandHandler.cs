using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.Users
{
    public class AddUserRequestHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserService _usersService;

        public AddUserRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<User> Handle(AddUserCommand request, CancellationToken cancellation)
        {
            return _usersService.AddAsync(request, cancellation);
        }
    }
}