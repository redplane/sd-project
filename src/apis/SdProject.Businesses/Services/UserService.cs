using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Cqrs.Queries.Users;
using SdProject.Businesses.Models.Exceptions;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Core.DbContexts;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Services
{
    public class UserService : IUserService
    {
        #region Properties

        private readonly SdProjectDbContext _context;

        #endregion

        #region Constructor

        public UserService(SdProjectDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Method

        public async Task<IEnumerable<User>> SearchAsync(SearchUserQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.AsQueryable();
            if (request != null && !string.IsNullOrWhiteSpace(request.FirstName))
                users = users.Where(x => x.FirstName.Contains(request.FirstName));

            if (request != null && !string.IsNullOrWhiteSpace(request.LastName))
                users = users.Where(x => x.FirstName.Contains(request.LastName));
            return await users.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Book>> SearchUserBooksAsync(SearchUserBooksQuery request,
            CancellationToken cancellationToken)
        {
            var userBooks = _context.UserBooks.AsQueryable();
            var books = _context.Books.AsQueryable();

            userBooks = userBooks.Where(x => x.UserId == request.UserId);
            if (request.HaveRead != null)
                userBooks = userBooks.Where(x => x.HaveRead == request.HaveRead.Value);

            if (request.BookId != null)
                books = books.Where(x => x.Id == request.BookId);
            
            return await (from ub in userBooks
                join b in books on ub.BookId equals b.Id
                select b).ToListAsync(cancellationToken);
        }

        public async Task<User> AddAsync(AddUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
                { FirstName = request.FirstName, LastName = request.LastName, Birthdate = request.Birthdate };
            var user = _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Entity;
        }

        public async Task<User> UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var doesUserExist = _context.Users.AsNoTracking().Any(x => x.Id == request.Id);
            if (!doesUserExist) 
                throw new UserNotFoundException();
            
            var entity = new User
            {
                Id = request.Id, FirstName = request.FirstName, LastName = request.LastName,
                Birthdate = request.Birthdate
            };
            var user = _context.Users.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Entity;
        }

        public async Task<UserBook> AddUserBookAsync(AddUserBookCommand request, CancellationToken cancellationToken)
        {
            var entity = new UserBook { UserId = request.UserId, BookId = request.BookId };
            var userBook = _context.UserBooks.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return userBook.Entity;
        }

        public async Task<UserBook> UpdateUserBookAsync(UpdateUserBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new UserBook { Id = request.Id, UserId = request.UserId, BookId = request.BookId };
            var userBook = _context.UserBooks.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return userBook.Entity;
        }

        public virtual async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        #endregion
    }
}