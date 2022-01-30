using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message = null, string deatils = null)
        {
            StatusCode = statusCode;
            Message = message;
            Deatils = deatils;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Deatils { get; set; }
    }
}