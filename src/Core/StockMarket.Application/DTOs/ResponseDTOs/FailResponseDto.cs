using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.DTOs.ResponseDTOs
{
    public class FailResponseDto<T>:ResponseDto<T> 
    {
        public List<string> Errors { get; set; }

        public static ResponseDto<T> Create(List<string> errors,HttpStatusCode statusCode=HttpStatusCode.BadRequest)
            => new FailResponseDto<T>() { Errors = errors ,StatusCode= statusCode };
        public static ResponseDto<T> Create(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new FailResponseDto<T>() { Errors = new() { error}, StatusCode = statusCode };
    }
}
