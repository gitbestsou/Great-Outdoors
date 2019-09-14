using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Exceptions
{
    public class ReturnExceptions : ApplicationException
    {
        public ReturnExceptions()
            : base()
        {
        }

        public ReturnExceptions(string message)
            : base(message)
        {
        }
        public ReturnExceptions(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
