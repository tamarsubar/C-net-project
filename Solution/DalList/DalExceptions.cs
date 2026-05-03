using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DalExceptions:Exception
    {
        public class DalExceptionExist : Exception
        {

            public DalExceptionExist(string? message) : base(message) { }

            public DalExceptionExist(string? message, Exception? innerException) : base(message, innerException) { }
        }
        public class DalExceptionNotExist : Exception
        {
            public DalExceptionNotExist(string? message) : base(message) { }

            public DalExceptionNotExist(string? message, Exception? innerException) : base(message, innerException) { }
        }
    }
}
