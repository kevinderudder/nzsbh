using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Services
{
    public interface IBooksService
    {
        Task<BookDto> Add(BookDto newBook);
        Task<IEnumerable<BookDto>> GetAll();
    }
}
