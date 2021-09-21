using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NZSBH.Api.Models
{
    public class ErrorMessageDto
    {

        private HttpStatusCode _statusCode;
        public int StatusCode
        {
            get {
                return (int)_statusCode;
            }
        }

        public IEnumerable<string> Messages { get; set; }

        public ErrorMessageDto(HttpStatusCode code, IEnumerable<string> messages)
        {
            _statusCode = code;
            Messages = messages;
        }

    }
}
