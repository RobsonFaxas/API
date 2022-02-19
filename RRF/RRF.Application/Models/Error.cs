using RRF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Application.Models
{
    public class Error
    {
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}
