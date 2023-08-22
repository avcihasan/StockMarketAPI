using FluentValidation;
using StockMarket.Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Validators.CategoryValidators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage("Kategori adını giriniz!")
                .MinimumLength(2)
                    .WithMessage("Kategori adı en az 2 karakter olmalıdır!")
                 .MaximumLength(15)
                    .WithMessage("Kategori adı en fazla 15 karakter olabilir!");
        }
    }
}
