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
    public class UpdateBookRequestHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookService _bookService;
        public UpdateBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellation)
        {
            return _bookService.UpdateBookAsync(request, cancellation);
        }
    }
}
