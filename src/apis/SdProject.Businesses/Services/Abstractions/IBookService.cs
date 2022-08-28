using Core.Entities;
using SdProject.Businesses.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SdProject.Businesses.Services.Abstractions
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> SearchBookAsync(SearchBookQuery request, CancellationToken cancellation);
        Task<IEnumerable<Book>> FindBookByUserAsync(SearchBookByUserQuery request, CancellationToken cancellation);
        Task<Book> AddBookAsync(AddBookCommand request, CancellationToken cancellation);
        Task<Book> UpdateBookAsync(UpdateBookCommand request, CancellationToken cancellation);
    }
}
