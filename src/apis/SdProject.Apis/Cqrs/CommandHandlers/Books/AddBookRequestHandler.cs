using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Models.Users;
using SdProject.Businesses.Services.Abstractions;
using Core.Entities;

namespace SdProject.Apis.Cqrs.CommandHandlers.Books
{
    public class AddBookRequestHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IBookService _bookService;
        public AddBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Task<Book> Handle(AddBookCommand request, CancellationToken cancellation)
        {
            return _bookService.AddBookAsync(request, cancellation);
        }
    }
}
