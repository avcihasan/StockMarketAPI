using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockMarket.Application.DTOs.ResponseDTOs
{
    public abstract class ResponseDto<T> 
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

    }
  
}
