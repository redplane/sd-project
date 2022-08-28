using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Models.Users;
using SdProject.Businesses.Services.Abstractions;
using Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.Users
{
    public class AddUserRequestHandler : IRequestHandler<AddUserCommand, global::Core.Entities.User>
    {
        private readonly IUserService _usersService;
        public AddUserRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<global::Core.Entities.User> Handle(AddUserCommand request, CancellationToken cancellation)
        {
            return _usersService.AddUserAsync(request, cancellation);
        }
    }
}
