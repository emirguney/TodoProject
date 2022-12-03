using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Shared.Dtos
{
    public class Result
    {
        public bool IsSuccess { get; set; }

        public dynamic Data { get; set; }

        public List<string> ErrorMessage { get; set; }
    }
}
