using System;
using System.Collections.Generic;
using System.Text;

namespace Tender.Models
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
        }

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Content { get; set; }
    }
}
