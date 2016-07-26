using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    
        public class NotFoundEntityEx:Exception
        {
            public NotFoundEntityEx(string message)
            {
                Message = message;
            }
            public string Message
            {
                get;
                private set;
            }
        }
}
