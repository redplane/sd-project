using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.Users
{
    public class UpdateUserBookRequestHandler : IRequestHandler<UpdateUserBookCommand, UserBook>
    {
        private readonly IUserService _usersService;

        public UpdateUserBookRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<UserBook> Handle(UpdateUserBookCommand request, CancellationToken cancellation)
        {
            return _usersService.UpdateUserBookAsync(request, cancellation);
        }
    }
}