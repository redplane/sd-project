using MediatR;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Cqrs.Commands.Users
{
    public class UpdateUserBookCommand : IRequest<UserBook>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}