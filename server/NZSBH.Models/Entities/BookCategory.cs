using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Models.Entities
{
    public class BookCategory:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
