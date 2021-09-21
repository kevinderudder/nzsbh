using MediatR;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Contracts.Queries;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NZSBH.Application.QueryHandlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IRepository<Book> _repo;
        private readonly IBooksDxos _dxos;

        public GetAllBooksQueryHandler(IRepository<Book> repo, IBooksDxos dxos)
        {
            _repo = repo;
            _dxos = dxos;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetListAsync(b => b.IsDeleted == false);
            return _dxos.MapBookDtos(data);
        }
    }
}
