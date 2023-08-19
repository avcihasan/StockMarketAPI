using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.DTOs.ResponseDTOs
{
    public class SuccessResponseDto<T> : ResponseDto<T> 
    {
        public T Data { get; set; }

        public static ResponseDto<T> Create(T data,HttpStatusCode statusCode)
            => new SuccessResponseDto<T>(){ Data= data, StatusCode= statusCode };
        public static ResponseDto<T> Create(HttpStatusCode statusCode)
            => new SuccessResponseDto<T>() { Data = default, StatusCode = statusCode };
    }
}
