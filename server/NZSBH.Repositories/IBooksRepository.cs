using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public interface IBooksRepository
    {
        void Add(Book newBook);
        Task<Book> GetBookAsync(Expression<Func<Book, bool>> predicate);
        Task<IEnumerable<Book>> GetListOfBooksAsync(Expression<Func<Book, bool>> predicate);
        Task<int> SaveChangesAsync();
        void Update(Book theBook);
    }
}