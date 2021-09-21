using FluentValidation;
using NZSBH.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Contracts.Commands
{
    public class AddBookCommandValidator:AbstractValidator<AddBookCommand> {
        public AddBookCommandValidator()
        {
            //Include(baseRequestValidator);
            RuleFor(x => x.Title).NotEmpty();

        }
    }


    public class AddBookCommand:CommandBase<BookDto>
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public bool IsHardCover { get; set; }
    }
}
