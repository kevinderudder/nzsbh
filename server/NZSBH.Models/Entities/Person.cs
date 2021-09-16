using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Models.Entities
{
    public abstract class Person:BaseAuditableEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dob { get; set; }


    }
}
