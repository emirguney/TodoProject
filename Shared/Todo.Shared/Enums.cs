using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Shared
{
    public class Response
    {
        public enum LanguageType
        {
            Turkish = 1,
            Engllish = 2
        }

        public enum ResponseStatus
        {
            Success = 200,
            NotAuthenticated = 10401,
            InitialError = 500,
            Forbiden403 = 10403
        }
    }
}
