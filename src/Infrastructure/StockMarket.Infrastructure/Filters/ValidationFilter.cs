using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockMarket.Application.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new();
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any()).Select(x=> x.Value.Errors.Select(x=>x.ErrorMessage));

                foreach (var error in errors)
                    foreach (var errorMessage in error)
                        errorDto.Errors.Add(errorMessage);

                        context.Result = new BadRequestObjectResult(ResponseDto<ErrorDto>.Fail(errorDto));
                return;
            }
          await  next();
        }
    }
}
