using SdProject.Businesses.Services.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using SdProject.Businesses.Models.Users;
using SdProject.Core.DbContexts;
using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using SdProject.Businesses.Exception;
using Microsoft.EntityFrameworkCore;

namespace SdProject.Businesses.Services
{
    public class UserService : IUserService
    {
        SdPDbContext _context;
        public UserService(SdPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> SearchUserAsync(SearchUserQuery request, CancellationToken cancellation)
        {
            var users = _context.User.AsQueryable();
            if (request != null && !string.IsNullOrWhiteSpace(request.FirstName))
            {
                users = users.Where(x => x.FirstName.Contains(request.FirstName));
            }

            if (request != null && !string.IsNullOrWhiteSpace(request.LastName))
            {
                users = users.Where(x => x.FirstName.Contains(request.LastName));
            }
            return users.ToList();
        }

        public async Task<IEnumerable<UserEntity>> FindUserByBookAsync(SearchUserByBookQuery request, CancellationToken cancellation)
        {
            return (from ub in _context.UserBookEntities
                    join u in _context.User on ub.BookId equals u.id
                    where ub.BookId == request.BookId
                    select new UserEntity
                    {
                        id = u.id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Birthdate = u.Birthdate
                    }).ToList();
        }

        public async Task<UserEntity> AddUserAsync(AddUserCommand request, CancellationToken cancellation)
        {
            UserEntity entity = new UserEntity { FirstName = request.FirstName, LastName = request.LastName, Birthdate = request.Birthdate };
            var user = _context.User.Add(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<UserEntity> UpdateUserAsync(UpdateUserCommand request, CancellationToken cancellation)
        {
            var checkExists = _context.User.AsNoTracking().FirstOrDefault(x => x.id == request.Id);
            if (checkExists == null)
            {
                throw new EntityNotFoundException(request.Id.ToString());
            }
            UserEntity entity = new UserEntity { id = request.Id, FirstName = request.FirstName, LastName = request.LastName, Birthdate = request.Birthdate };
            var user = _context.User.Update(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<UserBookEntity> AddUserBookAsync(AddUserBookCommand request, CancellationToken cancellation)
        {
            if (!isCheckExists(request.UserId, request.BookId))
            {
                throw new EntityNotFoundException("");
            }
            UserBookEntity entity = new UserBookEntity { UserId = request.UserId, BookId = request.BookId };
            var userBook = _context.UserBookEntities.Add(entity);
            await _context.SaveChangesAsync();
            return userBook.Entity;
        }

        public async Task<UserBookEntity> UpdateUserBookAsync(UpdateUserBookCommand request, CancellationToken cancellation)
        {
            if (!isCheckExists(request.UserId, request.BookId))
            {
                throw new EntityNotFoundException("");
            }
            UserBookEntity entity = new UserBookEntity { Id = request.Id, UserId = request.UserId, BookId = request.BookId };
            var userBook = _context.UserBookEntities.Update(entity);
            await _context.SaveChangesAsync();
            return userBook.Entity;
        }

        private bool isCheckExists(int UserId, int BookId)
        {
            var checkExistsUser = _context.User.AsNoTracking().FirstOrDefault(x => x.id == UserId);

            if (checkExistsUser == null)
                return false;

            var checkExistsBook = _context.Book.AsNoTracking().FirstOrDefault(x => x.Id == BookId);

            if (checkExistsBook == null)
                return false;

            return true;
        }
    }
}