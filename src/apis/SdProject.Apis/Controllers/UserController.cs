using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Models.Users;

namespace SdProject.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// User Search 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("search")]
        public async Task<IActionResult> SearchAsync([FromBody] SearchUserQuery command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// User Search 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("find")]
        public async Task<IActionResult> FindUserByBookAsync([FromBody] SearchUserByBookQuery command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserCommand command)
        {
            var validator = new Cqrs.CommandValidators.AddUserValidation();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserCommand command)
        {
            var validator = new Cqrs.CommandValidators.UpdateUserValidation();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// favorite
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost ("favorite")]
        public async Task<IActionResult> AddBookWithUserAsync([FromBody] AddUserBookCommand command)
        {
            var validator = new Cqrs.CommandValidators.AddUserBookValidation();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// favorite
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserBookAsync([FromBody] UpdateUserBookCommand command)
        {
            var validator = new Cqrs.CommandValidators.UpdateUserBookValidation();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
