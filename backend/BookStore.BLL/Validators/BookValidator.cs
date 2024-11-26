using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BookStore.DTO.DTOs;
namespace BookStore.BLL.Validators
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        public BookValidator()
        {
            RuleFor(b => b.title).NotEmpty().WithMessage("Title is required");
        }
    }
}
