using System.Threading;
using System.Threading.Tasks;
using SdProject.Core.Entities;

namespace SdProject.Businesses.Services.Abstractions
{
    public interface IUserBookService
    {
        Task<UserBook> GetAsync(int userId, int bookId, CancellationToken cancellationToken = default);
    }
}