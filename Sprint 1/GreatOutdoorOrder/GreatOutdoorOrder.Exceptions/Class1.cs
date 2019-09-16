﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsOrder.Exception
{
    public class OrderException : ApplicationException
    {
        public OrderException()
            : base()
        {
        }

        public OrderException(string message)
            : base(message)
        {
        }
        public OrderException(string message, ApplicationException innerException)
            : base(message, innerException)
        {
        }
    }
}
