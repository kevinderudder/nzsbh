using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Models.Entities
{
    public class Publisher:BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }
       
        public IEnumerable<Book> Books { get; set; }


        public void Activate() {
            this.IsActive = true;
        }

        public void Deactivate() {
            this.IsActive = false;
        }

        
    }
}
