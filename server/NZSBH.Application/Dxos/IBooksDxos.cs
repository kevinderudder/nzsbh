using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Application.Dxos
{
    public interface IBooksDxos
    {
        BookDto MapBookDto(Book book);

        List<BookDto> MapBookDtos(IEnumerable<Book> books);
    }
}
