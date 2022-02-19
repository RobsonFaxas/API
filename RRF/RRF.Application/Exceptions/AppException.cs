using RRF.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Application.Exceptions
{
    public class AppException : Exception
    {
        public Error Error { get; }
        public AppException(Error error)
        {
            this.Error = error;
        }
    }
}
