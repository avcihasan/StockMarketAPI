using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StockMarket.Application.Validators.CryptocurrencyValidators;

namespace StockMarket.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            service.AddValidatorsFromAssemblyContaining(typeof(CreateCryptocurrencyValidator));
        }
    }
}
