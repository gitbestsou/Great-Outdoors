using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoorsInventory.Entities;
using GreatOutdoorsInventory.DataAccessLayer;
using GreatOutdoorsInventory.Exceptions;

namespace GreatOutdoorsInventory.BusinessLayer
{
    public class InventoryBL
    {
        private static bool ValidateProduct(Inventory product)
        {
            StringBuilder sb = new StringBuilder();
            bool validProduct = true;
            if (product.ProductID <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Product ID");

            }
            if (product.ProductQuantity <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Product Quantity Required");

            }
            if (product.CostPrice <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Cost Price");

            }

            

            if (validProduct == false)
                throw new GreatOutdoorsInventoryException(sb.ToString());
            return validProduct;
        }

        public static bool AddToInventoryBL(Inventory newProduct)
        {
            bool productAdded = false;
            try
            {
                if (ValidateProduct(newProduct))
                {
                    InventoryDAL inventoryDAL = new InventoryDAL();
                    productAdded = inventoryDAL.AddToInventoryDAL(newProduct);
                }
            }
            catch (GreatOutdoorsInventoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productAdded;
        }

        public static List<Inventory> GetInventoryBL()
        {
            List<Inventory> inventory = null;
            try
            {
                InventoryDAL inventoryDAL = new InventoryDAL();
                inventory = inventoryDAL.GetInventoryDAL();
            }
            catch (GreatOutdoorsInventoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return inventory;
        }

       

        public static Inventory SearchInventoryBL(int searchProductID)
        {
            Inventory searchProduct = null;
            try
            {
                InventoryDAL inventoryDAL = new InventoryDAL();
                searchProduct = inventoryDAL.SearchInventoryDAL(searchProductID);
            }
            catch (GreatOutdoorsInventoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchProduct;

        }



        public static bool UpdateInventoryBL(Inventory updateProduct)
        {
            bool productUpdated = false;
            try
            {
                if (ValidateProduct(updateProduct))
                {
                    InventoryDAL productDAL = new InventoryDAL();
                    productUpdated = productDAL.UpdateInventoryDAL(updateProduct);
                }
            }
            catch (GreatOutdoorsInventoryException)
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
                    InventoryDAL inventoryDAL = new InventoryDAL();
                    productDeleted = inventoryDAL.DeleteProductDAL(deleteProductID);
                }
                else
                {
                    throw new GreatOutdoorsInventoryException("Invalid Product ID");
                }
            }
            catch (GreatOutdoorsInventoryException)
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
