using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message=null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            string errorMessage = string.Empty;
            switch (statusCode)
            {
               
                case 400:
                    return "A Bad Request";
                 
                case 401:
                    return "Autorized Error";
                   
                case 404:
                    return "Resource Not Found";
                   
                case 500:
                    return "Server Error";
                   

            }
            return errorMessage;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
