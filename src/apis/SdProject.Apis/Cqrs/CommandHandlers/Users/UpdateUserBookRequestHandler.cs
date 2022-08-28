﻿using System;
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
    public class AddUserBookRequestHandler : IRequestHandler<AddUserBookCommand, UserBookEntity>
    {
        private readonly IUserService _usersService;
        public AddUserBookRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<UserBookEntity> Handle(AddUserBookCommand request, CancellationToken cancellation)
        {
            return _usersService.AddUserBookAsync(request, cancellation);
        }
    }
}
