using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SdProject.Businesses.Cqrs.Commands.Books;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Cqrs.Queries.Books;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Services.Abstractions
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> SearchAsync(SearchBookQuery request, CancellationToken cancellationToken = default);

        Task<IEnumerable<Book>> SearchByUserAsync(SearchBookByUserQuery query, CancellationToken cancellationToken = default);

        Task<Book> AddAsync(AddBookCommand request, CancellationToken cancellationToken = default);

        Task<Book> UpdateAsync(UpdateBookCommand request, CancellationToken cancellationToken = default);

        Task MarkAsReadAsync(MarkBookAsReadCommand request, CancellationToken cancellationToken = default);

        Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}