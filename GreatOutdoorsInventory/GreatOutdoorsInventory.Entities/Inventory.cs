using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsInventory.Entities
{
    public class Inventory
    {
        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }


        private double costPrice;

        public double CostPrice
        {
            get { return costPrice; }
            set { costPrice = value; }
        }


        public Inventory()
        {
            productID = 0;
            productQuantity = 0;
            costPrice = 0;

        }
    }
}

