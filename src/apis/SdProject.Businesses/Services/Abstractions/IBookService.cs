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
        Task<IEnumerable<BookEntity>> SearchBookAsync(SearchBookQuery request, CancellationToken cancellation);
        Task<IEnumerable<BookEntity>> FindBooByUserkAsync(SearchBookByUserQuery request, CancellationToken cancellation);
        Task<BookEntity> AddBookAsync(AddBookCommand request, CancellationToken cancellation);
        Task<BookEntity> UpdateBookAsync(UpdateBookCommand request, CancellationToken cancellation);
    }
}
