using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsInventory.Exceptions
{
    public class GreatOutdoorsInventoryException : ApplicationException
    {
        public GreatOutdoorsInventoryException()
            : base()
        {
        }

        public GreatOutdoorsInventoryException(string message)
            : base(message)
        {
        }
        public GreatOutdoorsInventoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
