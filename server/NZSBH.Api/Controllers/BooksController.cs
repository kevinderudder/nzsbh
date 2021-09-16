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
        public async Task<BookDto> Post(BookDto b)
        {
            return await _booksService.Add(b);
        }
    }
}
