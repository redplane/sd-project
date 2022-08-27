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
    public class UpdateBookRequestHandler : IRequestHandler<UpdateBookCommand, BookEntity>
    {
        private readonly IBookService _bookService;
        public UpdateBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Task<BookEntity> Handle(UpdateBookCommand request, CancellationToken cancellation)
        {
            return _bookService.UpdateBookAsync(request, cancellation);
        }
    }
}
