using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Models
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public bool IsDeleted { get; set; }

        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}
