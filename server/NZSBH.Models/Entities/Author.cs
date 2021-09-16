using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Models.Entities
{
    public sealed class Author:Person
    {
        public IEnumerable<Book> Books { get; set; }
        public string Biography { get; set; }
    }
}
