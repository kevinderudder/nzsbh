using Microsoft.EntityFrameworkCore;
using NZSBH.Data;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly NzsbhDbContext _dbContext;
        private readonly DbSet<Book> _modelDbSets;

        public BooksRepository(NzsbhDbContext dbContext)
        {
            _dbContext = dbContext;
            _modelDbSets = _dbContext.Set<Book>();
        }

        public async Task<Book> GetBookAsync(Expression<Func<Book, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetListOfBooksAsync(Expression<Func<Book, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).ToListAsync();
        }

        public void Add(Book newBook)
        {
            _modelDbSets.Add(newBook);

        }

        public void Update(Book theBook)
        {
            _modelDbSets.Attach(theBook);
            _dbContext.Entry(theBook).State = EntityState.Modified;
        }

        public async Task<int> SaveChangesAsync()
        {
            int i = await _dbContext.SaveChangesAsync();
            return i;
        }


    }
}
