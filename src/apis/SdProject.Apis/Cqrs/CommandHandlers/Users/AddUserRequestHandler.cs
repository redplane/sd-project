using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Models.Users;
using SdProject.Businesses.Services.Abstractions;
using Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.User.Commands.Handlers
{
    public class AddUserRequestHandler : IRequestHandler<AddUserCommand, UserEntity>
    {
        private readonly IUserService _usersService;
        public AddUserRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellation)
        {
            return _usersService.AddUserAsync(request, cancellation);
        }
    }
}
