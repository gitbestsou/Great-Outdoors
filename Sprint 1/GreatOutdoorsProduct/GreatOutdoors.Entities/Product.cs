using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsProduct.Entities
{
    public class Product
    {
        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private int specificationID;

        public int SpecificationID
        {
            get { return specificationID; }
            set { specificationID = value; }
        }

        private double costPrice;

        public double CostPrice
        {
            get { return costPrice; }
            set { costPrice = value; }
        }

        private double sellingPrice;

        public double SellingPrice
        {
            get { return sellingPrice; }
            set { sellingPrice = value; }
        }

        private Boolean available;

        public Boolean Available
        {
            get { return available; }
            set { available = value; }
        }




        public Product()
        {
            productID = 0;
            productName = string.Empty;
            categoryID = 0;
            specificationID = 0;
            costPrice = 0;
            sellingPrice = 0;
            available = false;
        }
    }
}