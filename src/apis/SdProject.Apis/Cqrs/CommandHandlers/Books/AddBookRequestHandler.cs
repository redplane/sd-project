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
    public class AddBookRequestHandler : IRequestHandler<AddBookCommand, BookEntity>
    {
        private readonly IBookService _bookService;
        public AddBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Task<BookEntity> Handle(AddBookCommand request, CancellationToken cancellation)
        {
            return _bookService.AddBookAsync(request, cancellation);
        }
    }
}
