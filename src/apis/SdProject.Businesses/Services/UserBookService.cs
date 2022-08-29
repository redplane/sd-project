using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Services
{
    public class UserBookService : IUserBookService
    {
        private readonly SdProjectDbContext _dbContext;
        
        public Task<UserBook> GetAsync(int userId, int bookId, CancellationToken cancellationToken = default)
        {
            return _dbContext.UserBooks.AsQueryable()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.BookId == bookId, cancellationToken);
        }
    }
}