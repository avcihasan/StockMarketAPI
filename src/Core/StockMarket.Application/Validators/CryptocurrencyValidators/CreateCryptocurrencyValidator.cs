using FluentValidation;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Validators.CryptocurrencyValidators
{
    public class CreateCryptocurrencyValidator:AbstractValidator<CreateCryptocurrencyDto>
    {
        public CreateCryptocurrencyValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage("Kripto para adını giriniz!")
                .MinimumLength(2)
                    .WithMessage("Kripto para adı en az 2 karakter olmalıdır!")
                .MaximumLength(15)
                    .WithMessage("Kripto para adı en fazla 15 karakter olabilir!");

            RuleFor(x => x.Stock)              
                .GreaterThan(-1)
                    .WithMessage("Stok alanı negatif sayı olamaz!");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                    .WithMessage("Birim fiyat sıfırdan büyük olmalı!");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                    .WithMessage("Kategori Id sıfırdan büyük olamlı!");
        }
        
    }
   
}
