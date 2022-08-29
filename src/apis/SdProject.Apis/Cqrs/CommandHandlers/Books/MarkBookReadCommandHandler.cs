using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Cqrs.Commands.Users;
using SdProject.Businesses.Services.Abstractions;

namespace SdProject.Apis.Cqrs.CommandHandlers.Books
{
    public class UpdateHaveReadRequestHandler : IRequestHandler<MarkBookAsReadCommand>
    {
        private readonly IBookService _bookService;

        public UpdateHaveReadRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Unit> Handle(MarkBookAsReadCommand command, CancellationToken cancellation)
        {
            await _bookService.MarkAsReadAsync(command, cancellation);
            return Unit.Value;
        }
    }
}