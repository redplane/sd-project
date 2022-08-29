using MediatR;

namespace SdProject.Businesses.Cqrs.Commands.Users
{
    public class MarkBookAsReadCommand : IRequest
    {
        public int UserId { get; set; }
        
        public int BookId { get; set; }
    }
}