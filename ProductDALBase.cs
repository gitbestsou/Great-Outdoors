using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.GreatOutdoors.Entities;
using GreatOutdoors.Entities;
using Newtonsoft.Json;

namespace Capgemini.GreatOutdoors.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for ProductDAL class
    /// </summary>
    public abstract class ProductDALBase
    {
        //Collection of Products
        protected static List<Product> productList = new List<Product>()
        {
            new Product(){ ProductID = Guid.NewGuid(), ProductName = "Tent", CategoryName = Category.Camping, ProductStock = 1000, ProductSize = "small", ProductColour = "Red", ProductTechSpecs = "Good Pen", CostPrice = 10, SellingPrice = 15, ProductDiscount = 1 },
             new Product(){ ProductID = Guid.NewGuid(), ProductName = "Campbed", CategoryName = Category.Camping,ProductStock = 1000, ProductSize = "medium", ProductColour = "Red", ProductTechSpecs = "Good Pen", CostPrice = 10, SellingPrice = 15, ProductDiscount = 1 },
              new Product(){ ProductID = Guid.NewGuid(), ProductName = "Tent Stakes", CategoryName = Category.Camping,ProductStock = 1000, ProductSize = "Large", ProductColour = "Red", ProductTechSpecs = "Good Pen", CostPrice = 10, SellingPrice = 15, ProductDiscount = 1 },
               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Foot Warmers", CategoryName = Category.Camping,ProductStock = 1000, ProductSize = "small", ProductColour = "Blue", ProductTechSpecs = "Good Pen", CostPrice = 10, SellingPrice = 15, ProductDiscount = 1 },
            
            new Product(){ ProductID = Guid.NewGuid(), ProductName = "Golf CLub", CategoryName = Category.Golf ,ProductStock = 1000, ProductSize = "small", ProductColour = "Red", ProductTechSpecs = "Good Pencil", CostPrice = 5, SellingPrice = 10, ProductDiscount = 1 },
            new Product(){ ProductID = Guid.NewGuid(), ProductName = "Golf Cart", CategoryName = Category.Golf,ProductStock = 1000, ProductSize = "medium", ProductColour = "Red", ProductTechSpecs = "Good Pencil", CostPrice = 5, SellingPrice = 10, ProductDiscount = 1 },
              new Product(){ ProductID = Guid.NewGuid(), ProductName = "Club Head", CategoryName = Category.Golf,ProductStock = 1000, ProductSize = "Large", ProductColour = "Red", ProductTechSpecs = "Good Pencil", CostPrice = 5, SellingPrice = 10, ProductDiscount = 1 },
               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Gloves", CategoryName = Category.Golf,ProductStock = 1000, ProductSize = "small", ProductColour = "Blue", ProductTechSpecs = "Good Pencil", CostPrice = 5, SellingPrice = 10, ProductDiscount = 1 },
               
                new Product(){ ProductID = Guid.NewGuid(), ProductName = "Climbing Carabiners", CategoryName = Category.Mountaineering ,ProductStock = 2000, ProductSize = "small", ProductColour = "Red", ProductTechSpecs = "Good Pencil", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },
                new Product(){ ProductID = Guid.NewGuid(), ProductName = "Sling", CategoryName = Category.Mountaineering,ProductStock = 2000, ProductSize = "medium", ProductColour = "Red", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },
              new Product(){ ProductID = Guid.NewGuid(), ProductName = "Climbing Harness", CategoryName = Category.Mountaineering,ProductStock = 2000, ProductSize = "Large", ProductColour = "Red", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },
               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Rope", CategoryName = Category.Mountaineering,ProductStock = 2000, ProductSize = "small", ProductColour = "Blue", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },
               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Quick Draw", CategoryName = Category.Mountaineering,ProductStock = 2000, ProductSize = "medium", ProductColour = "Blue", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },

               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Safety Whistle", CategoryName = Category.OutdoorProtection,ProductStock = 2000, ProductSize = "large", ProductColour = "Blue", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },
               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Rain Poncho", CategoryName = Category.OutdoorProtection,ProductStock = 2000, ProductSize = "small", ProductColour = "Black", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },

               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Rucksack", CategoryName = Category.PersonalAccessories,ProductStock = 2000, ProductSize = "medium", ProductColour = "Black", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 },
               new Product(){ ProductID = Guid.NewGuid(), ProductName = "Waist Bag", CategoryName = Category.Mountaineering,ProductStock = 2000, ProductSize = "large", ProductColour = "Black", ProductTechSpecs = "Good Sharpener", CostPrice = 15, SellingPrice = 20, ProductDiscount = 1 } };
        private static string fileName = "products.json";

        //Methods for CRUD operations
        public abstract bool AddProductDAL(Product newProduct);
        public abstract List<Product> GetAllProductsDAL();
        public abstract Product GetProductByProductIDDAL(Guid searchProductID);
        public abstract List<Product> GetProductsByNameDAL(string ProductName);
        public abstract List<Product> GetProductsByCategoryDAL(Category categoryName);
        public abstract bool UpdateProductDAL(Product updateProduct);
        public abstract bool UpdateProductStockDAL(Product updateProduct);
        public abstract bool DeleteProductDAL(Guid deleteProductID);






        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(productList);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write(serializedJson);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Reads collection from the file in JSON format.
        /// </summary>
        public static void Deserialize()
        {
            string fileContent = string.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<Product>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    productList = systemUserListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static ProductDALBase()
        {
            Deserialize();
        }
    }
}


