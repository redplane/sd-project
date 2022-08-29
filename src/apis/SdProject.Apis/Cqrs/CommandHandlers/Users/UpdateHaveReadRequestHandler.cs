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
    public class UpdateHaveReadRequestHandler : IRequestHandler<UpdateHaveReadCommand, UserBook>
    {
        private readonly IUserService _usersService;
        public UpdateHaveReadRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<UserBook> Handle(UpdateHaveReadCommand request, CancellationToken cancellation)
        {
            return _usersService.UpdateHaveReadAsync(request, cancellation);
        }
    }
}
