using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NZSBH.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repo;
        private readonly IBooksDxos _dxos;

        public BooksService(IBooksRepository repo, IBooksDxos dxos)
        {
            this._repo = repo;
            this._dxos = dxos;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var data = await _repo.GetListOfBooksAsync(b => b.IsDeleted == false);
            return _dxos.MapBookDtos(data);
        }

        public async Task<BookDto> Add(BookDto newBook)
        {
            Book b = new Book();
            b.Title = newBook.Title;
            b.Isbn = newBook.Isbn;
            b.IsHardCover = newBook.IsHardCover;
            b.Modified = DateTime.Now;
            b.Created = DateTime.Now;

            _repo.Add(b);
            await _repo.SaveChangesAsync();
            return _dxos.MapBookDto(b);
            
        }

        public async Task<bool> Delete(Guid bookId)
        {
            var book = await _repo.GetBookAsync(b => b.Id == bookId && b.IsDeleted == false);
            if (book == null) throw new ApplicationException("Not foud");

            book.Delete();

            _repo.Update(book);
            int i = await _repo.SaveChangesAsync();
            return i > 0;
        }
    }
}
