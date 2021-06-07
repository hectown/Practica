using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.DTOs
{
    
        public class OperationResult<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }

            public T Data { get; set; }

            public ErrorType ErrorType { get; set; }
        }

        public enum ErrorType
        {
            None, Fatal, Connectivity, Business
        }
    
}
