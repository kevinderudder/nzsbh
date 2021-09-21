using MediatR;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Commands;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NZSBH.Application.CommandHandlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDto>
    {
        private readonly IRepository<Book> _repo;
        private readonly IBooksDxos _dxos;

        public AddBookCommandHandler(IRepository<Book> repo, IBooksDxos dxos)
        {
            _repo = repo;
            _dxos = dxos;
        }

        public async Task<BookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            Book b = new Book();
            b.Title = request.Title;
            b.Isbn = request.Isbn;
            b.IsHardCover = request.IsHardCover;


            _repo.Add(b);
            await _repo.SaveChangesAsync();
            return _dxos.MapBookDto(b);
        }
    }
}
