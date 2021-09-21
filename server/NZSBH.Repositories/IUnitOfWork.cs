using NZSBH.Models.Entities;

namespace NZSBH.Repositories
{
    public interface IUnitOfWork
    {

        IRepository<Book> BooksRepository { get; }

        void Commit();
        void Rollback();
    }
}