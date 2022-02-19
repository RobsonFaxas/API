using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRF.Application.Models
{
    public class OperationResult <T>
    {
        public OperationResult()
        {
            Errors = new List<Error>();
        }
        public T Payload { get; set; }
        public bool Success { get; set; }
        public List<Error> Errors { get; set; }

        public string GetErrorList()
        {
            if (this.Errors.Any())
                return "";

            var sb = new StringBuilder();
            foreach (var error in Errors)
                sb.AppendLine($"[{error.Code}] - {error.Message}");
            return sb.ToString();
        }
    }
}
