using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SdProject.Businesses.Cqrs.Commands.Books;
using SdProject.Businesses.Cqrs.Queries.Books;

namespace SdProject.Apis.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Properties

        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Method

        /// <summary>
        ///     Search for book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("search")]
        public async Task<IActionResult> SearchAsync([FromBody] SearchBookQuery command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        ///     User Search
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("by-user")]
        public async Task<IActionResult> FindBookByUserAsync([FromBody] SearchBookByUserQuery command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        ///     Add User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        ///     Update User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        #endregion
    }
}