using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Entities
{
  
    public class Category
    {
        private int _productID;
        private int _categoryID;
        private string _categoryName;

        public int ProductID { get => _productID; set => _productID = value; }
        public int CategoryID { get => _categoryID; set => _categoryID = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }


        public Category()
        {
            ProductID = 0;
            CategoryID = 0;
            CategoryName = string.Empty;



        }
    }
}
