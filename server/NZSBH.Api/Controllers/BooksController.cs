using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Commands;
using NZSBH.Contracts.Dtos;
using NZSBH.Contracts.Queries;
using NZSBH.Models.Entities;
using NZSBH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZSBH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BooksController : ApiControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly IBooksDxos _booksDxos;

        public BooksController(IMediator mediator)
            :base(mediator)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            return await ExecuteRequest(new GetAllBooksQuery());
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBookCommand cmd)
        {
            if (cmd == null) return BadRequest();
            return await ExecuteRequest(cmd);
        }

        /*
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _booksService.GetAll();
            return Ok(books);
        }


        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var books = await _booksService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public Book Get(Guid id)
        {
            return new Book() { Title = "Shadow of the wind", IsHardCover = true };
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookDto b)
        {
            try{
                var bto = await _booksService.Add(b);
                return CreatedAtAction("post", bto);
            }
            catch (ValidationException vex)
            {
                return StatusCodeAndMessage(HttpStatusCode.BadRequest, vex.Message);
            }
            catch (Exception ex)
            {
                return StatusCodeAndMessage(HttpStatusCode.InternalServerError, ex.Message);
            }


          try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (ValidationException vex)
            {
                return StatusCodeAndMessage(HttpStatusCode.BadRequest, vex.Message);
            }
            catch (Exception ex)
            {
                return StatusCodeAndMessage(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(BookDto b)
        {
            var bto = await _booksService.Update(b);
            return Ok(bto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try {
                bool isDeleted = await _booksService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else {
                    return StatusCode(500);
                }
            }
            catch (ApplicationException ex)
            {
                return NotFound();
            }
            
            
        }

        */
    }
}
