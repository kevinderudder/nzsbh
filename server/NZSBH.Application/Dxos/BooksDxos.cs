using AutoMapper;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Application.Dxos
{
    public class BooksDxos : IBooksDxos
    {
        private readonly IMapper _mapper;

        public BooksDxos()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Book, BookDto>();
            });

            _mapper = config.CreateMapper();
        }

        public BookDto MapBookDto(Book book)
        {
            return _mapper.Map<Book, BookDto>(book);
        }

        public List<BookDto> MapBookDtos(IEnumerable<Book> books)
        {
            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
