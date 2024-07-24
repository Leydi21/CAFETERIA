using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoVende.DtoOut
{
    public class BasicResponse<T>
    {
        public string Status { get; set; }
        public T Body { get; set; }
        public string Message { get; set; }
    }
}
