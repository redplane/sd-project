﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using SdProject.Businesses.Models.Users;

namespace SdProject.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// User Search 
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
        /// User Search 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("find")]
        public async Task<IActionResult> FindBookByUserAsync([FromBody] SearchBookByUserQuery command)
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
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookCommand command)
        {
            var validator = new Cqrs.CommandValidators.Books.AddBookValidation();
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
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookCommand command)
        {
            var validator = new Cqrs.CommandValidators.Books.UpdateBookValidation();
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
