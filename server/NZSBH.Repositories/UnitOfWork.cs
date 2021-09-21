using NZSBH.Data;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NzsbhDbContext _dbContext;

        private IRepository<Book> _bookRepository;

        #region Properties
        public IRepository<Book> BooksRepository
        {
            get
            {
                return _bookRepository = _bookRepository ?? new Repository<Book>(_dbContext);
            }
        }
        #endregion
       

        public UnitOfWork(NzsbhDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }
    }
}
