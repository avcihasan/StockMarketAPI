using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using StockMarket.Application.DTOs.ResponseDTOs;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockMarket.API.Extensions
{
    public static class ConfigureExceptionHandler
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this WebApplication app)
        {
            return app.UseExceptionHandler(configure =>
              {
                  configure.Run(async context =>
                  {
                      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      context.Response.ContentType = MediaTypeNames.Application.Json;

                      var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                      if (exceptionHandlerFeature is not null)
                      {
                          ErrorDto errorDto = new();
                          errorDto.Errors = FormatErrors(exceptionHandlerFeature.Error.Message);
                          await context
                            .Response
                            .WriteAsync(JsonSerializer.Serialize(
                                ResponseDto<ErrorDto>.Fail(errorDto)
                                ));
                      }
                  });
              });
        }

        private static List<string> FormatErrors(string message)
        {
            List<string> errors = new();

            if (message.Contains("\n"))
            {
                errors = message.Split("\n").ToList();
                if (errors.Last().IsNullOrEmpty())
                    errors.RemoveAt(errors.Count-1);
            }
            else
                errors.Add(message);

            return errors;
        }
    }
}
