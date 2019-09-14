using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using GreatOutdoorsProduct.Entities;
using GreatOutdoorsProduct.Exceptions;

namespace GreatOutdoorsProduct.DataAccessLayer
{
    public class ProductDAL
    {
        public static List<Product> productList = new List<Product>();

        public bool AddProductDAL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                productList.Add(newProduct);
                productAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsProductException(ex.Message);
            }
            return productAdded;

        }

        public List<Product> GetAllProductsDAL()
        {
            return productList;
        }

        public Product SearchProductDAL(int searchProductID)
        {
            Product searchProduct = null;
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductID == searchProductID)
                    {
                        searchProduct = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsProductException(ex.Message);
            }
            return searchProduct;
        }

        public List<Product> GetProductsByNameDAL(string productName)
        {
            List<Product> searchProduct = new List<Product>();
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductName == productName)
                    {
                        searchProduct.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsProductException(ex.Message);
            }
            return searchProduct;
        }

        public List<Product> GetProductsByCategoryDAL(int categoryID)
        {
            List<Product> searchProduct = new List<Product>();
            try
            {
                foreach (Product item in productList)
                {
                    if (item.CategoryID == categoryID)
                    {
                        searchProduct.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsProductException(ex.Message);
            }
            return searchProduct;
        }

        public bool UpdateProductDAL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                for (int i = 0; i < productList.Count; i++)
                {
                    if (productList[i].ProductID == updateProduct.ProductID)
                    {
                        updateProduct.ProductName = productList[i].ProductName;
                        updateProduct.CategoryID = productList[i].CategoryID;
                        updateProduct.SpecificationID = productList[i].SpecificationID;
                        updateProduct.CostPrice = productList[i].CostPrice;
                        updateProduct.SellingPrice = productList[i].SellingPrice;
                        updateProduct.Available = productList[i].Available;
                        productUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsProductException(ex.Message);
            }
            return productUpdated;

        }

        public bool DeleteProductDAL(int deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                Product deleteProduct = null;
                foreach (Product item in productList)
                {
                    if (item.ProductID == deleteProductID)
                    {
                        deleteProduct = item;
                    }
                }

                if (deleteProduct != null)
                {
                    productList.Remove(deleteProduct);
                    productDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new GreatOutdoorsProductException(ex.Message);
            }
            return productDeleted;

        }

    }
}