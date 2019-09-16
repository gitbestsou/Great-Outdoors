using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsSales.Exceptions
{
    public class GreatOutdoorsSalesException : ApplicationException
    {
        public GreatOutdoorsSalesException()
            : base()
        {
        }

        public GreatOutdoorsSalesException(string message)
            : base(message)
        {
        }
        public GreatOutdoorsSalesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
