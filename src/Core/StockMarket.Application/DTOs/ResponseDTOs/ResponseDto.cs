using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockMarket.Application.DTOs.ResponseDTOs
{
    public class ResponseDto<T>
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }


        public static ResponseDto<T> Success(T data, HttpStatusCode statusCode)
            => new() { Data = data, StatusCode = statusCode };
        public static ResponseDto<T> Success(HttpStatusCode statusCode)
            => new() { Data = default, StatusCode = statusCode };


        public static ResponseDto<ErrorDto> Fail(ErrorDto errors)
            => new() { Data = errors};
       
    }

}
