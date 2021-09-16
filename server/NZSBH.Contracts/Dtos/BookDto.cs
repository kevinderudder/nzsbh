using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Contracts.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public bool IsHardCover { get; set; }

        public Guid? PublisherId { get; set; }
        //public Publisher Publisher { get; set; }

        public Guid? BookCategoryId { get; set; }
        //public BookCategory BookCategory { get; set; }

        public static BookDto MapToDto(Book b) {
            BookDto dto = new BookDto() { 
                Id = b.Id,
                Title = b.Title,
                Isbn = b.Isbn,
                IsHardCover = b.IsHardCover
            };

            return dto;
        }

        public static IEnumerable<BookDto> MapToDtos(IEnumerable<Book> books) {
            List<BookDto> bookDtos = new List<BookDto>();
            foreach (Book b in books) {
                bookDtos.Add(MapToDto(b));
            }

            return bookDtos;
        }
    }
}
