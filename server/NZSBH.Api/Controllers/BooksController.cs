using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
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
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly IBooksDxos _booksDxos;

        public BooksController(IBooksService booksService, IBooksDxos booksDxos)
        {
            _booksService = booksService;
            _booksDxos = booksDxos;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
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
            var bto = await _booksService.Add(b);
            return CreatedAtAction("post", bto);
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
    }
}
