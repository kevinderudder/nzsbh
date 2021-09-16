using Microsoft.EntityFrameworkCore;
using NZSBH.Models.Entities;
using System;

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
    }
}
