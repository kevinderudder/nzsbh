using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
   public static class RepositoryExtensions
    {
        public static List<Book> GetHardCoveredBooks(this Repository<Book> repo) {
            return null;
        }
    }
}
