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
    public class UpdateUserBookRequestHandler : IRequestHandler<UpdateUserBookCommand, UserBookEntity>
    {
        private readonly IUserService _usersService;
        public UpdateUserBookRequestHandler(IUserService usersService)
        {
            _usersService = usersService;
        }

        public Task<UserBookEntity> Handle(UpdateUserBookCommand request, CancellationToken cancellation)
        {
            return _usersService.UpdateUserBookAsync(request, cancellation);
        }
    }
}