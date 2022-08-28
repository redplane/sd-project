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
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserCommand, global::Core.Entities.User>
    {
        private readonly IUserService _usersService;
        public UpdateUserRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<global::Core.Entities.User> Handle(UpdateUserCommand request, CancellationToken cancellation)
        {
            return _usersService.UpdateUserAsync(request, cancellation);
        }
    }
}
