using Microsoft.EntityFrameworkCore;
using NZSBH.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NZSBH.Data
{
    public class NzsbhDbContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> Bookcategories { get; set; }

        public NzsbhDbContext(DbContextOptions<NzsbhDbContext> options)
            : base(options)
        {

        }

        public override int SaveChanges()
        {
            this.AddAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
