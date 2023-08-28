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
using StockMarket.Application.ConfigurationModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace StockMarket.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection service,ConfigurationManager configuration)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            service.AddValidatorsFromAssemblyContaining(typeof(CreateCryptocurrencyValidator));

            service.Configure<JwtToken>(configuration.GetSection("JwtToken"));
        }
    }
}
