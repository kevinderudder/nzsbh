using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Models.Entities
{
    public class Book:BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public bool IsHardCover { get; set; }

        public Guid? PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public Guid? BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }

        public void Update(string title, string isbn, bool isHardCover, Guid? publisherId, Guid? bookCategoryId) {
            this.Title = title;
            this.Isbn = isbn;
            this.IsHardCover = IsHardCover;
            this.PublisherId = publisherId;
            this.BookCategoryId = bookCategoryId;
        }
    }
}
