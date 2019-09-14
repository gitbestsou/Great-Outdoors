using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Entities
{
    public class Return
    {

            private int _returnID;
            private int _orderID;
            private int _productID;
            private bool _reasonIncomplete;
            private bool _reasonWrong;
            private double _returnValue;
            private int _returnQuantity;

            public int ReturnID { get => _returnID; set => _returnID = value; }
            public int OrderID { get => _orderID; set => _orderID = value; }
            public int ProductID { get => _productID; set => _productID = value; }
            public bool ReasonIncomplete { get => _reasonIncomplete; set => _reasonIncomplete = value; }
            public bool ReasonWrong { get => _reasonWrong; set => _reasonWrong = value; }
            public double ReturnValue { get => _returnValue; set => _returnValue = value; }
            public int ReturnQuantity { get => _returnQuantity; set => _returnQuantity = value; }
        

    }
}
