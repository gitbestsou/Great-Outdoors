using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoorsProduct.Entities;
using GreatOutdoorsProduct.Exceptions;
using GreatOutdoorsProduct.DataAccessLayer;

namespace GreatOutdoorsProduct.BusinessLayer
{
    public class ProductBL
    {
        private static bool ValidateProduct(Product product)
        {
            StringBuilder sb = new StringBuilder();
            bool validProduct = true;
            if (product.ProductID <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Product ID");

            }
            if (product.ProductName == string.Empty)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Product Name Required");

            }
            if (product.CategoryID <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Category ID");

            }

            if (product.SpecificationID <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Specification ID");

            }

            if (product.CostPrice <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Cost Price");

            }

            if (product.SellingPrice <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Selling Price");

            }

            if (validProduct == false)
                throw new GreatOutdoorsProductException(sb.ToString());
            return validProduct;
        }

        public static bool AddProductBL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                if (ValidateProduct(newProduct))
                {
                    ProductDAL productDAL = new ProductDAL();
                    productAdded = productDAL.AddProductDAL(newProduct);
                }
            }
            catch (GreatOutdoorsProductException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productAdded;
        }

        public static List<Product> GetAllProductsBL()
        {
            List<Product> productList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productList = productDAL.GetAllProductsDAL();
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productList;
        }

        public static List<Product> GetProductsByNameBL(string productName)
        {
            List<Product> productList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productList = productDAL.GetProductsByNameDAL(productName);
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productList;
        }

        public static List<Product> GetProductsByCategoryBL(int categoryID)
        {
            List<Product> productList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productList = productDAL.GetProductsByCategoryDAL(categoryID);
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productList;
        }
        public static Product SearchProductBL(int searchProductID)
        {
            Product searchProduct = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                searchProduct = productDAL.SearchProductDAL(searchProductID);
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchProduct;

        }



        public static bool UpdateProductBL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                if (ValidateProduct(updateProduct))
                {
                    ProductDAL productDAL = new ProductDAL();
                    productUpdated = productDAL.UpdateProductDAL(updateProduct);
                }
            }
            catch (GreatOutdoorsProductException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productUpdated;
        }

        public static bool DeleteProductBL(int deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                if (deleteProductID > 0)
                {
                    ProductDAL productDAL = new ProductDAL();
                    productDeleted = productDAL.DeleteProductDAL(deleteProductID);
                }
                else
                {
                    throw new GreatOutdoorsProductException("Invalid Product ID");
                }
            }
            catch (GreatOutdoorsProductException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productDeleted;
        }

    }
}