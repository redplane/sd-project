using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.Users
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserService _usersService;

        public UpdateUserRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<User> Handle(UpdateUserCommand request, CancellationToken cancellation)
        {
            return _usersService.UpdateAsync(request, cancellation);
        }
    }
}