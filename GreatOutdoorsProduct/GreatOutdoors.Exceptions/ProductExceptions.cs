using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsProduct.Exceptions
{
    public class GreatOutdoorsProductException : ApplicationException
    {
        public GreatOutdoorsProductException()
            : base()
        {
        }

        public GreatOutdoorsProductException(string message)
            : base(message)
        {
        }
        public GreatOutdoorsProductException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
